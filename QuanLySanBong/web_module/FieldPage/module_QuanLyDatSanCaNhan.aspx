<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_QuanLyDatSanCaNhan.aspx.cs" Inherits="web_module_module_QuanLyDatSanCaNhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="qldscn">
        <div class="khoangcach">
            <h1>Quản lý đơn đặt sân của tôi</h1>
            <div class="d-flex flex-wrap ">
                <asp:Repeater runat="server" ID="rpDanhSachDatSan">
                    <ItemTemplate>
                        <div class="flex-item">
                            <div class="d-flex flex-column">
                                <div class="p-2">Sân : <%#Eval("field_name") %></div>
                                <div class="p-2">Thời gian : <%#Eval("book_time_detail") %></div>
                                <div class="p-2">Ngày đặt  : <%#Eval("transaction_datetime") %></div>
                                <div class="p-2">Ngày đá  : <%#Eval("transaction_bookdate") %></div>
                                <div class="d-flex">
                                    <div class="p-2"><span class="badge badge-success" style="<%#Eval("daXacNhan")%>">Đã xác nhận</span></div>
                                    <div class="p-2"><span class="badge badge-warning" style="<%#Eval("choXacNhan")%>">Chờ xác nhận</span></div>
                                    <div class="p-2"><span class="badge badge-secondary" style="<%#Eval("daHuy")%>">Đã hủy</span></div>
                                    <div class="p-2">
                                        <a href="#"><span class="badge badge-danger"
                                            onclick="myBtnHuy('<%#Eval("temp_transaction_id") %>')" style="<%#Eval("huy")%>">Hủy</span></a>
                                    </div>
                                </div>
                            </div>
                            <div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div style="padding: 8%;"></div>
    </div>
    <a href="#" id="btnHuy" runat="server" onserverclick="btnHuy_ServerClick"></a>
    <div style="display: none;">
        <input type="text" name="name" value="" id="txtIdTrans" runat="server" />
    </div>

    <script>
        function myBtnHuy(idTrans) {
            swal("Bạn có thực sự muốn hủy?",
                "Nếu hủy, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtIdTrans.ClientID%>").value = idTrans
                        document.getElementById("<%=btnHuy.ClientID%>").click()
                    }
                });
        }
    </script>
</asp:Content>

