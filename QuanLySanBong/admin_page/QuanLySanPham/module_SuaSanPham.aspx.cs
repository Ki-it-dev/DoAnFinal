using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLySanPham_module_SuaSanPham : System.Web.UI.Page
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
        }
    }
    protected void loadData()
    {
        string _idProduct = Request.Url.Segments.Last().Replace("-", "").Substring(14);
        var listSP = from s in db.tbProductsTypes select s;
        cbbLoaiSanPham.DataSource = listSP;
        cbbLoaiSanPham.DataBind();

        var _idTypeProducts = (from s in db.tbProducts
                               join t in db.tbProductsTypes on s.typeProducts_id equals t.typeProducts_id
                               where s.products_id == Convert.ToInt32(_idProduct)
                               select new { s.typeProducts_id, t.typeProducts_name, s }).FirstOrDefault();

        cbbLoaiSanPham.Text = _idTypeProducts.typeProducts_name;

        txtTenSanPham.Value = _idTypeProducts.s.products_name;
        txtSoLuong.Value = _idTypeProducts.s.products_quantity.ToString();
        txtSize.Value = _idTypeProducts.s.products_size;
        txtPrice.Value = _idTypeProducts.s.products_price.ToString();
        txtMoTa.Value = _idTypeProducts.s.products_description;
        txtColor.Value = _idTypeProducts.s.products_color;

        changeStyle(_idTypeProducts.typeProducts_id.ToString());
    }
    protected void changeStyle(string _idTypeProducts)
    {
        mainStyle = "display:block !important";
        if (_idTypeProducts == "1")
        {
            style1 = style2 = "display:none; !important";
        }
        if (_idTypeProducts == "2")
        {
            style1 = style2 = "display:block; !important";
        }
        if (_idTypeProducts == "3")
        {
            style1 = "display:none; !important";
            style2 = "display:block; !important";
        }
    }
    protected void cbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbbLoaiSanPham.Value != null)
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
    protected void save_ServerClick(object sender, EventArgs e)
    {
        string _idProduct = Request.Url.Segments.Last().Replace("-", "").Substring(14);
        if (cbbLoaiSanPham.Value != null)
        {
            if (_SanPham.validation(cbbLoaiSanPham.Value.ToString(), FileUpload, txtTenSanPham.Value
                , txtPrice.Value, txtSoLuong.Value, txtMoTa.Value, txtSize.Value, txtColor.Value))
            {
                saveUrlImg();
                if (_SanPham.Update_SanPham(Convert.ToInt32(_idProduct), txtTenSanPham.Value, Convert.ToDecimal(txtPrice.Value), txtMoTa.Value
                    , urlImg, Convert.ToInt32(txtSoLuong.Value),
                    Convert.ToInt32(cbbLoaiSanPham.Value.ToString()), txtSize.Value, txtColor.Value))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Cập nhật thành công', '','success').then(function(){window.location = '/quan-ly-san-pham';})", true);
                }
                else alert.alert_Warning(Page, "Cập nhật thất bại", "");
            }
            else alert.alert_Warning(Page, "Bạn phải nhập đầy đủ dữ liệu", "");
        }
        else alert.alert_Warning(Page, "Bạn phải chọn loại sẩn phẩm", "");
    }
}