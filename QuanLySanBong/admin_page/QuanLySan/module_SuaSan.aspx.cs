﻿using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_QuanLySan_module_SuaSan : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_San san = new cls_San();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack) loadData();
        }
        else
        {
            Response.Redirect("/dang-nhap");
        }
        
    }
    protected void loadData()
    {
        string _id = Request.Url.Segments.Last().Replace("-", "").Substring(6);

        var field = (from s in db.tbFields
                     join tp in db.tbFieldTypes on s.field_type_id equals tp.field_type_id
                     where s.field_id == int.Parse(_id)
                     select new { s.field_name, s.field_status, tp.field_type_name, tp.field_type_id });

        cbbLoaiSan.Value = Convert.ToString(field.FirstOrDefault().field_type_name);
        ddlStatus.SelectedValue = Convert.ToString(field.FirstOrDefault().field_status);
        txtField.Value = field.FirstOrDefault().field_name;

        //Do danh sach loai san vao dropdown list
        var listSan = from s in db.tbFieldTypes select s;
        cbbLoaiSan.DataSource = listSan;
        cbbLoaiSan.DataBind();

    }
    protected void save_ServerClick(object sender, EventArgs e)
    {
        if (txtField.Value.Length > 0)
        {
            string _id = Request.Url.Segments.Last().Replace("-", "").Substring(6);

            int getTypeId = san.San_LoaiSan(cbbLoaiSan.Text);
            bool status = false;
            string tenSan = txtField.Value;

            if (ddlStatus.Text == "Đang hoạt động") status = true;

            if (san.SanAdmin_Sua(int.Parse(_id), tenSan, getTypeId, status))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
                        "AlertBox", "swal('Cập nhật thành công', '','success').then(function(){window.location = '/quan-ly-san';})", true);
            }
            else
            {
                alert.alert_Warning(Page, "Cập nhật thất bại!!!", "");
            }
        }
        else { alert.alert_Warning(Page, "Vui lòng nhập đầy đủ dữ liệu!!!", ""); }
    }
}