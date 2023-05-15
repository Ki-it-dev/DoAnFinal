using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for webui
/// </summary>
public class webui
{
	public webui()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        //Trang chu
        list.Add("webTrangChu|trang-chu|~/Default.aspx");
        //Dang nhap
        list.Add("webDangNhap|dang-nhap|~/web_module/LoginPage/module_DangNhap.aspx");
        list.Add("webQuenMatKhau|quen-mat-khau|~/web_module/LoginPage/module_QuenMatKhau.aspx");
        //Dat san
        list.Add("webXacNhanDatSan|xac-nhan-dat-san|~/web_module/FieldPage/module_XacNhanDatSan.aspx");
        list.Add("webQuanLyDatSanCaNhan|quan-ly-dat-san-ca-nhan|~/web_module/FieldPage/module_QuanLyDatSanCaNhan.aspx");
        list.Add("webSan|danh-sach-san|~/web_module/FieldPage/module_San.aspx");
        //Phan hoi
        list.Add("webPhanHoi|phan-hoi-{id}|~/web_module/FieldPage/module_PhanHoiDatSan.aspx");
        list.Add("webDanhSachPhanHoi|danh-sach-phan-hoi-khach|~/web_module/FieldPage/module_DanhSachDaPhanHoi.aspx");
        list.Add("webPhanHoiChoNguoiDung|phan-hoi|~/web_module/module_DanhSachPhanHoiChoNguoiDung.aspx");

        //Danh sach san pham
        list.Add("webSanPham|san-pham|~/web_module/ProductsPage/module_SanPham.aspx");
        //Nguoi dung
        list.Add("webThongTinCaNhan|thong-tin-ca-nhan|~/web_module/UsersPage/module_XemThongTinCaNhan.aspx");
        list.Add("webChinhSuaThongTinCaNhan|chinh-sua-thong-tin-ca-nhan|~/web_module/UsersPage/module_ChinhSuaThongTinCaNhan.aspx");
        //Xac thuc email
        list.Add("webXacNhanEmail|xac-nhan-email-{value}|~/web_module/LoginPage/module_XacThucEmail.aspx");
        list.Add("webCapNhatTrangThaiTaiKhoan|cap-nhat-trang-thai-{value}|~/web_module/LoginPage/module_DangNhap.aspx");
        //Quên mật khẩu
        list.Add("webXacNhanMatKhau|quen-mat-khau-{value}|~/web_module/LoginPage/module_XacNhanMatKhau.aspx");
        list.Add("webCapNhatMatKhau|cap-nhat-mat-khau-{value}|~/web_module/LoginPage/module_CapNhatMatKhau.aspx");
        //PayPal
        list.Add("webPayPal|payPal|~/web_module/FieldPage/PaymentWithPayPal.aspx");

        return list;

    }
}