<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="LogIn.aspx.cs" Inherits="BodExpress.LogOn" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <br />
    <table class="style1">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <font face="Arial, Helvetica, sans-serif" size="4">Identificación de Usuario</font>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Usuario
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxTextBox ID="txtUser" runat="server" Width="170px" MaxLength="15">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Contraseña
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxTextBox ID="txtPassword" runat="server" Width="170px" MaxLength="15" Password="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btoIngreso" runat="server" Text="Ingresar" OnClick="btoIngreso_Click"
                    Font-Size="11px" Height="23px" Width="80px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Text="Atención, Su usuario y contraseña son incorrectos"
                    Visible="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <%--<asp:TextBox ID="txtUser" runat="server" Width="100" ></asp:TextBox><br />--%>
    <br />
    <br />
</asp:Content>
