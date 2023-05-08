using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_QuanLyTaiKhoan : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    cls_User cls_User = new cls_User();

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
        int result = cls_User.User_getUserGroupId(Request.Cookies["UserName"].Value);

        switch (result)
        {
            case 1:
                cls_User.User_getEmployList(rpTK);
                break;
            case 2:
                cls_User.User_getUserList(rpTK);
                break;
            default:
                alert.alert_Warning(Page, "Không đủ quyền để thực hiện", "");
                break;
        }
    }
    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        cls_User.User_Del(int.Parse(txtIdUser.Value));
        alert.alert_Success(Page, "Xóa thành công", "");
        loadData();
    }

    protected void btnSuaServer_ServerClick(object sender, EventArgs e)
    {
        Context.Items["idUser"] = txtIdUser.Value;
        Server.Transfer("/admin_page/module_CapNhatThongTin.aspx");
    }
}