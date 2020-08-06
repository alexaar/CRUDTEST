<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDTEST._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Panel runat="server" ID="pnlDatosActor">
            <asp:GridView ID="gvdActor" runat="server" AutoGenerateColumns="false" DataKeyNames="ID_ACTOR" OnRowDeleting="gvdActor_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID_ACTOR" HeaderText="ACTOR" />
                      <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                    <asp:BoundField DataField="APELLIDOS" HeaderText="APELLIDOS" />
                    <asp:CommandField ShowDeleteButton="true" EditText="Eliminar Actor" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnNuevo" Text="Nuevo Actor" runat="server" OnClick="btnNuevo_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlAltasActor" runat="server" Visible="false">
            <div>
                <asp:Label ID="lblNombre" Text="Nombre" runat="server"></asp:Label>             
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblApellidos" Text="Apellidos" runat="server"></asp:Label>             
                <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
            </div>
            <br />
 
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Actor" OnClick="btnGuardar_Click" />
        </asp:Panel>
    </div>
</asp:Content>


