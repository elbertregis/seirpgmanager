using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using SeiRPGManager.Web.Models;

namespace SeiRPGManager.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "00000000401012A6",
                clientSecret: "OFsGrczOKMMQ3ZXw8SGbiCRJY06BSMQ0");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "200897288-xkMPmp4oQnnga28t7oDkJg1yojGyi2UATpgDyFtP",
                consumerSecret: "g9Up7KRFhUFas6AAlISdBo58YnQxyxoZg6tNJBHo");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "625992587426055",
                appSecret: "917fa69575e8befdebd0cf79988c9c84");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
