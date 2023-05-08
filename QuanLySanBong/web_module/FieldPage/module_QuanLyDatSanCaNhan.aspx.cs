using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_QuanLyDatSanCaNhan : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    cls_San cls_San = new cls_San();
    cls_User cls_User = new cls_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                int idUser = cls_User.User_getUserId(Request.Cookies["UserName"].Value);
                cls_San.San_ShowAcc(idUser, rpDanhSachDatSan);
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }

    protected void btnHuy_ServerClick(object sender, EventArgs e)
    {
        int idUser = cls_User.User_getUserId(Request.Cookies["UserName"].Value);

        try
        {
            int idTrans = int.Parse(txtIdTrans.Value);

            if (cls_San.San_HuySan(idTrans))
                alert.alert_Success(Page, "Hủy thành công", "");
            else 
                alert.alert_Warning(Page, "Hủy thất bại", "");

            cls_San.San_ShowAcc(idUser, rpDanhSachDatSan);
        }
        catch
        {
            alert.alert_Warning(Page, "Lỗi hủy", "");
        }
    }
}