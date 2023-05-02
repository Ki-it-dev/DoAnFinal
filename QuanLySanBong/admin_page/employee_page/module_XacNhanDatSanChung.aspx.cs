using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_employee_page_module_XacNhanDatSanChung : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    cls_User cls_User = new cls_User();
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
                        cls_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
                        break;
                    case 2:
                        cls_QuanLyDatSan.Load_XacNhanDatSanChung(rpXacNhan);
                        break;
                    default:
                        alert.alert_Warning(Page, "Không đủ quyền để thực hiện", "");
                        break;
                }
            }
        }
        else
        {
            Response.Redirect("/trang-chu");
        }
    }

    protected void btnServerHuy_ServerClick(object sender, EventArgs e)
    {
        if (cls_QuanLyDatSan.Delete_SanChung(Convert.ToInt32(txtIdTrans.Value)))
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Hủy thành công', '','success').then(function(){window.location = '/xac-nhan-dat-san-chung';})", true);
        else alert.alert_Warning(Page, "Hủy thất bại", "");
        //Response.Redirect("/xac-nhan-dat-san-chung");
    }

    protected void btnServerXacNhan_ServerClick(object sender, EventArgs e)
    {
        if (cls_QuanLyDatSan.Update_TrangThaiSan(Convert.ToInt32(txtIdTrans.Value)))
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Cập nhật thành công', '','success').then(function(){window.location = '/xac-nhan-dat-san-chung';})", true);
        else alert.alert_Success(Page, "Cập nhật thất bại", "");
        //Response.Redirect("/xac-nhan-dat-san-chung");
    }
}