using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_LoaiSan
/// </summary>
public class cls_LoaiSan
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_LoaiSan()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Load_DanhSachLoaiSan(Repeater repeater)
    {
        var result = (from t in db.tbFieldTypes select t);

        if (result.Count() > 0)
        {
            repeater.DataSource = result;
            repeater.DataBind();
        }
    }
    public bool Insert_LoaiSan(string _name, decimal _price)
    {
        tbFieldType insert = new tbFieldType();
        insert.field_type_name = _name;
        insert.price = _price;
        db.tbFieldTypes.InsertOnSubmit(insert);
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
    public bool Update_LoaiSan(int _id, string _name, decimal _price)
    {
        tbFieldType update = db.tbFieldTypes.Where(x => x.field_type_id == _id).FirstOrDefault();
        update.field_type_name = _name;
        update.price = _price;
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
    public bool Delete_LoaiSan(int _id)
    {
        tbFieldType del = db.tbFieldTypes.Where(x => x.field_type_id == _id).FirstOrDefault();
        db.tbFieldTypes.DeleteOnSubmit(del);
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
}