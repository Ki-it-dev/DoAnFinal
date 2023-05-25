<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_DanhSachDaPhanHoi.aspx.cs" Inherits="web_module_FieldPage_module_DanhSachDaPhanHoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="qldsc">
        <div class="khoangcach">
            <h1>Quản lý giao dịch</h1>
                <div class="d-flex flex-column">
                    <div class="p-2" style="margin:auto">
                        <table class="table table-dark">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Mã phản hồi</th>
                                    <th scope="col">Nội dung đã phản hồi</th>
                                    <th scope="col">Nội dung phản hồi từ nhân viên</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpPhanHoi">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%#Eval("feedback_id") %></td>
                                            <td><%#Eval("feedback_content") %></td>
                                            <td><%#Eval("feedback_content_reply") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>

