using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_FieldPage_module_PhanHoiDatSan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_feedback _Feedback = new cls_feedback();
    cls_Notification _Notification = new cls_Notification();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void send_ServerClick(object sender, EventArgs e)
    {
        string content = txtPhanHoi.Value;

        if (content.Length > 0)
        {
            string idTrans = Request.Url.Segments.Last().Replace("-", "").Substring(7);

            var get = (from t in db.tbTempTransactions
                       join f in db.tbFields on t.field_id equals f.field_id
                       join b in db.tbBookTimes on t.book_time_id equals b.book_time_id
                       where t.temp_transaction_id == Convert.ToInt32(idTrans)
                       select new { f.field_name, b.book_time_detail, t.transaction_bookdate }).FirstOrDefault();

            if (_Feedback.Insert_FeedBack(Convert.ToInt32(idTrans), content) && _Notification.Notification_Insert_FeedBack(
                "Phản hồi " + get.field_name + " lúc " + get.book_time_detail + " vào ngày " + get.transaction_bookdate,
                Convert.ToInt32(idTrans)))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Cảm ơn bạn đã phản hồi! Vui lòng chờ nhân viên phản hồi lại nhé', '','success').then(function(){window.location = '/danh-sach-san';})", true);
            }
            else alert.alert_Warning(Page, "Lỗi", "");
        }
        else alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
    }
}