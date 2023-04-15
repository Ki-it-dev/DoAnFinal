<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ChiTietKhungGio.aspx.cs" Inherits="admin_page_QuanLyGio_module_ChiTietKhungGio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <a class="btn btn-primary" href="/quan-ly-khung-gio">Quay lại</a>
    <table class="table table-striped">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Khung giờ</th>
                <th scope="col">Loại khung giờ</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rpChiTietKhungGio">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Container.ItemIndex + 1 %></th>
                        <td><%#Eval("book_time_detail") %></td>
                        <td><%#Eval("book_time_type") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

