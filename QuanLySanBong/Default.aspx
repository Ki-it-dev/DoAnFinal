﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--nếu có css đơn giản tự viết thì thêm vô đây
        viết file css riêng thì bỏ vô thư mục css module t mở sẵn bên kia r
        hoặc viết trực tiếp vô code như ở dưới t viết cũng dc <img src="images/SanBong/TrangChu/istockphoto.png" width="100%" />
        phần sửa code ở trong Content2 mấy cái div đó.. sửa như html bt thôi dòng 11-> dòng 46
        trên chrome kiểm tra lên rồi coi cái element đó nó được chỉnh sửa css ở file nào .. có trong đó 
        sửa là sửa mấy file aspx.
        rồi cứ rứa đi.. Content1 chứa css, content 2 để sửa giao diện, nên tạo ra 1 file css trong cssModule lưu long.css cũng dc cho dễ quản lý
        --%>
    <style> 

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="d-flex flex-column ">
        <div class="p-2">
            <div class="d-flex flex-row justify-content-center align-items-center">
                <div class="p-2">
                    <div class="d-flex flex-column">
                        <div class="p-2">
                            <h1>Phát triển kĩ năng đá bóng với HG group</h1>
                        </div>
                        <div class="p-2">
                            <p class="des">
                                Đối với thời gian rảnh rỗi, chúng ta tự do lựa chọn, không có gì ngăn cản chúng ta làm những gì hài lòng nhất.<p>
                        </div>
                        <div class="p-2" style="margin-top: 10px">
                            <div class="d-flex justify-content-center">
                                <div class="p-4">
                                    <a href="/danh-sach-san" style="padding: 10px; text-decoration: none; border: solid 1px #984b4b; border-radius: 20px; background: #00FFB2; color: #136ED9; font-family: emoji; font-weight: 800; font-size: x-large;">ĐẶT NGAY
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="p-2">
                    <img src="images/SanBong/TrangChu/istockphoto.png" width="100%" />
                </div>
            </div>
        </div>
        <div class="p-2">
            <div class="d-flex justify-content-center" style="padding-top: 10px; font-size: 2.5rem">
                <div class="p-2"><a href="https://www.facebook.com/vanhau1997" class="fab fa-facebook-square"></a></div>
                <div class="p-2"><a href="https://twitter.com" class="fab fa-twitter-square"></a></div>
                <div class="p-2"><a href="https://instagram.com" class="fab fa-instagram-square"></a></div>
                <div class="p-2"><a href="https://linkedin.com" class="fab fa-linkedin"></a></div>
            </div>
        </div>
    </div>
</asp:Content>
