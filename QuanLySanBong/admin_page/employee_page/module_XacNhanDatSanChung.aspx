<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_XacNhanDatSanChung.aspx.cs" Inherits="admin_page_employee_page_module_XacNhanDatSanChung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="xndsc">
        <div class="khoangcach">
            <h1>Xác nhận đơn đặt sân</h1>
            <div class="d-flex flex-wrap ">
                <asp:Repeater runat="server" ID="rpXacNhan">
                    <ItemTemplate>
                        <div class="flex-item">
                            <div class="d-flex flex-column">
                                <div class="p-2">Sân : <%#Eval("field_name") %></div>
                                <div class="p-2">Thời gian : <%#Eval("book_time_detail") %> | <%#Eval("transaction_bookdate") %></div>
                                <div class="p-2">Người đặt : <%#Eval("users_fullname") %></div>
                                <div class="p-2">Ngày đặt  : <%#Eval("transaction_datetime") %></div>
                                <div class="d-flex flex-row-reverse">
                                    <div class="p-2">
                                        <a href="#"
                                            onclick="btnHuy('<%#Eval("temp_transaction_id") %>')">
                                            <span class="badge badge-danger">Hủy</span></a>
                                    </div>
                                    <div class="p-2">
                                        <a href="#"
                                            onclick="btnXacNhan('<%#Eval("temp_transaction_id") %>')">
                                            <span class="badge badge-success">Xác nhận</span></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <div style="display: none;">
        <input type="text" name="name" value="" runat="server" id="txtIdTrans" />
        <a href="#" id="btnServerHuy" runat="server" onserverclick="btnServerHuy_ServerClick">content</a>
        <a href="#" id="btnServerXacNhan" runat="server" onserverclick="btnServerXacNhan_ServerClick">content</a>
    </div>

    <script>
        function btnHuy(idTrans) {
            swal("Bạn có thực sự muốn hủy?",
                "Nếu hủy, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtIdTrans.ClientID%>").value = idTrans
                        document.getElementById("<%=btnServerHuy.ClientID%>").click()
                    }
                });

        }
        function btnXacNhan(idTrans) {
            document.getElementById("<%=txtIdTrans.ClientID%>").value = idTrans
            document.getElementById("<%=btnServerXacNhan.ClientID%>").click()
        }
    </script>
</asp:Content>

