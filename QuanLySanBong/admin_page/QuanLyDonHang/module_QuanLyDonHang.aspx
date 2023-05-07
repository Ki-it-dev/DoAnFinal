<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuanLyDonHang.aspx.cs" Inherits="admin_page_QuanLyDonHang_module_QuanLyDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="khoangcach">
            <h1>Quản lý đơn hàng</h1>
            <a class="btn btn-primary" runat="server" id="addDonHang" onserverclick="addDonHang_ServerClick">Thêm</a>
            <div style="margin-top: 50px;">
                <div class="d-flex flex-column">
                    <div class="p-2">
                        <table class="table table-dark">
                            <thead>
                                <tr>
                                    <th scope="col">Mã đơn</th>
                                    <%--<th scope="col">Số lượng</th>--%>
                                    <th scope="col">Tổng tiền</th>
                                    <th scope="col">Ngày tạo</th>
                                    <th scope="col">Nhân viên</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpDonHang">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%#Eval("bill_info_id") %></th>
                                            <%--<td><%#Eval("soLuong") %></td>--%>
                                            <td><%#Eval("total")%></td>
                                            <td><%#Eval("data_create")%></td>
                                            <td><%#Eval("users_fullname")%></td>
                                            <td>
                                                <a class="btn btn-secondary" href="/sua-don-hang-<%#Eval("bill_info_id")%>">
                                                    <i class="fa-solid fa-pen-to-square"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a class="btn btn-danger" onclick="btnXoa('<%#Eval("bill_info_id")%>')">
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
    <div class="d-none">
        <a href="#" id="btnXoaServer" runat="server" onserverclick="btnXoaServer_ServerClick"></a>

        <input type="text" runat="server" id="txtBillInfoId" name="name" value="" />
    </div>
    <script>
        function btnXoa(id) {
            swal("Bạn có thực sự muốn xóa đơn hàng này?",
                "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtBillInfoId.ClientID%>").value = id
                        var xoa = document.getElementById('<%=btnXoaServer.ClientID%>')
                        xoa.click();
                    }
                });
        }
    </script>
</asp:Content>

