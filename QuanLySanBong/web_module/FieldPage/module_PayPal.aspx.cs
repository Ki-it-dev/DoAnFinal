using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_FieldPage_module_PayPal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtPrice.Value = Context.Items["price"].ToString();
            txtFieldName.Value = Context.Items["fieldName"].ToString();
            TestPay();
        }
    }

    protected void TestPay()
    {
        var config = ConfigManager.Instance.GetProperties();
        var accessToken = new OAuthTokenCredential(config).GetAccessToken();
        var apiContext = new APIContext(accessToken);

        //var apiContext = PaypalConfiguration.GetAPIContext();
        string payerId = Request.Params["PayerID"];

        int tyGia = 23500;

        double gia = Convert.ToDouble(txtPrice.Value);

        string total = Math.Round(gia / tyGia, 2).ToString();

        if (string.IsNullOrEmpty(payerId))
        {
            var itemList = new ItemList()
            {
                items = new List<Item>()
                    {
                        new Item()
                        {
                            name = txtFieldName.Value,
                            currency = "USD",
                            price = total,
                            quantity = "1",
                            sku = "sku"
                        }
                    }
            };
            var payer = new Payer() { payment_method = "paypal" };
            var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/payPal?";
            var guid = Convert.ToString((new Random()).Next(100000));
            var redirectUrl = baseURI + "guid=" + guid;
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&cancel=true",
                return_url = redirectUrl
            };
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = total
            };
            var amount = new Amount()
            {
                currency = "USD",
                total = total, // Total must be equal to sum of shipping, tax and subtotal.
                details = details
            };
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Transaction description.",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = itemList
            });
            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            var createdPayment = Payment.Create(apiContext, payment);

            var links = createdPayment.links.GetEnumerator();
            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    Response.Redirect(link.href);
                }
            }
            Session.Add(guid, createdPayment.id);
        }
        else
        {
            var guid = Request.Params["guid"];
            var paymentId = Session[guid] as string;
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            var payment = new Payment() { id = paymentId };
            var executedPayment = payment.Execute(apiContext, paymentExecution);
        }
    }
}