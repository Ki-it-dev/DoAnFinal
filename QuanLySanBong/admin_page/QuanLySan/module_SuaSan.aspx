﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_SuaSan.aspx.cs" Inherits="admin_page_QuanLySan_module_SuaSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="cont">
        <formview id="cont2">
        <div class="form-group">
            <label for="txtField">Nhập tên sân</label>
            <input type="text" class="form-control" id="txtField" runat="server" placeholder="Nhập tên sân">
        </div>
        <span>Chọn loại sân</span>
        <dx:ASPxComboBox ID="cbbLoaiSan" runat="server" TextField="field_type_name"
            ValueField="field_type_id" ValueType="System.Int32" ClientInstanceName="cbbLoaiSan" Width="100%">
        </dx:ASPxComboBox>
            <br />
        <span>Chọn trạng thái</span>
        <asp:DropDownList runat="server" ID="ddlStatus" >
            <asp:ListItem Text="Đang hoạt động" />
            <asp:ListItem Text="Không hoạt động" />
        </asp:DropDownList>
        <%--<span>Chọn loại khung giờ</span>
        <dx:ASPxComboBox ID="cbbKhungGio" runat="server" TextField="book_time_type"
            ValueField="book_time_type" ValueType="System.Int32" ClientInstanceName="cbbKhungGio" Width="95%">
        </dx:ASPxComboBox>--%>
        <button type="submit" class="btn btn-primary" id="save" style="margin-left:80px;margin-right:15px"
            runat="server" 
            onserverclick="save_ServerClick">Lưu</button>
        <a href="/quan-ly-san" class="btn btn-primary">Quay lại</a>
    </formview>
    </div>
    
</asp:Content>

