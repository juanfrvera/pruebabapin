using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
   [Serializable]
    public class OficinaCompose
    {
       private List<OficinaSafCompose> safs;
       private OficinaResult oficina;
       
       #region Properties
       public OficinaResult Oficina
        {
           get {
               if (oficina == null) oficina = new OficinaResult();
               return oficina; }
           set { oficina = value; }
        } 
       public List<OficinaSafCompose> Safs
        {
            get
            {
                if (safs == null) safs = new List<OficinaSafCompose>(); 
                return safs; }
            set { safs = value; }
        }
       #endregion

       public List<OficinaSafResult> ToSafResult()
       {
           return (from o in Safs select o.Saf).ToList();
       }

    }

   [Serializable]
   public class OficinaSafCompose
   {
       private OficinaSafResult saf;
       private List<OficinaSafProgramaResult> programas;

       #region Properties
       public OficinaSafResult Saf
       {
           get
           {
               if (saf == null) saf = new OficinaSafResult();
               return saf;
           }
           set { saf = value; }
       }
       public List<OficinaSafProgramaResult> Programas
       {
           get
           {
               if (programas == null) 
                   programas = new List<OficinaSafProgramaResult>();
               return programas;
           }
           set { programas = value; }
       }      
       #endregion
       
   }

   
}
