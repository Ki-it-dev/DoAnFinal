using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_San : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    cls_San cls_San = new cls_San();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData(DateTime.Now.Date);
        }
        dteNgayBatDau.Value = DateTime.Now.ToString("yyyy-MM-dd").Replace(' ', 'T');
    }
    //Load ngay hien tai
    protected void loadData(DateTime date)
    {
        //Danh sach san
        cls_San.San_DanhSachNhomTheoTenSan(rpDanhSachSan);
        //Danh sach khung gio
        cls_San.San_DanhSachKhungGio(rpKhungGio);
        //Khach da dat san
        txtIdSanDaDat.Value = cls_San.San_DatSan(1, date, 1);
        txtIdTimeDaDat.Value = cls_San.San_DatSan(1, date, 0);
        //Khach da dat san nhung cho nhan vien xac nhan
        txtIdSanCho.Value = cls_San.San_DatSan(0, date, 1);
        txtIdTimeCho.Value = cls_San.San_DatSan(0, date, 0);
    }
    //Load ngay khac
    protected void btnDatSan_ServerClick(object sender, EventArgs e)
    {
        DateTime dateTime = Convert.ToDateTime(txtTimeDatTruoc.Value);
        dteNgayBatDau.Value = dateTime.ToString("yyyy-MM-dd").Replace(' ', 'T');
        loadData(dateTime);
    }

    protected void btnXemTrangThaiSan_ServerClick(object sender, EventArgs e)
    {
        int _idSan = int.Parse(txtIdSan.Value);
        int _idGio = int.Parse(txtIdGio.Value);

        string _idTime = DateTime.Parse(txtDateTime.Value).ToString("yyyy-MM-dd");

        if (cls_San.San_ChoXacNhan(_idSan, _idGio, Convert.ToDateTime(_idTime)) > 0)
        {
            alert.alert_Info(Page, "Sân đang được chờ xác nhận", "");
        }
        else
        {
            if (Request.Cookies["UserName"] == null)
            {
                alert.alert_Warning(Page, "Bạn phải đăng nhập để được đặt sân", "");
            }
            else
            {
                Context.Items["_idSan"] = _idSan;
                Context.Items["_idGio"] = _idGio;
                Context.Items["_idTime"] = _idTime;
                Server.Transfer("web_module/FieldPage/module_XacNhanDatSan.aspx");
            }
        }
    }

    protected void rpKhungGio_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpSanDat = e.Item.FindControl("rpSanDat") as Repeater;

        string book_time_id = DataBinder.Eval(e.Item.DataItem, "book_time_id").ToString();

        if (dteNgayBatDau.Value == "" || dteNgayBatDau.Value == DateTime.Now.ToString("yyyy-MM-dd").Replace(' ', 'T'))
        {
            cls_San.San_LoadGioTheoSanNgayHienTai(book_time_id, rpSanDat);
        }
        else cls_San.San_LoadGioTheoSanNgayKhac(book_time_id, rpSanDat);
    }
}