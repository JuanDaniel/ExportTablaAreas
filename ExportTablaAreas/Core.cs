using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BBI.JD
{
    public static class Core
    {
        public const string SCHEDULE_AREAS_DETALLE = "D01.Areas (Detalle) Para Exportar";
        public const string SCHEDULE_AREA_UTIL = "C02.Area Util Total";
        public const string SCHEDULE_AREA_CONST = "C14.Area Construida Total (S.H.O.)";
        public const string SCHEDULE_CAP_HAB = "C02.Capacidad Habitacional";

        public const string PARAMETER_SUP_UTIL = "AreaUtil_Objeto";
        public const string PARAMETER_SHO = "S.H.O. Objeto";
        public const string PARAMETER_CAP_HAB = "CapacidadHabitacional";
        public const string PARAMETER_NIVELES_TIPICOS = "NivelesTipicos";
        public const string PARAMETER_PORCIENTO_BD = "PorcientoBD";

        public const string AREA_NAME = "S.H.O.";

        public static IList<Element> GetData(Document document, ElementType type, bool fromLoadLinks = false, ElementValue[] filters = null)
        {
            filters = filters ?? new ElementValue[] { ElementValue.NOT_PLACED, ElementValue.NOT_ENCLOSED, ElementValue.REDUNDANT };

            IList<Element> elements = GetElements(document, type, fromLoadLinks);

            for (int i = elements.Count - 1; i >= 0; i--)
            {
                SpatialElement element = (SpatialElement)elements[i];

                ElementValue value = Distinguish(element);

                if (!filters.Contains(value))
                {
                    elements.Remove(element);
                }
            }

            return elements;
        }

        public static List<List<object>> GetFormatedData(Document document, ElementType type, bool fromLoadLinks = false, bool fullPath = false, ElementValue[] filters = null)
        {
            List<List<object>> data = new List<List<object>>();

            IList<Element> elements = GetData(document, type, fromLoadLinks, filters);

            foreach (SpatialElement element in elements)
            {
                ElementValue value = Distinguish(element);

                data.Add(GetValues(element, value, fullPath));
            }

            return data;
        }

        public static bool DeleteElements(Document document, List<ElementId> elementIds)
        {
            int ignoreEditing = 0;

            for (int i = 0; i < elementIds.Count; i++)
            {
                if (IsEditingByAnother(document, elementIds[i]))
                {
                    if (ignoreEditing == 0)
                    {
                        TaskDialog td = new TaskDialog("Delete elements");

                        td.Title = "Delete elements";
                        td.MainInstruction = "Ignore editing elements?";
                        td.MainContent = "There are elements that are being edited by other users.\nDo you want to continue to ignore them?";
                        td.FooterText = "BBI Tabla Áreas";
                        td.TitleAutoPrefix = false;
                        td.AllowCancellation = false;
                        td.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;
                        td.DefaultButton = TaskDialogResult.Yes;

                        TaskDialogResult result = td.Show();

                        if (result == TaskDialogResult.Yes)
                        {
                            ignoreEditing = 1;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (ignoreEditing == 1)
                    {
                        elementIds.RemoveAt(i--);
                    }
                }
            }

            Transaction transaction = null;

            try
            {
                transaction = new Transaction(document, "Delete Not Placed elements");

                transaction.Start();

                document.Delete(elementIds);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollBack();

                return false;
            }

            return true;
        }

        public static bool DeleteElement(Document document, ElementId elementId)
        {
            if (IsEditingByAnother(document, elementId))
            {
                return false;
            }

            Transaction transaction = null;

            try
            {
                transaction = new Transaction(document, "Delete Not Placed element");

                transaction.Start();

                document.Delete(elementId);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollBack();

                return false;
            }

            return true;
        }

        public static int GetTotalValueEmpty(Document document, ElementType type, string parameterName, bool fromLoadLinks = false)
        {
            int total = 0;

            IList<Element> elements = GetElements(document, type, fromLoadLinks);

            foreach (var element in elements)
            {
                Parameter parameter = element.LookupParameter(parameterName);

                if (!parameter.HasValue)
                {
                    total++;
                }
            }

            return total;
        }

        public static Dictionary<string, int> GetCountValueEmpty(Document document, ElementType type, string parameterName, bool fromLoadLinks = false)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            List<Document> documents = new List<Document>();

            documents.Add(document);

            if (fromLoadLinks)
            {
                Dictionary<RevitLinkType, Document> linksDocument = GetLinksDocument(document);

                documents.AddRange(linksDocument.Values);
            }

            IList<Element> elements;

            foreach (Document doc in documents)
            {
                elements = GetElements(doc, type);

                // Filter S.H.O. if element type is Area
                if (type == ElementType.AREA)
                {
                    elements = elements.Where(x => GetAreaSchemaNameFromArea(doc, (Area)x).Equals(AREA_NAME)).ToList();
                }

                foreach (Element element in elements)
                {
                    string key = element.Document.PathName;

                    Parameter parameter = element.LookupParameter(parameterName);

                    if (parameter != null)
                    {
                        if (!parameter.HasValue)
                        {
                            if (!result.ContainsKey(key))
                            {
                                result.Add(key, 0);
                            }

                            result[key]++;
                        }
                    }
                    else
                    {
                        result.Add(key, -1);
                        break;
                    }
                }
            }

            return result;
        }

        public static bool ValidFormatPorcientoBD(Document document, string parameterName = PARAMETER_PORCIENTO_BD, bool fromLoadLinks = false)
        {
            IList<Element> elements = GetElements(document, ElementType.ROOM, fromLoadLinks);

            foreach (var element in elements)
            {
                Parameter parameter = element.LookupParameter(parameterName);

                if (parameter != null)
                {
                    if (parameter.HasValue)
                    {
                        float value = 0;

                        if (float.TryParse(parameter.AsValueString(), out value))
                        {
                            if (value > 1)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static Dictionary<string, string> EqualScheduleParameterValue(Document document, string scheduleName, BuiltInCategory scheduleCategory, string parameterName, bool fromLoadLinks = false, bool greaterZero = true)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<Document> documents = new List<Document>();

            documents.Add(document);

            if (fromLoadLinks)
            {
                Dictionary<RevitLinkType, Document> linksDocument = GetLinksDocument(document);

                documents.AddRange(linksDocument.Values);
            }

            foreach (Document doc in documents)
            {
                if (!ContainsRoomsOrAreaSHO(doc))
                {
                    continue;
                }

                Parameter parameter = GetProjectParameter(doc, parameterName);

                if (parameter == null)
                {
                    result.Add(
                            doc.PathName,
                            string.Format("There is no parameter « {0} » in « {1} »", parameterName, doc.PathName)
                        );

                    continue;
                }

                double valueParameter;
                ParseDoubleValue(doc, parameter.AsValueString(), out valueParameter);

                ElementId categoryId = new ElementId(scheduleCategory);

                ViewSchedule schedule = new FilteredElementCollector(doc)
                            .OfClass(typeof(ViewSchedule))
                                .Cast<ViewSchedule>()
                                    .Where(x => x.Name == scheduleName && x.Definition.CategoryId == categoryId)
                                        .FirstOrDefault();

                if (schedule == null)
                {
                    result.Add(
                            doc.PathName,
                            string.Format("There is no schedule « {0} » in « {1} »", scheduleName, doc.PathName)
                        );

                    continue;
                }

                TableData table = schedule.GetTableData();
                TableSectionData section = table.GetSectionData(SectionType.Body);

                double valueSchedule = 0;

                try
                {
                    valueSchedule = GetTotalScheduleValue(doc, scheduleName, scheduleCategory);
                }
                catch (Exception ex)
                {
                    result.Add(
                        doc.PathName,
                        ex.Message
                    );

                    continue;
                }

                if (greaterZero)
                {
                    if (valueSchedule <= 0)
                    {
                        result.Add(
                            doc.PathName,
                            string.Format("The total value for « {0} » schedule in « {1} », must be greater than zero.", scheduleName, doc.PathName)
                        );

                        continue;
                    }
                }

                if (valueSchedule != valueParameter)
                {
                    result.Add(
                        doc.PathName,
                        string.Format("The « {0} » parameter value is not updated in « {1} »", parameterName, doc.PathName)
                    );
                }
            }

            return result;
        }

        public static Dictionary<string, string> ValidRangeCoeficiente(Document document, string parameterName1 = PARAMETER_SHO, string parameterName2 = PARAMETER_SUP_UTIL, bool fromLoadLinks = false)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            List<Document> documents = new List<Document>();

            documents.Add(document);

            if (fromLoadLinks)
            {
                Dictionary<RevitLinkType, Document> linksDocument = GetLinksDocument(document);

                documents.AddRange(linksDocument.Values);
            }

            foreach (Document doc in documents)
            {
                if (!ContainsRoomsOrAreaSHO(doc))
                {
                    continue;
                }

                Parameter parameter1 = GetProjectParameter(doc, parameterName1);

                if (parameter1 == null)
                {
                    result.Add(
                            doc.PathName,
                            string.Format("There is no parameter « {0} » in « {1} »", parameterName1, doc.PathName)
                        );

                    continue;
                }

                Parameter parameter2 = GetProjectParameter(doc, parameterName2);

                if (parameter2 == null)
                {
                    result.Add(
                            doc.PathName,
                            string.Format("There is no parameter « {0} » in « {1} »", parameterName2, doc.PathName)
                        );

                    continue;
                }

                double valueParameter1;
                double valueParameter2;

                if (!ParseDoubleValue(doc, parameter1.AsValueString(), out valueParameter1))
                {
                    result.Add(
                            doc.PathName,
                            string.Format("Wrong value for « {0} » parameter in « {1} »", parameterName1, doc.PathName)
                        );

                    continue;
                }

                if (!ParseDoubleValue(doc, parameter2.AsValueString(), out valueParameter2))
                {
                    result.Add(
                            doc.PathName,
                            string.Format("Wrong value for « {0} » parameter in « {1} »", parameterName2, doc.PathName)
                        );

                    continue;
                }

                if (valueParameter2 <= 0)
                {
                    result.Add(
                            doc.PathName,
                            string.Format("The value for « {0} » parameter in {1}, must be greater than zero.", parameterName2, doc.PathName)
                        );

                    continue;
                }

                double coeficient = valueParameter1 / valueParameter2;

                if (!(coeficient >= 1 && coeficient < 1.2))
                {
                    result.Add(
                        doc.PathName,
                        string.Format("Coeficiente SC/SU value is outside the range in {0}", doc.PathName)
                    );
                }
            }

            return result;
        }

        public static bool ValidDecimalFormat(Document document, ViewSchedule schedule, string[] decimalFields = null)
        {
            decimalFields = decimalFields ?? new string[] { "Cod1", "Area", "Coeficiente", "Sup. Constr. Real", "AreaCalculada", "Sup. Constr. Computada" };

            List<string> visibleFields = new List<string>();

            for (int i = 0, c = schedule.Definition.GetFieldCount(); i < c; i++)
            {
                ScheduleField field = schedule.Definition.GetField(i);

                if (!field.IsHidden)
                {
                    visibleFields.Add(field.GetName());
                }
            }

            TableData table = schedule.GetTableData();
            TableSectionData section = table.GetSectionData(SectionType.Body);

            string invalidDecimalSeparator =
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "." ? "," : ".";

            for (int i = schedule.Definition.ShowHeaders ? 1 : 0; i < section.NumberOfRows; i++)
            {
                foreach (string field in decimalFields)
                {
                    int j = visibleFields.FindIndex(x => x == field);

                    if (j > -1)
                    {
                        string value = schedule.GetCellText(SectionType.Body, i, j);

                        if (value.Contains(invalidDecimalSeparator))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool ValidTemplate(Document document)
        {
            ViewSheet sheet = new FilteredElementCollector(document)
                            .OfClass(typeof(ViewSheet))
                                .Cast<ViewSheet>()
                                    .Where(x => x.Name == "D94.HOME.1")
                                        .FirstOrDefault();

            return sheet != null;
        }

        public static bool UpdateHome(Document document)
        {
            if (IsEditingByAnother(document, document.ProjectInformation.Id))
            {
                return false;
            }

            double valueSchedule;
            Parameter parameter;

            Transaction transaction = null;

            try
            {
                transaction = new Transaction(document, "Updated Home");

                transaction.Start();

                // Update PARAMETER_SUP_UTIL
                using (SubTransaction subTransaction = new SubTransaction(document))
                {
                    try
                    {
                        subTransaction.Start();

                        valueSchedule = GetTotalScheduleValue(document, SCHEDULE_AREA_UTIL, BuiltInCategory.OST_Rooms);

                        parameter = GetProjectParameter(document, PARAMETER_SUP_UTIL);

                        if (parameter != null)
                        {
                            parameter.Set(valueSchedule);
                            parameter.SetValueString(valueSchedule.ToString());
                        }

                        subTransaction.Commit();
                    }
                    catch (Exception) {
                        if (null != subTransaction)
                        {
                            subTransaction.RollBack();
                        }

                        transaction.RollBack();

                        return false;
                    }
                }

                // Update PARAMETER_SHO
                using (SubTransaction subTransaction = new SubTransaction(document))
                {
                    try
                    {
                        subTransaction.Start();

                        valueSchedule = GetTotalScheduleValue(document, SCHEDULE_AREA_CONST, BuiltInCategory.OST_Areas);

                        parameter = GetProjectParameter(document, PARAMETER_SHO);

                        if (parameter != null)
                        {
                            parameter.Set(valueSchedule);
                            parameter.SetValueString(valueSchedule.ToString());
                        }

                        subTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        if (null != subTransaction)
                        {
                            subTransaction.RollBack();
                        }

                        transaction.RollBack();

                        return false;
                    }
                }

                // Update PARAMETER_CAP_HAB
                using (SubTransaction subTransaction = new SubTransaction(document))
                {
                    try
                    {
                        subTransaction.Start();

                        valueSchedule = GetTotalScheduleValue(document, SCHEDULE_CAP_HAB, BuiltInCategory.OST_Rooms);

                        parameter = GetProjectParameter(document, PARAMETER_CAP_HAB);

                        if (parameter != null)
                        {
                            parameter.Set(valueSchedule);
                            parameter.SetValueString(valueSchedule.ToString());
                        }

                        subTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        if (null != subTransaction)
                        {
                            subTransaction.RollBack();
                        }

                        transaction.RollBack();

                        return false;
                    }
                }

                return TransactionStatus.Committed == transaction.Commit();
            }
            catch (Exception)
            {
                if (null != transaction)
                {
                    transaction.RollBack();
                }

                return false;
            }
        }

        public static bool UpdateNumericParameter(Document document, ElementType type, Dictionary<string, string> parametersRelation, bool overwrite = false)
        {
            IList<Element> elements = GetElements(document, type, false);

            return UpdateNumericParameter(document, elements, parametersRelation, overwrite);
        }

        public static bool UpdateNumericParameter(Document document, IList<Element> elements, Dictionary<string, string> parametersRelation, bool overwrite = false)
        {
            Transaction transaction = null;
            int ignoreEditing = 0;

            try
            {
                transaction = new Transaction(document, "Updated Numeric Parameter");

                transaction.Start();

                /*FailureHandlingOptions failOpt = transaction.GetFailureHandlingOptions();

                failOpt.SetFailuresPreprocessor(new OwnFailureHandling());

                transaction.SetFailureHandlingOptions(failOpt);*/

                foreach (Element element in elements)
                {
                    if (IsEditingByAnother(document, element.Id))
                    {
                        if (ignoreEditing == 0)
                        {
                            TaskDialog td = new TaskDialog("Update Numeric Parameter");

                            td.Title = "Update Numeric Parameter";
                            td.MainInstruction = "Ignore editing elements?";
                            td.MainContent = "There are elements that are being edited by other users.\nDo you want to continue to ignore them?";
                            td.FooterText = "BBI Tabla Áreas";
                            td.TitleAutoPrefix = false;
                            td.AllowCancellation = false;
                            td.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;
                            td.DefaultButton = TaskDialogResult.Yes;

                            TaskDialogResult result = td.Show();

                            if (result == TaskDialogResult.Yes)
                            {
                                ignoreEditing = 1;
                            }
                            else
                            {
                                transaction.RollBack();

                                return false;
                            }
                        }

                        if (ignoreEditing == 1)
                        {
                            continue;
                        }
                    }

                    foreach (var item in parametersRelation)
                    {
                        Parameter parameter1 = element.LookupParameter(item.Key);
                        Parameter parameter2 = element.LookupParameter(item.Value);

                        CopyParameterValue(document, parameter1, parameter2, overwrite);
                    }
                }

                return TransactionStatus.Committed == transaction.Commit();
            }
            catch (Exception)
            {
                if (null != transaction)
                {
                    transaction.RollBack();
                }

                return false;
            }
        }

        public static bool UpdateControlPrograma(Document document, IList<Element> elements)
        {
            Transaction transaction = null;
            int ignoreEditing = 0;

            try
            {
                transaction = new Transaction(document, "Updated Control Programa");

                transaction.Start();

                foreach (Element element in elements)
                {
                    if (IsEditingByAnother(document, element.Id))
                    {
                        if (ignoreEditing == 0)
                        {
                            TaskDialog td = new TaskDialog("Update Control Programa parameters");

                            td.Title = "Update Control Programa parameters";
                            td.MainInstruction = "Ignore editing elements?";
                            td.MainContent = "There are elements that are being edited by other users.\nDo you want to continue to ignore them?";
                            td.FooterText = "BBI Tabla Áreas";
                            td.TitleAutoPrefix = false;
                            td.AllowCancellation = false;
                            td.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;
                            td.DefaultButton = TaskDialogResult.Yes;

                            TaskDialogResult result = td.Show();

                            if (result == TaskDialogResult.Yes)
                            {
                                ignoreEditing = 1;
                            }
                            else
                            {
                                transaction.RollBack();

                                return false;
                            }
                        }

                        if (ignoreEditing == 1)
                        {
                            continue;
                        }
                    }

                    // Update AreaPrograma = CoeficienteArea * CoeficienteNumHab
                    Parameter areaPrograma = element.LookupParameter("AreaPrograma");

                    if (areaPrograma != null)
                    {
                        Parameter parameter1 = element.LookupParameter("CoeficienteArea");
                        Parameter parameter2 = element.LookupParameter("CoeficienteNumHab");

                        if (parameter1 != null && parameter2 != null)
                        {
                            if (parameter1.HasValue && parameter2.HasValue)
                            {
                                areaPrograma.Set(parameter1.AsDouble() * parameter2.AsInteger());
                            }
                        }

                        // Update DesviacionArea = Area - AreaPrograma
                        Parameter desviacionArea = element.LookupParameter("DesviacionArea");

                        if (desviacionArea != null)
                        {
                            parameter1 = element.get_Parameter(BuiltInParameter.ROOM_AREA);

                            if (parameter1 != null)
                            {
                                if (parameter1.HasValue && areaPrograma.HasValue)
                                {
                                    desviacionArea.Set(parameter1.AsDouble() - areaPrograma.AsDouble());
                                }                                
                            }
                        }

                        // Update DesviacionPorcentage = DesviacionArea / AreaPrograma * 100
                        Parameter desviacionPorcentage = element.LookupParameter("DesviacionPorcentage");

                        if (desviacionPorcentage != null)
                        {
                            if (desviacionArea.HasValue && areaPrograma.HasValue)
                            {
                                if (areaPrograma.AsDouble() > 0)
                                {
                                    desviacionPorcentage.Set(desviacionArea.AsDouble() / areaPrograma.AsDouble() * 100);
                                }
                                else
                                {
                                    desviacionPorcentage.Set(0);
                                }
                            }                            
                        }
                    }
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollBack();

                return false;
            }

            return true;
        }

        public static double GetTotalScheduleValue(Document document, string scheduleName, BuiltInCategory scheduleCategory)
        {
            double value = 0;

            ElementId categoryId = new ElementId(scheduleCategory);

            ViewSchedule schedule = new FilteredElementCollector(document)
                        .OfClass(typeof(ViewSchedule))
                            .Cast<ViewSchedule>()
                                .Where(x => x.Name == scheduleName && x.Definition.CategoryId == categoryId)
                                    .FirstOrDefault();

            TableData table = schedule.GetTableData();
            TableSectionData section = table.GetSectionData(SectionType.Body);

            if (section.NumberOfRows == 2)
            {
                if (!ParseDoubleValue(document, schedule.GetCellText(SectionType.Body, 1, 0), out value))
                {
                    throw new Exception(
                        string.Format("Wrong total value for « {0} » schedule in « {1} »", scheduleName, document.PathName)
                    );
                }
            }
            else
            {
                if (section.NumberOfRows == 1 && schedule.Definition.ShowHeaders)
                {
                    throw new Exception(
                        string.Format("The « {0} » schedule does not contain data in « {1} »", scheduleName, document.PathName)
                    );
                }
                else
                {
                    throw new Exception(
                        string.Format("Invalid presentation for « {0} » schedule in « {1} »", scheduleName, document.PathName)
                    );
                }
            }

            return value;
        }

        public static Parameter GetProjectParameter(Document document, string parameterName)
        {
            /*Element projectInfo = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_ProjectInformation)
                    .FirstElement();*/

            return document.ProjectInformation.LookupParameter(parameterName);
        }

        public static Parameter GetProjectParameter(Document document, BuiltInParameter parameterId)
        {
            /*Element projectInfo = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_ProjectInformation)
                    .FirstElement();*/

            return document.ProjectInformation.get_Parameter(parameterId);
        }

        public static Dictionary<RevitLinkType, Document> GetLinksDocument(Document document, bool validTemplate = true)
        {
            Dictionary<RevitLinkType, Document> linksDocument = new Dictionary<RevitLinkType, Document>();

            FilteredElementCollector links = new FilteredElementCollector(document)
                    .OfClass(typeof(RevitLinkType));

            foreach (RevitLinkType link in links)
            {
                if (RevitLinkType.IsLoaded(document, link.Id))
                {
                    string path = ModelPathUtils.ConvertModelPathToUserVisiblePath(link.GetExternalFileReference().GetAbsolutePath());

                    Document doc = document.Application.Documents.Cast<Document>()
                            .Where(d => d.PathName == path)
                                .FirstOrDefault();

                    if (validTemplate)
                    {
                        if (ValidTemplate(doc))
                        {
                            if (!linksDocument.ContainsValue(doc))
                            {
                                linksDocument.Add(link, doc);
                            }
                        }
                    }
                    else
                    {
                        if (!linksDocument.ContainsValue(doc))
                        {
                            linksDocument.Add(link, doc);
                        }
                    }
                }
            }

            return linksDocument;
        }

        public static Dictionary<string, string> GetDefaultParametersRelation()
        {
            Dictionary<string, string> parametersRelation = new Dictionary<string, string>();

            parametersRelation.Add("Porciento BD", "PorcientoBD");
            parametersRelation.Add("Hab", "Habitacion");
            parametersRelation.Add("ModulosHab", "Modulos");
            parametersRelation.Add("Coeficiente", "CoeficienteArea");
            parametersRelation.Add("CoefNumHab", "CoeficienteNumHab");

            return parametersRelation;
        }

        public static bool ParseDoubleValue(Document document, string total, out double value)
        {
            NumberStyles style = NumberStyles.Number;
            CultureInfo culture = new CultureInfo(CultureInfo.CurrentCulture.Name);

            culture.NumberFormat.NumberDecimalSeparator = document.GetUnits().DecimalSymbol == DecimalSymbol.Dot ? "." : ",";

            return double.TryParse(total, style, culture, out value);
        }

        public static string GetAreaSchemaNameFromArea(Document document, Area area)
        {
            Parameter parameter = area.get_Parameter(BuiltInParameter.AREA_SCHEME_ID);

            if (parameter != null)
            {
                Element areaSchema = document.GetElement(parameter.AsElementId());

                parameter = areaSchema.get_Parameter(BuiltInParameter.AREA_SCHEME_NAME);

                if (parameter != null)
                {
                    return parameter.AsString();
                }
            }

            return string.Empty;
        }

        public static bool ContainsRoomsOrAreaSHO(Document document, bool fromLoadLinks = false)
        {
            return GetElements(document, ElementType.ROOM, fromLoadLinks).Count + GetElements(document, ElementType.AREA, fromLoadLinks).Where(x => GetAreaSchemaNameFromArea(document, (Area)x).Equals(AREA_NAME)).Count() > 0;
        }

        private static IList<Element> GetElements(Document document, ElementType type, bool fromLoadLinks = false)
        {
            FilteredElementCollector collector = new FilteredElementCollector(document);

            if (type == ElementType.AREA)
            {
                collector.WherePasses(new AreaFilter());
            }
            else
            {
                collector.WherePasses(new RoomFilter());
            }

            IList<Element> elements = collector.ToElements();

            if (fromLoadLinks)
            {
                // When a link contained in a link is referenced like Overlay, these not appear in document included parent link

                Dictionary<RevitLinkType, Document> linksDocument = GetLinksDocument(document);

                foreach (var item in linksDocument)
                {
                    collector = new FilteredElementCollector(item.Value);

                    if (type == ElementType.AREA)
                    {
                        collector.WherePasses(new AreaFilter());
                    }
                    else
                    {
                        collector.WherePasses(new RoomFilter());
                    }

                    foreach (Element element in collector)
                    {
                        elements.Add(element);
                    }
                }
            }

            return elements;
        }

        private static ElementValue Distinguish(SpatialElement element)
        {
            if (element.Area > 0)
            {
                return ElementValue.PLACED;
            }
            else if (element.Location == null)
            {
                return ElementValue.NOT_PLACED;
            }
            else
            {
                SpatialElementBoundaryOptions opt = new SpatialElementBoundaryOptions();

                IList<IList<BoundarySegment>> segs = element.GetBoundarySegments(opt);

                return (segs == null || segs.Count == 0) ? ElementValue.NOT_ENCLOSED : ElementValue.REDUNDANT;
            }
        }

        private static List<object> GetValues(SpatialElement element, ElementValue value, bool fullPath = false)
        {
            List<object> values = new List<object>();

            values.Add(element.Id.ToString());
            values.Add(element.Name);
            values.Add(element.Level != null ? element.Level.Name : "");
            values.Add(value.ToString());
            values.Add(fullPath ? element.Document.PathName : Path.GetFileName(element.Document.PathName));

            return values;
        }

        private static bool CopyParameterValue(Document document, Parameter parameter1, Parameter parameter2, bool overwrite)
        {
            if (parameter1 == null || parameter2 == null)
            {
                return false;
            }
            if (!parameter1.HasValue)
            {
                return false;
            }
            if (parameter2.HasValue && !overwrite)
            {
                return true;
            }

            double valueDouble;
            int valueInt;
            string valueString = "";

            switch (parameter1.StorageType)
            {
                case StorageType.Double:
                    valueString = parameter1.AsDouble().ToString();
                    break;

                case StorageType.ElementId:
                    break;

                case StorageType.Integer:
                    valueString = parameter1.AsInteger().ToString();
                    break;

                case StorageType.None:
                    break;

                case StorageType.String:
                    valueString = parameter1.AsString();
                    break;

                default:
                    break;
            }

            switch (parameter2.StorageType)
            {
                case StorageType.Double:
                    ParseDoubleValue(document, valueString, out valueDouble);
                    parameter2.Set(valueDouble);
                    parameter2.SetValueString(valueString);
                    break;

                case StorageType.ElementId:
                    break;

                case StorageType.Integer:
                    int.TryParse(valueString, out valueInt);
                    parameter2.Set(valueInt);
                    parameter2.SetValueString(valueString);
                    break;

                case StorageType.None:
                    break;

                case StorageType.String:
                    parameter2.Set(valueString);
                    parameter2.SetValueString(valueString);
                    break;

                default:
                    break;
            }

            return true;
        }

        private static bool IsEditingByAnother(Document document, ElementId elementId)
        {
            if (!document.IsWorkshared || document.IsDetached)
            {
                return false;
            }

            // Checkout attempt
            ICollection<ElementId> checkedOutIds = WorksharingUtils.CheckoutElements(document, new ElementId[] { elementId });

            // Confirm checkout
            bool checkedOutSuccessfully = checkedOutIds.Contains(elementId);

            if (!checkedOutSuccessfully)
            {
                return true;
            }

            ModelUpdatesStatus updatesStatus = WorksharingUtils.GetModelUpdatesStatus(document, elementId);

            return updatesStatus == ModelUpdatesStatus.DeletedInCentral || updatesStatus == ModelUpdatesStatus.UpdatedInCentral;
        }
    }

    public enum ElementType
    {
        ROOM,
        AREA
    }

    public enum ElementValue
    {
        NOT_PLACED,
        NOT_ENCLOSED,
        REDUNDANT,
        PLACED
    }

    public enum Rule
    {
        NOT_PLACED_ROOM,
        NOT_PLACED_AREA,
        NOT_ENCLOSED_ROOM,
        NOT_ENCLOSED_AREA,
        REDUNDANT_ROOM,
        REDUNDANT_AREA,
        EMPTY_NIVELES_TIPICO_ROOM,
        EMPTY_NIVELES_TIPICO_AREA,
        EMPTY_PORCIENTO_BD,
        DECIMAL_FORMAT_POCIENTO_BD,
        UPDATED_HOME_SUP_UTIL,
        UPDATED_HOME_SHO,
        UPDATED_HOME_CAP_HAB,
        RANGE_COEFICIENTE_SCSU,
        DECIMAL_FORMAT_POINT
    }

    public class RuleReponse
    {
        public RuleReponse(bool valid, string message, string[] subMessages = null)
        {
            Valid = valid;
            Message = message;
            SubMessages = subMessages ?? new string[]{ };
        }

        public bool Valid { set; get; }
        public string Message { set; get; }
        public string[] SubMessages { set; get; }
    }

    public enum Task
    {
        EXCLUDE_NOT_PLACED,
        SET_DEFAULT_NIVELES_TIPICO,
        SET_DEFAULT_PORCIENTO_BD,
        FORMAT_DECIMAL_POINT
    }

    public class ScheduleExport
    {
        public ScheduleExport(string field, string value = null, ParameterType type = ParameterType.STRING)
        {
            Field = field;
            Value = value;
            Type = type;
        }

        public string Field { get; set; }
        public string Value { get; set; }
        public ParameterType Type { get; set; }
    }

    public enum ParameterType
    {
        INT,
        DOUBLE,
        BOOL,
        CHAR,
        STRING
    }

    public class OwnFailureHandling : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            IList<FailureMessageAccessor> failures = failuresAccessor.GetFailureMessages();

            foreach (FailureMessageAccessor f in failures)
            {
                FailureDefinitionId id = f.GetFailureDefinitionId();

                /*if (BuiltInFailures.EditingFailures.OwnedByOther == id)
                {
                    TaskDialogResult result = TaskDialog.Show("Continue ?", "Continue", TaskDialogCommonButtons.Yes);

                    if (result == TaskDialogResult.Yes)
                    {
                        failuresAccessor.DeleteElements(f.GetFailingElementIds().ToList());
                    }
                }*/
            }

            return FailureProcessingResult.Continue;
        }
    }

    public class RoomPickFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            return (element.Category.Id.IntegerValue.Equals(
              (int)BuiltInCategory.OST_Rooms));
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }

    class SynchLockCallback : ICentralLockedCallback
    {
        // If unable to lock central, give up rather than waiting
        public bool ShouldWaitForLockAvailability()
        {
            return false;
        }
    }
}
