<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_SuaLoaiSan.aspx.cs" Inherits="admin_page_QuanLyLoaiSan_module_SuaLoaiSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <formview>
        <div class="form-group">
            <label for="txtField">Nhập loại sân</label>
            <input type="text" class="form-control" id="txtFieldType" runat="server" placeholder="Nhập tên sân">
        </div>
        <div class="form-group">
            <label for="txtField">Giá</label>
            <input type="number" class="form-control" id="txtPrice" runat="server" placeholder="Nhập giá">
        </div>
        <button type="button" class="btn btn-primary" id="save" runat="server" onserverclick="save_ServerClick">Lưu</button>
        <a href="/quan-ly-loai-san" class="btn btn-primary">Quay lại</a>
    </formview>
</asp:Content>

