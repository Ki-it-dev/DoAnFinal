using DevExpress.Web.Internal;
using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_San
/// </summary>
public class cls_San
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    private const string styleDefault = "min-width:100px;min-height:20px;";

    public cls_San()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Lay gia tien theo san
    public decimal San_GiaTienTheoSan(int idSan)
    {
        var getPrice = (from s in db.tbFields
                        join ts in db.tbFieldTypes on s.field_type_id equals ts.field_type_id
                        where s.field_id == idSan
                        select ts.price).FirstOrDefault();

        return Convert.ToDecimal(getPrice);
    }
    //Danh sach nhom theo then san
    public void San_DanhSachNhomTheoTenSan(Repeater repeater)
    {
        //Danh sach san
        var getData = (from l in db.tbFieldTypes
                       join ls in db.tbFields on l.field_type_id equals ls.field_type_id
                       where ls.field_status == true
                       group ls by new { ls.field_name } into k
                       select new
                       {
                           field_name = k.Key.field_name,
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
    //Danh sach san cho nguoi dung
    public void San_DanhSachSan(Repeater repeater)
    {
        //Danh sach san
        var getData = (from l in db.tbFieldTypes
                       join ls in db.tbFields on l.field_type_id equals ls.field_type_id
                       where ls.field_status == true
                       group ls by new { ls.field_name } into k
                       select new
                       {
                           field_type_id = (from t in db.tbFields where t.field_name == k.Key.field_name select t.field_type_id).FirstOrDefault(),
                           field_name = k.Key.field_name,
                           field_status = (from s in db.tbFields
                                           where s.field_name == k.Key.field_name
                                           select s.field_status).FirstOrDefault() == true
                                           ? "Đang hoạt động" : "Không hoạt động",
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
    //Danh sach san theo loai san
    public void San_DanhSachSanTheoLoaiSan(Repeater repeater, string name)
    {
        //Danh sach san
        var getData = (from l in db.tbFieldTypes
                       join ls in db.tbFields on l.field_type_id equals ls.field_type_id
                       where ls.field_status == true && l.field_type_name == name
                       select new
                       {
                           ls.field_id,
                           ls.field_name,
                           l.field_type_name,
                           field_status = ls.field_status == true ? "Đang hoạt động" : "Không hoạt động",
                       });

        if (getData.Any())
        {
            repeater.DataSource = getData;
            repeater.DataBind();
        }
    }
    //Danh sach khung gio
    public void San_DanhSachKhungGio(Repeater repeater)
    {
        var getBookTime = from bt in db.tbBookTimes
                          where bt.book_time_status == true
                          select new
                          {
                              bt.book_time_id,
                              bt.book_time_detail,
                          };

        repeater.DataSource = getBookTime;
        repeater.DataBind();
    }
    //Khach da dat san
    public string San_DatSan(int trangThaiSan, DateTime dateBook, int returnType)
    {
        var getTimeBook = (from st in db.tbTempTransactions
                           join ss in db.tbFields on st.field_id equals ss.field_id
                           join bt in db.tbBookTimes on st.book_time_id equals bt.book_time_id
                           where
                           st.transaction_status == trangThaiSan
                           && st.transaction_bookdate == dateBook
                           && ss.field_status == true
                           select new
                           {
                               st.book_time_id,
                               st.field_id,
                           });
        if (returnType == 1)
            return string.Join(",", getTimeBook.Select(x => x.field_id));//id san
        return string.Join(",", getTimeBook.Select(x => x.book_time_id));//id time
    }
    //San cho nhan vien xac nhan
    public int San_ChoXacNhan(int idSan, int idGio, DateTime dateBook)
    {
        var getData = (from st in db.tbTempTransactions
                       join ss in db.tbFields on st.field_id equals ss.field_id
                       join bt in db.tbBookTimes on st.book_time_id equals bt.book_time_id
                       where
                       st.field_id == idSan
                       && bt.book_time_id == idGio
                       && st.transaction_status == 0
                       && ss.field_status == true
                       && st.transaction_bookdate == dateBook
                       select new
                       {
                           st.field_id,
                           st.book_time_id,
                       }).Count();
        return getData;
    }
    //Load theo khung gio trong san ngay hien tai
    public void San_LoadGioTheoSanNgayHienTai(string idBookTime, Repeater repeater)
    {
        var getSanDat = from bt in db.tbBookTimes
                            //join t in db.tbTempTransactions on bt.book_time_id equals t.book_time_id
                        join f in db.tbFields on bt.book_time_type equals f.book_time_type
                        where bt.book_time_id == int.Parse(idBookTime) && f.field_status == true
                        select new
                        {
                            bt.book_time_id,
                            f.field_id,
                            style = Convert.ToInt32(bt.book_time_detail.Substring(0, 2)) < DateTime.Now.Hour ? "pointer-events: none;background:aqua;" + styleDefault : styleDefault,
                        };

        repeater.DataSource = getSanDat;
        repeater.DataBind();
    }
    //Load theo khung gio trong san ngay khac
    public void San_LoadGioTheoSanNgayKhac(string idBookTime, Repeater repeater)
    {
        var getSanDat = from bt in db.tbBookTimes
                            //join s in db.tbTempTransactions on bt.book_time_id equals s.book_time_id
                        join f in db.tbFields on bt.book_time_type equals f.book_time_type
                        where bt.book_time_id == int.Parse(idBookTime) && f.field_status == true
                        select new
                        {
                            bt.book_time_id,
                            f.field_id,
                            style = styleDefault,
                        };

        repeater.DataSource = getSanDat;
        repeater.DataBind();
    }
    //Get ten san
    public string San_TenSan(int idSan)
    {
        var getSan = from s in db.tbFields where s.field_id == idSan && s.field_status == true select s;

        return getSan.FirstOrDefault().field_name;
    }
    //Get id theo loai san
    public int San_LoaiSan(string loaiSan)
    {
        int getId = (from s in db.tbFieldTypes where s.field_type_name == loaiSan select s.field_type_id).FirstOrDefault();

        return getId;
    }
    //Show ra san cua tung tai khoan
    public void San_ShowAcc(int userId, Repeater repeater)
    {
        //Lay ra toan bo san da dat
        var getData = (from t in db.tbTempTransactions
                       join f in db.tbFields on t.field_id equals f.field_id
                       join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                       where t.users_id == userId && f.field_status == true
                       select new
                       {
                           transaction_datetime = DateTime.Parse(t.transaction_datetime.ToString()).ToString("dd-MM-yyyy"),
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("dd-MM-yyyy"),
                           f.field_name,
                           bt.book_time_detail,
                           f.field_id,
                           bt.book_time_id,

                           t.temp_transaction_id,

                           daXacNhan = t.transaction_status == 1 ? "display:block" : "display:none",
                           choXacNhan = t.transaction_status == 0 ? "display:block" : "display:none",
                           huy = t.transaction_status == 0 ? "display:block" : "display:none",
                           chinhSua = t.transaction_status == 0 ? "display:block" : "display:none",
                           daHuy = t.transaction_status == -1 ? "display:block" : "display:none",
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
    public bool San_HuySan(int idTrans)
    {
        tbTempTransaction del = db.tbTempTransactions.Where(x => x.temp_transaction_id == idTrans).FirstOrDefault();

        tbAlert delAlert = db.tbAlerts.Where(x => x.trans_id == del.temp_transaction_id).FirstOrDefault();

        db.tbTempTransactions.DeleteOnSubmit(del);
        db.tbAlerts.DeleteOnSubmit(delAlert);

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
    //Them xoa sua san ben admin
    public bool SanAdmin_Sua(int _id, string _nameField, int _typeFieldId, bool status)
    {
        try
        {
            db.tbFields.Where(x => x.field_type_id == _id).ToList().ForEach(dv => dv.field_status = status);
            db.tbFields.Where(x => x.field_type_id == _id).ToList().ForEach(dv => dv.field_name = _nameField);
            db.tbFields.Where(x => x.field_type_id == _id).ToList().ForEach(dv => dv.field_type_id = _typeFieldId);

            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool SanAdmin_Them(string _nameField, int _typeFieldId, int _idTypeTime)
    {
        var listIdType = from b in db.tbBookTimes where b.book_time_type == _idTypeTime select b;
        string[] arrIdType = string.Join(",", listIdType.Select(x => x.book_time_id)).Split(',');
        try
        {
            //for (int i = 0; i < arrIdType.Length; i++)
            //{
            //    tbField insert = new tbField();
            //    insert.field_name = _nameField;
            //    insert.field_status = true;
            //    insert.field_type_id = _typeFieldId;
            //    insert.book_time_id = Convert.ToInt32(arrIdType[i]);
            //    db.tbFields.InsertOnSubmit(insert);
            //    db.SubmitChanges();
            //}
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool SanAdmin_Del(string name)
    {
        db.tbFields.Where(x => x.field_name == name).ToList().ForEach(dv => dv.field_status = false);

        //var del = db.tbFields.Where(x => x.field_name == name);

        //var delTrans = (from t in db.tbTempTransactions
        //                join s in db.tbFields on t.field_id equals s.field_id
        //                where s.field_name == name
        //                select t);

        //var delAlert = (from t in db.tbTempTransactions
        //                join s in db.tbFields on t.field_id equals s.field_id
        //                join a in db.tbAlerts on t.temp_transaction_id equals a.trans_id
        //                where s.field_name == name
        //                select a);

        //db.tbFields.DeleteAllOnSubmit(del);
        //db.tbTempTransactions.DeleteAllOnSubmit(delTrans);
        //db.tbAlerts.DeleteAllOnSubmit(delAlert);

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
    //Danh sach quan ly san admin
    public void SanDanhSachSan_Admin(Repeater repeater)
    {
        //Danh sach san
        var getData = (from l in db.tbFieldTypes
                       join ls in db.tbFields on l.field_type_id equals ls.field_type_id
                       group ls by new { ls.field_name } into k
                       select new
                       {
                           field_type_id = (from t in db.tbFields where t.field_name == k.Key.field_name select t.field_type_id).FirstOrDefault(),
                           field_name = k.Key.field_name,
                           field_status = (from s in db.tbFields
                                           where s.field_name == k.Key.field_name
                                           select s.field_status).FirstOrDefault() == true
                                           ? "Đang hoạt động" : "Không hoạt động",
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
}