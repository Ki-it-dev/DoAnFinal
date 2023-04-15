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

    cls_User user = new cls_User();
    public cls_Notification()
    {
        //
        // TODO: Add constructor logic here
        //
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

}