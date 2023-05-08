using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_DangNhap : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_DangKy cls_DangKy = new cls_DangKy();
    cls_Email cls_Email = new cls_Email();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string account = Request.QueryString["Account"].ToString();
            if (Request.Url.Segments.Last() != "dang-nhap")
            {
                string account = Request.Url.Segments.Last().Replace("-", "").Substring(16);
                loginName.Value = account;
            }
        }
    }

    protected void setNull()
    {
        registerUsername.Value = "";
        registerPassword.Value = "";
        registerRepeatPassword.Value = "";
        registerName.Value = "";
        phoneNumbers.Value = "";
        registerEmail.Value = "";
    }
    protected void btnRegister_ServerClick(object sender, EventArgs e)
    {
        if (cls_DangKy.DangKy_KiemTraNhap(phoneNumbers.Value, registerUsername.Value,
            registerPassword.Value, registerRepeatPassword.Value,
            registerEmail.Value, registerName.Value) != true)
        {
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
            return;
        }
        if (cls_DangKy.DangKy_KiemTraNhapLaiMatKhau(registerPassword.Value, registerRepeatPassword.Value) != true)
        {
            alert.alert_Warning(Page, "Vui lòng nhập lại mật khẩu", "");
            return;
        }

        int resultCheck = cls_DangKy.DangKy(phoneNumbers.Value, registerUsername.Value, registerEmail.Value);

        Random random = new Random();
        string activityCode = random.Next(1001, 9999).ToString();

        switch (resultCheck)
        {
            case 0:
                if (cls_DangKy.DangKy_Them(phoneNumbers.Value, registerUsername.Value,
                registerPassword.Value, registerEmail.Value, registerName.Value, activityCode))
                {
                    cls_Email.sendCode(registerName.Value, registerEmail.Value, activityCode);
                    //Response.Redirect("web_module/module_XacThucEmail.aspx?Email=" + registerEmail.Value);
                    Response.Redirect("/xac-nhan-email" + "-" + registerEmail.Value);
                }
                break;
            case 1:
                alert.alert_Warning(Page, "Tài khoản đã tồn tại", "");
                break;
            case 2:
                alert.alert_Warning(Page, "Số điện thoại đã tồn tại", "");
                break;
            case 3:
                alert.alert_Warning(Page, "Email đã tồn tại", "");
                break;
            default:
                alert.alert_Warning(Page, "Invalid error message...", "");
                break;
        }
    }
    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        string pass = loginPassword.Value;
        string account = loginName.Value;
        var viewUserName = from tb in db.tbUsers
                           where tb.users_account == account
                           && tb.users_password == pass
                           && tb.users_status == true
                           select tb;

        if (viewUserName.Count() > 0)
        {
            tbUser list = viewUserName.Single();
            HttpCookie ck = new HttpCookie("UserName");
            //string s = ck.Value;
            ck.Value = account;
            Response.Cookies.Add(ck);

            int result = Convert.ToInt32(viewUserName.FirstOrDefault().group_user_id);

            switch (result)
            {
                case 1:
                    Response.Redirect("/thong-ke");
                    break;
                default:
                    Response.Redirect("/trang-chu");
                    break;
            }
            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Sai tên đăng nhập / mật khẩu!', '','warning')", true);
        }
    }
}