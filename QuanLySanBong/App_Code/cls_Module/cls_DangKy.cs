using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_DangKy
/// </summary>
public class cls_DangKy
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    public cls_DangKy()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool DangKy_KiemTraCapNhapTaiKhoan(string phoneNumber,
        string email, string fullName,string add)
    {
        if (/*userName == "" ||*/ email == "" ||
            /*identity.Value == "" || */fullName == "" || phoneNumber == "" || add == "") return false;
        return true;
    }
    public bool DangKy_KiemTraNhap(string phoneNumber,
        string userName, string pass, string repPass, string email, string fullName)
    {
        if (userName == "" || pass == "" ||
            repPass == "" || email == "" ||
            /*identity.Value == "" || */fullName == "" || phoneNumber == "") return false;
        return true;
    }

    public bool DangKy_KiemTraNhapLaiMatKhau(string pass, string repPass)
    {
        if (pass != repPass) return false;
        return true;
    }

    public bool DangKy_KiemTraTonTai(string check,string[] arrCheck)
    {
        for (int i = 0; i < arrCheck.Length; i++)
            if (check == arrCheck[i]) 
                return false;
        return true;
    }

    public bool DangKy_Them(string phoneNumber,
        string userName, string pass, string email, string fullName,string code)
    {
        tbUser insert = new tbUser();

        insert.group_user_id = 3;
        insert.users_password = pass;
        insert.users_account = userName;
        insert.users_fullname = fullName;
        insert.users_phoneNumber = phoneNumber;
        insert.users_email = email.Trim();
        insert.users_status = false;
        insert.users_codeActivityEmail = code;

        db.tbUsers.InsertOnSubmit(insert);

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
    public bool DangKy_CapNhat(string phoneNumber,
        string add, string email, string fullName,int idUser)
    {
        var update = db.tbUsers.Where(x => x.users_id == idUser).FirstOrDefault();

        update.users_fullname = fullName;
        update.users_phoneNumber = phoneNumber;
        update.users_email = email;
        update.users_address = add;

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
    public bool DangKy_CapNhat_Admin(string phoneNumber,
        string add, string email, string fullName, int idUser,int phanQuyen,string status)
    {
        var update = db.tbUsers.Where(x => x.users_id == idUser).FirstOrDefault();

        update.users_fullname = fullName;
        update.users_phoneNumber = phoneNumber;
        update.users_email = email;
        update.users_address = add;
        update.group_user_id = phanQuyen;

        if(status == "Kích hoạt")
            update.users_status = true;
        else update.users_status = false;

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
    public int DangKy(string phoneNumber,string userName,string email)
    {
        //Lay tai khoan trong CSDL
        var getAccount = from u in db.tbUsers select u;

        //Kiem tra tai khoan
        if (getAccount.Count() > 0)
        {
            string[] arrAcc = string.Join(",", getAccount.Select(x => x.users_account)).Split(',');
            string[] arrPhone = string.Join(",", getAccount.Select(x => x.users_phoneNumber)).Split(',');
            string[] arrEmail = string.Join(",", getAccount.Select(x => x.users_email.Trim())).Split(',');

            if (DangKy_KiemTraTonTai(userName,arrAcc) != true)
            {
                return 1;//Tai khoan ton tai
            }
            if(DangKy_KiemTraTonTai(phoneNumber, arrPhone) != true)
            {
                return 2;//So dien thoai ton tai
            }
            if (DangKy_KiemTraTonTai(email, arrEmail) != true)
            {
                return 3;//Email ton tai
            }
        }
        return 0;
    }
    //User
    public int KiemTraCapNhatTaiKhoan(string phoneNumber,int idUser)
    {
        //Lay tai khoan trong CSDL
        var getAccount = from u in db.tbUsers select u;

        //Kiem tra tai khoan
        if (getAccount.Count() > 0)
        {
            var getNumPhoneUser = (from u in db.tbUsers
                                  where u.users_id == idUser
                                  select u).First().users_phoneNumber;

            string[] arrPhone = string.Join(",", getAccount.Select(x => x.users_phoneNumber)).Split(',');

            if(getNumPhoneUser == phoneNumber)
            {
                return 0;
            }
            
            if (DangKy_KiemTraTonTai(phoneNumber, arrPhone) != true)
            {
                return 1;//So dien thoai ton tai
            }
        }
        return 0;
    }
}