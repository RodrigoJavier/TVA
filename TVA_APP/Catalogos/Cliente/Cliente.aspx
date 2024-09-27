<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="TVA_APP.Catalogos.Cliente.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h2>Lista de Pacientes</h2>
            <asp:GridView ID="ClientesGV"
                runat="server"
                CssClass="table table-striped table-bordered table-condensd"
                AutoGenerateColumns="false"
                DataKeyNames="CLIENTE_ID"
                OnRowCommand="ClientesGV_RowCommand"
                >
                
                <Columns>
                    
                    <asp:BoundField DataField="CLIENTE_ID" HeaderText="CLIENTE_ID" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="CLAVE" HeaderText="CLAVE" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="MAIL" HeaderText="MAIL" ItemStyle-Width="180px"/>
                    <asp:BoundField DataField="ESTATUS" HeaderText="ESTATUS" ItemStyle-Width="180px"/>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Accion" ShowHeader="true" Text="Agregar Compra" 
                        ControlStyle-CssClass="btn btn-primary btn-xs" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select2" HeaderText="Accion" ShowHeader="true" Text="Consultar Compras" 
                        ControlStyle-CssClass="btn btn-warning btn-xs" />

                </Columns>

            </asp:GridView>
            

        </div>
    </div>
</asp:Content>