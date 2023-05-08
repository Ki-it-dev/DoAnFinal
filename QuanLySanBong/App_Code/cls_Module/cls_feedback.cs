using System;
using System.Collections.Generic;
//using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_feedback
/// </summary>
public class cls_feedback
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_feedback()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void GetAllFeedBackFromUser(Repeater repeater)
    {
        var getData = (from f in db.tbFeedbacks
                       join t in db.tbTempTransactions on f.trans_id equals t.temp_transaction_id
                       join a in db.tbAlerts on f.trans_id equals a.trans_id
                       where a.alert_Type_Id == 2
                       select new
                       {
                           f.feedback_id,
                           f.feedback_content,
                           status = f.feedback_content_reply.Length > 0 ? "Đã phản hồi" : "Chưa phản hồi",
                           t.field_id,
                           f.feedback_dateCreate,
                           a.alert_Id,
                       });

        if (getData.Count() > 0)
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    public void GetAllFeedBackForUser(Repeater repeater,int idUser)
    {
        var getData = (from f in db.tbFeedbacks
                       join t in db.tbTempTransactions on f.trans_id equals t.temp_transaction_id
                       where t.users_id == idUser
                       select new
                       {
                           t.field_id,
                           f.feedback_dateCreate,
                           f.feedback_id,
                           f.feedback_content,
                           status = f.feedback_content_reply.Length > 0 ? "Đã phản hồi" : "Chưa phản hồi",
                       });

        if (getData.Count() > 0)
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    public void GetALlFeedBackFromEmploy(int idUser, Repeater repeater)
    {
        var getData = (from f in db.tbFeedbacks
                       join t in db.tbTempTransactions on f.trans_id equals t.temp_transaction_id
                       where t.users_id == idUser
                       select f);

        if (getData.Count() > 0)
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    public string GetContentFeedBackFromUser(int idFeedBack)
    {
        var get = (from f in db.tbFeedbacks
                   where f.feedback_id == idFeedBack
                   select f).FirstOrDefault();

        return get.feedback_content;
    }
    public bool Update_FeedBack(int idFeedBack, string content, int _idEmploy)
    {
        var update = db.tbFeedbacks.Where(x => x.feedback_id == idFeedBack).FirstOrDefault();

        update.feedback_content_reply = content;
        update.emp_id = _idEmploy;

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
    public bool Insert_FeedBack(int _idTrans, string content)
    {
        tbFeedback insert = new tbFeedback();

        insert.feedback_content = content;
        insert.trans_id = _idTrans;
        insert.feedback_dateCreate = DateTime.Now;

        db.tbFeedbacks.InsertOnSubmit(insert);

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