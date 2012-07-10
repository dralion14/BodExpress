<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdministrador.master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="BodExpress.Usuarios" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
        ClientIDMode="AutoID" DataSourceID="odsUsuarios" KeyFieldName="nombre">
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
            <dx:GridViewDataTextColumn FieldName="nombre" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="pass" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="area" VisibleIndex="2">
                <PropertiesComboBox ValueType="System.String">
                    <Items>
                        <dx:ListEditItem Selected="True" Text=" " />
                        <dx:ListEditItem Text="Unidad Clínica" Value="UC" />
                        <dx:ListEditItem Text="Bodega" Value="Bod" />
                        <dx:ListEditItem Text="Administrador" Value="Adm" />
                    </Items>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="odsUsuarios" runat="server" 
        DataObjectTypeName="CORE.USUARIO" DeleteMethod="Delete" InsertMethod="Create" 
        SelectMethod="getAll" TypeName="CORE.CRUD_Usuario" UpdateMethod="Update">
    </asp:ObjectDataSource>
</asp:Content>
