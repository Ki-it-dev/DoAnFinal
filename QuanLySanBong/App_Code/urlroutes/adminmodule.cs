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

        return list;
    }
}