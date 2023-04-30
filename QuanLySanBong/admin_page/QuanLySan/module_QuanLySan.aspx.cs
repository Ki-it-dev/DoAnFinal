using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_QuanLySan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_San san = new cls_San();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) loadData();
    }
    protected void loadData()
    {
        san.SanDanhSachSan_Admin(rpSan);
    }
    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        if (san.SanAdmin_Del(txtName.Value)) alert.alert_Success(Page, "Cập nhật trạng thái thành công", "");
        else alert.alert_Warning(Page, "Cập nhật trạng thái thất bại", "");
        loadData();
    }
    protected void addField_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-san");
    }
}