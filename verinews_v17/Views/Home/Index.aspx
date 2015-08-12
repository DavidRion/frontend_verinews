<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Verinews.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Script footer slide -->
    <script type="text/javascript">
        jQuery(function ($) {
            var open = false
            $('.footerSlideMyButton').click(function () {
                if (open === false) {
                    $('#footerSlideContent').animate({ height: '300px' });
                    $(this).css('backgroundPosition', 'bottom left');
                    open = true;
                } else {
                    $('#footerSlideContent').animate({ height: '0px' });
                    $(this).css('backgroundPosition', 'top left');
                    open = false;
                }
            });
        });
    </script>
   
    <!-- navigation circulaire -->
    <nav role="navigation" style="position:realtive; z-index:10;">
        <h1 onclick = "void(0);">Menu</h1>
        <ol>
            <li><a class="footerSlideMyButton" href="#" onclick="showCategory('footerSlideText1');"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></a></li>
            <li><a class="footerSlideMyButton" href="#" onclick="showCategory('footerSlideText2');"><span class="glyphicon glyphicon-stats" aria-hidden="true"></a></li>
            <li><a href="/Home/About">Cat.3</a></li>
            <li><a href="#" onclick="pieChart();">Cat.4</a></li>
            <li><a href="#"><span class="glyphicon glyphicon-off" aria-hidden="true"></a></li>
        </ol>
    </nav>
    
    <!-- Titre page-->
    <br />
    <div class="col-md-8 col-md-offset-2">
        <h1 style="margin:0;" class="text-center" >Projet d'aide à la rédaction - Verinews</h1>
    </div>
    <br /><br /><br /><br />

    <!-- Champs Titre -->
    <div class="input-group input-group-lg col-md-8 col-md-offset-2">
        <span class="input-group-addon " style="width : 250px;"><span class="glyphicon glyphicon-tag" aria-hidden="true"></span> Titre de l'article</span>
        <input type="text" class="form-control" placeholder="Entrez un titre pour votre article">
    </div><br />

    <!-- Champs Rédaction article -->
    <div class="input-group input-group-lg col-md-8 col-md-offset-2 ">
        <span class="input-group-addon" style="width : 250px; vertical-align:top;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span> Contenu de l'article</span>
        <textarea class="form-control" placeholder="Entrez contenu pour votre article" style="height : 500px;"></textarea>
    </div>

    <!-- Footer déroulant -->
    <div id="footerSlideContainer" class="row-fluid" style=" z-index: 10;">
	    <div class="footerSlideMyButton" id="footerSlideButton" ></div>

	    <div id="footerSlideContent">
            <!-- Content category 1 ****************************************************************************************************************************************************** -->
		    <div id="footerSlideText1" class="container-fluid">
			    <div><h3>Onglet recherche!</h3></div>
                
        <form method="post" class="form-inline" action="#" id="searchForm">
        <!-- BLOC 1 ************************************************************************************************************************************************************ -->
        <div class="form-group" >
        <div class="input-group col-md-10">
            <h2>
                <small>Recherche par mots clés</small>
                <input checked data-toggle="toggle" data-size="large" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox" onchange="switcherSearchText(this);">
            </h2>
            <div class="input-group">
                <span class="input-group-addon">Critère 1</span>
                <input type="text" class="form-control" id="criteria1" name="criteria1" value="<%= ViewData["criteria1"] %>" placeholder="Critere 1...">
            </div>
            <div class="input-group">
                <span class="input-group-addon">Critère 2</span>
                <input type="text" class="form-control" id="criteria2" name="criteria2" value="<%= ViewData["criteria2"] %>" placeholder="Critère 2...">
            </div>

            <div>
                <button type="submit" class="btn btn-success">Chercher!</button>
            </div>
        </div>
        </div>
        <!-- BLOC 2 ************************************************************************************************************************************************************ -->
        <div class="form-group" >
        <div class="input-group col-md-12">
            <h2>
                <small>Recherche par thème</small>
                <input checked data-toggle="toggle" data-size="large" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox" onchange="switcherSearchTheme(this);">
            </h2>
            <div class="col-md-4">Lifestyle1</div>
            <div class="input-group col-md-8">
                <input id="Checkbox1" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
            <div class="col-md-4">Lifestyle2</div>
            <div class="input-group col-md-8" id="lifestyle2">
                <input id="Checkbox2" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
            <div class="col-md-4">Lifestyle3</div>
            <div class="input-group col-md-8" id="lifestyle3">
                <input id="Checkbox3" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
            <div class="col-md-4">Lifestyle4</div>
            <div class="input-group col-md-8" id="lifestyle4">
                <input id="Checkbox4" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
        </div>
        </div>
        
        <!-- BLOC 3 ************************************************************************************************************************************************************ -->
        <div class="form-group" >
        <div class="input-group col-md-12">
            <h2>
                <small>Recherche par sentiments</small>
                <input checked data-toggle="toggle" data-size="large" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox" onchange="switcherSearchFeeling(this);">
            </h2>
            <div class="col-md-4">Sentiment Positif</div>
            <div class="input-group col-md-8">
                <input id="Checkbox5" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
            <div class="col-md-4">Sentiment Négatif</div>
            <div class="input-group col-md-8">
                <input id="Checkbox6" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
            <div class="col-md-4">Sentiment Neutre</div>
            <div class="input-group col-md-8">
                <input id="Checkbox7" checked data-toggle="toggle" data-size="small" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox">
            </div>
        </div>
        </div>
        <!-- BLOC 4 ************************************************************************************************************************************************************ -->
        <div class="form-group" >
        <div class="input-group col-md-12">
            <h2>
                <small>Fourchette de temps à analyser</small>
                <input checked data-toggle="toggle" data-size="large" data-on="<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>" data-off="<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>" type="checkbox" onchange="switcherSearchDate(this);">
            </h2>

            <div class="col-md-2">De :</div>
            <div class="input-group date" id="startDate">
                <span id="startDateBtn" class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span><input type="text" class="form-control">
                <script type="text/javascript">
                    $('.input-group.date').datepicker({
                        language: "fr"
                    });
                </script>
            </div>
            <br />
            <div class="col-md-2">À :</div>
            <div class="input-group date" id="endDate">
                <span class="input-group-addon"><i class="glyphicon glyphicon-th" id="I1"></i></span><input id="endDate" type="text" class="form-control">
                <script type="text/javascript">
                    $(function () {
                        $('#endDate').datepicker({
                            language: "fr",
                            
                        });
                    });
                </script>
            </div> 
      
        </div>
        </div>
        </form>
	</div>
            
        <!-- Content category 2 -->  		
        <div id="footerSlideText2" style="display:none;" class="container-fluid">
		    <h3>Hey! I'm a Sliding Footer Category 2</h3>
            <table width="100%">
                <tr>
                    <td width="33%"><div id="chartPie"  style="height: 240px; margin: 0 auto"></div></td>

                    <td width="34%"><div id="chart_div" style="margin: 0 auto"></div></td>

                    <td width="33%"><div id="donutchart" style="height: 240px; margin: 0 auto"></div></td>
                </tr>
            </table>            
	        </div>
        </div>
    </div>

    <!-- Script Footer -->
    <script type="text/javascript">
        var divPrecedent = document.getElementById('footerSlideText1');
    </script> 

    <!-- script ajax search for line chart and pie chart -->
    <script type="text/javascript">
        $(document).ready(function () {

            $('#searchForm').on('submit', function (e) {

                e.preventDefault();

                $.ajax({
                    type: "POST",
                    url: "/Home/ajaxPie",
                    data: $(this).serialize(),
                    success: function (res) {

                        res2 = res.split("<JSONSEPARATOR>");
                        
                        //envoi au line chart
                        var jsonLineChart = JSON.parse(res2[0]);
                        //console.log(jsonLineChart);
                        drawLineChart(res2[0], jsonLineChart.length); 
                        
                        //envoi au pie chart chart
                        var jsonPieChart = JSON.parse(res2[1]);
                        //console.log(jsonPieChart);
                        drawPieChart(res2[1]);

                        showCategory('footerSlideText2');
                        
                    }
                });
            });

        });

    </script>

    <!-- script pie chart google -->
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawAllCharts);

        function drawAllCharts() {

            drawPieChart('<%= ViewData["jsonTwtPieChart"] %>');
            drawLineChart('<%= ViewData["jsonTableLineChart"] %>', <%= ViewData["lengthLinechartTable"] %>);

        }

        function drawPieChart(jsonTwtPieChart) {

            console.log('DEBUT DRAW PIECHART');

            var chartDrawing = {

                init: function () {
                    var twtPieChart = JSON.parse(jsonTwtPieChart);
                    //transmission des données au pie chart
                    //negative percentage
                    var negativeDonut = twtPieChart.percentageNegativeTweet;
                    negative = parseFloat(negativeDonut);
                    //positive percentage
                    var positiveDonut = twtPieChart.percentagePositiveTweet;
                    positive = parseFloat(positiveDonut);
                    //neutral percentage
                    var neutralDonut = twtPieChart.percentageNeutralTweet;
                    neutral = parseFloat(neutralDonut);

                    var data = google.visualization.arrayToDataTable([
                        ['Opinions', 'Pourcentage'],
                        ['Positif', positive],
                        ['Negatif', negative],
                        ['Neutre', neutral]
                    ]);

                    var options = {
                        title: 'Opinions',
                        pieHole: 0.4,
                        'width': 500,
                        'height': 250
                    };

                    var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
                    chart.draw(data, options);
                }
            };
            
            //setTimeout(function () {
                chartDrawing.init();
            //}, 600);
            
        }
    </script>

    <!-- line chart google -->
     <script type="text/javascript">


         function drawLineChart(tableLineChartJSON, lengthTable) {

            //console.log('DEBUT LINECHART');

            //json deserialize            
            var tableLineChart = JSON.parse( tableLineChartJSON );

            //remise en forme du tableau          
            var table = new Array();
            table[0] = new Array();
            table[0][0] = "Date";
            table[0][1] = 'Positif';
            table[0][2] = 'Negatif';
            table[0][3] = 'Neutre'
                   
            for(var cpt = 0; cpt < lengthTable; cpt++)
            {
                table[cpt+1]= new Array();

                var dateString = tableLineChart[cpt].TweetCountDate_date.substr(6);
                var currentTime = new Date(parseInt(dateString ));
                var month = currentTime.getMonth() + 1;
                var day = currentTime.getDate();
                var year = currentTime.getFullYear();
                var date = day + "/" + month + "/" + year;

                table[cpt+1][0] = date;
                table[cpt+1][1] = tableLineChart[cpt].count_positive;
                table[cpt+1][2] = tableLineChart[cpt].count_negative;
                table[cpt+1][3] = tableLineChart[cpt].count_neutral; 
            }

            //console.log(table);

            var data = google.visualization.arrayToDataTable(table);

            var options = {
                title: 'Evolution des opinions',
                'width':500,
                'height':250
            };

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));

             chart.draw(data, options);
         }
    </script>

</asp:Content>