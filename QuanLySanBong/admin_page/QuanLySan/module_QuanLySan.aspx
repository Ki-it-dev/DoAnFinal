<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuanLySan.aspx.cs" Inherits="admin_page_module_QuanLySan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="khoangcach">
            <h1>Quản lý sân</h1>
            <a class="btn btn-secondary" id="addField" runat="server" onserverclick="addField_ServerClick">Thêm</a>
                <div class="d-flex flex-column">
                    <div class="p-2" style="margin:auto">
                        <table class="table table-dark  table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Tên sân</th>
                                    <th scope="col">Trạng thái sân</th>
                                    <th scope="col"></th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpSan">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                                            <td><%#Eval("field_name")%></td>
                                            <td><%#Eval("field_status")%></td>
                                            <td>
                                                <a class="btn btn-secondary" href="/sua-san-<%#Eval("field_id") %>"><i class="fa-solid fa-pen-to-square"></i></a>
                                            </td>
                                            <td>
                                                <a class="btn btn-danger" onclick="btnXoa('<%#Eval("field_name")%>')"><i class="fa-solid fa-xmark"></i></a>
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

        <input type="text" runat="server" id="txtName" name="name" value="" />
    </div>
    <script>
        function btnXoa(name) {
            swal("Bạn có thực sự muốn chuyển sân này thành trạng thái không hoạt động?",
                "",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtName.ClientID%>").value = name
                        var xoa = document.getElementById('<%=btnXoaServer.ClientID%>')
                        xoa.click();
                    }
                });
        }
    </script>

</asp:Content>

