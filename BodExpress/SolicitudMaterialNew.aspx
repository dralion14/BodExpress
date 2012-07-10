<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUnidadClinica.master" AutoEventWireup="true"
    CodeBehind="SolicitudMaterialNew.aspx.cs" Inherits="BodExpress.SolicitudMaterialNew" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
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
    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ClientIDMode="AutoID" DataSourceID="odsDestino"
        ValueType="System.String">
    </dx:ASPxComboBox>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
        DataSourceID="odsMaterial" KeyFieldName="M_ID">
        <Columns>
            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="M_ID" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_TIPO" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_CANTIDAD" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
        </Columns>
        <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
        <Settings ShowFilterRow="True" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Enviar Solicitud de Material" OnClick="Continuar" ClientInstanceName="boton">
    </dx:ASPxButton>
    <dx:ASPxListBox ID="ASPxListBox1" ClientInstanceName="selList" runat="server" Height="0%" Width="0%"/>
    <asp:ObjectDataSource ID="odsDestino" runat="server" SelectMethod="getNombres" TypeName="CORE.CRUD_UnidadClinica">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="uc_id" SessionField="UC_ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="getAllUC" TypeName="CORE.CRUD_Material">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="uc_id" SessionField="UC_ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
