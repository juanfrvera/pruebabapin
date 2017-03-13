using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{    
	public partial class ProyectoComentarioTecnicoList : WebControlGrid<nc.ProyectoComentarioTecnicoResult,int>    
    {
		public override GridView GridView { get { return this.Grid;} }
        protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}

        protected void GridComentarioTecnico_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text == "True")
                    e.Row.Cells[8].Text = "Si";
                else
                    e.Row.Cells[8].Text = "No";

            }
        }
    }
}
