using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyLoaiSan_module_SuaLoaiSan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_LoaiSan _LoaiSan = new cls_LoaiSan();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) loadData();
    }
    protected void loadData()
    {
        string _idTypeTime = Request.Url.Segments.Last().Replace("-", "").Substring(10);

        var get = (from l in db.tbFieldTypes where l.field_type_id == Convert.ToInt32(_idTypeTime) select l).FirstOrDefault();

        txtFieldType.Value = get.field_type_name;
        txtPrice.Value = get.price.ToString();
    }
    protected void save_ServerClick(object sender, EventArgs e)
    {
        string _idTypeTime = Request.Url.Segments.Last().Replace("-", "").Substring(10);
        if (txtFieldType.Value.Length == 0 || txtPrice.Value.Length == 0)
        {
            alert.alert_Warning(Page, "Bạn phải nhập đầy đủ dữ liệu", "");
            return;
        }
        if (_LoaiSan.Update_LoaiSan(Convert.ToInt32(_idTypeTime), txtFieldType.Value, Convert.ToDecimal(txtPrice.Value)))
        {
            txtFieldType.Value = txtPrice.Value = "";
            alert.alert_Success(Page, "Cập nhật thành công", "");
            //Response.Redirect("/quan-ly-loai-san");
        }
        else alert.alert_Success(Page, "Cập nhật thất bại", "");
    }
}