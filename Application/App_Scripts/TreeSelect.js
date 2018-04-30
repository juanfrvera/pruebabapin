
//helper
function $(id){ return document.getElementById(id);}
//TreeData
TreeData=
{
 //data a personalizar
 Handler            : undefined
,RootText           : undefined
,divTree            : undefined
,divPanel           : undefined
,txtSelect          : undefined
,hdSelect           : undefined
,hdFilter           : undefined
,lblPath            : undefined    
//properties
,Panel              : undefined
,Tree               : undefined
,NodeSelected       : undefined
,ChangeValueHandler : undefined
,SelectOption       : undefined
,ShowOption         : undefined
//metodos
,BuildTree      :function(){ TreeSelect.init();} 
,ShowTree       : function(x,y) {
                    try
                    {
                        TreeData.BuildTree();
                        TreeData.Panel = new YAHOO.widget.Panel(TreeData.divPanel, { //xy:[x,y]
                                                                                    fixedcenter: true
                                                                                    ,width:"400px"
                                                                                    ,autoscroll: true
                                                                                    ,visible: false 
                                                                                    ,close :false
                                                                                    } );
                	    $(TreeData.divPanel).style.height = "400px";                	    
                	    TreeData.Panel.render();
                        TreeData.Panel.show();
                    }catch(e){alert(e.message);} 
                } 
,SelectedNode   : function(node){
    try {
        debugger;
                        if( node.Seleccionable == true || TreeData.SelectOption == 1 ){
                            TreeData.NodeSelected = node;
                            $(TreeData.lblPath).innerHTML =  '['+TreeData.NodeSelected.BreadcrumbCodigo+'] '+TreeData.NodeSelected.DescripcionInvertida;  
                        }
                         else
                         {
                            alert ("No se puede Seleccionar");
                         }           
                    }catch(e){alert(e.message);}   
                }
,Open           : function (){
    try {
                TreeData.NodeSelected = null;
                        var strJson = $(TreeData.hdSelect).value;
                        if (strJson != "") {
                            var node = YAHOO.lang.JSON.parse(strJson); 
                            TreeData.SelectedNode(node);
                        }  
                        TreeData.ShowTree(50,50);
                    }catch(e){alert(e.message);} 
                }
,Select         : function Select(){
    try {
        debugger;
                          if(TreeData.NodeSelected != null && TreeData.NodeSelected != undefined)
                          {
                              if(TreeData.NodeSelected.Seleccionable == true || TreeData.SelectOption == 1 ){ 
                                $(TreeData.txtSelect).value = '['+TreeData.NodeSelected.BreadcrumbCodigo+'] '+TreeData.NodeSelected.DescripcionInvertida; 
                                $(TreeData.hdSelect).value =  YAHOO.lang.JSON.stringify(TreeData.NodeSelected);
                              }                     
                                TreeData.Panel.hide();
                                $(TreeData.txtSelect).focus();
                                TreeData.OnChangeValue();
                         }   
                         else
                         {
                            alert ("No se puede Seleccionar.");
                         }                      
                     }catch(e){alert(e.message);}                      
                }
,Close          :function (){
                        try{      
                            if(TreeData.Tree)TreeData.Tree.destroy();
                            if(TreeData.Panel)TreeData.Panel.hide();
                        }catch(e){alert(e.message);} 
                } 
,Clear          :function (){
                        try{
                            $(TreeData.hdSelect).value = "";
                            $(TreeData.txtSelect).value = "";
                            TreeData.NodeSelected = null;
                            $(TreeData.lblPath).innerHTML = "";
                            $(TreeData.txtSelect).focus();
                            TreeData.Close();
                            TreeData.OnChangeValue();
                        }catch(e){alert(e.message);} 
                }
,OnChangeValue  :function(){
                     try{
                         if(TreeData.ChangeValueHandler != undefined && TreeData.ChangeValueHandler !=null)
                         TreeData.ChangeValueHandler();
                     }catch(e){alert(e.message);} 
                }    
}
//YAHOO.util.Event.onDOMReady(init);
//-------------------------------------------------------------------------------------------------------------
TreeSelect = function() {
var tree, currentIconMode;
//---------------------------------------------------------------------- 
function changeIconMode() {
    try{
        var newVal = parseInt(this.value);
        if (newVal != currentIconMode) {
            currentIconMode = newVal;
        }
        buildTree();
    }catch(e){alert(e.message);} 
}
//----------------------------------------------------------------------     
function loadNodeData(node, fnLoadComplete)  {
    try
    {
        var id =node.data.Id;
        var sUrl = TreeData.Handler+"?id=" + id+((TreeData.hdFilter != undefined)?"&filter="+$(TreeData.hdFilter).value:"")+"&t"+(new Date().getTime());
        var callback = {
            success: function(oResponse) {
                        var oResults = eval("(" + oResponse.responseText + ")");                        
                        for (var i=0, j=oResults.length; i<j; i++) {
                            var tempNode = new YAHOO.widget.TextNode('['+oResults[i].Codigo+'] '+oResults[i].Text, node, false);
                            tempNode.data = oResults[i];                        
                        }
                        oResponse.argument.fnLoadComplete();
                     }
            ,failure:function(oResponse) {oResponse.argument.fnLoadComplete(); }                
            ,argument: {"node": node,"fnLoadComplete": fnLoadComplete}
            ,timeout: 7000
        };
        YAHOO.util.Connect.asyncRequest('GET', sUrl, callback);
    }catch(e){alert(e.message);} 
}
//---------------------------------------------------------------------- 
function buildTree(){
    try{
       TreeData.Tree = new YAHOO.widget.TreeView(TreeData.divTree);           
       TreeData.Tree.setDynamicLoad(loadNodeData, currentIconMode);           
       var tempNode = new YAHOO.widget.TextNode(TreeData.RootText, TreeData.Tree.getRoot(), true);   
       TreeData.Tree.subscribe("labelClick", function(node){TreeData.SelectedNode(node.data);});   
       TreeData.Tree.draw();
   }catch(e){alert(e.message);} 
}
//----------------------------------------------------------------------  
return {
        init: function() {
            YAHOO.util.Event.on(["mode0", "mode1"], "click", changeIconMode);
            var el = document.getElementById("mode1");
            if (el && el.checked) {
                currentIconMode = parseInt(el.value);
            } else {
                currentIconMode = 1;
            } 
            buildTree();
        } 
    }
} ();
//once the DOM has loaded, we can go ahead and set up our tree:
//YAHOO.util.Event.onDOMReady(Ingematica.TreeSelect.init,Ingematica.TreeSelect,true)
//-----------------------------------------------------------------------------------------------
function stringToRegExp(pattern, flags){
    return new RegExp(
        pattern.replace(/[\[\]\\{}()+*?.$^|]/g, function(m){return '\\'+m;}),
        flags);
}
//-----------------------------------------------------------------------------------------------
//------------------------------ Autocomplete ---------------------------------------------------
function AutocompleteDataSource(handler,filter,selectOption,showOption)
{
this.DataSource     = undefined;
this.Handler        = handler;
this.Create         = function(){
                        this.DataSource = new YAHOO.widget.DS_XHR(this.Handler);    
                        this.DataSource.scriptQueryParam = "query";
                        this.DataSource.scriptQueryAppend = 'filter='+filter+'&SelectOption='+selectOption+'&ShowOption='+showOption+'&t'+(new Date().getTime());
                        this.DataSource.responseType = YAHOO.widget.DS_XHR.TYPE_JSON;
                        this.DataSource.responseSchema = { resultsList: "Nodes", fields: [{ key: "Id" }, { key: "ParentId" }, { key: "Level" }, { key: "Orden" }, { key: "Text" }, { key: "Codigo" }, { key: "BreadcrumbId" }, { key: "BreadcrumbOrden" }, { key: "BreadcrumbCodigo" }, { key: "Descripcion" }, { key: "DescripcionInvertida" }, { key: "Seleccionable" }] };
                     }
}
function AutocompleteSelect(autocompleteHandler,filter,txtSelect,hdSelect,AutoCompleteContainer,onChangeValue,selectOption,showOption){ 
    
    var ds = new AutocompleteDataSource(autocompleteHandler,filter,selectOption,showOption);
    ds.Create();
//    var dataSource = new YAHOO.widget.DS_XHR(autocompleteHandler);    
//    dataSource.scriptQueryParam = "query";
//    dataSource.scriptQueryAppend = 'filter='+filter;
//    dataSource.responseType = YAHOO.widget.DS_XHR.TYPE_JSON;
//    dataSource.responseSchema = {resultsList:"Nodes",fields:[{key:"Id"},{key:"ParentId"},{key:"Level"},{key:"Orden"},{key:"Text"},{key:"BreadcrumbId"},{key:"BreadcrumbOrden"},{key:"Descripcion"},{key:"DescripcionInvertida"}]};    
    
    // Instantiate the AutoComplete
    var autoComplete = new YAHOO.widget.AutoComplete(txtSelect, AutoCompleteContainer, ds.DataSource);
    autoComplete.minQueryLength = 4;
    autoComplete.queryDelay = 0.3;
    autoComplete.resultTypeList = false;
    autoComplete.maxResultsDisplayed=20;   
    autoComplete.formatResult = function(oResultData, sQuery, sResultMatch) {        
        try
        {
            var pattern1=stringToRegExp(sQuery, 'gi');        
            var descripcion = oResultData.DescripcionInvertida.replace(pattern1,"<b>"+sQuery+"</b>");
            var codigo = oResultData.BreadcrumbCodigo.replace(pattern1,"<b>"+sQuery+"</b>");
            return  '<div title="['+oResultData.BreadcrumbCodigo+']'+oResultData.DescripcionInvertida+'" >['+codigo+'] '+descripcion+'</div>';
        }
	    catch(e){alert(e.message);}
    };    
    var itemSelectHandler = function(sType, aArgs) {
        try
        {	 
	        var o = aArgs[2];
            $(txtSelect).value = '['+o.BreadcrumbCodigo+'] '+o.DescripcionInvertida;
            var strJson = '{"Id":' + o.Id + ',"ParentId":' + o.ParentId + ',"Level":' + o.Level + ',"Orden":' + o.Orden + ',"Text":"' + o.Text + '","Codigo":"' + o.Codigo + '","BreadcrumbId":"' + o.BreadcrumbId + '","BreadcrumbOrden":"' + o.BreadcrumbOrden + '","BreadcrumbCodigo":"' + o.BreadcrumbCodigo + '","Descripcion":"' + o.Descripcion + '","DescripcionInvertida":"' + o.DescripcionInvertida + '","Seleccionable":"' + o.Seleccionable + '"}';
	        $(hdSelect).value= strJson;
	        onChangeValue();
	    }
	    catch(e){alert(e.message);}
    };
    autoComplete.itemSelectEvent.subscribe(itemSelectHandler)    
    return {
        oDS: ds.DataSource,
        oAC: autoComplete
    };
}
//**************************************************************************************************************************
//**************************************** AutoComplete 2
function AutocompleteSimpleDataSource(handler,filter,selectOption,showOption)
{
this.DataSource     = undefined;
this.Handler        = handler;
this.Create         = function(){                       
                        this.DataSource = new YAHOO.widget.DS_XHR(this.Handler);    
                        this.DataSource.scriptQueryParam = "query";
                        this.DataSource.scriptQueryAppend = 'filter='+filter+'&SelectOption='+selectOption+'&ShowOption='+showOption+'&t'+(new Date().getTime());
                        this.DataSource.responseType = YAHOO.widget.DS_XHR.TYPE_JSON;
                        this.DataSource.responseSchema = {resultsList:"List",fields:[{key:"ID"},{key:"Text"}]};    
                    }
}
function AutocompleteSimple(autocompleteHandler,filter,txtSelect,hdSelect,AutoCompleteContainer,onChangeValue,selectOption,showOption){ 
    
    var ds = new AutocompleteSimpleDataSource(autocompleteHandler,filter,selectOption,showOption);
    ds.Create();  
    // Instantiate the AutoComplete
    var autoComplete = new YAHOO.widget.AutoComplete(txtSelect, AutoCompleteContainer, ds.DataSource);
    autoComplete.minQueryLength     = 4;
    autoComplete.queryDelay         = 0.3;
    autoComplete.resultTypeList     = false;
    autoComplete.maxResultsDisplayed= 20;   
    autoComplete.formatResult       = function(oResultData, sQuery, sResultMatch) {        
                                        try
                                        {
                                            if(oResultData.Text != null && oResultData.Text != undefined)
                                            {
                                                var pattern1=stringToRegExp(sQuery, 'gi');   
                                                var descripcion = oResultData.Text.replace(pattern1,"<b>"+sQuery+"</b>");
                                                return  '<div title="['+oResultData.Text+'" >'+descripcion+'</div>';
                                            }
                                        }
	                                    catch(e){alert(e.message);}
                                    };    
    var itemSelectHandler           = function(sType, aArgs) {
                                        try
                                        {	 
	                                        var o = aArgs[2];
                                            $(txtSelect).value = o.Text;
	                                        var strJson = '{"ID":'+o.ID+',"Text":"'+o.Text+'"}';
	                                        $(hdSelect).value= strJson;
	                                        onChangeValue();
	                                    }
	                                    catch(e){alert(e.message);}
                                    };
    autoComplete.itemSelectEvent.subscribe(itemSelectHandler)    
    return {
        oDS: ds.DataSource,
        oAC: autoComplete
    };
}