using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLySanPham_module_DanhSachSanPham : System.Web.UI.Page
{
    cls_SanPham _SanPham = new cls_SanPham();
    cls_Alert _Alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) _SanPham.SanPham_LoadDanhSachSanPham(rpSanPham);
    }

    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        if (_SanPham.Delete_SanPham(Convert.ToInt32(txtId.Value)))
        {
            _Alert.alert_Success(Page, "Xóa thành công", "");
        }else _Alert.alert_Warning(Page, "Xóa thất bại", "");
        _SanPham.SanPham_LoadDanhSachSanPham(rpSanPham);
    }

    protected void addSanPham_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-san-pham");
    }
}