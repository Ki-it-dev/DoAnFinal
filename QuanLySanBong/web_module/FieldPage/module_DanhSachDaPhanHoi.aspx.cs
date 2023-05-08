using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_FieldPage_module_DanhSachDaPhanHoi : System.Web.UI.Page
{
    cls_feedback _Feedback = new cls_feedback();
    cls_User _User = new cls_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                int _idUser = _User.User_getUserId(Request.Cookies["UserName"].Value);

                _Feedback.GetALlFeedBackFromEmploy(_idUser, rpPhanHoi);
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }
}