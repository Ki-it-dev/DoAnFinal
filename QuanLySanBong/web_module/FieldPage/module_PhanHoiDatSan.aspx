<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_PhanHoiDatSan.aspx.cs" Inherits="web_module_FieldPage_module_PhanHoiDatSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="cont">
        <formview id="cont2">
        <div class="form-group">
            <label for="txtPhanHoi">Nội dung phản hồi</label>
            <textarea class="form-control" id="txtPhanHoi" runat="server" rows="3"></textarea>
        </div>
        <button type="submit" class="btn btn-primary" id="send" runat="server" onserverclick="send_ServerClick">Submit</button>
    </formview>
    </div>
</asp:Content>

