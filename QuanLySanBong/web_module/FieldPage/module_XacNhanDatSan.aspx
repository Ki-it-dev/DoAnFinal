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
                                <img style="margin-bottom: 30px; margin-right: 20px; width: 20rem; height: 10rem;" src="data:image/jpeg;base64,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" alt="">
                            </div>
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
                                <button class="btn btn-success" runat="server" id="btnXacNhan" onserverclick="btnXacNhan_ServerClick" style="font-size: 1rem; border-radius: 10px;"><i class="fa-solid fa-check"></i></button>
                            </div>
                            <div class="p-2">
                                <div class="d-flex flex-column justify-content-center">
                                    <span style="margin-top: 10px; margin-right: 10px; color: red; font-style: italic;">Tổng tiền: <%=price%></span>
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
        </div>

    </div>
    <div style="padding: 8%;"></div>

</asp:Content>

