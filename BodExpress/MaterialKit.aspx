<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true"
    CodeBehind="MaterialKit.aspx.cs" Inherits="BodExpress.MaterialKit" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
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
        DataSourceID="odsMaterial" KeyFieldName="M_ID" OnRowInserting="GRID_RowInserting">
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                <EditButton>
                    <Image Url="~/images/edit.png">
                    </Image>
                </EditButton>
                <NewButton Visible="True">
                    <Image Url="~/images/new.png">
                    </Image>
                </NewButton>
                <DeleteButton Visible="True">
                    <Image Url="~/images/delete.png">
                    </Image>
                </DeleteButton>
                <CancelButton>
                    <Image Url="~/images/no.png">
                    </Image>
                </CancelButton>
                <UpdateButton>
                    <Image Url="~/images/yes.png">
                    </Image>
                </UpdateButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="M_ID" Visible="False" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="M_NOMBRE" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Descripción" FieldName="M_DESCRIPCION" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_TIPO" Visible="False" VisibleIndex="3">
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
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
                    DataSourceID="odsKit" OnBeforePerformDataSelect="detailGrid_DataSelect" KeyFieldName="M_ID">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="M_ID" Visible="False" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre" FieldName="M_NOMBRE" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Descripción" FieldName="M_DESCRIPCION" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Tipo" FieldName="M_TIPO" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </DetailRow>
            <EditForm>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 80px">
                            Nombre
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="ASPxNombre" runat="server" Width="300px" Text=''>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Materiales
                        </td>
                        <td>
                            <dx:ASPxGridView ID="ASPxGridView2" ClientInstanceName="grid" runat="server" DataSourceID="odsMat"
                                KeyFieldName="M_ID" Width="100%" AutoGenerateColumns="False" ClientIDMode="AutoID">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn FieldName="M_NOMBRE" VisibleIndex="1" />
                                    <dx:GridViewDataColumn FieldName="M_DESCRIPCION" VisibleIndex="2" />
                                </Columns>
                                <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxListBox ID="ASPxListBox" ClientInstanceName="selList" runat="server" Height="0%"
                                Width="0%" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1" runat="server"
                                ReplacementType="EditFormUpdateButton" />
                            <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement2" runat="server"
                                ReplacementType="EditFormCancelButton" />
                        </td>
                    </tr>
                </table>
            </EditForm>
        </Templates>
        <Settings ShowFilterRow="True" />
        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="odsKit" runat="server" SelectMethod="getAllMaterial" TypeName="CORE.CRUD_Kit">
        <SelectParameters>
            <asp:SessionParameter Name="Kit_id" SessionField="M_ID" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="getAllKit" TypeName="CORE.CRUD_Material"
        DataObjectTypeName="CORE.MATERIAL" DeleteMethod="DeleteKit"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMat" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_Material">
    </asp:ObjectDataSource>
</asp:Content>
