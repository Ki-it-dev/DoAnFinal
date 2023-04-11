using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLySan_module_ThemSan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_San san = new cls_San();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadData();
    }
    protected void loadData()
    {
        //Do danh sach loai san vao dropdown list
        var listSan = from s in db.tbFieldTypes select s;
        cbbLoaiSan.DataSource = listSan;
        cbbLoaiSan.DataBind();
    }
    protected void save_ServerClick(object sender, EventArgs e)
    {
        if(cbbLoaiSan.SelectedItem.ToString().Length > 0 && txtField.Value.Length > 0)
        {
            int _id = (from s in db.tbFieldTypes where s.field_type_name == cbbLoaiSan.SelectedItem.ToString() select s.field_type_id).FirstOrDefault();
            if (san.SanAdmin_Them(txtField.Value, _id))
            {
                txtField.Value = "";
                alert.alert_Success(Page, "Thêm thành công", "");
                //Response.Redirect("/quan-ly-san");
            }
            else
            {
                alert.alert_Warning(Page, "Thêm thất bại!!!", "");
            }
        }else { alert.alert_Warning(Page, "Vui lòng nhập đầy đủ dữ liệu!!!", ""); }
    }
}