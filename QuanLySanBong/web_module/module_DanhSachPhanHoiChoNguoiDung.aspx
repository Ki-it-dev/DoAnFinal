﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_DanhSachPhanHoiChoNguoiDung.aspx.cs" Inherits="web_module_module_DanhSachPhanHoiChoNguoiDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="qldsc">
        <div class="khoangcach">
            <h1>Quản lý giao dịch</h1>
            <div style="margin-top: 50px;">
                <div class="d-flex flex-column">
                    <div class="p-2">
                        <table class="table table-dark">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã phản hồi</th>
                                    <th scope="col">Nội dung phản hồi</th>
                                    <th scope="col">Trạng thái</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpPhanHoi">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%#Eval("feedback_id") %></td>
                                            <td><%#Eval("feedback_content") %></td>
                                            <td><%#Eval("status")%></td>
                                            <%--<td>
                                                <a href="/cap-nhat-phan-hoi-<%#Eval("feedback_id") %>" class="btn btn-success">Sửa</a>
                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div style="padding:8%;"></div>
    </div>

</asp:Content>

