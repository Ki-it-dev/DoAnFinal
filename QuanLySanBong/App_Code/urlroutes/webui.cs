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
        list.Add("webDangNhap|dang-nhap|~/web_module/web_login/module_DangNhap.aspx");
        list.Add("webQuenMatKhau|quen-mat-khau|~/web_module/web_login/module_QuenMatKhau.aspx");
        //Dat san
        list.Add("webXacNhanDatSan|xac-nhan-dat-san|~/web_module/web_fields/module_XacNhanDatSan.aspx");
        list.Add("webQuanLyDatSanCaNhan|quan-ly-dat-san-ca-nhan|~/web_module/web_fields/module_QuanLyDatSanCaNhan.aspx");
        list.Add("webSan|danh-sach-san|~/web_module/web_fields/module_San.aspx");
        //Danh sach san pham
        list.Add("webSanPham|san-pham|~/web_module/web_products/module_SanPham.aspx");
        //Nguoi dung
        list.Add("webThongTinCaNhan|thong-tin-ca-nhan|~/web_module/web_users_profile/module_XemThongTinCaNhan.aspx");
        list.Add("webChinhSuaThongTinCaNhan|chinh-sua-thong-tin-ca-nhan|~/web_module/web_users_profile/module_ChinhSuaThongTinCaNhan.aspx");

        return list;

    }
}