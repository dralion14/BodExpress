<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true"
    CodeBehind="RecepcionMaterialNew.aspx.cs" Inherits="BodExpress.RecepcionMaterialNew" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ClientIDMode="AutoID" DataSourceID="odsSolicitud"
        ValueField="SC_ID" ValueType="System.String" TextField="SC_ID" OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged">
    </dx:ASPxComboBox>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Continuar" OnClick="Continuar">
    </dx:ASPxButton>
    <dx:ASPxListBox ID="ASPxListBox1" ClientInstanceName="selList" runat="server" 
        ClientIDMode="AutoID" DataSourceID="odsMaterial">
        <Columns>
            <dx:ListBoxColumn Caption="ID Material" FieldName="M_ID" />
            <dx:ListBoxColumn Caption="Nombre Material" FieldName="M_NOMBRE" />
            <dx:ListBoxColumn Caption="Cantidad" FieldName="D_CANTIDAD" />
        </Columns>
    </dx:ASPxListBox>
    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Ingresar Recepción" OnClick="Ingresar" ClientInstanceName="b_ingresar">
    </dx:ASPxButton>
    <asp:ObjectDataSource ID="odsSolicitud" runat="server" SelectMethod="getPendientes" TypeName="CORE.CRUD_SolicitudCompra">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="getAll" 
        TypeName="CORE.CRUD_SolicitudCompraDetalle" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="sc_id" SessionField="SC_ID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
