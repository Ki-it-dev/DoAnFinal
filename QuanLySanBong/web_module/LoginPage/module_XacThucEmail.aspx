<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_XacThucEmail.aspx.cs" Inherits="web_module_module_XacThucEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; top: 200px; left: 200px;">
        <input type="text" name="name" value="" runat="server" id="txtActiveCode" />

        <button id="btnXacThuc" runat="server" onserverclick="btnXacThuc_ServerClick">Xác thực</button>
    </div>
</asp:Content>

