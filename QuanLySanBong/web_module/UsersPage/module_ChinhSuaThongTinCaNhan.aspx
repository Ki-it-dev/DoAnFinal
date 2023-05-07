<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ChinhSuaThongTinCaNhan.aspx.cs" Inherits="web_module_module_ChinhSuaThongTinCaNhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="khoangcach">
            <h1>THÔNG TIN CÁ NHÂN</h1>
            <div class="d-flex justify-content-center">
                <section class="xn" style="padding: 20px 30px;">
                    <div class="d-flex flex-column">
                        <div class="p-2">
                            <div class="d-flex flex-row">
                                <div class="p-2">
                                    <img style="margin-bottom: 30px; margin-right: 20px; width: 10rem; height: 10rem;" src="images/tt.jpg" alt="">
                                </div>
                                <div class="p-2">
                                    <div class="d-flex flex-column">
                                        <div class="p-2">
                                            <p>
                                                Email:
                                                <input type="email" name="name" id="txtEmail" runat="server" />
                                            </p>
                                            <asp:RegularExpressionValidator ID="validateEmail"
                                                runat="server" ErrorMessage="Invalid email." ForeColor="red"
                                                ControlToValidate="txtEmail"
                                                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                        </div>
                                        <div class="p-2">
                                            <p>
                                                Tên tài khoản :
                                                <input type="text" name="name" id="txtTaiKhoan" readonly runat="server" />
                                            </p>
                                        </div>
                                        <%--<div class="p-2">
                                            <p>
                                                CMND/CCCD :
                                                <input type="text" name="name" id="txtCMND" runat="server" />
                                            </p>
                                        </div>--%>
                                        <div class="p-2">
                                            <p>
                                                Họ và Tên:
                                                <input type="text" name="name" id="txtTen" runat="server" />
                                            </p>
                                        </div>
                                        <div class="p-2">
                                            <p>
                                                Số điện thoại:
                                                <input type="text" name="name" id="txtPhone" runat="server" />
                                            </p>
                                        </div>
                                        <div class="p-2">
                                            <p>
                                                Địa chỉ :
                                                <input type="text" name="name" id="txtDiaChi" runat="server" />
                                            </p>
                                        </div>
                                        <div class="p-2">
                                            <p>Trạng thái  : <%=users_status%></p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="p-2">
                            <div class="d-flex flex-row-reverse">
                                <div class="p-2">
                                    <button class="btn btn-secondary" id="btnChinhSua" runat="server" onserverclick="btnChinhSua_ServerClick" style="font-size: 1rem; border-radius: 20px;"><i class="fa-solid fa-pen-to-square"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>

                </section>
            </div>
        </div>
    <div style="display: none;">
        <input type="text" runat="server" id="txtCheckCMND" name="name" value="" />
        <input type="text" runat="server" id="txtCheckPhone" name="name" value="" />
        <input type="text" runat="server" id="txtCheckAccount" name="name" value="" />
    </div>
</asp:Content>

