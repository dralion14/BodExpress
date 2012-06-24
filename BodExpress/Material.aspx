<%@ Page Title="BodExpress - Material" Language="C#" MasterPageFile="~/MasterUnidadClinica.master"
    AutoEventWireup="true" CodeBehind="Material.aspx.cs" Inherits="BodExpress._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v10.2.Web, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ContentHead">
</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="ContentMain">
    <h2>
        LISTA DE MATERIALES
    </h2>
    <p>
        <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
            DataSourceID="odsMATERIAL" KeyFieldName="M_ID">
            <Columns>
                <dx:GridViewCommandColumn ButtonType="Image" Caption=" " VisibleIndex="0" Width="10%">
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
                <dx:GridViewDataTextColumn FieldName="M_ID" ReadOnly="True" VisibleIndex="0" Caption="ID"
                    Width="5%">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="1" Caption="Nombre"
                    Width="15%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="M_TIPO" VisibleIndex="2"
                    Width="10%">
                    <PropertiesComboBox ValueType="System.String">
                        <Items>
                            <dx:ListEditItem Selected="True" Text="" />
                            <dx:ListEditItem Text="General" Value="General" />
                            <dx:ListEditItem Text="Médico" Value="Médico" />
                        </Items>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="M_DESCRIPCION" VisibleIndex="4" Caption="Descripción"
                    Width="60%">
                    <Settings FilterMode="DisplayText" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_MEDIDA_DISTRIBUCION" VisibleIndex="3" Visible="False"
                    Caption="Medida distribución">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_MEDIDA_COMPRA" VisibleIndex="5" Visible="False"
                    Caption="Medida compra">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_REAL" VisibleIndex="6" Visible="False"
                    Caption="Stock real">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_IDEAL" VisibleIndex="7" Visible="False"
                    Caption="Stock ideal">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_BAJO" VisibleIndex="8" Visible="False"
                    Caption="Stock bajo">
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFilterRow="True" />
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsMATERIAL" runat="server" DataObjectTypeName="CORE.MATERIAL"
            DeleteMethod="Delete" InsertMethod="Create" OnSelecting="ObjectDataSource1_Selecting"
            SelectMethod="getAll" TypeName="CORE.CRUD_Material" UpdateMethod="Update"></asp:ObjectDataSource>
    </p>
</asp:Content>
