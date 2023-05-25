using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_CapNhatThongTin : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_DangKy cls_DangKy = new cls_DangKy();

    protected string txtTenTaiKhoan;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                if (Context.Items["idUser"] == null)
                {
                    Response.Redirect("/trang-chu");
                }
                else
                {
                    string _id = Context.Items["idUser"].ToString();

                    txtIdUser.Value = _id;
                    loadData(int.Parse(_id));
                }
            }
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }
    protected void loadData(int id)
    {
        var getUser = (from u in db.tbUsers
                       group u by new
                       {
                           u.users_status,
                       } into k
                       select new
                       {
                           users_account = (from us in db.tbUsers where us.users_id == id select us.users_account).First(),
                           users_address = (from us in db.tbUsers where us.users_id == id select us.users_address).First(),
                           users_phoneNumber = (from us in db.tbUsers where us.users_id == id select us.users_phoneNumber).First(),
                           users_fullname = (from us in db.tbUsers where us.users_id == id select us.users_fullname).First(),
                           users_email = (from us in db.tbUsers where us.users_id == id select us.users_email).First(),
                           users_id = id,
                           users_status = k.Key.users_status == true ? "Kích hoạt" : "Chưa kích hoạt",
                       }).First();

        var getQuyen = (from q in db.tbGroupUsers select q);

        txtTenTaiKhoan = getUser.users_account;
        //txtCMND.Value = getUser.users_identity;
        txtDiaChi.Value = getUser.users_address;
        txtEmail.Value = getUser.users_email;
        txtPhone.Value = getUser.users_phoneNumber;
        txtTaiKhoan.Value = getUser.users_account;
        txtTen.Value = getUser.users_fullname;

        ddlPhanQuyen.Items.Clear();
        ddlPhanQuyen.AppendDataBoundItems = true;
        ddlPhanQuyen.DataTextField = "group_user_name";
        ddlPhanQuyen.DataValueField = "group_user_id";
        ddlPhanQuyen.DataSource = getQuyen;
        ddlPhanQuyen.DataBind();

        //ddlPhanQuyen.SelectedItem.Text = getQuyen.First().group_user_name == "admin" ? "Admin" : 
        //    getQuyen.First().group_user_name == "employee" ? "Nhân viên" : "Khách hàng";

        //ddlStatus.SelectedItem.Text = getUser.users_status == true ? "Kích hoạt" : "Chưa kích hoạt";

        //ddlStatus.Items.Clear();
        //ddlStatus.AppendDataBoundItems = true;
        //ddlStatus.DataTextField = "users_status";
        //ddlStatus.DataValueField = "users_id";
        //ddlStatus.DataSource = getUser;
        //ddlStatus.DataBind();
    }
    protected void btnChinhSua_ServerClick(object sender, EventArgs e)
    {
        txtDiaChi.Value = txtDiaChi.Value == null ? "" : txtDiaChi.Value;

        if (cls_DangKy.DangKy_KiemTraCapNhapTaiKhoan(txtPhone.Value,
            txtEmail.Value, txtTen.Value, txtDiaChi.Value) != true)
        {
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin", "");
            return;
        }

        int resultCheck = cls_DangKy.KiemTraCapNhatTaiKhoan(txtPhone.Value, int.Parse(txtIdUser.Value));

        switch (resultCheck)
        {
            case 0:
                if (cls_DangKy.DangKy_CapNhat_Admin(txtPhone.Value, txtDiaChi.Value,
                    txtEmail.Value, txtTen.Value, int.Parse(txtIdUser.Value),
                    Convert.ToInt32(ddlPhanQuyen.SelectedValue), ddlStatus.SelectedItem.Text))
                {
                    loadData(int.Parse(txtIdUser.Value));
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                    Response.Redirect("/quan-ly-tai-khoan");
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