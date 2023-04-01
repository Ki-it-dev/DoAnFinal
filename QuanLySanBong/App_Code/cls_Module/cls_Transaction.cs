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
    public bool Transaction_Insert(int idSan,int idUser,int idBookTime,double price,DateTime dateBook)
    {
        tbTempTransaction insert = new tbTempTransaction();

        insert.field_id = idSan;
        insert.users_id = idUser;
        insert.book_time_id = idBookTime;
        insert.isHidden = false;
        insert.transaction_status = 0;
        insert.transaction_bookdate = dateBook;
        insert.price = (decimal)price;
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