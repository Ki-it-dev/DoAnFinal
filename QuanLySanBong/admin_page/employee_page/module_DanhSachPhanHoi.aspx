<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_DanhSachPhanHoi.aspx.cs" Inherits="admin_page_employee_page_module_DanhSachPhanHoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="khoangcach">
            <h1>Quản lý phản hồi</h1>
                <div class="d-flex flex-column">
                    <div class="p-2" style="margin:auto">
                        <table class="table table-dark  table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <%--<th scope="col">Mã phản hồi</th>--%>
                                    <th scope="col">Mã đặt sân</th>
                                    <th scope="col">Nội dung phản hồi</th>
                                    <th scope="col">Ngày gửi</th>
                                    <th scope="col">Trạng thái</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpPhanHoi">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <%--<td><%#Eval("feedback_id") %></td>--%>
                                            <td><%#Eval("field_id") %></td>
                                            <td><%#Eval("feedback_content") %></td>
                                            <td><%#Eval("feedback_dateCreate") %></td>
                                            <td><%#Eval("status")%></td>
                                            <td>
                                                <a href="/cap-nhat-phan-hoi-<%#Eval("feedback_id") %>-<%#Eval("alert_Id") %>" class="btn btn-success">TRẢ LỜI</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
</asp:Content>