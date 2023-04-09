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
            Response.Redirect("/trang-chu");
        }
    }

    protected void btnServerHuy_ServerClick(object sender, EventArgs e)
    {
        var getIDSanAD = from s in db.tbTempTransactions
                         where s.book_time_id == Convert.ToInt32(txtIdGio.Value) && s.field_id == Convert.ToInt32(txtIdSan.Value)
                         orderby s.temp_transaction_id
                         select s.temp_transaction_id;

        tbTempTransaction del = db.tbTempTransactions.Where(x => x.temp_transaction_id == Convert.ToInt32(getIDSanAD.FirstOrDefault())).FirstOrDefault();



        db.tbTempTransactions.DeleteOnSubmit(del);

        db.SubmitChanges();
        alert.alert_Success(Page, "Hủy thành công", "");
        Response.Redirect("/xac-nhan-dat-san-chung");
        //cls_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
    }

    protected void btnServerXacNhan_ServerClick(object sender, EventArgs e)
    {
        var getIDSanAD = from s in db.tbTempTransactions
                         where s.book_time_id == Convert.ToInt32(txtIdGio.Value) && s.field_id == Convert.ToInt32(txtIdSan.Value)
                         && s.transaction_status == 0
                         orderby s.temp_transaction_id
                         select s.temp_transaction_id;

        tbTempTransaction update = db.tbTempTransactions.Where(x => x.temp_transaction_id == Convert.ToInt32(getIDSanAD.FirstOrDefault())).FirstOrDefault();
        update.transaction_status = 1;

        db.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công", "");
        Response.Redirect("/xac-nhan-dat-san-chung");
        //cls_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
    }
}