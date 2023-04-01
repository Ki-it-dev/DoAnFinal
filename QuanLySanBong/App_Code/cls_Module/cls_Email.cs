using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for cls_Email
/// </summary>
public class cls_Email
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    public cls_Email()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    public void sendCode(string name, string email, string code)
    {
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new System.Net.NetworkCredential("khoale548@gmail.com", "pktfimfetvjhjyty");
        smtpClient.EnableSsl = true;

        MailMessage msg = new MailMessage();
        msg.Subject = "Activity Code to Verify Email Address";
        msg.Body = "Dear " + name + ", Your Activation Code is " + code + "\n\n\nThanks";
        string toAddress = email;
        msg.To.Add(toAddress);
        string fromAddress = "DevKhoa<Khoale548@gmail.com>";
        msg.From = new MailAddress(fromAddress);

        try
        {
            smtpClient.Send(msg);
        }
        catch
        {
            throw;
        }
    }

    public void sendCodePass(string email,string code)
    {
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new System.Net.NetworkCredential("khoale548@gmail.com", "pktfimfetvjhjyty");
        smtpClient.EnableSsl = true;

        MailMessage msg = new MailMessage();
        msg.Subject = "Activity Code to Change Password";
        msg.Body = "Your code is " + code + "\n\n\nThanks";
        string toAddress = email;
        msg.To.Add(toAddress);
        string fromAddress = "DevKhoa<Khoale548@gmail.com>";
        msg.From = new MailAddress(fromAddress);

        try
        {
            smtpClient.Send(msg);
        }
        catch
        {
            throw;
        }
    }
}