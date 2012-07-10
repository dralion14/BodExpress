<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBodega.master" AutoEventWireup="true"
    CodeBehind="SolicitudCompraNew.aspx.cs" Inherits="BodExpress.SolicitudCompraNew" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <script type="text/javascript">
    // <![CDATA[
        function grid_SelectionChanged(s, e) {
            s.GetSelectedFieldValues("M_NOMBRE", GetSelectedFieldValuesCallback);
        }
        function GetSelectedFieldValuesCallback(values) {
            selList.BeginUpdate();
            try {
                selList.ClearItems();
                for (var i = 0; i < values.length; i++) {
                    selList.AddItem(values[i]);
                }
            } finally {
                selList.EndUpdate();
            }
        }
      // ]]>
    </script>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
        DataSourceID="odsMaterial" ClientInstanceName="grid" KeyFieldName="M_ID">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" ShowSelectCheckbox="True" 
                ButtonType="Image" Width="10%">
                <EditButton>
                    <Image Url="~/images/edit.png">
                    </Image>
                </EditButton>
                <CancelButton>
                    <Image Url="~/images/no.png">
                    </Image>
                </CancelButton>
                <UpdateButton>
                    <Image Url="~/images/yes.png">
                    </Image>
                </UpdateButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="M_ID" VisibleIndex="0" 
                ShowInCustomizationForm="True" Width="15%">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_NOMBRE" VisibleIndex="1" 
                ShowInCustomizationForm="True" Width="40%">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="M_TIPO" VisibleIndex="2" Width="20%">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn FieldName="M_CANTIDAD" VisibleIndex="3" 
                Width="15%">
                <PropertiesSpinEdit DisplayFormatString="g" MaxValue="9999" MinValue="1" 
                    NumberType="Integer">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
        </Columns>
        <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Enviar Solicitud de Compra" OnClick="Continuar" ClientInstanceName="boton">
    </dx:ASPxButton>
    <dx:ASPxListBox ID="ASPxListBox1" ClientInstanceName="selList" runat="server" Height="0%" Width="0%"/>
    <asp:ObjectDataSource ID="odsMaterial" runat="server" 
        SelectMethod="getAllComprar" TypeName="CORE.CRUD_Material" 
        OldValuesParameterFormatString="original_{0}" 
        DataObjectTypeName="CORE.CRUD_Material+MATERIAL_FALTANTE" 
        UpdateMethod="updateComprar">
    </asp:ObjectDataSource>
</asp:Content>
