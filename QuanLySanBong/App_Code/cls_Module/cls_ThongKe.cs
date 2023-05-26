using DevExpress.Data.Linq.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_ThongKe
/// </summary>
public class cls_ThongKe
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThongKe()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string GetSoLuongDatSanTheoThangVaNam(int year, int idTypeField)
    {
        List<decimal> listSanDaDatTrongThang = new List<decimal>();

        var getFieldType = (from fy in db.tbFieldTypes select fy);

        string[] arrFieldType = string.Join(",", getFieldType.Select(x => x.field_type_id)).Split(',');


        if (idTypeField == 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                decimal sum = 0;

                foreach (var item in arrFieldType)
                {
                    var countField = (from s in db.tbFields
                                      join t in db.tbTempTransactions on s.field_id equals t.field_id
                                      where t.transaction_bookdate.Value.Year == year && t.transaction_bookdate.Value.Month == i
                                      && t.transaction_status == 1 && s.field_type_id == Convert.ToInt32(item)
                                      select t).Count();

                    var get = (from s in db.tbFields
                               join ts in db.tbFieldTypes on s.field_type_id equals ts.field_type_id
                               join t in db.tbTempTransactions on s.field_id equals t.field_id
                               where t.transaction_bookdate.Value.Year == year && t.transaction_bookdate.Value.Month == i
                               && t.transaction_status == 1 && s.field_type_id == Convert.ToInt32(item)
                               //group ts by new {ts.field_type_id} into k
                               select new
                               {
                                   total = ts.price * countField,
                               });

                    if (get.Any())
                    {
                        sum += Convert.ToDecimal(get.FirstOrDefault().total);
                    }
                    else
                    {
                        sum += 0;
                    }
                }

                if (sum > 0)
                {
                    listSanDaDatTrongThang.Add(sum);
                }
                else
                {
                    listSanDaDatTrongThang.Add(0);
                }
            }
        }
        else
        {
            for (int i = 1; i <= 12; i++)
            {
                decimal sum = 0;

                foreach (var item in arrFieldType)
                {
                    var countField = (from s in db.tbFields
                                      join t in db.tbTempTransactions on s.field_id equals t.field_id
                                      where t.transaction_bookdate.Value.Year == year && t.transaction_bookdate.Value.Month == i
                                      && t.transaction_status == 1 && s.field_type_id == Convert.ToInt32(item)
                                      && s.field_type_id == idTypeField
                                      select t).Count();

                    var get = (from s in db.tbFields
                               join ts in db.tbFieldTypes on s.field_type_id equals ts.field_type_id
                               join t in db.tbTempTransactions on s.field_id equals t.field_id
                               where t.transaction_bookdate.Value.Year == year && t.transaction_bookdate.Value.Month == i
                               && t.transaction_status == 1 && s.field_type_id == Convert.ToInt32(item)
                               && s.field_type_id == idTypeField
                               select new
                               {
                                   total = ts.price * countField,
                               });

                    if (get.Any())
                    {
                        sum += Convert.ToDecimal(get.FirstOrDefault().total);
                    }
                    else
                    {
                        sum += 0;
                    }
                }

                if (sum > 0)
                {
                    listSanDaDatTrongThang.Add(sum);
                }
                else
                {
                    listSanDaDatTrongThang.Add(0);
                }
            }
        }

        return string.Join(",", listSanDaDatTrongThang.Select(x => x));
    }
    public string GetSoLuongDatHangTheoThangVaNam(int year)
    {
        List<decimal> listDonHang = new List<decimal>();

        for (int i = 1; i <= 12; i++)
        {
            var get = (from b in db.tbBillInfos
                       //join pb in db.tbProductBills on b.bill_info_id equals pb.bill_info_id
                       where b.data_create.Value.Year == year && b.data_create.Value.Month == i
                       select new
                       {
                           b.total,
                       });

            if (get.Any())
            {
                decimal totalSum = Convert.ToDecimal(get.Sum(x => x.total));

                listDonHang.Add(Convert.ToDecimal(totalSum));
            }
            else
            {
                listDonHang.Add(0);
            }
        }

        return string.Join(",", listDonHang.Select(x => x));
    }
    public string GetSoLuongNguoiDungDatSanTrongNam(int year)
    {
        List<int> listSoLuongNguoiDungDatSanTrongNam = new List<int>();

        var countAllUser = (from u in db.tbUsers where u.group_user_id == 3 && u.users_status == true select u).Count();

        var countUserDaDatSan = (from u in db.tbUsers
                                 where u.group_user_id == 3 && u.users_status == true
                                 join t in db.tbTempTransactions on u.users_id equals t.users_id
                                 where t.transaction_bookdate.Value.Year == year
                                 group t by new { t.users_id } into us
                                 select new
                                 {
                                     total = us.Key,
                                 }).Count();

        listSoLuongNguoiDungDatSanTrongNam.Add(countAllUser);

        if (countUserDaDatSan > 0)
        {
            listSoLuongNguoiDungDatSanTrongNam.Add(countUserDaDatSan);
        }
        else
        {
            listSoLuongNguoiDungDatSanTrongNam.Add(0);
        }

        return string.Join(",", listSoLuongNguoiDungDatSanTrongNam.Select(x => x));
    }

}