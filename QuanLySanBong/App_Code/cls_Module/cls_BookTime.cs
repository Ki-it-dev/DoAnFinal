using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

}