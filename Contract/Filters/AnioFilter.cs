using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class AnioFilter : _AnioFilter
    {	
	 public String Anio_From {get;set;}
     public String Anio_To { get; set; }
    }

}
