<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ThemSan.aspx.cs" Inherits="admin_page_QuanLySan_module_ThemSan" %>

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
            ValueField="field_type_id" ValueType="System.Int32" ClientInstanceName="cbbLoaiSan" Width="95%">
        </dx:ASPxComboBox>
       <%-- <span>Chọn khung giờ</span>
        <dx:ASPxComboBox ID="cbbTime" runat="server" TextField="book_time_type"
            ValueField="book_time_type" ValueType="System.Int32" ClientInstanceName="cbbTime" Width="95%">
        </dx:ASPxComboBox>--%>
            <br />
        <button type="button" class="btn btn-primary" id="save" runat="server" onserverclick="save_ServerClick">Lưu</button>
        <a href="/quan-ly-san" class="btn btn-primary">Quay lại</a>
    </formview>
    </div>
    
</asp:Content>

