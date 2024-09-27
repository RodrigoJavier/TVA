<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TVA_APP.Catalogos.Producto.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h2>Lista de Productos</h2>
            <asp:GridView ID="ProductoGV"
                runat="server"
                CssClass="table table-striped table-bordered table-condensd"
                AutoGenerateColumns="false"
                DataKeyNames="PRODUCTO_ID"
                OnRowCommand="ProductoGV_RowCommand">

                <Columns>

                    <asp:BoundField DataField="PRODUCTO_ID" HeaderText="PRODUCTO_ID" ItemStyle-Width="180px" />
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" ItemStyle-Width="180px" />
                    <asp:BoundField DataField="COSTO_UNITARIO" HeaderText="COSTO_UNITARIO" ItemStyle-Width="180px" />
                    <asp:BoundField DataField="ESTATUS" HeaderText="ESTATUS" ItemStyle-Width="180px" />
                    <asp:TemplateField HeaderText="Cantidad" ShowHeader="True">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Accion" ShowHeader="true" Text="Agregar Carrito" ControlStyle-CssClass="btn btn-primary btn-xs" />

                </Columns>

            </asp:GridView>


        </div>
    </div>
</asp:Content>
