﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_San.aspx.cs" Inherits="web_module_module_San" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="d-flex flex-column " style="height: 100vh">
            <div class="p-2">

                <div class="d-flex float-right" style="margin-top:20px">
                    <div class="pic-note" style=" background-color: aqua"><p id="note">QUÁ GIỜ ĐẶT</p></div>
                    <div class="pic-note" style=" background-color: #0d6efd;"><p id="note">SẴN SÀNG ĐẶT</p></div>
                    <div class="pic-note" style=" background-color: yellow;"><p id="note">CHỜ XÁC NHẬN</p></div>
                    <div class="pic-note" style=" background-color: red;"><p id="note">ĐÃ ĐẶT</p></div>
                </div>
            </div>
            <div class="p-2">
                <input type="date" name="name" value="" id="dteNgayBatDau" runat="server" onchange="myFunChange()" />
                <h2 style="color: snow"><%#Eval("field_type_name") %></h2>
                <table class="table table-bordered">
                    <thead style="text-align:center">
                        <tr>
                            <th scope="col">Giờ / Sân</th>
                            <asp:Repeater runat="server" ID="rpDanhSachSan">
                                <ItemTemplate>
                                    <th scope="col"><%#Eval("field_name") %></th>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                    </thead>
                    <tbody style="height: 55px;line-height:3;text-align:center">
                        <asp:Repeater runat="server" ID="rpKhungGio" OnItemDataBound="rpKhungGio_ItemDataBound">
                            <ItemTemplate>
                                <tr style="margin:10px">
                                    <th scope="row"><%#Eval("book_time_detail") %></th>
                                    <asp:Repeater runat="server" ID="rpSanDat">
                                        <ItemTemplate>
                                            <td>
                                                <a href="#" class="btn btn-primary cursor-poiter" style='<%#Eval("style")%>min-width: 110px;min-height: 30px;'
                                                    id="btnSan_<%#Eval("book_time_id") %>_<%#Eval("field_id") %>"
                                                    onclick="btnTimes('<%#Eval("book_time_id") %>','<%#Eval("field_id") %>')"></a>
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

            </div>

        <div style="display: none;">
            <%--<input type="text" id="txtTrangThaiSan" runat="server" name="name" />--%>

            <input type="text" id="txtIdSan" runat="server" />
            <input type="text" id="txtIdGio" runat="server" />
            <input type="text" id="txtDateTime" runat="server" />
            <a href="#" id="btnXemTrangThaiSan" runat="server" onserverclick="btnXemTrangThaiSan_ServerClick"></a>

            <input type="text" id="txtIdSanDaDat" runat="server" name="name" />
            <input type="text" id="txtIdTimeDaDat" runat="server" name="name" />

            <input type="text" id="txtIdSanCho" runat="server" name="name" />
            <input type="text" id="txtIdTimeCho" runat="server" name="name" />

            <input type="text" id="txtIdSanDat" runat="server" />

            <input type="text" id="txtTimeDatTruoc" runat="server" name="name" value="" />
            <a href="#" id="btnDatSan" runat="server" onserverclick="btnDatSan_ServerClick"></a>
        </div>
    </div>
    <style>
        .sanDaDat {
            background: red !important;
            color: #fff !important;
            font-weight: 600;
            pointer-events: none;
        }

        .sanCho {
            background: yellow !important;
            color: #000 !important;
            font-weight: 600;
            /*pointer-events: none;*/
        }
    </style>

    <script>

        var _idSanDaDat = document.getElementById("<%=txtIdSanDaDat.ClientID%>").value.split(',')
        var _idTimeDaDat = document.getElementById("<%=txtIdTimeDaDat.ClientID%>").value.split(',')

        var _idSanCho = document.getElementById("<%=txtIdSanCho.ClientID%>").value.split(',')
        var _idTimeCho = document.getElementById("<%=txtIdTimeCho.ClientID%>").value.split(',')

        function btnTimes(_idgio, _idsan) {
            document.getElementById("<%=txtIdGio.ClientID%>").value = _idgio;
            document.getElementById("<%=txtIdSan.ClientID%>").value = _idsan;
            document.getElementById("<%=txtDateTime.ClientID%>").value = document.getElementById("<%=dteNgayBatDau.ClientID%>").value;
            document.getElementById("<%=btnXemTrangThaiSan.ClientID%>").click();
        }

        function myFunChange() {
            document.getElementById("<%=txtTimeDatTruoc.ClientID%>").value = document.getElementById("<%=dteNgayBatDau.ClientID%>").value
            document.getElementById("<%=btnDatSan.ClientID%>").click();
        }

        //console.log("San da dat: ", _idSanDaDat, _idTimeDaDat)
        //console.log("San cho: ", _idSanCho, _idTimeCho)

        $(document).ready(function () {
            for (var i = 0; i < _idSanDaDat.length; i++) {
                var getElements = document.querySelectorAll("#btnSan_" + _idTimeDaDat[i] + "_" + _idSanDaDat[i]);
                //console.log("San da dat: ", getElements)
                getElements.forEach(function (element) {
                    element.classList.add('sanDaDat');
                });
            }
            for (var i = 0; i < _idSanCho.length; i++) {
                var getElements = document.querySelectorAll("#btnSan_" + _idTimeCho[i] + "_" + _idSanCho[i]);
                //console.log("San cho: ", getElements)
                getElements.forEach(function (element) {
                    element.classList.add('sanCho');
                });
            }

            var dtToday = new Date();

            var month = dtToday.getMonth() + 1;
            var day = dtToday.getDate();
            var year = dtToday.getFullYear();
            if (month < 10)
                month = '0' + month.toString();
            if (day < 10)
                day = '0' + day.toString();

            var maxDate = year + '-' + month + '-' + day;

            $('#ContentPlaceHolder1_dteNgayBatDau').attr('min', maxDate);
        })

    </script>
</asp:Content>

