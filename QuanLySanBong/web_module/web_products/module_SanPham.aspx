<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="module_SanPham.aspx.cs" Inherits="web_module_module_SanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sanpham">
        <div class="container-fluid" style="padding-top: 8%;">
            <div class="d-flex justify-content-between">
                <div class="d-flex align-items-start">
                    <h1>Sản Phẩm</h1>
                </div>

                <div class="d-flex align-items-end">
                    <asp:DropDownList ID="ddlSanPham" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlSanPham_SelectedIndexChanged" class="dropdown">
                    </asp:DropDownList>
                </div>

            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
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
                                                            <%--<div class="p-2"><h6 class="card-title"><%#Eval("products_size") %> </h6></div>--%>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

