using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_XacNhanDatSanChung : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_User cls_User = new cls_User();
    cls_QuanLyDatSan cls_QuanLyDatSan = new cls_QuanLyDatSan();
    cls_Notification cls_Notification = new cls_Notification();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                int result = cls_User.User_getUserGroupId(Request.Cookies["UserName"].Value);

                switch (result)
                {
                    case 1:
                        cls_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
                        break;
                    case 2:
                        cls_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
                        break;
                    default:
                        alert.alert_Warning(Page, "Không đủ quyền để thực hiện", "");
                        break;
                }
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }

    protected void btnServerHuy_ServerClick(object sender, EventArgs e)
    {
        if (cls_QuanLyDatSan.Delete_SanChung(Convert.ToInt32(txtIdTrans.Value)))
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Hủy thành công', '','success').then(function(){window.location = '/xac-nhan-dat-san-chung';})", true);
        else alert.alert_Warning(Page, "Hủy thất bại", "");
    }

    protected void btnServerXacNhan_ServerClick(object sender, EventArgs e)
    {
        var get = (from f in db.tbFields
                   join t in db.tbTempTransactions on f.field_id equals t.field_id
                   join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                   select new { f.field_name, bt.book_time_detail }).FirstOrDefault();

        //string nameField = cls_San.San_TenSan(int.Parse(txtIdSan.Value));
        //string timeDetail = cls_BookTime.BookTime_GetBookTimeDetail(int.Parse(txtIdGio.Value));

        var bookDate = (from s in db.tbAlerts
                        where s.alert_Id == Convert.ToInt32(txtIdAlert.Value)
                        join t in db.tbTempTransactions on s.trans_id equals t.temp_transaction_id
                        select new { t.transaction_bookdate });

        if (cls_Notification.Notification_Update_Field(Convert.ToInt32(txtIdAlert.Value), get.field_name, get.book_time_detail, Convert.ToDateTime(bookDate.FirstOrDefault().transaction_bookdate))
            && cls_QuanLyDatSan.Update_TrangThaiSan(Convert.ToInt32(txtIdTrans.Value))
            )
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Xác nhận thành công', '','success').then(function(){window.location = '/xac-nhan-dat-san-chung';})", true);
        }
        else alert.alert_Success(Page, "Xác nhận thất bại", "");
    }
}