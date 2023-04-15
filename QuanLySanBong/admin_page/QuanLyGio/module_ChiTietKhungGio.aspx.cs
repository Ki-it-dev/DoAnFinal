using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyGio_module_ChiTietKhungGio : System.Web.UI.Page
{
    cls_BookTime _BookTime = new cls_BookTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) loadData();
    }

    protected void loadData()
    {
        string _idTypeTime = Request.Url.Segments.Last().Replace("-", "").Substring(15);

        _BookTime.BookTime_Detail(Convert.ToInt32(_idTypeTime), rpChiTietKhungGio);
    }

}