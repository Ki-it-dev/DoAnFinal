using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_QuanLyDatSan
/// </summary>
public class cls_QuanLyDatSan
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLyDatSan()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Load_QuanLyDatSanChung(Repeater repeater)
    {
        var getData = (from f in db.tbFields
                       join tf in db.tbFieldTypes on f.field_type_id equals tf.field_type_id
                       join t in db.tbTempTransactions on f.field_id equals t.field_id
                       join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                       join u in db.tbUsers on t.users_id equals u.users_id
                       select new
                       {
                           f.field_name,
                           bt.book_time_detail,
                           u.users_account,
                           tf.price,
                           t.transaction_datetime,
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("dd-MM-yyyy"),
                           transaction_status = t.transaction_status == 1 ? "Đã xác nhận" : "Chờ xác nhận",
                       });

        if (getData.Any())
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    public void Load_XacNhanDatSanChung(Repeater repeater)
    {
        var getData = (from f in db.tbFields
                       join t in db.tbTempTransactions on f.field_id equals t.field_id
                       join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                       join u in db.tbUsers on t.users_id equals u.users_id
                       join a in db.tbAlerts on t.temp_transaction_id equals a.trans_id
                       where t.transaction_status == 0
                       select new
                       {
                           f.field_id,
                           f.field_name,
                           u.users_account,
                           u.users_fullname,
                           bt.book_time_detail,
                           bt.book_time_id,
                           a.alert_Id,
                           t.temp_transaction_id,

                           transaction_datetime = DateTime.Parse(t.transaction_datetime.ToString()).ToString("dd-MM-yyyy"),
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("dd-MM-yyyy"),
                       });

        if (getData.Any())
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    //Load san theo alert
    public void Load_XacNhanTheoAlert(int idField, int idBookTime, int idAlert, Repeater repeater)
    {
        var getData = (from f in db.tbFields
                       join t in db.tbTempTransactions on f.field_id equals t.field_id
                       join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                       join a in db.tbAlerts on t.temp_transaction_id equals a.trans_id
                       join u in db.tbUsers on t.users_id equals u.users_id
                       where
                       t.transaction_status == 0
                       && a.alert_Id == idAlert && t.field_id == idField && bt.book_time_id == idBookTime
                       && bt.book_time_id == idBookTime && f.field_id == idField
                       select new
                       {
                           f.field_name,
                           bt.book_time_detail,
                           u.users_account,
                           u.users_fullname,
                           transaction_datetime = DateTime.Parse(t.transaction_datetime.ToString()).ToString("dd-MM-yyyy"),
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("dd-MM-yyyy"),
                           bt.book_time_id,
                           t.field_id,
                           a.alert_Id,
                       });

        if (getData.Any())
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    //Cap nhat trang thai thanh cong trong dat san chung
    public bool Update_TrangThaiSan(int idTrans)
    {
        tbTempTransaction update = db.tbTempTransactions.Where(x => x.temp_transaction_id == idTrans).FirstOrDefault();
        update.transaction_status = 1;
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    //Huy san trong dat san chung
    public bool Delete_SanChung(int idTrans)
    {
        tbTempTransaction del = 
            db.tbTempTransactions.Where(x => x.temp_transaction_id == idTrans).FirstOrDefault();
        //Xoa thong tin san da dat trong bang thong bao
        var delAlert = db.tbAlerts.Where(x=>x.trans_id == idTrans);

        db.tbTempTransactions.DeleteOnSubmit(del);
        db.tbAlerts.DeleteAllOnSubmit(delAlert);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}