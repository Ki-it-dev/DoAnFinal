<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuanLyDatSanChung.aspx.cs" Inherits="admin_page_employee_page_module_QuanLyDatSanChung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="khoangcach">
            <h1>Quản lý giao dịch</h1>
                <div class="d-flex flex-column">
                    <div class="p-2" style="margin:auto">
                        <table class="table table-dark  table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã sân</th>
                                    <th scope="col">Tài khoản</th>
                                    <th scope="col">Thời gian</th>
                                    <th scope="col">Giá tiền</th>
                                    <th scope="col">Ngày giao dịch</th>
                                    <th scope="col">Trạng thái</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpQlGD">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%#Eval("field_name") %></td>
                                            <td><%#Eval("users_account") %></td>
                                            <td><%#Eval("book_time_detail") %> | <%#Eval("transaction_bookdate") %> </td>
                                            <td><%#Eval("price","{0:0,00}") %> VNĐ</td>
                                            <td><%#Eval("transaction_datetime") %></td>
                                            <td><%#Eval("transaction_status")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="p-2">
                        <div class="d-flex flex-row-reverse"><a class="alert alert-warning" style="text-decoration: none" href="/xac-nhan-dat-san-chung">Đến trang xác nhận đơn</a></div>
                    </div>
                </div>
            </div>
</asp:Content>

