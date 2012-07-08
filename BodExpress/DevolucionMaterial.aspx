<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUnidadClinica.master" AutoEventWireup="true" 
         CodeBehind="DevolucionMaterial.aspx.cs" Inherits="BodExpress.DevolucionMaterial" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="ContentMain">
    <h2>
        DEVOLUCION DE MATERIAL
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getAll" TypeName="CORE.CRUD_DevolucionMaterial"></asp:ObjectDataSource>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <dx:GridViewCommandColumn ButtonType="Image" Caption=" " 
                    ShowInCustomizationForm="True" VisibleIndex="0">
                    <EditButton Visible="True">
                    </EditButton>
                    <NewButton Visible="True">
                    </NewButton>
                    <DeleteButton Visible="True">
                    </DeleteButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="Id Unidad Clínica" FieldName="DM_ID" 
                    VisibleIndex="0" ShowInCustomizationForm="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UC_ID" VisibleIndex="1" 
                    Caption="Unidad Clínica" ShowInCustomizationForm="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="Fecha de Devolución" FieldName="DM_FECHA" 
                    ShowInCustomizationForm="True" VisibleIndex="2">
                </dx:GridViewDataDateColumn>
            </Columns>
        </dx:ASPxGridView>
    </h2>
</asp:Content>
