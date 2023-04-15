using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyLoaiSan_module_ThemLoaiSan : System.Web.UI.Page
{
    cls_LoaiSan _LoaiSan = new cls_LoaiSan();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void save_ServerClick(object sender, EventArgs e)
    {
        if (txtFieldType.Value.Length == 0 || txtPrice.Value.Length == 0)
        {
            alert.alert_Warning(Page, "Bạn phải nhập đầy đủ dữ liệu", "");
            return;
        }

        if (_LoaiSan.Insert_LoaiSan(txtFieldType.Value, Convert.ToDecimal(txtPrice.Value)))
        {
            txtFieldType.Value = txtPrice.Value = "";
            alert.alert_Success(Page, "Thêm thành công", "");
        }
        else alert.alert_Success(Page, "Thêm thất bại", "");
    }
}