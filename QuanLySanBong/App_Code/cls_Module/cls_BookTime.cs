using System;
using System.Collections.Generic;
using System.Linq;
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
}