using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_users_profile_module_ChinhSuaThongTinCaNhan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_DangKy cls_DangKy = new cls_DangKy();
    cls_User cls_User = new cls_User();

    protected string users_status;

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
            alert.alert_Warning(Page, "Vui lòng đăng nhập để tiếp tục", "");
        }
    }

    protected void loadData()
    {
        var getUser = (from u in db.tbUsers
                       where u.users_account == Request.Cookies["UserName"].Value
                       select new
                       {
                           u.users_account,
                           u.users_address,
                           u.users_email,
                           u.users_fullname,
                           //u.users_identity,
                           u.users_phoneNumber,
                           users_status = u.users_status == true ? "Đã kích hoạt" : "Chưa kích hoạt",
                       }).FirstOrDefault();

        //txtCMND.Value = getUser.users_identity;
        txtDiaChi.Value = getUser.users_address;
        txtEmail.Value = getUser.users_email;
        txtPhone.Value = getUser.users_phoneNumber;
        txtTaiKhoan.Value = getUser.users_account;
        txtTen.Value = getUser.users_fullname;
        users_status = getUser.users_status;
    }
    protected void btnChinhSua_ServerClick(object sender, EventArgs e)
    {
        if (cls_DangKy.DangKy_KiemTraCapNhapTaiKhoan(txtPhone.Value,
            txtEmail.Value, txtTen.Value, txtDiaChi.Value) != true)
        {
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
            return;
        }

        int idUser = cls_User.User_getUserId(Request.Cookies["UserName"].Value);
        int resultCheck = cls_DangKy.KiemTraCapNhatTaiKhoan(txtPhone.Value, idUser);

        switch (resultCheck)
        {
            case 0:
                if (cls_DangKy.DangKy_CapNhat(txtPhone.Value, txtDiaChi.Value, txtEmail.Value, txtTen.Value, idUser))
                {
                    loadData();
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                }
                break;
            case 1:
                alert.alert_Warning(Page, "Số điện thoại đã tồn tại", "");
                break;
            default:
                alert.alert_Warning(Page, "Invalid error message...", "");
                break;
        }
    }
}