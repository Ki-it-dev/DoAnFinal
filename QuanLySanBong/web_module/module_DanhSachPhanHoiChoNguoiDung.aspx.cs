using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_DanhSachPhanHoiChoNguoiDung : System.Web.UI.Page
{
    cls_feedback _Feedback = new cls_feedback();
    cls_User _User = new cls_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            int _idUser = _User.User_getUserId(Request.Cookies["UserName"].Value);

            if (!IsPostBack) { _Feedback.GetAllFeedBackForUser(rpPhanHoi, _idUser); }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }
}