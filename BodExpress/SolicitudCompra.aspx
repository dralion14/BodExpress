<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true"
    CodeBehind="SolicitudCompra.aspx.cs" Inherits="BodExpress.SolicitudCompra" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Nueva Solicitud de Compra" onclick="Nuevo">
    </dx:ASPxButton>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
        DataSourceID="odsMaterial" KeyFieldName="SC_ID">
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                <DeleteButton Visible="True">
                    <Image Url="~/images/delete.png">
                    </Image>
                </DeleteButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="SC_ID" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="E_ID" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Fecha" FieldName="SC_FECHA" VisibleIndex="2">
            </dx:GridViewDataDateColumn>
        </Columns>
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
                    DataSourceID="odsDetalle" KeyFieldName="SC_ID" OnBeforePerformDataSelect="detailGrid_DataSelect">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID Solicitud" FieldName="SC_ID" VisibleIndex="0" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ID Material" FieldName="M_ID" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cantidad" FieldName="DSC_CANTIDAD" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
        <Settings ShowFilterRow="True" />
        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="odsDetalle" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_SolicitudCompraDetalle">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="sc_id" SessionField="SC_ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_SolicitudCompra"
        DataObjectTypeName="CORE.SOLICITUD_COMPRA" DeleteMethod="Delete" InsertMethod="Create"
        UpdateMethod="Update"></asp:ObjectDataSource>
</asp:Content>
