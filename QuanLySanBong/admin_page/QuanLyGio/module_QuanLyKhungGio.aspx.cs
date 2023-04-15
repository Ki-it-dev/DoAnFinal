using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyGio_module_QuanLyKhungGio : System.Web.UI.Page
{
    cls_BookTime _BookTime = new cls_BookTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) loadData();
    }

    protected void loadData()
    {
        _BookTime.BookTime_List(rpKhungGio);
    }

    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {

    }

    protected void addBookTime_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-khung-gio");
    }
}