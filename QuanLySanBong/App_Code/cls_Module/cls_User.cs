using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cls_User
/// </summary>
public class cls_User
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_User()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string User_getUserName(int id)
    {
        var getUserName = (from u in db.tbUsers where u.users_id == id select u).FirstOrDefault().users_fullname;

        return getUserName;
    }
    public string User_getUserFullName(string cookie)
    {
        var getUserFullName = (from u in db.tbUsers where u.users_account == cookie select u).FirstOrDefault().users_fullname;

        return getUserFullName;
    }
    public int User_getUserGroupId(string cookie)
    {
        var getUserGroupId = (from u in db.tbUsers where u.users_account == cookie select u).FirstOrDefault().group_user_id;

        return (int)getUserGroupId;
    }
    public int User_getUserId(string cookie)
    {
        var getUserId = (from u in db.tbUsers where u.users_account == cookie select u).FirstOrDefault().users_id;

        return getUserId;
    }
    public object User_getUserWithCookie(string cookie)
    {
        var getUser = (from u in db.tbUsers
                      where u.users_account == cookie
                      select new
                      {
                          u.users_account,
                          u.users_address,
                          u.users_email,
                          u.users_fullname,
                          //u.users_identity,
                          u.users_phoneNumber,
                          users_status = u.users_status == true ? "Đã kích hoạt" : "Chưa kích hoạt",
                      }).FirstOrDefault();

        return getUser;
    }
    public void User_getUserList(Repeater repeater)
    {
        var getUserList = from u in db.tbUsers
                          join pq in db.tbGroupUsers on u.group_user_id equals pq.group_user_id
                          select new
                          {
                              u.users_phoneNumber,
                              u.users_fullname,
                              u.users_account,
                              u.users_password,
                              u.users_address,
                              u.users_id,
                              users_status = u.users_status == true ? "Đã kích hoạt" : "Chưa kích hoạt",
                              pq.group_user_name,
                          };
        repeater.DataSource = getUserList;
        repeater.DataBind();
    }
    public bool User_Del(int idUser)
    {
        tbUser delete = db.tbUsers.Where(x => x.users_id == idUser).FirstOrDefault();
        db.tbUsers.DeleteOnSubmit(delete);
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