<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectoGraficos.aspx.cs" Inherits="UI.Web.Graficos.ProyectoGraficos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Bapin - Reportes graficos</title>
    
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

        function drawVisualization2(dataValues, chartTitle, columnNames, categoryCaption) {
            //Matias 20141015 - Tarea 158
            /*
            if (dataValues.length < 1)
                return;

            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column'); //columnNames.split(',')[0]);
            data.addColumn('number', 'Value1'); //columnNames.split(',')[1]);

            for (var i = 0; i < dataValues.length; i++) {
                //data.addRow([dataValues[i].ColumnName, dataValues[i].Value1, dataValues[i].Value2, dataValues[i].Value3]);
                var row = new Array();
                row[0] = dataValues[i].ColumnName;
                row[1] = parseInt(dataValues[i].Value1);
                data.addRow(row);
            }

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".

            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico2'));
            
            //Matias - Zoom & Print test.
            function selectHandler() {
                
                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+2, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Localizaciones', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });*/
            //FinMatias 20141015 - Tarea 158
        }

        function drawVisualization4(dataValues, chartTitle, columnNames, categoryCaption) {
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico4'));
            
            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+4, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Finalidad & Función', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });
        }

        function drawVisualization5(dataValues, chartTitle, columnNames, categoryCaption) {
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico5'));
            
            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+5, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Proceso', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });
        }

        function drawVisualization6(dataValues, chartTitle, columnNames, categoryCaption) {
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico6'));
            
            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+6, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Modo Adjudicación', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });
        }

        function drawVisualization3(dataValues, chartTitle, columnNames, categoryCaption) {
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico3'));
            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+3, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Estado', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico1'));

            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+1, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.

            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Provincia', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });          
            
        }

        function drawVisualization7(dataValues, chartTitle, columnNames, categoryCaption) {
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico7'));
            
            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+7, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Plan', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });
        }

        function drawVisualization8(dataValues, chartTitle, columnNames, categoryCaption) {
            //Matias 20141015 - Tarea 158
            
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

            //Matias 20131007 - "Ver porcentajes en leyenda" ==> permite agregar y ordenar la leyenda con porcentajes
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
            //FinMatias - "Ver porcentajes en leyenda".
            
            var chart = new google.visualization.PieChart(document.getElementById('DivGrafico8'));
            
            //Matias - Zoom & Print test.
            function selectHandler() {

                var strWindowFeatures = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, width=820, height=630, top=10, left=185";
                windowZoom = window.open("ProyectoGraficosZoom.aspx?grafico="+8, "_blank", strWindowFeatures);
            }
            google.visualization.events.addListener(chart, 'select', selectHandler);
            //FinMatias - Zoom & Print test.
            
            chart.draw(view, { width: 430, height: 280, is3D: true, title: 'Fuente de Financiamiento', chartArea: { left: 0, top: 40, width: "100%", height: "70%" }, 
                hAxis: { title: 'Year', titleTextStyle: { color: 'red'} }
            });
            
            //FinMatias 20141015 - Tarea 158
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
            canvas.setAttribute('width', chartArea.offsetWidth);
            canvas.setAttribute('height', chartArea.offsetHeight);
            canvas.setAttribute('style', 'position: absolute; ' + 'top: ' + (-chartArea.offsetHeight * 2) + 'px;' + 'left: ' + (-chartArea.offsetWidth * 2) + 'px;');

            doc.body.appendChild(canvas);
            canvg(canvas, svg);
            //var imgData = canvas.toDataURL("image/png");
            var imgData = canvas.toDataURL('image/jpeg');
            canvas.parentNode.removeChild(canvas);
            return imgData;
        }

        function ExportarPDF() {
            /*chartCont -> 'DivGrafico', imgCont -> 'DivGraficoImagen'*/
            
            var originalContents = document.body.innerHTML;

            var filtrosProyectos = document.getElementById('txtFiltrosHidden').value;
            var cantProyectos = document.getElementById('txtCantidadProyectosHidden').value;

            var arrayGraficos = [];

            for (var i = 1; i < 9; i++) {
                //Matias 20141015 - Tarea 158 - Agregue el IF para evitar el error de intentar el grafico 2 (Localizaciones)
                if (i != 2) {
                    var chartContainer = document.getElementById('DivGrafico' + i);
                    var doc = chartContainer.ownerDocument;
                    arrayGraficos[i] = doc.createElement('img' + i);
                    arrayGraficos[i].src = getImgData(chartContainer);
                }
            }

            //Crea el PDF
            doc = new jsPDF('l', 'mm', 'a4');
            doc.setProperties({
                title: 'Bapin - Reportes Graficos',
                subject: 'Graficos',
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
            
            //Agrega las 4 imagenes (en la siguiente pagina agrega las 4 imagenes restantes.
            doc.addImage(arrayGraficos[1].src, 'JPEG', 30, 50);
            doc.addImage(arrayGraficos[8].src, 'JPEG', 160, 50); //Matias 20141015 - Tarea 158 - Antes: arrayGraficos[2]
            doc.addImage(arrayGraficos[3].src, 'JPEG', 30, 122);
            doc.addImage(arrayGraficos[4].src, 'JPEG', 160, 122);
            
            //Pie de pagina
            doc.setFont('courier');
            doc.setFontSize(8);
            doc.setTextColor(0, 0, 255);
            doc.text(20, 202, 'http://bapin.ec.gba.gov.ar');
            doc.setTextColor(0, 0, 0);
            doc.text(265, 202, 'Hoja 1');
            
            //Nueva pagina
            doc.addPage();

            doc.setFont("helvetica"); //courier, times, helvetica, 
            doc.setFontSize(14);
            doc.setTextColor(237, 131, 17);
            doc.text(112, 20, 'BAPIN - Reportes Graficos');
            doc.setFont("helvetica");
            doc.setFontSize(10);
            doc.setTextColor(0, 0, 0);
            doc.text(20, 28, cantProyectos);

            //Acomoda el filtro para que entre en todo el ancho de la pagina
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

            //Agrega las otras 4 imagenes que faltaban mostrar.
            doc.addImage(arrayGraficos[5].src, 'JPEG', 30, 50);
            doc.addImage(arrayGraficos[6].src, 'JPEG', 160, 50);
            doc.addImage(arrayGraficos[7].src, 'JPEG', 30, 122);
            //doc.addImage(arrayGraficos[8].src, 'JPEG', 160, 122); //Matias 20141015 - Tarea 158
            
            //Pie de pagina
            doc.setFont('courier');
            doc.setFontSize(8);
            doc.setTextColor(0, 0, 255);
            doc.text(20, 202, 'http://bapin.ec.gba.gov.ar');
            doc.setTextColor(0, 0, 0);
            doc.text(265, 202, 'Hoja 2');

            //Abre/guarda el PDF generado
            doc.save('Bapin - Graficos.pdf');

        }
         
    </script>
</head>
<body class="Landscape">

     <div class="headerExtendido">
          <div id="header"> 
          <table>
              <tr>
                  <td>
                      <!--<img src="../Images/logoMECON.png" width="174demas" height="52" alt="Logo Ministerio de Economía" title="Logo Ministerio de Economía" align="middle" /> -->
                      <span class="mainTitle">Sistema Nacional de Inversiones Públicas</span> 
                      <br />
                      <span class="mainTitleSubtitle">BAPIN</span>
                  </td>
                  <td style=" width:400px; text-align:right">
                      <span class="admin"></span>
                  </td>
              </tr></table>
          </div>            
    </div>

    <div class="navExtendida">
        <div id="nav"> </div>
    </div>

    <form id="form2" runat="server">
        
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
                    <td style ="width:110px" >&nbsp;&nbsp;&nbsp;<asp:Literal ID="txtFiltros" Text="Filtros" runat="server" ></asp:Literal></td>
                </tr>
                <tr>
                    <td style ="width:110px" >&nbsp;&nbsp;&nbsp;<asp:Literal ID="txtCantidadProyectos" Text="Cant. Proyectos" runat="server" ></asp:Literal></td>
                </tr>
        </table>
        <%-- German - 20130615 - Tarea 69 --%>
        <table style="margin-left:20px; margin-right:20px; margin-bottom:20px; margin-top:5px; width:98%; border-width: 1px;
            border-spacing: 2px; border-style: outset; border-color: gray; border-collapse: collapse; background-color: white;
            border-collapse: separate; ">
        <tr>
            <td>
                <div id="DivGrafico1"></div>
                <div id="DivGraficoImagen1"></div>                             
            </td>

            <td>
                <div id="DivGrafico8"></div>
                <div id="DivGraficoImagen8"></div>
            </td>

            <td>
                <div id="DivGrafico3"></div>
                <div id="DivGraficoImagen3"></div>
            </td>
        </tr>
        
        <tr>
            <td>
                <div id="DivGrafico4"></div>                       
                <div id="DivGraficoImagen4"></div>
            </td>

            <td>
                <div id="DivGrafico5"></div>
                <div id="DivGraficoImagen5"></div>
            </td>

            <td>
                <div id="DivGrafico6"></div>
                <div id="DivGraficoImagen6"></div>
            </td>
        </tr>

        <tr>
            <td>
                <div id="DivGrafico7"></div>
                <div id="DivGraficoImagen7"></div>                   
            </td>

            <td>
                <div id="DivGrafico2"></div>
                <div id="DivGraficoImagen2"></div>
            </td>

            <td>
                <div id="DivGrafico9"></div>
                <div id="DivGraficoImagen9"></div>
            </td>
        </tr>
        </table>
    
        </div>

    </form>

        <div align="center">
            <button onclick="printDiv('DivPrintArea');">Imprimir</button>
            <button onclick="ExportarPDF();">Exportar a PDF</button>
            <button onclick="window.close(); return false;">Cerrar</button>            
	    </div>
        
        
        <br />
    	

    

</body>
</html>
