<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_XacNhanMatKhau.aspx.cs" Inherits="web_module_web_login_module_CapNhatMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="position: relative; top: 200px; left: 200px;">
        <input type="text" name="name" value="" runat="server" id="txtActiveCode" />

        <button id="btnXacThuc" runat="server" onserverclick="btnXacThuc_ServerClick">Xác thực</button>
    </div>
</asp:Content>

