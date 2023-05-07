using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaypalConfiguration
/// </summary>
public class PaypalConfiguration
{
    public readonly static string clientId;
    public readonly static string clientSecret;

    static PaypalConfiguration()
    {
        var config = getconfig();
        clientId = "AbVsY6_J8Q5Y7UjjZLc4eXkbUFLLuhz2L9ukGdRvNRdpZYzppqIPq8-aK6_7K4n_s5-q31rpHbXDyYWO";
        clientSecret = "EBryXa8OPdP9KjVHqX3IVYvF2m1CPrhwLqNqtYthhFrnWdtGMxgyqKz21fGCcrIf3czRc0BREYM3FTnE";
    }


    private static Dictionary<string, string> getconfig()
    {
        return PayPal.Api.ConfigManager.Instance.GetProperties();
    }

    private static string GetAccessToken()
    {
        string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
        return accessToken;
    }
    public static APIContext GetAPIContext()
    {
        APIContext apicontext = new APIContext(GetAccessToken());
        apicontext.Config = getconfig();
        return apicontext;
    }
}