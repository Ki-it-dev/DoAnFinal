﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.MasterPage
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_User cls_User = new cls_User();

    protected string styleNone, txtNone, adminNone;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            txtUserName.InnerText = cls_User.User_getUserFullName(Request.Cookies["UserName"].Value);
            txtUserName.HRef = "";
            int result = cls_User.User_getUserGroupId(Request.Cookies["UserName"].Value);

            switch (result)
            {
                //Admin
                case 1:
                    adminNone = "display:block";
                    txtNone = "display:block";
                    break;
                //Employ
                case 2:
                    txtNone = "display:block";
                    adminNone = "display:none";
                    loadDataNotificationForEmploy();
                    break;
                //User
                default:
                    txtNone = "display:none";
                    adminNone = "display:none";
                    loadDataNotificationForUser();
                    break;
            }
        }
        else
        {
            styleNone = "display:none";
        }
    }
    protected void loadDataNotificationForEmploy()
    {
        var getNotif = (from notif in db.tbAlerts
                        join t in db.tbTempTransactions on notif.bookDate equals t.transaction_bookdate
                        where notif.field_id == t.field_id && notif.book_time_id == t.book_time_id && notif.bookDate == t.transaction_bookdate
                        select new
                        {
                            notif.alert_content,
                            notif.alert_Id,
                            notif.field_id,
                            notif.book_time_id,
                            notif.alert_datetime,
                            notif.bookDate,
                            t.transaction_datetime,
                            daXacNhan = notif.alert_status == true ? "color:red" : "",
                            choXacNhan = notif.alert_status == false ? "color:#000" : "",
                        }).OrderBy(x => x.choXacNhan).ThenBy(x => x.transaction_datetime).ToList();


        if (getNotif.Any())
        {
            rpNotif.DataSource = getNotif;
            rpNotif.DataBind();
        }

    }
    protected void loadDataNotificationForUser()
    {
        int idUser = cls_User.User_getUserId(Request.Cookies["UserName"].Value);

        var getNotif = from notif in db.tbAlerts
                       where notif.alert_status == true && notif.users_id == idUser
                       select new
                       {
                           notif.alert_content,
                           notif.alert_Id,
                           notif.field_id,
                           notif.book_time_id,

                           daXacNhan = "",
                           choXacNhan = "",
                       };

        if (getNotif.Any())
        {
            rpNotif.DataSource = getNotif;
            rpNotif.DataBind();
        }
    }
    protected void btnLogOut_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("/trang-chu");
    }

    protected void btnTimKiem_ServerClick(object sender, EventArgs e)
    {
        string value = txtTimKiem.Value;

        //Danh sach san pham
        var dsSanPham = db.tbProducts.Where(x => x.products_name.Contains(value));

        string _idSanPham = string.Join(",", dsSanPham.Select(x => x.products_id));

        Context.Items["_idSanPham"] = _idSanPham;

        Server.Transfer("/web_module/module_TimKiem.aspx");
    }
}