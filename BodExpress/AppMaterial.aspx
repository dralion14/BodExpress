<%@ Page Title="BodExpress - Material" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AppMaterial.aspx.cs" Inherits="BodExpress._Default" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="ContentHead">
</asp:Content>
<asp:Content ID="MenuContent" runat="server" 
    contentplaceholderid="ContentMenu">
        <table width="100%">
            <tr>
                <td class="BarraMenuOUTLF" onmouseover="this.className='BarraMenuINLF';" onmouseout="this.className='BarraMenuOUTLF';" onclick="location.href='AppMaterial.aspx'">
                    Lista de Materiales</td>
            </tr>            
        </table>

</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="ContentMain">
    <h2>
        LISTA DE MATERIALES
    </h2>
    <p>
        <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
            ClientIDMode="AutoID" DataSourceID="SqlDataSource1" KeyFieldName="M_ID">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption=" " 
                    Width="10%">
                    <EditButton Visible="True">
                        <Image AlternateText="Editar" ToolTip="Editar" Url="~/images/edit.png">
                        </Image>
                    </EditButton>
                    <NewButton Visible="True">
                        <Image AlternateText="Nuevo" ToolTip="Nuevo" Url="~/images/new.png">
                        </Image>
                    </NewButton>
                    <DeleteButton Visible="True">
                        <Image AlternateText="Eliminar" ToolTip="Eliminar" Url="~/images/delete.png">
                        </Image>
                    </DeleteButton>
                    <SelectButton>
                        <Image AlternateText="Seleccionar" ToolTip="Seleccionar">
                        </Image>
                    </SelectButton>
                    <CancelButton>
                        <Image AlternateText="Cancelar" ToolTip="Cancelar" Url="~/images/no.png">
                        </Image>
                    </CancelButton>
                    <UpdateButton>
                        <Image AlternateText="Actualizar" ToolTip="Actualizar" Url="~/images/yes.png">
                        </Image>
                    </UpdateButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="M_ID" ReadOnly="True" VisibleIndex="0" 
                    Caption="ID" Width="10%">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="1" 
                    Caption="Nombre" Width="15%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_TIPO" VisibleIndex="2" Caption="Tipo" 
                    Width="15%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_DESCRIPCION" VisibleIndex="4" 
                    Caption="Descripción" Width="50%">
                    <Settings AllowAutoFilter="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_MEDIDA_DISTRIBUICION" VisibleIndex="3" 
                    Visible="False" Caption="Medida distribución interna">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_MEDIDA_COMPRA" VisibleIndex="5" 
                    Visible="False" Caption="Medida compra proveedor">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_REAL" VisibleIndex="6" 
                    Visible="False" Caption="Stock real">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_IDEAL" VisibleIndex="7" 
                    Visible="False" Caption="Stock ideal">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_BAJO" VisibleIndex="8" 
                    Visible="False" Caption="Stock bajo">
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BODEXPRESSConnectionString %>" 
            SelectCommand="SELECT * FROM [MATERIAL]"></asp:SqlDataSource>
    </p>
</asp:Content>
