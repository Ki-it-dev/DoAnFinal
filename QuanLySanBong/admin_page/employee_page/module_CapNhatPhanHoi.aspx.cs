using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_CapNhatPhanHoi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_feedback _Feedback = new cls_feedback();
    cls_User _User = new cls_User();
    cls_Alert _Alert = new cls_Alert();
    cls_Notification _Notification = new cls_Notification();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                string[] listId = Request.Url.Segments.Last().Split('-');

                int idPhanHoi = int.Parse(listId[4]);
                int idAlert = int.Parse(listId[5]);

                //_Alert.alert_Success(Page, idPhanHoi + "-" + idAlert, "");

                txtPhanHoiCuaKhach.Value = _Feedback.GetContentFeedBackFromUser(Convert.ToInt32(idPhanHoi));
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }

    protected void send_ServerClick(object sender, EventArgs e)
    {
        string content = txtPhanHoiNhanVien.Value;

        string[] listId = Request.Url.Segments.Last().Split('-');

        int idFeedBack = int.Parse(listId[4]);
        int idAlert = int.Parse(listId[5]);

        if (content.Length > 0)
        {
            //string idFeedBack = Request.Url.Segments.Last().Replace("-", "").Substring(14);
            //string idAlert = Request.Url.Segments.Last().Replace("-", "").Substring(14);

            int _idUser = _User.User_getUserId(Request.Cookies["UserName"].Value);

            var get = (from t in db.tbTempTransactions
                       join f in db.tbFields on t.field_id equals f.field_id
                       join b in db.tbBookTimes on t.book_time_id equals b.book_time_id
                       join fb in db.tbFeedbacks on t.temp_transaction_id equals fb.trans_id
                       join a in db.tbAlerts on t.temp_transaction_id equals a.trans_id
                       where fb.feedback_id == Convert.ToInt32(idFeedBack) && a.alert_Type_Id == 2 && a.alert_Id == idAlert
                       select new { f.field_name, b.book_time_detail, t.transaction_bookdate, a.alert_Id }).FirstOrDefault();


            if (_Feedback.Update_FeedBack(Convert.ToInt32(idFeedBack), content, _idUser) &&
                _Notification.Notification_Update_FeedBack("Phản hồi của bạn đã được trả lời (sân " + get.field_name + " lúc " + get.book_time_detail + " vào ngày " + get.transaction_bookdate + ")", get.alert_Id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Phản hồi thành công', '','success').then(function(){window.location = '/danh-sach-phan-hoi';})", true);
            }
            else _Alert.alert_Warning(Page, "Lỗi", "");
        }
        else _Alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
    }
}