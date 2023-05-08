using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Notification
/// </summary>
public class cls_Notification
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    public cls_Notification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Notification_Insert_FeedBack(string content, int idTrans)
    {
        tbAlert insert = new tbAlert();

        insert.trans_id = idTrans;
        insert.alert_Type_Id = 2;
        insert.alert_status = false;
        insert.alert_content = content;
        insert.isRead = false;
        insert.alert_datetime = DateTime.Now;

        db.tbAlerts.InsertOnSubmit(insert);

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

    public bool Notification_Update_FeedBack(string content, int idAlert)
    {
        var update = db.tbAlerts.Where(x => x.alert_Id == idAlert).FirstOrDefault();

        update.alert_content = content;
        update.alert_status = true;

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

    public bool Notification_Insert_Field(string content, string linkTo, int idTrans)
    {
        tbAlert insert = new tbAlert();

        insert.alert_Type_Id = 1;
        insert.trans_id = idTrans;
        //insert.users_id = idUser;
        insert.alert_status = false;
        insert.alert_content = content;
        insert.alert_link_to = linkTo;
        insert.isRead = false;
        //insert.field_id = idField;
        //insert.book_time_id = idBookTime;
        insert.alert_datetime = DateTime.Now;
        //insert.bookDate = date;

        db.tbAlerts.InsertOnSubmit(insert);

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
    public bool Notification_Update_Field(int idAlert, string nameField, string timeDetail, DateTime bookDate)
    {
        tbAlert updateStatus = db.tbAlerts.Where(x => x.alert_Id == idAlert).FirstOrDefault();
        updateStatus.alert_status = true;
        updateStatus.alert_content = nameField + " đá vào lúc " + timeDetail + " ngày " + bookDate + " đã được xác nhận!!!";

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