UIHelper = {
    Validate: function(condition, errorMessage) {
        if (!condition)
            throw errorMessage;
    },
    CallTryMethod: function(method) {
        try {
            method();
            return true;
        }
        catch (e) {
            alert("An exception occurred in the script. Error name: " + e.name + ". Error message: " + e.message);
            return false;
        }
    },
    JsonToString: function(value) {
        var str = value + '';
        charToRemove = '"';
        regExp = new RegExp("[" + charToRemove + "]", "g");
        str = str.replace(regExp, "#");
        return str;
    },
    StrinToJson: function(value) {
        //debugger;
        var str = value + '';
        charToRemove = "#";
        regExp = new RegExp("[" + charToRemove + "]", "g");
        str = str.replace(regExp, '"');
        return str;
    }
    ,SetValueSelect:function(control,value){
       //debugger;
       var count = control.length;
       for (i = 0; i < count; i++) {
          if (control[i].value == value) {
             control[i].selected = true;
          }   
       }

    }
}
