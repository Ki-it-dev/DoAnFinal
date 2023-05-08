using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_DanhSachPhanHoi : System.Web.UI.Page
{
    cls_feedback _Feedback = new cls_feedback();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack) { _Feedback.GetAllFeedBackFromUser(rpPhanHoi); }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }
}