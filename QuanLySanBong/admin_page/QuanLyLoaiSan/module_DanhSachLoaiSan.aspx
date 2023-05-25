<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_DanhSachLoaiSan.aspx.cs" Inherits="admin_page_QuanLyLoaiSan_module_DanhSachLoaiSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="khoangcach">
            <h1>Quản lý loại sân</h1>
            <a class="btn btn-secondary" id="addLoaiSan" runat="server" onserverclick="addLoaiSan_ServerClick">Thêm</a>
                <div class="d-flex flex-column">
                    <div class="p-2" style="margin:auto">
                        <table class="table table-dark  table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Tên loại sân</th>
                                    <th scope="col">Giá</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpLoaiSan">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%#Eval("field_type_name")%></td>
                                            <td><%#Eval("price")%></td>
                                            <td>
                                                <a class="btn btn-secondary" href="/sua-loai-san-<%#Eval("field_type_id") %>"><i class="fa-solid fa-pen-to-square"></i></a>
                                            </td>
                                            <td>
                                                <a class="btn btn-danger" onclick="btnXoa('<%#Eval("field_type_id")%>')"><i class="fa-solid fa-xmark"></i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
    <div class="d-none">
        <a href="#" id="btnXoaServer" runat="server" onserverclick="btnXoaServer_ServerClick"></a>

        <input type="text" runat="server" id="txtId" name="name" value="" />
    </div>
    <script>
        function btnXoa(id) {
            swal("Bạn có thực sự muốn xóa loại sân này?",
                "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtId.ClientID%>").value = id
                        var xoa = document.getElementById('<%=btnXoaServer.ClientID%>')
                        xoa.click();
                    }
                });
        }
    </script>
</asp:Content>