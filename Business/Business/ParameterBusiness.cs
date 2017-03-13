using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ParameterBusiness : _ParameterBusiness 
    {   
	   #region Singleton
	   private static volatile ParameterBusiness current;
	   private static object syncRoot = new Object();

	   //private ParameterBusiness() {}
	   public static ParameterBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ParameterBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Add(Parameter entity, IContextUser contextUser)
       {
           base.Add(entity, contextUser);
           Refresh();
       }
       public override void Validate(Parameter entity, string actionName, IContextUser contextUser, System.Collections.Hashtable args)
       {
           base.Validate(entity, actionName, contextUser, args);
           Refresh();
       }
       public override void Delete(int id, IContextUser contextUser)
       {
           base.Delete(id, contextUser);
           Refresh();
       }
       public override void Delete(Parameter entity, IContextUser contextUser)
       {
           base.Delete(entity, contextUser);
           Refresh();
       }
       void Refresh()
       {
           if (SolutionContext.Current.ParameterManager != null)
               SolutionContext.Current.ParameterManager.Refresh();
       }

       public override void Update(Parameter entity, IContextUser contextUser)
       {
           //Matias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
           //Codigo temporal con el objetivo de actualizar TODAS las auditorias ==> comprimir el DataPostOperation.           
           #region ComprimirAuditoriasHistoricas
           //bool esAdministrador = (contextUser.Perfiles.Where(perf => perf.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;
           //if (esAdministrador && entity.Code.Equals("ACTIVAR_AUDITORIA") && entity.StringValue.Equals("S"))
           //{
           //    int i = 0;

           //    List<AuditOperationResult> auditOperationList = AuditOperationBusiness.Current.GetResult(new AuditOperationFilter { StatusName = "DPostO_NO_Comprimido" });
               
           //    foreach (AuditOperationResult aor in auditOperationList)
           //    {
           //        AuditOperation ao = aor.ToEntity();
           //        if (!ao.StatusName.Equals("DPostO_Comprimido"))
           //        {
           //            //Auditoria no compimida...
           //            //ao.DataPreOperation = null;
           //            ao.DataPostOperation = CompressString(ao.DataPostOperation);
           //            ao.EndDate = DateTime.Now;
           //            ao.StatusName = "DPostO_Comprimido";
           //            AuditOperationBusiness.Current.Update(ao, contextUser);
                       
           //            i++;                       
           //            if (i == 3000)
           //                break;
           //        }                   
           //    }
           //}
           #endregion
           //FinMatias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
           
           base.Update(entity, contextUser);

           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;
       }

        //Matias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
        #region ComprimirAuditoriasHistoricas
        //private string CompressString(string texto)
       //{
       //    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(texto);
       //    var memoryStream = new System.IO.MemoryStream();
       //    using (var gZipStream = new System.IO.Compression.GZipStream(memoryStream, System.IO.Compression.CompressionMode.Compress, true))
       //    {
       //        gZipStream.Write(buffer, 0, buffer.Length);
       //    }

       //    memoryStream.Position = 0;

       //    var compressedData = new byte[memoryStream.Length];
       //    memoryStream.Read(compressedData, 0, compressedData.Length);

       //    var gZipBuffer = new byte[compressedData.Length + 4];
       //    Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
       //    Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);

       //    return Convert.ToBase64String(gZipBuffer);
        //}
        #endregion
        //FinMatias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria

       #endregion


    }
}
