using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_XacNhanDatSan : System.Web.UI.Page
{
    cls_User cls_User = new cls_User();
    cls_San cls_San = new cls_San();
    cls_BookTime cls_BookTime = new cls_BookTime();
    cls_Price cls_Price = new cls_Price();
    cls_Transaction cls_Transaction = new cls_Transaction();

    protected string txtDateTimeNow, field_name, book_time_detail, txtusers_fullname, price;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Items["_idSan"] == null && Context.Items["_idGio"] == null && Context.Items["_idTime"] == null)
            {
                Response.Redirect("/trang-chu");
            }
            else
            {
                string _idSan = Context.Items["_idSan"].ToString();
                string _idGio = Context.Items["_idGio"].ToString();
                string _idTime = Context.Items["_idTime"].ToString();

                txtIdGio.Value = _idGio;
                txtIdSan.Value = _idSan;
                txtTime.Value = _idTime;

                txtDateTimeNow = _idTime;
                field_name = cls_San.San_TenSan(Convert.ToInt32(_idSan));
                book_time_detail = cls_BookTime.BookTime_GetBookTimeDetail(Convert.ToInt32(_idGio));
                txtusers_fullname = cls_User.User_getUserFullName(Request.Cookies["UserName"].Value);
                price = cls_Price.Price(Convert.ToInt32(_idGio));
            }
        }
    }

    protected void btnReturn_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/danh-sach-san");
    }
    protected void btnXacNhan_ServerClick(object sender, EventArgs e)
    {
        int getUserId = cls_User.User_getUserId(Request.Cookies["UserName"].Value);

        string getBookTime = cls_BookTime.BookTime_GetBookTimeDetail(Convert.ToInt32(txtIdGio.Value)).Substring(0, 2);
        string getPrice = cls_Price.Price(Convert.ToInt32(txtIdGio.Value));

        if (Convert.ToInt32(getBookTime) < DateTime.Now.Hour && DateTime.Now == Convert.ToDateTime(txtTime.Value))
        {
            Response.Redirect("/danh-sach-san");
        }
        else
        {
            if (cls_Transaction.Transaction_Insert(
                    int.Parse(txtIdSan.Value), getUserId, int.Parse(txtIdGio.Value),
                    double.Parse(getPrice), Convert.ToDateTime(txtTime.Value)
                ))
            {
                //alert.alert_Success(Page, "Xác nhận thành công Vui lòng chờ nhân viên xác nhận", "");
                Response.Redirect("/quan-ly-dat-san-ca-nhan");
            }
        }
    }
}