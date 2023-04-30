using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_BookTime
/// </summary>
public class cls_BookTime
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_BookTime()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string BookTime_GetBookTimeDetail(int idGio)
    {
        var getTimeDetail = from t in db.tbBookTimes where t.book_time_id == idGio select t;
        return getTimeDetail.FirstOrDefault().book_time_detail;
    }
    //Admin
    public void BookTime_List(Repeater repeater)
    {
        var result = from t in db.tbBookTimes
                     group t by t.book_time_type into k
                     select new
                     {
                         book_time_type = k.Key,
                     };
        if (result.Any())
        {
            repeater.DataSource = result;
            repeater.DataBind();
        }
    }
    //Chi tiet khung gio
    public void BookTime_Detail(int _idType, Repeater repeater)
    {
        var result = from t in db.tbBookTimes where t.book_time_type == _idType select t;

        if (result.Any())
        {
            repeater.DataSource = result;
            repeater.DataBind();
        }
    }
    //Them khung gio
    public bool BookTime_Create(int _idTypeBookTime, string bookDetail)
    {
        tbBookTime insert = new tbBookTime();

        insert.book_time_type = _idTypeBookTime;
        insert.book_time_detail = bookDetail;
        insert.book_time_status = false;

        db.tbBookTimes.InsertOnSubmit(insert);

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
    //Cap nhat thanh khung gio chinh
    public bool BookTime_UpdateStatus(int _idTypeBookTime)
    {
        var listIdType = from b in db.tbBookTimes where b.book_time_type == _idTypeBookTime select b;
        string[] arrIdType = string.Join(",", listIdType.Select(x => x.book_time_id)).Split(',');

        var nameField = (from s in db.tbFields
                         group s by new { s.field_name, s.field_type_id } into k
                         select new { k.Key.field_name, k.Key.field_type_id });

        try
        {
            //foreach (var item in arrIdType)
            //{
            //    db.tbFields.FirstOrDefault().book_time_id = Convert.ToInt32(item);
            //}

            db.tbBookTimes.Where(x => x.book_time_type == _idTypeBookTime).ToList()
            .ForEach(dv => dv.book_time_status = true);

            db.tbBookTimes.Where(x => x.book_time_type != _idTypeBookTime).ToList()
            .ForEach(dv => dv.book_time_status = false);

            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    //Xoa khung gio
    public bool BookTime_Delete(int _idTypeBookTime)
    {
        var del = db.tbBookTimes.Where(x => x.book_time_type == _idTypeBookTime);
        //var updateId = (from s in db.tbFields
        //                join t in db.tbBookTimes on s.book_time_type equals t.book_time_type
        //                where t.book_time_type == _idTypeBookTime
        //                select s.book_time_id);

        //foreach (var item in updateId)
        //{
        //    tbField update = db.tbFields.Where(x => x.book_time_id == item).FirstOrDefault();

        //    update.book_time_id = null;
        //}

        db.tbBookTimes.DeleteAllOnSubmit(del);

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