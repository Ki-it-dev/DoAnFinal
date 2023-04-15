using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Transaction
/// </summary>
public class cls_Transaction
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Transaction()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Transaction_Id(int _idUser, int _idSan, int _idGio, DateTime time)
    {
        var getIdTrans = (from s in db.tbFields
                          join t in db.tbTempTransactions on s.field_id equals t.field_id
                          where t.users_id == _idUser && s.book_time_id == _idGio && s.field_id == _idSan && t.transaction_bookdate == time
                          select t.temp_transaction_id).FirstOrDefault();
        return getIdTrans;
    }
    public bool Transaction_Insert(int idSan, int idUser, decimal price, DateTime dateBook)
    {
        tbTempTransaction insert = new tbTempTransaction();

        insert.field_id = idSan;
        insert.users_id = idUser;
        //insert.book_time_id = idBookTime;
        insert.isHidden = false;
        insert.transaction_status = 0;
        insert.transaction_bookdate = dateBook;
        //insert.price = (decimal)price;
        insert.transaction_datetime = DateTime.Now;

        db.tbTempTransactions.InsertOnSubmit(insert);
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