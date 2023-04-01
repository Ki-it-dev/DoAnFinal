using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Price
/// </summary>
public class cls_Price
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Price()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Price(int idGio)
    {
        var getPrice = from p in db.tbPrices where p.book_time_id == idGio select p;
        return getPrice.FirstOrDefault().price.ToString();
    }
}