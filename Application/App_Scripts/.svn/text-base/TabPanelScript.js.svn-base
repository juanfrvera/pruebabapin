window.onbeforeunload= function(){ConfirmClose();}
window.onunload= function(){HandleOnClose();}
var myclose = false;
function ConfirmClose()
{
    if (event.clientY < 0)
	{
		event.returnValue = 'Si cierra el Navegador perderá sus cambios, ¿Desea hacerlo de todas formas?';
		setTimeout('myclose=false',100);
		myclose=true;
	}
}
function HandleOnClose()
{
	if (myclose==true){
	    alert("Window is closed");	
	}
}
