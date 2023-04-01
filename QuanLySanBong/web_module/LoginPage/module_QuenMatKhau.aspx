<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuenMatKhau.aspx.cs" Inherits="web_module_module_QuenMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="index">
        <div style="position: relative; top: 200px; left: 200px;">
            <input type="text" name="name" value="" runat="server" id="txtEmail" placeholder="Vui lòng nhập email"/>

            <button id="btnReturn" runat="server" onserverclick="btnReturn_ServerClick">Quay lại</button>
            <button id="btnGetPass" runat="server" onserverclick="btnGetPass_ServerClick">Tìm kiếm</button>
        </div>
    </div>
</asp:Content>

