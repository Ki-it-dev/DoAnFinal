<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_CapNhatMatKhau.aspx.cs" Inherits="web_module_module_CapNhatMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="index">
        <div style="position: relative; top: 200px; left: 200px;">
            <input type="text" name="name" value="" runat="server" id="txtPass" placeholder="Vui lòng nhập mật khẩu"/>
            <input type="text" name="name" value="" runat="server" id="txtRepPass" placeholder="Vui lòng nhập lại mật khẩu"/>

            <button id="btnXacThuc" runat="server" onserverclick="btnXacThuc_ServerClick">Lưu</button>
        </div>
    </div>
</asp:Content>

