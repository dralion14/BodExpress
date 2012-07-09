<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true" CodeBehind="ReporteBodega.aspx.cs" Inherits="BodExpress.ReporteBodega" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Lista de Materiales Bodega" OnClick="ReporteMaterial">
    </dx:ASPxButton>
</asp:Content>
