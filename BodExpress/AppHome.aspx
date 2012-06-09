<%@ Page Title="BodExpress - Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppHome.aspx.cs" Inherits="BodExpress.AppHome" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentHead" runat="server">
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