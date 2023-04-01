using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_TimKiem : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    protected string styleNone, noneSp, txtDateTimeNow;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string _idSanPham;

            txtDateTimeNow = DateTime.Now.ToString();

            if (Context.Items["_idSanPham"] == null)
            {
                Response.Redirect("/trang-chu");
            }
            else
            {
                _idSanPham = Context.Items["_idSanPham"].ToString();

                txtIdSanPhamTimKiem.Value = _idSanPham;

                if (txtIdSanPhamTimKiem.Value != "")
                {
                    styleNone = "display:none";
                    noneSp = "display:block";
                    loadSanPham();
                }
                else
                {
                    styleNone = "display:block";
                    noneSp = "display:none";
                }
            }
        }
    }

    protected void loadSanPham()
    {
        string[] arrIdSanPham = txtIdSanPhamTimKiem.Value.Split(',');

        //Danh sach san pham
        var getSanPham = from sp in db.tbProducts where arrIdSanPham.Contains(sp.products_id.ToString()) select sp;

        rpSanPham.DataSource = getSanPham;
        rpSanPham.DataBind();
    }
}