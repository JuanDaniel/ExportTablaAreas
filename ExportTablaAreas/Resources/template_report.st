<html>
	<head>
		<title>$TITLE$</title>

		<meta charset="UTF-8">
        <meta name="author" content="Add-in ExportTablaAreas (Juan Daniel SANTANA)">

		<style type="text/css">
			* {
				margin: 0;
				padding: 0;
			}

			h1 {
				font-size: 34px;
				text-align: center;
			}

			#container {
				width: 98%;
			    padding-right: 15px;
			    padding-left: 15px;
			    padding-top: 20px;
			    margin-right: auto;
			    margin-left: auto;
			}

			div.box {
				padding: 1rem;
			    margin: 1rem -15px 0;
			    border: solid #f8f9fa;
			    border-width: .2rem 0 0;
			}

			div.box div.header {
				font-size: 20px;
			}

			div.box div.header p {
			    font-weight: bold;
			}

			div.box div.content {
				font-size: 16px;
			}

			div.card {
			    position: relative;
			    display: -ms-flexbox;
			    display: flex;
			    -ms-flex-direction: column;
			    flex-direction: column;
			    min-width: 0;
			    word-wrap: break-word;
			    background-color: #fff;
			    background-clip: border-box;
			    border: 1px solid rgba(0,0,0,.125);
			    border-radius: .25rem;
			    margin-bottom: 20px;
			}

			div.card div.card-header {
			    padding: .75rem 1.25rem;
			    margin-bottom: 0;
			    background-color: rgba(0,0,0,.03);
			    border-bottom: 1px solid rgba(0,0,0,.125);
			    font-weight: bold;
			}

			div.card div.card-body {
			    -ms-flex: 1 1 auto;
			    flex: 1 1 auto;
			    min-height: 1px;
			    padding: 1.25rem;
			}

			div.card .card-title {
			    margin-bottom: .75rem;
			}

			.bg-light {
			    background-color: #f8f9fa!important;
			}

			.border-good {
			    border-color: green!important;
			}

			.border-error {
			    border-color: red!important;
			}

			ul li {
				margin: 5px 0;
				line-height: 2rem;
			}

			ul.children {
				margin-left: 20px;
			}

			ul.submessages {
			    margin-left: 50px;
			    margin-bottom: 20px;
			}

			p {
				margin-bottom: 15px;
			}

			p.good {
				position: relative;
			    padding: .75rem 1.25rem;
			    margin-bottom: 1rem;
			    border: 1px solid transparent;
			    border-radius: .25rem;

			    color: #155724;
			    background-color: #d4edda;
			    border-color: #c3e6cb;
			}

			p.error {
				position: relative;
			    padding: .75rem 1.25rem;
			    margin-bottom: 1rem;
			    border: 1px solid transparent;
			    border-radius: .25rem;

			    color: #721c24;
			    background-color: #f8d7da;
			    border-color: #f5c6cb;
			}

			#rules {
				padding: 15px 30px;
			    border: 1px solid #eee;
			    border-left-width: .25rem;
			    border-radius: .25rem;
			}

			#rules.good {
				border-left-color: green;
			}

			#rules.error {
				border-left-color: red;
			}

			.footer p{
				text-align: center;
				font-size: 12px;
			}
		</style>
	</head>
	
	<body>
		<div id="container">
			<h1>Report Tabla Areas</h1>

			<div class="box">
				<div class="header">
					<p>Main information</p>
				</div>
				<div class="content">
					<p><strong>Project:</strong> $PROJECT_NAME$</p>
					<p><strong>File:</strong> $PROJECT_FILE$</p>
					<p><strong>Checked links:</strong> $CHECKED_LINKS$</p>
					<p><strong>Report date:</strong> $REPORT_DATE$</p>
					$if(REPORT_RESULT)$
						<p><strong>State:</strong> <span style="color: green;">Passed</span></p>	
					$else$
						<p><strong>State:</strong> <span style="color: red;">Not Passed</span></p>
					$endif$
				</div>
			</div>
			
			<div class="box">
				<div class="header">
					<p>Tested rules</p>
				</div>
				<div class="content">
					<ul id="rules" class="$if(REPORT_RESULT)$ good $else$ error $endif$">
						$if(RULE_1)$
							<li>
								<span>Check Not Placed</span>

								<ul class="children">
									<li><a href="#NOT_PLACED_ROOM">Room</a></li>
									<li><a href="#NOT_PLACED_AREA">Area</a></li>
								</ul>
							</li>
						$endif$

						$if(RULE_2)$
							<li>
								<span>Check Not Enclosed</span>

								<ul class="children">
									<li><a href="#NOT_ENCLOSED_ROOM">Room</a></li>
									<li><a href="#NOT_ENCLOSED_AREA">Area</a></li>
								</ul>
							</li>
						$endif$

						$if(RULE_3)$
							<li>
								<span>Check Redundant</span>

								<ul class="children">
									<li><a href="#REDUNDANT_ROOM">Room</a></li>
									<li><a href="#REDUNDANT_AREA">Area</a></li>
								</ul>
							</li>
						$endif$

						$if(RULE_4)$
							<li>
								<span>Check empty NivelesTipicos</span>

								<ul class="children">
									<li><a href="#EMPTY_NIVELES_TIPICO_ROOM">Room</a></li>
									<li><a href="#EMPTY_NIVELES_TIPICO_AREA">Area</a></li>
								</ul>
							</li>
						$endif$

						$if(RULE_5)$
							<li><a href="#EMPTY_PORCIENTO_BD">Check empty PorcientoBD</a></li>
						$endif$

						$if(RULE_6)$
							<li><a href="#DECIMAL_FORMAT_POCIENTO_BD">Check decimal format PorcientoBD</a></li>
						$endif$

						$if(RULE_7)$
							<li>
								<span>Updated Home</span>

								<ul class="children">
									<li><a href="#UPDATED_HOME_SUP_UTIL">Sup. Útil</a></li>
									<li><a href="#UPDATED_HOME_SHO">S.H.O</a></li>
									<li><a href="#UPDATED_HOME_CAP_HAB">Capacidad Habitacional</a></li>
								</ul>
							</li>
						$endif$

						$if(RULE_8)$
							<li><a href="#RANGE_COEFICIENTE_SCSU">Check Coeficiente SC/SU value between 1 - 1.2</a></li>
						$endif$

						$if(RULE_9)$
							<li><a href="#DECIMAL_FORMAT_POINT">Check decimal format point</a></li>
						$endif$
					</ul>	
				</div>
			</div>

			<div class="box">
				<div class="header">
					<p>Results</p>
				</div>
				<div class="content">
					$if(RULE_1)$
						<div id="NOT_PLACED_ROOM" class="card bg-light $if(NOT_PLACED_ROOM.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(NOT_PLACED_ROOM.valid)$ border-good $else$ border-error $endif$">Check Not Placed (Room)</div>

							<div class="card-body">
								$if(NOT_PLACED_ROOM.valid)$
									<p class="good">Placed Room.</p>
								$else$
									<p class="error">There are $NOT_PLACED_ROOM.message$ total Not Placed Room.</p>

									<ul class="submessages">
										$NOT_PLACED_ROOM.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>

						<div id="NOT_PLACED_AREA" class="card bg-light $if(NOT_PLACED_AREA.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(NOT_PLACED_AREA.valid)$ border-good $else$ border-error $endif$">Check Not Placed (Area)</div>

							<div class="card-body">
								$if(NOT_PLACED_AREA.valid)$
									<p class="good">Placed Area.</p>
								$else$
									<p class="error">There are $NOT_PLACED_AREA.message$ total Not Placed Area.</p>

									<ul class="submessages">
										$NOT_PLACED_AREA.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_2)$
						<div id="NOT_ENCLOSED_ROOM" class="card bg-light $if(NOT_ENCLOSED_ROOM.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(NOT_ENCLOSED_ROOM.valid)$ border-good $else$ border-error $endif$">Check Not Enclosed (Room)</div>

							<div class="card-body">
								$if(NOT_ENCLOSED_ROOM.valid)$
									<p class="good">Enclosed Room.</p>
								$else$
									<p class="error">There are $NOT_ENCLOSED_ROOM.message$ total Not Enclosed Room.</p>

									<ul class="submessages">
										$NOT_ENCLOSED_ROOM.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>

						<div id="NOT_ENCLOSED_AREA" class="card bg-light $if(NOT_ENCLOSED_AREA.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(NOT_ENCLOSED_AREA.valid)$ border-good $else$ border-error $endif$">Check Not Enclosed (Area)</div>

							<div class="card-body">
								$if(NOT_ENCLOSED_AREA.valid)$
									<p class="good">Enclosed Area.</p>
								$else$
									<p class="error">There are $NOT_ENCLOSED_AREA.message$ total Not Enclosed Area.</p>

									<ul class="submessages">
										$NOT_ENCLOSED_AREA.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_3)$
						<div id="REDUNDANT_ROOM" class="card bg-light $if(REDUNDANT_ROOM.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(REDUNDANT_ROOM.valid)$ border-good $else$ border-error $endif$">Check Redundant (Room)</div>

							<div class="card-body">
								$if(REDUNDANT_ROOM.valid)$
									<p class="good">Not Redundant Room.</p>
								$else$
									<p class="error">There are $REDUNDANT_ROOM.message$ total Redundant Room.</p>

									<ul class="submessages">
										$REDUNDANT_ROOM.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>

						<div id="REDUNDANT_AREA" class="card bg-light $if(REDUNDANT_AREA.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(REDUNDANT_AREA.valid)$ border-good $else$ border-error $endif$">Check Redundant (Area)</div>

							<div class="card-body">
								$if(REDUNDANT_AREA.valid)$
									<p class="good">Not Redundant Area.</p>
								$else$
									<p class="error">There are $REDUNDANT_AREA.message$ total Redundant Area.</p>

									<ul class="submessages">
										$REDUNDANT_AREA.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_4)$
						<div id="EMPTY_NIVELES_TIPICO_ROOM" class="card bg-light $if(EMPTY_NIVELES_TIPICO_ROOM.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(EMPTY_NIVELES_TIPICO_ROOM.valid)$ border-good $else$ border-error $endif$">Check empty NivelesTipicos (Room)</div>

							<div class="card-body">
								$if(EMPTY_NIVELES_TIPICO_ROOM.valid)$
									<p class="good">No empty NivelesTipicos for Room.</p>
								$else$
									<p class="error">There are $EMPTY_NIVELES_TIPICO_ROOM.message$ total empty NivelesTipicos for Room.</p>

									<ul class="submessages">
										$EMPTY_NIVELES_TIPICO_ROOM.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>

						<div id="EMPTY_NIVELES_TIPICO_AREA" class="card bg-light $if(EMPTY_NIVELES_TIPICO_AREA.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(EMPTY_NIVELES_TIPICO_AREA.valid)$ border-good $else$ border-error $endif$">Check empty NivelesTipicos (Area S.H.O)</div>

							<div class="card-body">
								$if(EMPTY_NIVELES_TIPICO_AREA.valid)$
									<p class="good">No empty NivelesTipicos for Area (S.H.O)</p>
								$else$
									<p class="error">There are $EMPTY_NIVELES_TIPICO_AREA.message$ total empty NivelesTipicos for Area (S.H.O)</p>

									<ul class="submessages">
										$EMPTY_NIVELES_TIPICO_AREA.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_5)$
						<div id="EMPTY_PORCIENTO_BD" class="card bg-light $if(EMPTY_PORCIENTO_BD.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(EMPTY_PORCIENTO_BD.valid)$ border-good $else$ border-error $endif$">Check empty PorcientoBD</div>

							<div class="card-body">
								$if(EMPTY_PORCIENTO_BD.valid)$
									<p class="good">No empty PorcientoBD.</p>
								$else$
									<p class="error">There are $EMPTY_PORCIENTO_BD.message$ total empty PorcientoBD.</p>

									<ul class="submessages">
										$EMPTY_PORCIENTO_BD.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_6)$
						<div id="DECIMAL_FORMAT_POCIENTO_BD" class="card bg-light $if(DECIMAL_FORMAT_POCIENTO_BD.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(DECIMAL_FORMAT_POCIENTO_BD.valid)$ border-good $else$ border-error $endif$">Check decimal format PorcientoBD</div>

							<div class="card-body">
								$if(DECIMAL_FORMAT_POCIENTO_BD.valid)$
									<p class="good">Correct decimal format PorcientoBD.</p>
								$else$
									<p class="error">Wrong decimal format PorcientoBD.</p>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_7)$
						<div id="UPDATED_HOME_SUP_UTIL" class="card bg-light $if(UPDATED_HOME_SUP_UTIL.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(UPDATED_HOME_SUP_UTIL.valid)$ border-good $else$ border-error $endif$">Updated Home (Sup. Útil)</div>

							<div class="card-body">
								$if(UPDATED_HOME_SUP_UTIL.valid)$
									<p class="good">Sup. Útil is updated.</p>
								$else$
									<p class="error">Sup. Útil is not updated.</p>

									<ul class="submessages">
										$UPDATED_HOME_SUP_UTIL.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>

						<div id="UPDATED_HOME_SHO" class="card bg-light $if(UPDATED_HOME_SHO.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(UPDATED_HOME_SHO.valid)$ border-good $else$ border-error $endif$">Updated Home (S.H.O)</div>

							<div class="card-body">
								$if(UPDATED_HOME_SHO.valid)$
									<p class="good">S.H.O is updated.</p>
								$else$
									<p class="error">S.H.O is not updated.</p>

									<ul class="submessages">
										$UPDATED_HOME_SHO.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>

						<div id="UPDATED_HOME_CAP_HAB" class="card bg-light $if(UPDATED_HOME_CAP_HAB.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(UPDATED_HOME_CAP_HAB.valid)$ border-good $else$ border-error $endif$">Updated Home (Capacidad Habitacional)</div>

							<div class="card-body">
								$if(UPDATED_HOME_CAP_HAB.valid)$
									<p class="good">Capacidad Habitacional is updated.</p>
								$else$
									<p class="error">Capacidad Habitacional is not updated.</p>

									<ul class="submessages">
										$UPDATED_HOME_CAP_HAB.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_8)$
						<div id="RANGE_COEFICIENTE_SCSU" class="card bg-light $if(RANGE_COEFICIENTE_SCSU.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(RANGE_COEFICIENTE_SCSU.valid)$ border-good $else$ border-error $endif$">Check Coeficiente SC/SU value between 1 - 1.2</div>

							<div class="card-body">
								$if(RANGE_COEFICIENTE_SCSU.valid)$
									<p class="good">Coeficiente SC/SU value is in the range (1 - 1.2)</p>
								$else$
									<p class="error">Coeficiente SC/SU value is outside the range. This one has to be in the range (1 - 1.2)</p>

									<ul class="submessages">
										$RANGE_COEFICIENTE_SCSU.subMessages:{it| <li>$it$</li> }$
									</ul>
								$endif$
							</div>
						</div>
					$endif$

					$if(RULE_9)$
						<div id="DECIMAL_FORMAT_POINT" class="card bg-light $if(DECIMAL_FORMAT_POINT.valid)$ border-good $else$ border-error $endif$">
							<div class="card-header $if(DECIMAL_FORMAT_POINT.valid)$ border-good $else$ border-error $endif$">Check decimal format point</div>

							<div class="card-body">
								$if(DECIMAL_FORMAT_POINT.valid)$
									<p class="good">Correct decimal format.</p>
								$else$
									<p class="error">Wrong decimal format.</p>
								$endif$
							</div>
						</div>
					$endif$
				</div>
			</div>

			<div class="footer">
				<p>$YEAR$ © Add-in ExportTablaAreas ($VERSION$)</p>
			</div>
		</div>
	<body>
</html>