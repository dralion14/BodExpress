<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true"
    CodeBehind="RecepcionMaterialNew.aspx.cs" Inherits="BodExpress.RecepcionMaterialNew" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <script type="text/javascript">
    // <![CDATA[
        function grid_SelectionChanged(s, e) {
            s.GetSelectedFieldValues("M_NOMBRE", GetSelectedFieldValuesCallback);
        }
        function GetSelectedFieldValuesCallback(values) {
            selList.BeginUpdate();
            try {
                selList.ClearItems();
                for (var i = 0; i < values.length; i++) {
                    selList.AddItem(values[i]);
                }
            } finally {
                selList.EndUpdate();
            }
        }
      // ]]>
    </script>
    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ClientIDMode="AutoID" DataSourceID="odsSolicitud"
        ValueField="SC_ID" ValueType="System.String" TextField="SC_ID" OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged">
    </dx:ASPxComboBox>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Continuar" OnClick="Continuar">
    </dx:ASPxButton>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
         ClientInstanceName="grid">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="SC_ID" VisibleIndex="0" Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_ID" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DSC_CANTIDAD" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
        </Columns>
        <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <dx:ASPxListBox ID="ASPxListBox" ClientInstanceName="selList" runat="server" Height="0%"
        Width="0%" />
    <asp:ObjectDataSource ID="odsSolicitud" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_SolicitudCompra">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="getAll" 
        TypeName="CORE.CRUD_SolicitudCompraDetalle">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="sc_id" SessionField="SC_ID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
