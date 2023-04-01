using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_login_module_XacThucEmail : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnXacThuc_ServerClick(object sender, EventArgs e)
    {
        string email = Request.QueryString["Email"].ToString();

        tbUser update = db.tbUsers.Where(x => x.users_email == email).FirstOrDefault();

        if (txtActiveCode.Value == update.users_codeActivityEmail.Trim())
        {
            update.users_status = true;
            db.SubmitChanges();
            alert.alert_Success(Page, "Xác thực thành công ", "");
            //Xac thuc email
            Response.Redirect("/web_module/module_DangNhap.aspx?Account=" + update.users_account);
        }
        else
        {
            alert.alert_Warning(Page, "Nhập sai mã xác thực", "");
        }
    }
}