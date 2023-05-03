using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_CapNhatPhanHoi : System.Web.UI.Page
{
    cls_feedback _Feedback = new cls_feedback();
    cls_User _User = new cls_User();
    cls_Alert _Alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string idPhanHoi = Request.Url.Segments.Last().Replace("-", "").Substring(14);

            txtPhanHoiCuaKhach.Value = _Feedback.GetContentFeedBackFromUser(Convert.ToInt32(idPhanHoi));
        }
    }

    protected void send_ServerClick(object sender, EventArgs e)
    {
        string content = txtPhanHoiNhanVien.Value;

        if (content.Length > 0)
        {
            string idFeedBack = Request.Url.Segments.Last().Replace("-", "").Substring(14);
            int _idUser = _User.User_getUserId(Request.Cookies["UserName"].Value);

            if (_Feedback.Update_FeedBack(Convert.ToInt32(idFeedBack), content, _idUser))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Phản hồi thành công', '','success').then(function(){window.location = '/danh-sach-phan-hoi';})", true);
            }
            else _Alert.alert_Warning(Page, "Lỗi", "");
        }
        else _Alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
    }
}