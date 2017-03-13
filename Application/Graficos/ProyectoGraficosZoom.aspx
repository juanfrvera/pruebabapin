<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectoGraficosZoom.aspx.cs" Inherits="UI.Web.Graficos.ProyectoGraficosZoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bapin - Reportes graficos - Zoom</title>

    <script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="http://canvg.googlecode.com/svn/trunk/rgbcolor.js"></script> 
    <script type="text/javascript" src="http://canvg.googlecode.com/svn/trunk/canvg.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/jspdf.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/jspdf.plugin.addimage.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/jspdf.plugin.split_text_to_size.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/FileSaver.js/FileSaver.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/Blob.js/Blob.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/Blob.js/BlobBuilder.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/Deflate/deflate.js"></script>
    <script type="text/javascript" src="../App_Scripts/jspdf2/Deflate/adler32cs.js"></script>

    <script type="text/javascript">
        //google.load('visualization', '1.1', { packages: ['controls'] }); Instancia para DASHBOARD
        google.load("visualization", "1", { packages: ["corechart"] });
    </script>

    <style type="text/css" media="print">

    .Landscape
    {
        width: 100%;
        height: 100%;
        margin: 0% 0% 0% 0%;
        filter: progid:DXImageTransform.Microsoft.BasicImage(Rotation=3);
    }

    </style>
    
    <script type="text/javascript">

        /*
        window.onload = function () {
            var btnClose = document.getElementById("btCerrar");
            btnClose.addEventListener("click", function () { window.close(); });
        }
        */

        function drawVisualizationANTERIOR_ok(dataValues, chartTitle, columnNames, categoryCaption) {
            if (dataValues.length < 1)
                return;

            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column'); //columnNames.split(',')[0]);
            data.addColumn('number', 'Value1'); //columnNames.split(',')[1]);

            for (var i = 0; i < dataValues.length; i++) {
                var row = new Array();
                row[0] = dataValues[i].ColumnName;
                row[1] = parseInt(dataValues[i].Value1);
                data.addRow(row);
            }

            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico'));

            chart.draw(data, { width: 780, height: 430, is3D: true, title: chartTitle, chartArea: { left: 0, top: 20, width: "100%", height: "100%" },
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });

        }

        function drawVisualization(dataValues, chartTitle, columnNames, categoryCaption) {
            if (dataValues.length < 1)
                return;

            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column'); //columnNames.split(',')[0]);
            data.addColumn('number', 'Value1'); //columnNames.split(',')[1]);

            for (var i = 0; i < dataValues.length; i++) {
                var row = new Array();
                row[0] = dataValues[i].ColumnName;
                row[1] = parseInt(dataValues[i].Value1);
                data.addRow(row);
            }

            data.sort([{ column: 1, desc: true }, { column: 0}]);
            
            var total = 0;

            for (var i = 0; i < data.getNumberOfRows(); i++) {                
                // increment the total
                total += data.getValue(i, 1);
                // format the output to an empty string
                data.setFormattedValue(i, 1, '');
            }            

            var view = new google.visualization.DataView(data);
            view.setColumns([{
                type: 'string',
                label: 'Topping',
                calc: function (dt, row) {
                    var label = dt.getValue(row, 0);
                    var value = dt.getValue(row, 1);
                    var percent = Math.ceil(1000 * value / total) / 10;
                    return label + ': ' + value + ' (' + percent + '%)';                    
                }
            }, 1]);

            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico'));
                        
            //Matias 20141029 - Tarea 161 - Agregue el "sliceVisibilityThreshold: 1/2000, " para incluir registros >= 0.2%
	    chart.draw(view, { sliceVisibilityThreshold: 1/2000, width: 780, height: 430, is3D: true, title: chartTitle, chartArea: { left: 0, top: 20, width: "100%", height: "100%" },
                hAxis: { title: 'Year', titleTextStyle: { color: 'red' } }
            });

        }

        function printDiv(divArea) {
            var printContents = document.getElementById(divArea).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }        

        function getImgData(chartContainer) {
            var chartArea = chartContainer.getElementsByTagName('svg')[0].parentNode;
            var svg = chartArea.innerHTML;
            var doc = chartContainer.ownerDocument;
            
            var canvas = doc.createElement('canvas');
            canvas.setAttribute('width', chartArea.offsetWidth );
            canvas.setAttribute('height', chartArea.offsetHeight );
            canvas.setAttribute('style', 'position: absolute; ' + 'top: ' + (-chartArea.offsetHeight * 2) + 'px;' + 'left: ' + (-chartArea.offsetWidth * 2) + 'px;');

            doc.body.appendChild(canvas);
            canvg(canvas, svg);
            //var imgData = canvas.toDataURL("image/png");
            var imgData = canvas.toDataURL('image/jpeg');
            canvas.parentNode.removeChild(canvas);
            return imgData;
        }

        function ExportarPDF(chartCont, imgCont) {
            var originalContents = document.body.innerHTML;
            var chartContainer = document.getElementById(chartCont);
            var imgContainer = document.getElementById(imgCont);

            var filtrosProyectos = document.getElementById('txtFiltrosHidden').value;
            var cantProyectos = document.getElementById('txtCantidadProyectosHidden').value;
            
            var doc = chartContainer.ownerDocument;
            var img = doc.createElement('img');
            img.src = getImgData(chartContainer);

            //Crea el PDF
            doc = new jsPDF('l', 'mm','a4');
            doc.setProperties({
                title: 'Bapin - Reportes Graficos',
                subject: 'Grafico con Zoom',
                author: 'Direccion de Inversion Publica',
                keywords: 'bapin, graficos, mecon, buenos aires, ministerio, economia',
                creator: 'DIP'
            });

            doc.setFont("helvetica"); //courier, times, helvetica, 
            //doc.setFontType("bold");
            doc.setFontSize(14);
            doc.setTextColor(237, 131, 17);
            doc.text(112, 20, 'BAPIN - Reportes Graficos');

            doc.setFont("helvetica");
            //doc.setFontType("italic"); //bolditalic
            doc.setFontSize(10);
            doc.setTextColor(0, 0, 0);
            doc.text(20, 28, cantProyectos);
            //doc.setLineWidth(0.2);
            //doc.line(20, 29, 46, 29);

            //Acomoda el filtro para que entre en todo el ancho de la pagina
            filtrosProyectos = 'Filtros aplicados: [' + filtrosProyectos + ']';

            var sizes = [10]
            , fonts = [['Helvetica', '']]
            , font, size, lines
            , verticalOffset = 34

            for (var i in fonts) {
                if (fonts.hasOwnProperty(i)) {
                    font = fonts[i]
                    size = sizes[i]
                    lines = doc.setFont(font[0], font[1])
					            .setFontSize(size)
					            .splitTextToSize(filtrosProyectos, 550)
                    doc.text(20, verticalOffset + size / 72, lines)
                    verticalOffset += (lines.length + 0.6) * size / 72
                }
            }
            //doc.setLineWidth(0.1);
            //doc.line(20, 35, 46, 35);
            
            doc.addImage(img.src, 'JPEG', 50, 55);

            //Pie de pagina
            doc.setFont('courier');
            doc.setFontSize(8);
            doc.setTextColor(0, 0, 255);
            doc.text(20, 202, 'http://bapin.ec.gba.gov.ar');
            doc.setTextColor(0, 0, 0);
            doc.text(265, 202, 'Hoja 1');
            
             //doc.addPage();
            //doc.text(20, 20, 'Esta es la segunda pagina');
            //doc.text(20, 30, 'client-side Javascript...PDF.');

            //Abre/guarda el PDF generado
            doc.save('Bapin - Grafico Zoom.pdf');
            
        }

    </script>

