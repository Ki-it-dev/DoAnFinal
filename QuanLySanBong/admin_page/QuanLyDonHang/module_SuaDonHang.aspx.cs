using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyDonHang_module_SuaDonHang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_SanPham _SanPham = new cls_SanPham();
    cls_Alert _Alert = new cls_Alert();
    cls_HoaDonSanPham _HoaDonSanPham = new cls_HoaDonSanPham();
    cls_User _User = new cls_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string _idBill = Request.Url.Segments.Last().Replace("-", "").Substring(10);

            txtProductsName.Value = _SanPham.SanPham_LoadDanhSachTenSanPham();
            txtProductsId.Value = _SanPham.SanPham_LoadDanhSachIdSanPham();
            txtProductsPrice.Value = _SanPham.SanPham_LoadDanhSachGiaSanPham();

            txtQuantityOnServer.Value = _HoaDonSanPham.getAllQuantityProductInBill(Convert.ToInt32(_idBill));
            txtProductsNameOnServer.Value = _HoaDonSanPham.getAllProductInBill(Convert.ToInt32(_idBill));
            txtPriceOnServer.Value = _HoaDonSanPham.getAllPriceProductInBill(Convert.ToInt32(_idBill));
        }
    }

    protected void save_ServerClick(object sender, EventArgs e)
    {
        int _idUser = _User.User_getUserId(Request.Cookies["UserName"].Value);
        string _idBill = Request.Url.Segments.Last().Replace("-", "").Substring(10);

        decimal total = Convert.ToDecimal(txtTong.Value);

        string[] arrIdProducts = txtIdProductsSelect.Value.Split(',');
        string[] arrQuantitys = txtQuantitysProducts.Value.Split(',');

        if (_HoaDonSanPham.insert_ThongTinHoaDon(_idUser, 0, total))
        {
            int _idLastBill = (from b in db.tbBillInfos orderby b.bill_info_id descending select b.bill_info_id).FirstOrDefault();
            if (_HoaDonSanPham.update_HoaDon(_idUser, arrIdProducts, arrQuantitys, Convert.ToInt32(_idBill), total))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Cập nhật thành công', '','success').then(function(){window.location = '/quan-ly-don-hang';})", true);
            }
        }
        else _Alert.alert_Warning(Page, "Cập nhật thất bại!", "");
    }
}