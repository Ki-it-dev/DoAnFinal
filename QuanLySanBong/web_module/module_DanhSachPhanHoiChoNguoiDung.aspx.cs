using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_DanhSachPhanHoi : System.Web.UI.Page
{
    cls_feedback _Feedback = new cls_feedback();
    cls_User _User = new cls_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        int _idUser = _User.User_getUserId(Request.Cookies["UserName"].Value);

        if (!IsPostBack) { _Feedback.GetAllFeedBackForUser(rpPhanHoi, _idUser); }
    }
}