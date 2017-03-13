function autocompleteOnPopulating(hiddenId, textId, hiddenIsPostBackId)
{
    document.getElementById(hiddenId).value='0';  
    document.getElementById(hiddenIsPostBackId).value='0';
    document.getElementById(textId).setAttribute('style','background-color:#ffffff;');
}
function autocompleteOnSelectItem(ev, hiddenId, textId, acBehaviorId, hiddenIsPostBackId, doAutoPosback)
{   
    var index=$find(acBehaviorId)._selectIndex;                                        
    var value=$find(acBehaviorId).get_completionList().childNodes[index]._value;
    var text=$find(acBehaviorId).get_completionList().childNodes[index].innerHTML;
    $find(acBehaviorId).get_element().value=text;
    document.getElementById(hiddenId).value=value; 
    document.getElementById(textId).setAttribute('style','background-color:#f0f0f0;');
    document.getElementById(hiddenIsPostBackId).value=1; 
    
    if(doAutoPosback == 'True')
    {
        __doPostBack(hiddenIsPostBackId,'1');    
    }
}
function autocompleteOnGetList(hiddenId, acBehaviorId, hiddenIsPostBackId)
{   
    document.getElementById(hiddenId).value="0";  
    document.getElementById(hiddenIsPostBackId).value='0';
    var comletionList=$find(acBehaviorId).get_completionList();
    for(i=0;i<comletionList.childNodes.length;i++)
    {
        var _value=comletionList.childNodes[i]._value;
        comletionList.childNodes[i]._value=_value.substring(_value.lastIndexOf('|')+1);
        _value=_value.substring(0,_value.lastIndexOf('|'));
        comletionList.childNodes[i].innerHTML=_value.replace('|',' ');
    }
}
function autocompleteOnLostFocus(hiddenId, textId, hiddenIsPostBackId)
{
    if(document.getElementById(hiddenId).value == 0)
    {
        document.getElementById(textId).value = '';
        document.getElementById(hiddenIsPostBackId).value='0';
        document.getElementById(textId).setAttribute('style','background-color:#ffffff;');
    }
}
function autocompleteDoFocus(textId)
{
    var v = document.getElementById(textId); 
    v.focus();
}


function onLostFocusComplete(textId, separator, maxLength)
{
    var number = document.getElementById(textId).value;
    if(number != '' && IsNumeric(number))
    {
        while(number.length < maxLength) 
        {
            number = separator + number; 
        }
        document.getElementById(textId).value = number;
    }
}

function onFocusDelete(textId, separator, maxLength)
{
    document.getElementById(textId).value = document.getElementById(textId).value.replace(/^[0]+/g,"");
    document.getElementById(textId).select();
}

function IsNumeric(sText)
{
   var ValidChars = "0123456789";
   var IsNumber=true;
   var Char;
 
   for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {
             IsNumber = false;
         }
      }
   return IsNumber;
   
   }
