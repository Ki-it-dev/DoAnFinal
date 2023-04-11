using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_QuanLySan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_San san = new cls_San();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) loadData();
    }
    protected void loadData()
    {
        //Do danh sach loai san vao dropdown list
        var listSan = from s in db.tbFieldTypes select s;

        cbbLoaiSan.DataSource = listSan;
        cbbLoaiSan.DataBind();
        //Do toan bo danh sach san
        san.SanAdmin_DanhSachSan(rpSan);
    }
    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        if (san.SanAdmin_Del(int.Parse(txtId.Value))){
            alert.alert_Success(Page, "Xóa thành công", "");
            loadData();
        }
        else alert.alert_Warning(Page, "Xóa thất bại", "");
    }
    protected void addField_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-san");
    }
    protected void cbbLoaiSan_SelectedIndexChanged(object sender, EventArgs e)
    {
        var _name = cbbLoaiSan.SelectedItem;

        san.San_DanhSachSanTheoLoaiSan(rpSan,_name.ToString());
    }

    
}