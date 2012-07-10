<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUnidadClinica.master" AutoEventWireup="true"
    CodeBehind="SolicitudMaterial.aspx.cs" Inherits="BodExpress.SolicitudMaterial" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ MasterType VirtualPath="~/MasterUnidadClinica.Master" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="ContentMain">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Nueva Solicitud de Material" onclick="Nuevo">
    </dx:ASPxButton>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
        DataSourceID="odsSolicitud" KeyFieldName="SM_ID">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="SM_ID" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S_UC" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S_EST" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S_UC_DEST" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S_TIPO" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S_SM_REC" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="S_FECHA" VisibleIndex="6">
            </dx:GridViewDataDateColumn>
        </Columns>
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
                    DataSourceID="odsDetalle" KeyFieldName="M_ID" OnBeforePerformDataSelect="detailGrid_DataSelect">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="SM_ID" VisibleIndex="0" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M_ID" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="D_CANTIDAD" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
        <Settings ShowFilterRow="True" />
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="odsSolicitud" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_SolicitudMaterial">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="uc_id" SessionField="S_UC" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsDetalle" runat="server" SelectMethod="getAll" TypeName="CORE.CRUD_SolicitudMaterialDetalle">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="sm_id" SessionField="SM_ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
