<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuanLyKhungGio.aspx.cs" Inherits="admin_page_QuanLyGio_module_QuanLyKhungGio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="qldsc">
        <div class="khoangcach">
            <h1>Quản lý sân</h1>
            <a class="btn btn-primary" runat="server" id="addBookTime" onserverclick="addBookTime_ServerClick">Thêm</a>
            <div style="margin-top: 50px;">
                <div class="d-flex flex-column">
                    <div class="p-2">
                        <table class="table table-dark">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Khung giờ</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                    <%--<th scope="col"></th>--%>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpKhungGio">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%#Eval("book_time_type")%></td>
                                            <td>
                                                <a class="btn btn-secondary" href="/chi-tiet-khung-gio-<%#Eval("book_time_type") %>">Chi tiết
                                                </a>
                                            </td>
                                            <td>
                                                <a class="btn btn-secondary" onclick="btnCapNhat('<%#Eval("book_time_type")%>')">
                                                    <i class="fa-solid fa-pen-to-square"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a class="btn btn-danger" onclick="btnXoa('<%#Eval("book_time_type")%>')">
                                                    <i class="fa-solid fa-xmark"></i>
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div style="padding: 8%;"></div>
    </div>
    <div class="d-none">
        <a href="#" id="btnXoaServer" runat="server" onserverclick="btnXoaServer_ServerClick"></a>
        <a href="#" id="btnCapNhatStatus" runat="server" onserverclick="btnCapNhatStatus_ServerClick"></a>

        <input type="text" runat="server" id="txtTypeBookID" name="name" value="" />
    </div>
    <script>
        function btnCapNhat(id) {
            swal("Bạn có thực sự muốn khung giờ này là khung giờ chính?",
                "",
                "info",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtTypeBookID.ClientID%>").value = id
                        document.getElementById('<%=btnCapNhatStatus.ClientID%>').click()
                    }
                });
        }


        function btnXoa(id) {
            swal("Bạn có thực sự muốn xóa khung giờ này?",
                "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtTypeBookID.ClientID%>").value = id
                        var xoa = document.getElementById('<%=btnXoaServer.ClientID%>')
                        xoa.click();
                    }
                });
        }
    </script>
</asp:Content>

