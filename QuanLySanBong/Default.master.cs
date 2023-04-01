using System;
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

            int result = cls_User.User_getUserGroupId(Request.Cookies["UserName"].Value);

            switch (result)
            {
                case 1:
                    adminNone = "display:block";
                    txtNone = "display:block";
                    break;
                case 2:
                    txtNone = "display:block";
                    adminNone = "display:none";
                    break;
                default:
                    txtNone = "display:none";
                    adminNone = "display:none";
                    break;
            }
        }
        else
        {
            styleNone = "display:none";
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
