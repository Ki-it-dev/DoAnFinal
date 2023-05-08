using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyGio_module_QuanLyKhungGio : System.Web.UI.Page
{
    cls_BookTime _BookTime = new cls_BookTime();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack) loadData();
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }

    protected void loadData()
    {
        _BookTime.BookTime_List(rpKhungGio);
    }

    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        if (_BookTime.BookTime_Delete(Convert.ToInt32(txtTypeBookID.Value))) alert.alert_Success(Page, "Xóa thành công", "");
        else alert.alert_Warning(Page, "Xóa thất bại", "");
        loadData();
    }

    protected void addBookTime_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-khung-gio");
    }

    protected void btnCapNhatStatus_ServerClick(object sender, EventArgs e)
    {
        if (_BookTime.BookTime_UpdateStatus(Convert.ToInt32(txtTypeBookID.Value))) alert.alert_Success(Page, "Cập nhật trạng thái thành công", "");
        else alert.alert_Warning(Page, "Cập nhật trạng thái thất bại", "");
        loadData();
    }
}