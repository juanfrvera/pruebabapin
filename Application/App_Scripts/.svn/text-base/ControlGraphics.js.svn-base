
function Graphic(objName,dataControl,charID)
{
this.ObjName     = objName;
this.DataControl = dataControl;
this.CharID      = charID;
this.Handler     = objName+'.GetData';
this.GetData     =function()
                 {
                    //debugger ;
                   var data = $('#' + this.DataControl).val();           
                   if(data == undefined || data == "")
                     return '{"title":{"text":""},"wmode" : "transparent"}';
                   return data;
                 }  
}
var ControlGraphics =
{Graphics           : new Array()
,AddGraphic         : function(graphic)
                    {
                        this.Graphics[this.Graphics.length]=graphic;   
                    }
,LoadChartFromFile  :function(graphic)
                    {
                        alert ("Entre en loadchartfromfile")
                        swfobject.embedSWF
                        (
                            "../Graphics/open-flash-chart.swf",
                            graphic.CharID,
                            $('#' + graphic.CharID).innerWidth(),
                            $('#' + graphic.CharID).innerHeight(),
                            "9.0.0",
                            "expressInstall.swf",
                            {"data-file": graphic.Handler
                            ,"loading": "Actualizando..."
                            ,"wmode" : "transparent"
                            }
                        );            
                        alert ("swfobject" + swfobject.toString() );
                    }
,LoadChartFromMethod:function(graphic)
                   {
                        swfobject.embedSWF
                        (
                            "../Graphics/open-flash-chart.swf",
                            graphic.CharID,
                            $('#' + graphic.CharID).innerWidth(),
                            $('#' + graphic.CharID).innerHeight(),
                            "9.0.0",
                            "expressInstall.swf",
                            {"get-data": graphic.Handler
                            ,"wmode" : "transparent"
                            }
                        );                    
                    }                    
,ShowGraphics       :function()
                    {   var i=0;
                        for(i=0;i<this.Graphics.length;i++)
                        {
                          this.LoadChartFromMethod(this.Graphics[i]);  
                        }                    
                    }
}