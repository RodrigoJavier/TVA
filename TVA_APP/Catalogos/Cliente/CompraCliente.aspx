<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompraCliente.aspx.cs" Inherits="TVA_APP.Catalogos.Cliente.CompraCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h2>Lista de </h2>
            <asp:GridView ID="CompraClientesGV"
                runat="server"
                CssClass="table table-striped table-bordered table-condensd"
                AutoGenerateColumns="false"
                DataKeyNames="CLAVE"
                >
                
                <Columns>
                    
                    <asp:BoundField DataField="CLAVE" HeaderText="CLAVE" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="MAIL" HeaderText="MAIL" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="FECHA" HeaderText="FECHA" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" ItemStyle-Width="180px"/>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Accion" ShowHeader="true" Text="Editar" 
                        ControlStyle-CssClass="btn btn-primary btn-xs" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select1" HeaderText="Accion" ShowHeader="true" Text="Ver Historial" 
                        ControlStyle-CssClass="btn btn-dark btn-xs" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select2" HeaderText="Accion" ShowHeader="true" Text="Consulta" 
                        ControlStyle-CssClass="btn btn-warning btn-xs" />
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" 
                        ControlStyle-CssClass="btn btn-danger btn-xs"/>

                </Columns>

            </asp:GridView>
            
            <asp:Button ID="btnAgregarVenta" runat="server" Text="Agregar Venta" ControlStyle-CssClass="btn btn-dark btn-xs m-md-3" ItemStyle-Width="50px" OnClick="btnAgregarVenta_Click"/>

        </div>
    </div>
</asp:Content>