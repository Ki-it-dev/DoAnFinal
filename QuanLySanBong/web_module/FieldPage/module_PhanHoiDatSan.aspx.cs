using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_FieldPage_module_PhanHoiDatSan : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    cls_feedback _Feedback = new cls_feedback();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void send_ServerClick(object sender, EventArgs e)
    {
        string content = txtPhanHoi.Value;

        if (content.Length > 0)
        {
            string idTrans = Request.Url.Segments.Last().Replace("-", "").Substring(7);

            if(_Feedback.Insert_FeedBack(Convert.ToInt32(idTrans), content))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Cảm ơn bạn đã phản hồi! Vui lòng chờ nhân viên phản hồi lại nhé', '','success').then(function(){window.location = '/danh-sach-san';})", true);
            }
            else alert.alert_Warning(Page, "Lỗi", "");
        }
        else alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
    }
}