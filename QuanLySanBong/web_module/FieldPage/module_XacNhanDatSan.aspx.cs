using DevExpress.Web.ASPxHtmlEditor.Internal;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_XacNhanDatSan : System.Web.UI.Page
{
    cls_User cls_User = new cls_User();
    cls_San cls_San = new cls_San();
    cls_BookTime cls_BookTime = new cls_BookTime();
    cls_Transaction cls_Transaction = new cls_Transaction();
    cls_Notification _Notification = new cls_Notification();

    cls_Alert alert = new cls_Alert();

    protected string txtDateTimeNow, field_name, book_time_detail, txtusers_fullname, price;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                if (Context.Items["_idSan"] == null && Context.Items["_idGio"] == null && Context.Items["_idTime"] == null)
                {
                    Response.Redirect("/trang-chu");
                }
                else
                {
                    const double tyGia = 23500;

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
                    price = cls_San.San_GiaTienTheoSan(Convert.ToInt32(txtIdSan.Value)).ToString();

                    txtFieldName.Value = field_name;
                    txtPrice.Value = price;
                    txtAmount.Value = Math.Round(Convert.ToDouble(price) / tyGia, 2).ToString();
                }
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
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
        decimal getPrice = cls_San.San_GiaTienTheoSan(Convert.ToInt32(txtIdSan.Value));

        string nameUser = cls_User.User_getUserFullName(Request.Cookies["UserName"].Value);
        string nameField = cls_San.San_TenSan(int.Parse(txtIdSan.Value));
        string timeDetail = cls_BookTime.BookTime_GetBookTimeDetail(int.Parse(txtIdGio.Value));

        string contentAlert = nameField + " đá vào lúc " + timeDetail + " ngày " + DateTime.Parse(txtTime.Value.ToString()).ToString("dd/MM/yyyy") + " đang cần được xác nhận!!!";
        string linkToAlert = "/xac-nhan-dat-san-" + txtIdSan.Value + "-" + txtIdGio.Value;

        if (Convert.ToInt32(getBookTime) < DateTime.Now.Hour && DateTime.Now == Convert.ToDateTime(txtTime.Value))
        {
            Response.Redirect("/danh-sach-san");
        }
        else
        {
            Context.Items["price"] = txtPrice.Value;
            Context.Items["fieldName"] = txtFieldName.Value;
            //Server.Transfer("module_PayPal.aspx");

            if (cls_Transaction.Transaction_Insert(
                    int.Parse(txtIdSan.Value), getUserId, Convert.ToDateTime(txtTime.Value), Convert.ToInt32(txtIdGio.Value)
                ))
            {
                int _idTrans = cls_Transaction.Transaction_Id(getUserId, int.Parse(txtIdSan.Value), int.Parse(txtIdGio.Value), Convert.ToDateTime(txtTime.Value));

                if (_Notification.Notification_Insert_Field(contentAlert, linkToAlert, _idTrans))
                    Response.Redirect("https://sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&amount=" + txtAmount.Value + "&business=sb-w3tgq26030242@business.example.com&item_name=" + txtFieldName.Value + "-" + _idTrans + "&return=http://localhost:52425/");
                alert.alert_Warning(Page, "Lỗi", "");
                //Response.Redirect("/quan-ly-dat-san-ca-nhan");
                //Server.Transfer("module_PayPal.aspx");
            }
        }
    }
}