<%@ Page Title="" Language="C#" MasterPageFile="~/MasterUnidadClinica.master" AutoEventWireup="true" 
         CodeBehind="SolicitudMaterial.aspx.cs" Inherits="BodExpress.SolicitudMaterial" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="ContentMain">
    <h2>
        SOLICITUD DE MATERIAL
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getAll" TypeName="CORE.CRUD_SolicitudMaterial"></asp:ObjectDataSource>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Caption=" ">
                    <EditButton Visible="True">
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
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="ID Unidad Clínica" FieldName="UC_ID" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UC_NOMBRE" VisibleIndex="1" 
                    Caption="Unidad Clínica">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UC_ENCARGADO" VisibleIndex="2" 
                    Caption="Encargado">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UC_PRIORIDAD" VisibleIndex="3" 
                    Visible="False">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
    </h2>
</asp:Content>
