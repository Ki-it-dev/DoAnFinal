using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_XacNhanDatSanTheoAlert : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_QuanLyDatSan _QuanLyDatSan = new cls_QuanLyDatSan();
    cls_San cls_San = new cls_San();
    cls_BookTime cls_BookTime = new cls_BookTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        string[] listId = Request.Url.Segments.Last().Split('-');
        //{field}-{bookTime}-{idAlert}
        int idField = int.Parse(listId[4]);
        int idBookTime = int.Parse(listId[5]);
        int idAlert = int.Parse(listId[6]);

        if (!IsPostBack)
        {
            _QuanLyDatSan.Load_XacNhanTheoAlert(idField, idBookTime, idAlert, rpXacNhan);
        }
    }

    protected void btnServerHuy_ServerClick(object sender, EventArgs e)
    {
        var getIDSanAD = from s in db.tbTempTransactions
                         where s.book_time_id == Convert.ToInt32(txtIdGio.Value) && s.field_id == Convert.ToInt32(txtIdSan.Value)
                         orderby s.temp_transaction_id
                         select s.temp_transaction_id;

        tbTempTransaction del = db.tbTempTransactions.Where(x => x.temp_transaction_id == Convert.ToInt32(getIDSanAD.FirstOrDefault())).FirstOrDefault();
        tbAlert delAlert = db.tbAlerts.Where(x => x.alert_Id == int.Parse(txtIdAlert.Value)).FirstOrDefault();

        db.tbTempTransactions.DeleteOnSubmit(del);
        db.tbAlerts.DeleteOnSubmit(delAlert);

        db.SubmitChanges();

        alert.alert_Success(Page, "Hủy thành công", "");
        Response.Redirect("/xac-nhan-dat-san-chung");
        //_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
        //_QuanLyDatSan.Load_XacNhanTheoAlert(0, 0, 0, rpXacNhan);
    }

    protected void btnServerXacNhan_ServerClick(object sender, EventArgs e)
    {
        string[] listId = Request.Url.Segments.Last().Split('-');
        int idAlert = int.Parse(listId[6]);

        var getIDSanAD = from s in db.tbTempTransactions
                         where s.book_time_id == Convert.ToInt32(txtIdGio.Value) && s.field_id == Convert.ToInt32(txtIdSan.Value)
                         && s.transaction_status == 0
                         orderby s.temp_transaction_id
                         select s.temp_transaction_id;

        string nameField = cls_San.San_TenSan(int.Parse(txtIdSan.Value));
        string timeDetail = cls_BookTime.BookTime_GetBookTimeDetail(int.Parse(txtIdGio.Value));

        var bookDate = (from s in db.tbAlerts where s.alert_Id == idAlert select s.bookDate).FirstOrDefault();

        tbTempTransaction update = db.tbTempTransactions.Where(x => x.temp_transaction_id == Convert.ToInt32(getIDSanAD.FirstOrDefault())).FirstOrDefault();
        update.transaction_status = 1;

        tbAlert updateStatus = db.tbAlerts.Where(x => x.alert_Id == idAlert).FirstOrDefault();
        updateStatus.alert_status = true;
        updateStatus.alert_content = nameField + " đá vào lúc " + timeDetail + " ngày " + bookDate + " đã được xác nhận!!!";

        db.SubmitChanges();
        alert.alert_Success(Page, "Xác nhận thành công", "");
        Response.Redirect("/xac-nhan-dat-san-chung");
        //Response.Redirect("/xac-nhan-dat-san-chung");
        //_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
        //_QuanLyDatSan.Load_XacNhanTheoAlert(0, 0, 0, rpXacNhan);
    }
}