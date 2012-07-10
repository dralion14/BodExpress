<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true"
    CodeBehind="SolicitudCompraNew.aspx.cs" Inherits="BodExpress.SolicitudCompraNew" %>

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
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
        DataSourceID="odsMaterial" KeyFieldName="M_ID" ClientInstanceName="grid">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="M_ID" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_DESCRIPCION" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_TIPO" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_MEDIDA_DISTRIBUCION" Visible="False" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_MEDIDA_COMPRA" Visible="False" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_STOCK_REAL" Visible="False" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_STOCK_IDEAL" Visible="False" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_STOCK_BAJO" Visible="False" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
        </Columns>
        <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Enviar Solicitud de Compra" OnClick="Continuar" ClientInstanceName="boton">
    </dx:ASPxButton>
    <dx:ASPxListBox ID="ASPxListBox1" ClientInstanceName="selList" runat="server" Height="0%"
        Width="0%" />
    <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_Material">
    </asp:ObjectDataSource>
</asp:Content>
