<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_XemThongTinCaNhan.aspx.cs" Inherits="web_module_module_XemThongTinCaNhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="qlttcn">
        <div class="khoangcach">
            <h2 style="color: white">THÔNG TIN CÁ NHÂN</h2>
            <div class="d-flex justify-content-start">
                <section class="xn" style="padding: 20px 30px;">
                    <div class="d-flex flex-column">
                        <div class="p-2">
                            <div class="d-flex flex-row">
                                <asp:Repeater runat="server" ID="rpThongTinCaNhan">
                                    <ItemTemplate>
                                        <div class="p-2">
                                            <img style="margin-bottom: 30px; margin-right: 20px; width: 10rem; height: 10rem;" src="images/tt.jpg" alt="">
                                        </div>
                                        <div class="p-2">
                                            <div class="d-flex flex-column">
                                                <div class="p-2">
                                                    <p>Email: <%#Eval("users_email") %></p>
                                                </div>
                                                <div class="p-2">
                                                    <p>Tên tài khoản : <%#Eval("users_account") %></p>
                                                </div>
                                                <%--<div class="p-2">
                                                    <p>CMND/CCCD : <%#Eval("users_identity") %></p>
                                                </div>--%>
                                                <div class="p-2">
                                                    <p>Họ và Tên: <%#Eval("users_fullname") %></p>
                                                </div>
                                                <div class="p-2">
                                                    <p>Số điện thoại: <%#Eval("users_phoneNumber") %></p>
                                                </div>
                                                <div class="p-2">
                                                    <p>Địa chỉ : <%#Eval("users_address") %></p>
                                                </div>
                                                <div class="p-2">
                                                    <p>Trạng thái  : <%#Eval("users_status") %></p>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <div class="p-2">
                            <div class="d-flex flex-row-reverse">
                                <div class="p-2">
                                    <button class="btn btn-secondary" id="btnSua" runat="server" onserverclick="btnSua_ServerClick" style="font-size: 1rem; border-radius: 20px;"><i class="fa-solid fa-pen-to-square"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>

                </section>
            </div>
            <div style="padding: 8%;"></div>
        </div>
    </div>
</asp:Content>

