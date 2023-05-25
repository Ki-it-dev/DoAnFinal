<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_ThongKe.aspx.cs" Inherits="admin_page_module_ThongKe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--Thong ke don dat san / don hang / nguoi dung /--%>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <div class="row align-items-start">
        <div>
            <div id="cont-tk">
                <asp:DropDownList runat="server" ID="ddlYear" style="margin-right:20px;">
                <asp:ListItem Text="2021" />
                <asp:ListItem Text="2022" />
                <asp:ListItem Text="2023" Selected />
            </asp:DropDownList>
                
            <asp:DropDownList ID="ddlLoaiSan" CssClass="form-control" runat="server" Width="20%"></asp:DropDownList>
            <button id="btnXemThongKeDatSanTheoThangVaNam" runat="server" 
                style="margin-left:20px;width: 60px;border-radius:10px;"
                class="btn btn-primary"
                onserverclick="btnXemThongKeDatSanTheoThangVaNam_ServerClick">Xem</button>              
            </div>
            
            <div class="row" style="margin-top:100px;justify-content:center">
                <div class="col-4">
                    <span>Thống kê đơn đặt sân</span>
                    <canvas id="thongKeDatSan"></canvas>
                </div>

                <div class="col-4" style="">
                    <span>Thống kê đơn hàng</span>
                    <canvas id="thongKeDonHang"></canvas>
                </div>

                <div class="col-auto">
                    <span>Thống kê người dùng đặt sân</span>
                    <canvas id="thongKeNguoiDung"></canvas>
                </div>
            </div>

        </div>
        <div class="col">
            <div class="d-none">
                <input type="text" id="txtSoLuongDatHang" runat="server" />
                <input type="text" id="txtSoLuongNguoiDungDaDatSan" runat="server" />
                <input type="text" id="txtSoLuongDatSanTheoThangVaNam" runat="server" />
            </div>
        </div>
    </div>


    <script>
        const ctx = document.getElementById('thongKeDatSan');

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                datasets: [{
                    label: 'Tổng tiền của từng tháng',
                    data: document.getElementById("<%=txtSoLuongDatSanTheoThangVaNam.ClientID%>").value.split(','),
                    borderWidth: 1,
                }]
            },
            options: {
                scales: {
                    y: {
                        //max: 10,
                        beginAtZero: true
                    }
                }
            }
        });

        const thongKeNguoiDung = document.getElementById('thongKeNguoiDung')

        new Chart(thongKeNguoiDung, {
            type: 'pie',
            data: {
                labels: [
                    'Tổng số người dùng trong hệ thống',
                    'Tổng số người dùng đã đặt sân trong năm',
                ],
                datasets: [{
                    //label: 'My First Dataset',
                    data: document.getElementById("<%=txtSoLuongNguoiDungDaDatSan.ClientID%>").value.split(','),
                    backgroundColor: [
                        'rgb(255, 99, 132)',
                        'rgb(54, 162, 235)',
                    ],
                    hoverOffset: 4
                }]
            },
        });

        const ctxThongKeDonDatHang = document.getElementById('thongKeDonHang')

        new Chart(ctxThongKeDonDatHang, {
            type: 'bar',
            data: {
                labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                datasets: [{
                    label: 'Tổng tiền của từng tháng',
                    data: document.getElementById("<%=txtSoLuongDatHang.ClientID%>").value.split(','),
                    borderWidth: 1,
                }]
            },
            options: {
                scales: {
                    y: {
                        //max: 10,
                        beginAtZero: true
                    }
                }
            }
        });

    </script>

</asp:Content>
