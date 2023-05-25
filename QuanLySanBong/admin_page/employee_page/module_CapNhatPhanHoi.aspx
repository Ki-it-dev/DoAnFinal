<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_CapNhatPhanHoi.aspx.cs" Inherits="admin_page_employee_page_module_CapNhatPhanHoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="cont">
        <formview id="cont2">
        <div class="form-group">
            <label for="txtPhanHoiCuaKhach">Nội dung phản hồi của khách</label>
            <textarea class="form-control" id="txtPhanHoiCuaKhach" runat="server" rows="3" readonly></textarea>
        </div>

        <div class="form-group">
            <label for="txtPhanHoiNhanVien">Nội dung phản hồi của nhân viên</label>
            <textarea class="form-control" id="txtPhanHoiNhanVien" runat="server" rows="3"></textarea>
        </div>

        <button type="submit" class="btn btn-primary" id="send" runat="server" 
            onserverclick="send_ServerClick">Gửi</button>
    </formview>
    </div>
</asp:Content>

