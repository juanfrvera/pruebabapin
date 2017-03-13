using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nc = Contract;

namespace UI.Web
{
    public partial class ConfigMensajesList : WebControlGrid<nc.MessageConfigurationResult, int>
    {
        public override GridView GridView { get { return this.Grid; } }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }

        protected override void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (Convert.ToInt32(e.Row.Cells[1].Text))
                {
                    case 1:
                        e.Row.Cells[1].Text = "Nuevo";
                        break;
                    case 2:
                        e.Row.Cells[1].Text = "Eliminación";
                        break;
                    case 3:
                        e.Row.Cells[1].Text = "Modificación";
                        break;

                    default:
                        e.Row.Cells[1].Text = "";
                        break;
                }

            }
        }
    }
}