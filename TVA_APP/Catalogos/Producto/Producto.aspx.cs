using BLL_TVA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVA_APP.Catalogos.Producto
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RecargarGV();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        public void RecargarGV()
        {
            ProductoGV.DataSource = Producto_BLL.GetListProducto();
            ProductoGV.DataBind();
        }

        protected void ProductoGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                try
                {
                    int id_url = int.Parse(Request.QueryString["Id"]);

                    int index = int.Parse(e.CommandArgument.ToString());
                    int grid_id = int.Parse(ProductoGV.DataKeys[index].Values["PRODUCTO_ID"].ToString());
                    Venta_BLL.AgregarVenta(DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy")), int.Parse(Request.QueryString["Id"]), "COMPLETO");

                    int index2 = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = ProductoGV.Rows[index2];

                    // Buscar el control TextBox en la fila seleccionada
                    TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

                    // Obtener el valor ingresado en el TextBox
                    int cantidad = int.Parse(txtCantidad.Text);

                    decimal precio = 1000;
                    //decimal precio = decimal.Parse( ProductoGV.DataKeys[index2].Values["COSTO_UNITARIO"].ToString());
                    Venta_BLL.AgregarDetalleVenta(grid_id, cantidad,0,(cantidad*precio));

                    
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            Response.Redirect("~/Catalogos/Cliente/CompraCliente.aspx");
        }
    }
}