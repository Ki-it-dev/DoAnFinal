using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_SanPham
/// </summary>
public class cls_SanPham
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_SanPham()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SanPham_LoadDanhSachSanPham(Repeater repeater)
    {
        var getSanPham = from sp in db.tbProducts select sp;

        repeater.DataSource = getSanPham;
        repeater.DataBind();
    }
    public void SanPham_ShowDropDown(DropDownList dropDownList)
    {
        //Danh sach san pham
        var getSanPham = from sp in db.tbProducts
                         join t in db.tbProductsTypes on sp.typeProducts_id equals t.typeProducts_id
                         group sp by new
                         {
                             sp.typeProducts_id,
                         }into k
                         select new
                         {
                             typeProducts_id = k.Key.typeProducts_id,
                             typeProducts_name = (from p in db.tbProducts 
                                                  join t in db.tbProductsTypes on p.typeProducts_id equals t.typeProducts_id
                                                  where p.typeProducts_id == k.Key.typeProducts_id select t.typeProducts_name).FirstOrDefault(),
                         };
        //Dropdown list san pham
        dropDownList.Items.Clear();
        dropDownList.Items.Insert(0, "Chọn sản phẩm");
        dropDownList.AppendDataBoundItems = true;
        dropDownList.DataTextField = "typeProducts_name";
        dropDownList.DataValueField = "typeProducts_id";
        dropDownList.DataSource = getSanPham;
        dropDownList.DataBind();
    }
    public void SanPham_LoadWithDropDown(int idTypeProducts,Repeater repeater)
    {
        var getSanPham = from sp in db.tbProducts
                         join t in db.tbProductsTypes on sp.typeProducts_id equals t.typeProducts_id
                         where t.typeProducts_id == idTypeProducts
                         select sp;

        repeater.DataSource = getSanPham;
        repeater.DataBind();
    }
}