<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SinPermiso.aspx.cs" Inherits="BodExpress.SinPermiso" %>
<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <p>Usted no tiene los permisos para acceder a esta funcionalidad.</p>
    <asp:Label ID="lblPaginaSinPermiso" runat="server"></asp:Label>
&nbsp;
<asp:HyperLink ID="lnkVolver" runat="server" Text="[Volver]" NavigateUrl="~/LogIn.aspx"></asp:HyperLink>
</asp:Content>
