using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLySanPham_module_ThemSanPham : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_Alert alert = new cls_Alert();
    cls_SanPham _SanPham = new cls_SanPham();
    protected string style1, style2, mainStyle, urlImg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
            mainStyle = "display:none !important";
        }
    }
    protected void loadData()
    {
        var listSP = from s in db.tbProductsTypes select s;
        cbbLoaiSanPham.DataSource = listSP;
        cbbLoaiSanPham.DataBind();
    }
    protected void save_ServerClick(object sender, EventArgs e)
    {
        if (cbbLoaiSanPham.Value != null)
        {
            if (_SanPham.validation(cbbLoaiSanPham.Value.ToString(), FileUpload, txtTenSanPham.Value
                , txtPrice.Value, txtSoLuong.Value, txtMoTa.Value, txtSize.Value, txtColor.Value))
            {
                saveUrlImg();
                if (_SanPham.Insert_SanPham(txtTenSanPham.Value, Convert.ToDecimal(txtPrice.Value), txtMoTa.Value
                    , urlImg, Convert.ToInt32(txtSoLuong.Value),
                    Convert.ToInt32(cbbLoaiSanPham.Value.ToString()), txtSize.Value, txtColor.Value))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Thêm thành công', '','success').then(function(){window.location = '/quan-ly-san-pham';})", true);
                }
                else alert.alert_Warning(Page, "Thêm thất bại", "");
            }
            else alert.alert_Warning(Page, "Bạn phải nhập đầy đủ dữ liệu", "");
        }
        else alert.alert_Warning(Page, "Bạn phải chọn loại sẩn phẩm", "");
    }
    protected void saveUrlImg()
    {
        try
        {
            if (Page.IsValid && FileUpload.HasFile)
            {
                String folderUser = Server.MapPath("~/images/SanPham/");
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                //string filename;
                string ulr = "/images/SanPham/";
                HttpFileCollection hfc = Request.Files;
                string filename = ulr + Path.GetRandomFileName() + Path.GetExtension(FileUpload.FileName);
                string path = HttpContext.Current.Server.MapPath("~/" + filename);
                FileUpload.SaveAs(path);
                urlImg = filename;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void changeStyle()
    {
        mainStyle = "display:block !important";
        if (cbbLoaiSanPham.Value.ToString() == "1")
        {
            style1 = style2 = "display:none; !important";
        }
        if (cbbLoaiSanPham.Value.ToString() == "2")
        {
            style1 = style2 = "display:block; !important";
        }
        if (cbbLoaiSanPham.Value.ToString() == "3")
        {
            style1 = "display:none; !important";
            style2 = "display:block; !important";
        }
    }
    protected void cbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbbLoaiSanPham.Value != null)
        {
            changeStyle();
        }
    }
}