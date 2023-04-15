using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyLoaiSan_module_DanhSachLoaiSan : System.Web.UI.Page
{
    cls_LoaiSan _LoaiSan = new cls_LoaiSan();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) loadData();
    }
    protected void loadData()
    {
        _LoaiSan.Load_DanhSachLoaiSan(rpLoaiSan);
    }
    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        if (_LoaiSan.Delete_LoaiSan(Convert.ToInt32(txtId.Value)))
            alert.alert_Success(Page, "Xóa thành công", "");
        else
            alert.alert_Warning(Page, "Xóa thất bại", "");
        loadData();
    }

    protected void addLoaiSan_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-loai-san");
    }
}