<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Creación de estudiantes</h2>

        <div>
            <p class="lead">Carnet:</p>
            <asp:TextBox class="lead" ID="txtId" runat="server"></asp:TextBox>
        </div>
        <div>
            <p class="lead">Nombres: </p>
            <asp:TextBox class="lead" ID="txtFirstName" runat="server"></asp:TextBox>
        </div>
        <div>
            <p class="lead">Apellidos:</p>
            <asp:TextBox class="lead" ID="txtLastName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="saveStudent" class="btn btn-primary btn-lg" runat="server" Text="Guardar" OnClick="saveStudent_Click" />
        </div>
        <div>
            <p><%= this.message %></p>
        </div>
    </div>

</asp:Content>
