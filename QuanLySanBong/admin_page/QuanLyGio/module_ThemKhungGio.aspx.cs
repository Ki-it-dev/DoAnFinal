using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyGio_module_ThemKhungGio : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_BookTime _BookTime = new cls_BookTime();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void save_ServerClick(object sender, EventArgs e)
    {
        if (timeValueArr.Value == "") { alert.alert_Warning(Page, "Vui lòng nhập đầy đủ dữ liệu", ""); return; }

        var countData = from t in db.tbBookTimes select t;

        if (countData.Count() > 0)
        {
            int _idTypeBookTime = (int)(from t in db.tbBookTimes select t).OrderByDescending(x => x.book_time_type).FirstOrDefault().book_time_type;

            int count = Convert.ToInt32(txtCount.Value);
            string[] arrStart = timeStartArr.Value.Split(',');
            string[] arrEnd = timeEndArr.Value.Split(',');

            for (int i = 0; i <= count; i++)
            {
                string details = arrStart[i] + "-" + arrEnd[i];
                if (!_BookTime.BookTime_Create(_idTypeBookTime + 1, details))
                {
                    alert.alert_Warning(Page, "Thêm thất bại", "");
                    return;
                }
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Thêm thành công', '','success').then(function(){window.location = '/quan-ly-khung-gio';})", true);

        }
        else
        {

        }
    }
}