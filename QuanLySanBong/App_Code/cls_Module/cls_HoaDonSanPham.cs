using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_HoaDonSanPham
/// </summary>
public class cls_HoaDonSanPham
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_HoaDonSanPham()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool insert_ThongTinHoaDon(int _idEmploy, int _idTrans)
    {
        tbBillInfo insert = new tbBillInfo();

        insert.data_create = DateTime.Now;
        insert.trans_id = _idTrans;
        insert.emp_id = _idEmploy;

        db.tbBillInfos.InsertOnSubmit(insert);
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
    public bool insert_HoaDonChiTiet(int _idBillInfo, string[] _idProduct, string[] _quantity)
    {
        for (int i = 0; i < _idProduct.Length; i++)
        {
            tbProductBill insert = new tbProductBill();

            insert.bill_info_id = _idBillInfo;
            insert.product_id = Convert.ToInt32(_idProduct[i]);
            insert.quantity = Convert.ToInt32(_quantity[i]);
            db.tbProductBills.InsertOnSubmit(insert);
            db.SubmitChanges();
        }

        try
        {
            
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool update_HoaDon(int _idEmploy,int _idTrans, string[] _idProduct, string[] _quantity,int _idBillInfo)
    {
        //Cap nhat du lieu
        tbBillInfo update = db.tbBillInfos.Where(x=>x.bill_info_id == _idBillInfo).FirstOrDefault();

        update.trans_id = _idTrans;
        update.emp_id = _idEmploy;
        //Xoa het du lieu ton tai vs id bill info bang nhau
        var del = db.tbProductBills.Where(x => x.bill_info_id == _idBillInfo);
        db.tbProductBills.DeleteAllOnSubmit(del);
        //Chen lai du lieu
        insert_HoaDonChiTiet(_idBillInfo,_idProduct, _quantity);

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