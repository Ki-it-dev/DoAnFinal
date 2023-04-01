﻿using System;
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

    public void Load_QuanLyDatSanChung(Repeater repeater) {
        var getData = (from f in db.tbFields
                       join t in db.tbTempTransactions on f.field_id equals t.field_id
                       join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                       join u in db.tbUsers on t.users_id equals u.users_id
                       select new
                       {
                           f.field_name,
                           bt.book_time_detail,
                           u.users_account,
                           t.price,
                           t.transaction_datetime,
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("dd-MM-yyyy"),
                           transaction_status = t.transaction_status == 1 ? "Đã xác nhận" : "Chờ xác nhận",
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
    public void Load_XacNhanDatSanChung(Repeater repeater)
    {
        var getData = (from f in db.tbFields
                      join t in db.tbTempTransactions on f.field_id equals t.field_id
                      join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                      join u in db.tbUsers on t.users_id equals u.users_id
                      where t.transaction_status == 0
                       select new
                       {
                           f.field_name,
                           u.users_account,
                           u.users_fullname,
                           bt.book_time_detail,

                           transaction_datetime = DateTime.Parse(t.transaction_datetime.ToString()).ToString("dd-MM-yyyy"),
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("dd-MM-yyyy"),

                           t.book_time_id,
                           t.field_id,

                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
}