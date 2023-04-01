using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_login_module_QuenMatKhau : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_Email cls_Email = new cls_Email();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnReturn_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/trang-chu");
    }

    protected void btnGetPass_ServerClick(object sender, EventArgs e)
    {
        string email = txtEmail.Value;

        var getCodePass = (from u in db.tbUsers where u.users_email == email select u);

        Random random = new Random();
        string activityCode = random.Next(1001, 9999).ToString();

        if (getCodePass.Count() > 0)
        {
            tbUser update = db.tbUsers.Where(x => x.users_email == email).First();
            cls_Email.sendCodePass(email, activityCode);
            update.users_codeActivityEmail = activityCode;
            db.SubmitChanges();
            Response.Redirect("web_module/module_XacNhanMatKhau.aspx?Email=" + email);
        }
        else
        {
            alert.alert_Warning(Page, "Email chưa được xác thực", "");
        }
    }
}