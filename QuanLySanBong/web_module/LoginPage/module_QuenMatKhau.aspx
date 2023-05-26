<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuenMatKhau.aspx.cs" Inherits="web_module_module_QuenMatKhau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="index">     
        <div class="contn" style="padding-top: 10vh;width:600px;margin: auto">     
            <div id="title"><h3>TÌM TÀI KHOẢN CỦA BẠN</h3></div>         
            <div class="col-lg-12 login-form">
                <form>
                    <div class="form-group">
                                <label class="form-control-label">Vui lòng nhập Email của bạn</label><br />
                                <input type="text" name="name" value="" runat="server" id="txtEmail" placeholder="Email"/>
                                <i class="fa fa-envelope" aria-hidden="true"></i>
                            </div>                           
                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <!-- Error Message -->
                                </div>
                                <div class="col--12 login-btm login-button float-right">
                                    <button id="btnReturn" runat="server" onserverclick="btnReturn_ServerClick" class="btn btn-outline-danger">QUAY LẠI</button>
                                    <button id="btnGetPass" runat="server" onserverclick="btnGetPass_ServerClick" class="btn btn-outline-primary">TÌM KIẾM</button>
                                </div>                             
                            </div>
                        </form>
                    </div>
        </div>
    </div>
</asp:Content>

