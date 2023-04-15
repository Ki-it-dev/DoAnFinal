using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
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
        var getSanPham = (from sp in db.tbProducts select sp).OrderByDescending(x => x.products_id);

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
                         } into k
                         select new
                         {
                             typeProducts_id = k.Key.typeProducts_id,
                             typeProducts_name = (from p in db.tbProducts
                                                  join t in db.tbProductsTypes on p.typeProducts_id equals t.typeProducts_id
                                                  where p.typeProducts_id == k.Key.typeProducts_id
                                                  select t.typeProducts_name).FirstOrDefault(),
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
    public void SanPham_LoadWithDropDown(int idTypeProducts, Repeater repeater)
    {
        var getSanPham = from sp in db.tbProducts
                         join t in db.tbProductsTypes on sp.typeProducts_id equals t.typeProducts_id
                         where t.typeProducts_id == idTypeProducts
                         select sp;

        repeater.DataSource = getSanPham;
        repeater.DataBind();
    }
    public bool Insert_SanPham(string name, decimal price, string descrip, string img, int quantity, int _idTypeProdcut, string size, string color)
    {
        tbProduct insert = new tbProduct();

        insert.products_name = name;
        insert.products_price = price;
        insert.products_description = descrip;
        insert.products_quantity = quantity;
        insert.producst_picture = img;
        insert.typeProducts_id = _idTypeProdcut;

        if (_idTypeProdcut == 1)
        {
            insert.products_color = null;
            insert.products_size = null;
        }
        if (_idTypeProdcut == 2)
        {
            insert.products_color = color;
            insert.products_size = size;
        }
        if (_idTypeProdcut == 3)
        {
            insert.products_size = size;
            insert.products_color = null;
        }

        db.tbProducts.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch { return false; }
    }
    public bool Update_SanPham(int _id,string name, decimal price, string descrip, string img, int quantity, int _idTypeProdcut, string size, string color)
    {
        tbProduct update = db.tbProducts.Where(x => x.products_id == _id).FirstOrDefault();

        update.products_name = name;
        update.products_price = price;
        update.products_description = descrip;
        update.products_quantity = quantity;
        update.producst_picture = img;
        update.typeProducts_id = _idTypeProdcut;

        if (_idTypeProdcut == 1)
        {
            update.products_color = null;
            update.products_size = null;
        }
        if (_idTypeProdcut == 2)
        {
            update.products_color = color;
            update.products_size = size;
        }
        if (_idTypeProdcut == 3)
        {
            update.products_size = size;
            update.products_color = null;
        }

        try
        {
            db.SubmitChanges();
            return true;
        }
        catch { return false; }
    }
    public bool Delete_SanPham(int _id)
    {
        tbProduct del = db.tbProducts.Where(x => x.products_id == _id).FirstOrDefault();
        db.tbProducts.DeleteOnSubmit(del);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool validation(string _idTypeProducts, FileUpload file,
        string tenSanPham, string gia, string soLuong, string moTa, string size, string color)
    {
        if (tenSanPham.Length == 0
                || gia.Length == 0
                || soLuong.Length == 0
                || moTa.Length == 0)
        {
            return false;
        }
        if (file.HasFile == false) return false;

        if (_idTypeProducts == "2")
        {
            if (size.Length == 0 || size.All(Char.IsLetter) == false
                || color.Length == 0)
            {
                return false;
            }
        }
        if (_idTypeProducts == "3")
        {
            if (size.Length == 0 || size.All(Char.IsDigit) == false)
            {
                return false;
            }
        }

        return true;
    }
}