</head>
<body class="Landscape">

    <form id="form1" runat="server">
        
        <asp:HiddenField id="txtFiltrosHidden" value="No hay filtros" runat="server" />
        <asp:HiddenField id="txtCantidadProyectosHidden" value="0" runat="server" />

        <div id="DivPrintArea">

        <br />
        <span class="SitemapNode">&nbsp; Reportes gráficos </span>

        <%-- German - 20130615 - Tarea 69 --%>
        <br/>
        <span>&nbsp; &nbsp; Filtros aplicados: </span>
        <table width="100%"  cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td style ="width:110px" >&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="txtFiltros" Text="Filtros" runat="server" ></asp:Literal>                        
                    </td>
                </tr>
                <tr>
                    <td style ="width:110px" >&nbsp;&nbsp;&nbsp;
                        <asp:Literal ID="txtCantidadProyectos" Text="Cant. Proyectos" runat="server" ></asp:Literal>                        
                    </td>
                </tr>
        </table>
        <%-- German - 20130615 - Tarea 69 --%>
        <table style="margin-left:20px; margin-right:20px; margin-bottom:20px; margin-top:5px; border-width: 1px;
            border-spacing: 2px; border-style: outset; border-color: gray; border-collapse: collapse; background-color: white;
            border-collapse: separate; ">
            <tr>
                <td>
                    <div id="DivGrafico"></div>                
                    <div id="DivGraficoImagen"></div>                
                </td>
            </tr>
        </table>

        </div>
    </form>

        <div align="center">
            <button onclick="printDiv('DivPrintArea');">Imprimir</button>
            <button onclick="ExportarPDF('DivGrafico', 'DivGraficoImagen');">Exportar a PDF</button>
            <button onclick="window.close(); return false;">Cerrar</button>            
	    </div>
        
        <br />
    	
    <%-- </form> --%>

</body>
</html>
