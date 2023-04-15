using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminmodule
/// </summary>
public class adminmodule
{
	public adminmodule()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        //Quan ly dat san
        list.Add("webQuanLyDatSanChung|quan-ly-dat-san-chung|~/admin_page/employee_page/module_QuanLyDatSanChung.aspx");
        list.Add("webXacNhanDatSanChung|xac-nhan-dat-san-chung|~/admin_page/employee_page/module_XacNhanDatSanChung.aspx");
        //Quan ly tai khoan nguoi dung
        list.Add("webQuanLyTaiKhoan|quan-ly-tai-khoan|~/admin_page/module_QuanLyTaiKhoan.aspx");
        //Dat san theo thong bao
        list.Add("webXacNhanDatSanTheoThongBaoCuaKhachHang|xac-nhan-dat-san-{field}-{bookTime}-{idAlert}|~/admin_page/employee_page/module_XacNhanDatSanTheoAlert.aspx");
        //Quan ly san
        list.Add("webQuanLySan|quan-ly-san|~/admin_page/QuanLySan/module_QuanLySan.aspx");
        list.Add("webThemSan|them-san|~/admin_page/QuanLySan/module_ThemSan.aspx");
        list.Add("webSuaSan|sua-san-{id}|~/admin_page/QuanLySan/module_SuaSan.aspx");
        //Quan ly khung gio
        list.Add("webQuanLyKhungGio|quan-ly-khung-gio|~/admin_page/QuanLyGio/module_QuanLyKhungGio.aspx");
        list.Add("webChiTietKhungGio|chi-tiet-khung-gio-{typeID}|~/admin_page/QuanLyGio/module_ChiTietKhungGio.aspx");
        list.Add("webThemKhungGio|them-khung-gio|~/admin_page/QuanLyGio/module_ThemKhungGio.aspx");
        //Quan ly loai san
        list.Add("webQuanLyLoaiSan|quan-ly-loai-san|~/admin_page/QuanLyLoaiSan/module_DanhSachLoaiSan.aspx");
        list.Add("webThemLoaiSan|them-loai-san|~/admin_page/QuanLyLoaiSan/module_ThemLoaiSan.aspx");
        list.Add("webSuaLoaiSan|sua-loai-san-{idLoaiSan}|~/admin_page/QuanLyLoaiSan/module_SuaLoaiSan.aspx");
        //Quan ly san pham
        list.Add("webQuanLySanPham|quan-ly-san-pham|~/admin_page/QuanLySanPham/module_DanhSachSanPham.aspx");
        list.Add("webThemSanPham|them-san-pham|~/admin_page/QuanLySanPham/module_ThemSanPham.aspx");
        list.Add("webSuaSanPham|cap-nhat-san-pham-{idSanPham}|~/admin_page/QuanLySanPham/module_SuaSanPham.aspx");

        return list;
    }
}