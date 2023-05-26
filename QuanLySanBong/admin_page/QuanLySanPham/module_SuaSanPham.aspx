<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_SuaSanPham.aspx.cs" Inherits="admin_page_QuanLySanPham_module_SuaSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="cont">
        <formview id="cont2">
        <div class="form-group">
            <label for="txtField">Nhập tên sản phẩm</label>
            <input type="text" class="form-control" id="txtTenSanPham" runat="server" placeholder="Nhập tên sản phẩm">
        </div>
        <div class="form-group">
            <label for="txtPrice">Giá</label>
            <input type="number" class="form-control" id="txtPrice" runat="server" placeholder="Nhập giá" min="0">
        </div>

        <span>Chọn loại sản phẩm</span>
        <dx:ASPxComboBox ID="cbbLoaiSanPham" runat="server" TextField="typeProducts_name"
            OnSelectedIndexChanged="cbbLoaiSanPham_SelectedIndexChanged" AutoPostBack="true"
            ValueField="typeProducts_id" ValueType="System.Int32" ClientInstanceName="cbbLoaiSanPham" Width="100%">
        </dx:ASPxComboBox>

        <div style="<%=mainStyle%>">
            <div class="form-group">
                <label for="txtSoLuong">Số lượng</label>
                <input type="number" class="form-control" id="txtSoLuong" runat="server" placeholder="Nhập số lượng" min="0">
            </div>

            <div class="form-group">
                <label for="FileUpload">Ảnh</label>
                <asp:FileUpload CssClass="form-control"
                    ID="FileUpload" runat="server" accept=".png, .jpg, .jpeg" />
            </div>

            <div class="form-group">
                <label for="txtMoTa">Mô tả</label>
                <input type="text" class="form-control" id="txtMoTa" runat="server" placeholder="Nhập mô tả">
            </div>

            <div class="form-group" style="display: none; <%=style1%>">
                <label for="txtColor">Màu</label>
                <input type="text" class="form-control" id="txtColor" runat="server" placeholder="Nhập màu">
            </div>

            <div class="form-group" style="display: none; <%=style2%>">
                <label for="txtSize">Size</label>
                <input type="text" class="form-control" id="txtSize" runat="server" placeholder="Nhập size">
            </div>
        </div>

        <button type="button" class="btn btn-primary" id="save" runat="server" onserverclick="save_ServerClick">Lưu</button>
        <a href="/quan-ly-san-pham" class="btn btn-primary">Quay lại</a>
    </formview>
    </div>
</asp:Content>

