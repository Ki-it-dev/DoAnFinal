using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_ThongKe : System.Web.UI.Page
{
    cls_LoaiSan _LoaiSan = new cls_LoaiSan();
    cls_ThongKe _ThongKe = new cls_ThongKe();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
            _LoaiSan.Load_DDLDanhSachLoaiSan(ddlLoaiSan);
        }
    }
    protected void loadData()
    {
        txtSoLuongDatSanTheoThangVaNam.Value = _ThongKe.GetSoLuongDatSanTheoThangVaNam(DateTime.Now.Year, 0);
        txtSoLuongNguoiDungDaDatSan.Value = _ThongKe.GetSoLuongNguoiDungDatSanTrongNam(DateTime.Now.Year);
        txtSoLuongDatHang.Value = _ThongKe.GetSoLuongDatHangTheoThangVaNam(DateTime.Now.Year);
    }

    protected void btnXemThongKeDatSanTheoThangVaNam_ServerClick(object sender, EventArgs e)
    {
        //Thong ke dat san
        if (ddlLoaiSan.SelectedValue == "Chọn loại sân")
        {
            txtSoLuongDatSanTheoThangVaNam.Value = _ThongKe.GetSoLuongDatSanTheoThangVaNam(Convert.ToInt32(ddlYear.SelectedValue), 0);
        }
        else
        {
            //Thong ke dat san
            txtSoLuongDatSanTheoThangVaNam.Value = _ThongKe.GetSoLuongDatSanTheoThangVaNam(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlLoaiSan.SelectedValue));
            //Thong ke nguoi dung
            txtSoLuongNguoiDungDaDatSan.Value = _ThongKe.GetSoLuongNguoiDungDatSanTrongNam(Convert.ToInt32(ddlYear.SelectedValue));
            //Thong ke don hang
            txtSoLuongDatHang.Value = _ThongKe.GetSoLuongDatHangTheoThangVaNam(Convert.ToInt32(ddlYear.SelectedValue));
        }
    }
}