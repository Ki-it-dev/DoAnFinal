﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_SuaSan.aspx.cs" Inherits="admin_page_QuanLySan_module_SuaSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <formview>
        <div class="form-group">
            <label for="txtField">Nhập tên sân</label>
            <input type="text" class="form-control" id="txtField" runat="server" placeholder="Nhập tên sân">
        </div>
        <span>Chọn loại sân</span>
        <dx:ASPxComboBox ID="cbbLoaiSan" runat="server" TextField="field_type_name"
            ValueField="field_type_id" ValueType="System.Int32" ClientInstanceName="cbbLoaiSan" Width="95%">
        </dx:ASPxComboBox>
        <span>Chọn trạng thái</span>
        <asp:DropDownList runat="server" ID="ddlStatus">
            <asp:ListItem Text="Đang hoạt động" />
            <asp:ListItem Text="Không hoạt động" />
        </asp:DropDownList>
        <button type="submit" class="btn btn-primary" id="save" runat="server" onserverclick="save_ServerClick">Lưu</button>
        <a href="/quan-ly-san" class="btn btn-primary">Quay lại</a>
    </formview>
</asp:Content>

