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
}