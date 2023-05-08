using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_XemThongTinCaNhan : System.Web.UI.Page
{
    cls_User user = new cls_User();    
    cls_Alert alert = new cls_Alert();  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }
    protected void loadData()
    {
        string cookie = Request.Cookies["UserName"].Value;

        rpThongTinCaNhan.DataSource = user.User_getUserWithCookie(cookie);
        rpThongTinCaNhan.DataBind();
    }
    protected void btnSua_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/chinh-sua-thong-tin-ca-nhan");
    }
}