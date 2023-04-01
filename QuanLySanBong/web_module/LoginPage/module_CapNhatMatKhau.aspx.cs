using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_CapNhatMatKhau : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnXacThuc_ServerClick(object sender, EventArgs e)
    {
        string pass = txtPass.Value;
        string repPass = txtRepPass.Value;

        string acc = Request.QueryString["Account"].ToString();

        if (pass == "" || repPass == "")
        {
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
            return;
        }

        if (pass != repPass)
        {
            alert.alert_Warning(Page, "Nhập sai", "");
            return;
        }

        tbUser update = db.tbUsers.Where(x => x.users_account == acc).FirstOrDefault();
        update.users_password = pass;
        db.SubmitChanges();
        alert.alert_Success(Page, "Thành công", "");
        Response.Redirect("/Default.aspx?Account=" + update.users_account);
    }
}