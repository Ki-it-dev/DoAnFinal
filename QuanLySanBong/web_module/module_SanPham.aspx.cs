using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_SanPham : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    cls_SanPham cls_SanPham = new cls_SanPham();

    protected string txtDateTimeNow;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlSanPhamData();
        }
        txtDateTimeNow = DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void ddlSanPhamData()
    {
        cls_SanPham.SanPham_ShowDropDown(ddlSanPham);
        //Danh sach san pham
        cls_SanPham.SanPham_LoadDanhSachSanPham(rpSanPham);
    }
    protected void ddlSanPham_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSanPham.Text == "Chọn sản phẩm")
            ddlSanPhamData();
        else
        {
            int idType = int.Parse(ddlSanPham.SelectedValue);
            cls_SanPham.SanPham_LoadWithDropDown(idType, rpSanPham);
        }
    }
}