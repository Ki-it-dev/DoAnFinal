<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_TimKiem.aspx.cs" Inherits="web_module_module_TimKiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="<%=styleNone%>">
        <div id="xn">
            <h1 style="color: greenyellow; padding-top: 25%; text-align: center;">Không tìm thấy dữ liệu</h1>
            <div style="padding: 10%"></div>
        </div>
    </div>

    <div id="sanpham" style="<%=noneSp%>">
        <div class="container-fluid" style="padding-top: 8%;">
            <div class="d-flex justify-content-between">
            </div>
            <div class="card-deck">
                <div class="container-fluid">
                    <div class="row">
                        <asp:Repeater runat="server" ID="rpSanPham">
                            <ItemTemplate>
                                <div class="col-lg-2 col-md-1 col-sm-1 mb-3">
                                    <div class="card">
                                        <img class="card-img-top" src="<%#Eval("producst_picture")%>" alt="Card image cap">
                                        <div class="card-body">
                                            <div class="d-flex align-items-center flex-column" style="height: 200px;">
                                                <div class=" p-2">
                                                    <h4 class="card-title"><%#Eval("products_name") %></h4>
                                                </div>
                                                <div class="d-flex">
                                                    <div class="p-2">
                                                        <h6 class="card-title"><%#Eval("products_size") %> </h6>
                                                    </div>
                                                    <div class="p-2"></div>
                                                    <div class="p-2">
                                                        <h6 class="card-title"><%#Eval("products_color") %></h6>
                                                    </div>

                                                </div>
                                                <div class="p-2">
                                                    <p class="card-text"><%#Eval("products_description") %></p>
                                                </div>
                                                <div class="mt-auto p-2">
                                                    <h6><%#Eval("products_price","{0:0,00}") %> VNĐ</h6>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-footer">
                                            <small class="text-muted">Last updated: <%=txtDateTimeNow%></small>
                                            <small style="float: right" class="text-muted mt-3">SL: còn <%#Eval("products_quantity") %></small>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
        <div style="padding: 8%;"></div>
    </div>

    <div style="display: none;">
        <input type="text" runat="server" id="txtIdSanPhamTimKiem" name="name" value="" />
    </div>
</asp:Content>

