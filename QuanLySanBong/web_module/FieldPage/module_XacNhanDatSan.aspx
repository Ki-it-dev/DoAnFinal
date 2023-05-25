<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_XacNhanDatSan.aspx.cs" Inherits="web_module_module_XacNhanDatSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="khoangcach">
        <h1>Xác nhận đặt sân</h1>
        <div class="d-flex justify-content-center">
            <section class="xn" style="padding: 20px 30px;">
                <div class="d-flex flex-column">
                    <div class="p-2">
                        <div class="d-flex flex-row">
                            
                            <div class="p-2">
                                <div class="d-flex flex-column">
                                    <div class="p-2">
                                        <p>Tên sân: <%=field_name %></p>
                                    </div>
                                    <div class="p-2">
                                        <p>Thời gian: <%=book_time_detail %> </p>
                                    </div>
                                    <div class="p-2">
                                        <p>Ngày đặt: <%=txtDateTimeNow %></p>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="p-2">
                        <p>Họ và tên : <%=txtusers_fullname%></p>
                    </div>

                    <div class="p-2">
                        <div class="d-flex flex-row-reverse">
                            <div class="p-2">
                                <button class="btn btn-danger" runat="server" id="btnReturn" onserverclick="btnReturn_ServerClick" style="font-size: 1rem; border-radius: 10px;"><i class="fa-solid fa-xmark"></i></button>
                            </div>
                            <div class="p-2">
                                <%--<div id="paypal-payment-button"></div>--%>
                                <button class="btn btn-success" runat="server" id="btnXacNhan" onserverclick="btnXacNhan_ServerClick" style="font-size: 1rem; border-radius: 10px;"><i class="fa-solid fa-check"></i></button>
                            </div>
                            <div class="p-2">
                                <div class="d-flex flex-column justify-content-center">
                                    <span style="font-size:25px;font-weight: bold;margin-top: 10px; margin-right: 10px; color: #d4f025; font-style: italic;">Tổng tiền: <%=price%></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>

        <div class="d-none">
            <input type="text" id="txtIdSan" runat="server" name="name" value="" />
            <input type="text" id="txtIdGio" runat="server" name="name" value="" />
            <input type="text" id="txtTime" runat="server" name="name" value="" />

            <input type="text" id="txtFieldName" runat="server" name="name" value="" />
            <input type="text" id="txtPrice" runat="server" name="name" value="" />

            <input type="text" id="txtAmount" runat="server" name="name" value="" />
        </div>

    </div>
    
   <%-- <script src="https://www.paypal.com/sdk/js?client-id=AYWhG8KH4Fv1ELpvTYj-cDbrT_O2n3gDjx9jR7aS95VgrBaB_k7dNxJ6qbfJOlQsKMeG3avVC_yaAFuH&disable-funding=credit,card"></script>
    <script>
        paypal.Buttons({
            style: {
                color: 'blue',
                shape: 'pill'
            },
            createOrder: function (data, actions) {
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: '0.1'
                        }
                    }]
                });
            },
            onApprove: function (data, actions) {
                return actions.order.capture().then(function (details) {
                    //console.log(details)
                    window.location.replace("http://localhost:52425/thanh-toan-thanh-cong")
                })
            },
            onCancel: function (data) {
                window.location.replace("http://localhost:52425/thanh-toan-that-bai")
            }
        }).render('#paypal-payment-button');
    </script>--%>
</asp:Content>

