using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaundryMangement.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public WebForm1()
        {
            this.Setup_EventHandlers();
        }

        void Setup_EventHandlers()
        { this.Load += Page_Load; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["IsAjax"] == "1")
            {
                String Cmd = Request.Params["Cmd"];
                String Output_Data = "";

                switch (Cmd)
                {
                    case "Load":
                        Table Tb =
                            new Table()
                            {
                                ClientIDMode = System.Web.UI.ClientIDMode.Static,
                                ID = "Tb",
                                BorderStyle = BorderStyle.Solid,
                                BorderWidth = new Unit(2, UnitType.Point),
                                BorderColor = Color.Black,
                                GridLines = GridLines.Both
                            };


                        for (Int32 Ct = 0; Ct <= 100; Ct++)
                        {
                            TableRow Tb_Row = new TableRow();
                            TableCell Tb_Cell = new TableCell();
                            Tb_Cell.Text = Ct.ToString();
                            Tb_Row.Cells.Add(Tb_Cell);
                            Tb.Rows.Add(Tb_Row);
                        }

                        StringBuilder RenderedHtml = new StringBuilder();
                        HtmlTextWriter Writer = new HtmlTextWriter(new StringWriter(RenderedHtml));
                        Tb.RenderControl(Writer);

                        Output_Data = RenderedHtml.ToString();

                        break;
                }

                this.Response.Clear();
                this.Response.ContentType = "text/plain";
                this.Response.Write(Output_Data);
                this.Response.End();                
            }
        }
    }
}