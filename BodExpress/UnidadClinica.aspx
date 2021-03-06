﻿<%@ Page Title="BodExpress - Home" Language="C#" MasterPageFile="~/MasterBodega.master"
    AutoEventWireup="true" CodeBehind="UnidadClinica.aspx.cs" Inherits="BodExpress.UnidadClinica" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="ContentMain">
    <h2>
        UNIDADES CLÍNICAS
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="CORE.UNIDAD_CLINICA"
            DeleteMethod="Delete" InsertMethod="Create" SelectMethod="getAll" TypeName="CORE.CRUD_UnidadClinica"
            UpdateMethod="Update"></asp:ObjectDataSource>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
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
                <dx:GridViewDataTextColumn FieldName="UC_NOMBRE" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UC_ENCARGADO" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UC_PRIORIDAD" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
    </h2>
</asp:Content>
