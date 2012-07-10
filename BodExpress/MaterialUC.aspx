<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUnidadClinica.master" AutoEventWireup="true" CodeBehind="MaterialUC.aspx.cs" Inherits="BodExpress.MaterialUC" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
        ClientIDMode="AutoID" DataSourceID="odsMATERIAL" KeyFieldName="M_ID">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="M_ID" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UC_ID" Visible="False" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="M_NOMBRE" 
                VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Stock Real" FieldName="M_STOCK_REAL" 
                VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Stock Ideal" FieldName="M_STOCK_IDEAL" 
                VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Stock Bajo" FieldName="M_STOCK_BAJO" 
                VisibleIndex="5">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="odsMATERIAL" runat="server"
            SelectMethod="getAll" TypeName="CORE.CRUD_UnidadStock" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="1" Name="uc_id" SessionField="UC_ID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
