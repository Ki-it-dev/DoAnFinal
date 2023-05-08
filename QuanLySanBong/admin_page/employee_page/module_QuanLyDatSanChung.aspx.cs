using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_QuanLyDatSanChung : System.Web.UI.Page
{
    cls_User cls_User = new cls_User();
    cls_Alert alert = new cls_Alert();
    cls_QuanLyDatSan cls_QuanLyDatSan = new cls_QuanLyDatSan();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                int result = cls_User.User_getUserGroupId(Request.Cookies["UserName"].Value);

                switch (result)
                {
                    case 1:
                        cls_QuanLyDatSan.Load_QuanLyDatSanChung(rpQlGD);
                        break;
                    case 2:
                        cls_QuanLyDatSan.Load_QuanLyDatSanChung(rpQlGD);
                        break;
                    default:
                        alert.alert_Warning(Page, "Không đủ quyền để thực hiện", "");
                        break;
                }
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }
}