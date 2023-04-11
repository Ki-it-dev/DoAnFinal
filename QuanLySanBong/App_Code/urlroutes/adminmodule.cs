﻿using System;
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

        return list;
    }
}