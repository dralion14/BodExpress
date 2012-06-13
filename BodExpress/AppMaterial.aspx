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
                <dx:GridViewCommandColumn ButtonType="Image" Caption=" " VisibleIndex="0" 
                    Width="10%">
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
                <dx:GridViewDataTextColumn FieldName="M_ID" ReadOnly="True" VisibleIndex="0" 
                    Caption="ID" Width="5%">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="1" 
                    Caption="Nombre" Width="15%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn Caption="Tipo" FieldName="M_TIPO" 
                    VisibleIndex="2" Width="10%">
                    <PropertiesComboBox ValueType="System.String">
                        <Items>
                            <dx:ListEditItem Selected="True" Text="Todos" />
                            <dx:ListEditItem Text="General" Value="General" />
                            <dx:ListEditItem Text="Médico" Value="Médico" />
                            <dx:ListEditItem Text="Kit" Value="Kit" />
                        </Items>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="M_DESCRIPCION" VisibleIndex="4" 
                    Caption="Descripción" Width="60%">
                    <Settings FilterMode="DisplayText" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_MEDIDA_DISTRIBUCION" VisibleIndex="3" 
                    Visible="False" Caption="Medida distribución">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_MEDIDA_COMPRA" VisibleIndex="5" 
                    Visible="False" Caption="Medida compra">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_REAL" VisibleIndex="6" 
                    Visible="False" Caption="Stock real">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_IDEAL" VisibleIndex="7" 
                    Visible="False" Caption="Stock ideal">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="M_STOCK_BAJO" VisibleIndex="8" 
                    Visible="False" Caption="Stock bajo">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFilterRow="True" />
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BODEXPRESSConnectionString %>" 
            SelectCommand="SELECT * FROM [MATERIAL]" 
            DeleteCommand="DELETE FROM MATERIAL WHERE [M_ID] = @M_ID" 
            InsertCommand="INSERT INTO MATERIAL(M_NOMBRE, M_DESCRIPCION, M_TIPO, M_MEDIDA_DISTRIBUCION, M_MEDIDA_COMPRA, M_STOCK_REAL, M_STOCK_IDEAL, M_STOCK_BAJO) VALUES (@M_NOMBRE, @M_DESCRIPCION, @M_TIPO, @M_MEDIDA_DISTRIBUCION, @M_MEDIDA_COMPRA, @M_STOCK_REAL, @M_STOCK_IDEAL, @M_STOCK_BAJO)" 
            
            UpdateCommand="UPDATE MATERIAL SET M_NOMBRE = @M_NOMBRE, M_DESCRIPCION = @M_DESCRIPCION, M_TIPO = @M_TIPO, M_MEDIDA_DISTRIBUCION = @M_MEDIDA_DISTRIBUCION, M_MEDIDA_COMPRA = @M_MEDIDA_COMPRA, M_STOCK_REAL = @M_STOCK_REAL, M_STOCK_IDEAL = @M_STOCK_IDEAL, M_STOCK_BAJO = @M_STOCK_BAJO WHERE [M_ID] = @M_ID">
            <DeleteParameters>
                <asp:Parameter Name="M_ID" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="M_NOMBRE" />
                <asp:Parameter Name="M_DESCRIPCION" />
                <asp:Parameter Name="M_TIPO" />
                <asp:Parameter Name="M_MEDIDA_DISTRIBUCION" />
                <asp:Parameter Name="M_MEDIDA_COMPRA" />
                <asp:Parameter Name="M_STOCK_REAL" />
                <asp:Parameter Name="M_STOCK_IDEAL" />
                <asp:Parameter Name="M_STOCK_BAJO" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="M_NOMBRE" />
                <asp:Parameter Name="M_DESCRIPCION" />
                <asp:Parameter Name="M_TIPO" />
                <asp:Parameter Name="M_MEDIDA_DISTRIBUCION" />
                <asp:Parameter Name="M_MEDIDA_COMPRA" />
                <asp:Parameter Name="M_STOCK_REAL" />
                <asp:Parameter Name="M_STOCK_IDEAL" />
                <asp:Parameter Name="M_STOCK_BAJO" />
                <asp:Parameter Name="M_ID" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
