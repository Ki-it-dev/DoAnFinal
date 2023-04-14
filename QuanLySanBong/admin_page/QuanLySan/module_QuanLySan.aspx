﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuanLySan.aspx.cs" Inherits="admin_page_module_QuanLySan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="qldsc">
        <div class="khoangcach">
            <h1>Quản lý sân</h1>
            <a class="btn btn-secondary" id="addField" runat="server" onserverclick="addField_ServerClick">Thêm</a>
            <%--<span>Chọn loại sân</span>
            <dx:ASPxComboBox ID="cbbLoaiSan" runat="server" TextField="field_type_name" OnSelectedIndexChanged="cbbLoaiSan_SelectedIndexChanged"
                ValueField="field_type_id" ValueType="System.Int32" ClientInstanceName="cbbLoaiSan" AutoPostBack="true" Width="95%">
            </dx:ASPxComboBox>--%>

            <div style="margin-top: 50px;">
                <div class="d-flex flex-column">
                    <div class="p-2">
                        <table class="table table-dark">
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
                                                <a class="btn btn-danger" onclick="btnXoa('<%#Eval("field_id")%>')"><i class="fa-solid fa-xmark"></i></a>
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

        <input type="text" runat="server" id="txtId" name="name" value="" />
    </div>
    <script>
        function btnXoa(id) {
            swal("Bạn có thực sự muốn xóa?",
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

