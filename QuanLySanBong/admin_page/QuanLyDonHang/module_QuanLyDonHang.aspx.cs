using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLyDonHang_module_QuanLyDonHang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    cls_HoaDonSanPham _HoaDonSanPham = new cls_HoaDonSanPham();
    cls_Alert _Alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack) loadData();
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
    }

    protected void loadData()
    {
        var bills = (from b in db.tbBillInfos
                     join pb in db.tbProductBills on b.bill_info_id equals pb.bill_info_id
                     //join t in db.tbTempTransactions on b.trans_id equals t.temp_transaction_id
                     join sp in db.tbProducts on pb.product_id equals sp.products_id
                     join u in db.tbUsers on b.emp_id equals u.users_id
                     group b by new { b.bill_info_id } into k
                     select new
                     {
                         k.Key.bill_info_id,
                         products_name = (from p in db.tbProducts
                                          join ppb in db.tbProductBills on p.products_id equals ppb.product_id
                                          where ppb.bill_info_id == k.Key.bill_info_id
                                          select p.products_name).FirstOrDefault(),
                         soLuong = (from p in db.tbProducts
                                    join ppb in db.tbProductBills on p.products_id equals ppb.product_id
                                    where ppb.bill_info_id == k.Key.bill_info_id
                                    select p.products_name).Count(),
                         data_create = (from ppb in db.tbBillInfos
                                        where ppb.bill_info_id == k.Key.bill_info_id
                                        select ppb.data_create).FirstOrDefault(),
                         //field_id = (from p in db.tbFields
                         //            join tt in db.tbTempTransactions on p.field_id equals tt.field_id
                         //            join ppb in db.tbBillInfos on tt.temp_transaction_id equals ppb.trans_id
                         //            where ppb.bill_info_id == k.Key.bill_info_id
                         //            select p.field_id).FirstOrDefault(),
                         users_fullname = (from p in db.tbUsers
                                           join ppb in db.tbBillInfos on p.users_id equals ppb.emp_id
                                           where ppb.bill_info_id == k.Key.bill_info_id
                                           select p.users_fullname).FirstOrDefault(),
                         total = (from p in db.tbProducts
                                  join ppb in db.tbProductBills on p.products_id equals ppb.product_id
                                  join bi in db.tbBillInfos on ppb.bill_info_id equals bi.bill_info_id
                                  //join s in db.tbTempTransactions on bi.trans_id equals s.temp_transaction_id
                                  //join ss in db.tbFields on s.field_id equals ss.field_id
                                  //join ty in db.tbFieldTypes on ss.field_type_id equals ty.field_type_id
                                  where ppb.bill_info_id == k.Key.bill_info_id
                                  select (p.products_price * ppb.quantity) /*+ ty.price*/).Sum(),
                     });

        rpDonHang.DataSource = bills;
        rpDonHang.DataBind();
    }

    protected void addDonHang_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/them-don-hang");
    }

    protected void btnXoaServer_ServerClick(object sender, EventArgs e)
    {
        string _idBill = txtBillInfoId.Value;

        if (_HoaDonSanPham.del_HoaDon(Convert.ToInt32(_idBill))){
            _Alert.alert_Success(Page, "Xóa thành công", "");
        }
        else _Alert.alert_Warning(Page, "Xóa thất bại", "");
        loadData();
    }
}