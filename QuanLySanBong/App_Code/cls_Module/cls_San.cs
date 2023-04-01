using System;
using System.Collections.Generic;
using System.Linq;
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
    //Danh sach san
    public void San_DanhSachSan(Repeater repeater)
    {
        //Danh sach san
        var getData = (from l in db.tbFieldTypes
                       join ls in db.tbFields on l.field_type_id equals ls.field_type_id
                       select new
                       {
                           ls.field_id,
                           ls.field_name,
                           l.field_type_name,
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
    //Danh sach khung gio
    public void San_DanhSachKhungGio(Repeater repeater)
    {
        var getBookTime = from bt in db.tbBookTimes
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
        var getTimeBook = (from p in db.tbPrices
                           join bt in db.tbBookTimes on p.book_time_id equals bt.book_time_id
                           join ss in db.tbFields on p.field_type_id equals ss.field_type_id
                           join st in db.tbTempTransactions on ss.field_id equals st.field_id
                           //join tta in db.tbTempTransactionAdmins on s.field_id equals tta.field_id
                           //join st in db.tbTransactions on tta.temp_transaction_id equals st.temp_transaction_id
                           where st.transaction_status == trangThaiSan
                           //&& st.transaction_bookdate.Value.Day == dateBook.Day
                           //&& st.transaction_bookdate.Value.Month == dateBook.Month
                           //&& st.transaction_bookdate.Value.Year == dateBook.Year
                           && st.transaction_bookdate == dateBook
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
        var getData = (from p in db.tbPrices
                       join bt in db.tbBookTimes on p.book_time_id equals bt.book_time_id
                       join s in db.tbFields on p.field_type_id equals s.field_type_id
                       join st in db.tbTempTransactions on s.field_id equals st.field_id
                       where
                       st.field_id == idSan
                       && st.book_time_id == idGio
                       && st.transaction_status == 0
                       //&& st.transaction_bookdate.Value.Day == dateBook.Day
                       //&& st.transaction_bookdate.Value.Month == dateBook.Month
                       //&& st.transaction_bookdate.Value.Year == dateBook.Year
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
        //var getBookTime = from bt in db.tbBookTimes
        //                  select new
        //                  {
        //                      bt.book_time_id,
        //                      bt.book_time_detail,
        //                      field_id = idSan,
        //                      style = Convert.ToInt32(bt.book_time_detail.Substring(0, 2)) < DateTime.Now.Hour ? "pointer-events: none;background:aqua" : "",
        //                  };
        var getSanDat = from bt in db.tbBookTimes
                        join p in db.tbPrices on bt.book_time_id equals p.book_time_id
                        join f in db.tbFields on p.field_type_id equals f.field_type_id
                        where bt.book_time_id == int.Parse(idBookTime)
                        select new
                        {
                            bt.book_time_id,
                            f.field_id,
                            style = Convert.ToInt32(bt.book_time_detail.Substring(0, 2)) < DateTime.Now.Hour ? "pointer-events: none;background:aqua;"+ styleDefault : styleDefault,
                        };

        repeater.DataSource = getSanDat;
        repeater.DataBind();
    }
    //Load theo khung gio trong san ngay khac
    public void San_LoadGioTheoSanNgayKhac(string idBookTime, Repeater repeater)
    {
        //var getBookTime = from bt in db.tbBookTimes
        //                  select new
        //                  {
        //                      bt.book_time_id,
        //                      bt.book_time_detail,
        //                      field_id = idSan,
        //                      style = "",
        //                  };
        var getSanDat = from bt in db.tbBookTimes
                        join p in db.tbPrices on bt.book_time_id equals p.book_time_id
                        join f in db.tbFields on p.field_type_id equals f.field_type_id
                        where bt.book_time_id == int.Parse(idBookTime)
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
        var getSan = from s in db.tbFields where s.field_id == idSan select s;

        return getSan.FirstOrDefault().field_name;
    }
    //Show ra san cua tung tai khoan
    public void San_ShowAcc(int userId, Repeater repeater)
    {
        //Lay ra toan bo san da dat
        var getData = (from t in db.tbTempTransactions
                       join f in db.tbFields on t.field_id equals f.field_id
                       join bt in db.tbBookTimes on t.book_time_id equals bt.book_time_id
                       where t.users_id == userId
                       select new
                       {
                           transaction_datetime = DateTime.Parse(t.transaction_datetime.ToString()).ToString("yyyy-MM-dd"),
                           transaction_bookdate = DateTime.Parse(t.transaction_bookdate.ToString()).ToString("yyyy-MM-dd"),
                           f.field_name,
                           bt.book_time_detail,
                           f.field_id,
                           bt.book_time_id,

                           daXacNhan = t.transaction_status == 1 ? "display:block" : "display:none",
                           choXacNhan = t.transaction_status == 0 ? "display:block" : "display:none",
                           huy = t.transaction_status == 0 ? "display:block" : "display:none",
                           chinhSua = t.transaction_status == 0 ? "display:block" : "display:none",
                           daHuy = t.transaction_status == -1 ? "display:block" : "display:none",
                       });

        repeater.DataSource = getData;
        repeater.DataBind();
    }
    public bool San_HuySan(int idSan, int idGio, int idUser)
    {
        tbTempTransaction del = db.tbTempTransactions.Where
            (x => x.field_id == idSan &&
            x.book_time_id == idGio &&
            x.users_id == idUser).FirstOrDefault();
        db.tbTempTransactions.DeleteOnSubmit(del);
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