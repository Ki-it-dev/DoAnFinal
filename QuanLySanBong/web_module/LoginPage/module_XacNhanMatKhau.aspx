<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_XacNhanMatKhau.aspx.cs" Inherits="web_module_module_CapNhatMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .contn{
    text-align:center;
}
h3 {
    border-bottom: 1px solid green;
}
.form-group{
    margin:30px;
}
    </style>
    <div class="contn" style="padding-top: 10vh;width:600px;margin: auto">     
            <div id="title"><h3>XÁC THỰC EMAIL</h3></div>         
            <div class="col-lg-12 login-form">
                <form>
                    <div class="form-group">
                                <label class="form-control-label">Vui lòng nhập mã code được gửi về Email của bạn</label><br />
                                <input type="text" name="name" value="" runat="server" id="txtActiveCode"/>
                            </div>                           
                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <!-- Error Message -->
                                </div>
                                <div class="col--12 login-btm login-button float-right">
                                    <button id="btnXacThuc" runat="server" onserverclick="btnXacThuc_ServerClick" class="btn btn-outline-success">XÁC THỰC</button>
                                </div>                             
                            </div>
                        </form>
                    </div>
        </div>
</asp:Content>

