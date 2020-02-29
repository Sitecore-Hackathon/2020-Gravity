namespace Sitecore.Foundation.Accounts
{
    using Sitecore.Data;

    public struct Templates
    {
        public struct AccountsSettings
        {
            public static readonly ID ID = new ID("{24D14C1A-7975-47F5-885D-13FCA3930FA1}");

            public struct Fields
            {
                public static readonly ID RegisterPage = new ID("{461907A7-35E8-4CC4-BCBE-D18C223660A5}");
                public static readonly ID LoginPage = new ID("{8CF7D298-ED12-47A9-B968-8D2CAF8FCCD4}");
               public static readonly ID AfterLoginPage = new ID("{D9EDE02C-A980-4C88-A13F-AF7DFFCB2DDA}");
            }
        }

        public struct MailTemplate
        {
            public static readonly ID ID = new ID("{26DF8F38-7E1B-43D2-85DD-68DF05FA276B}");

            public struct Fields
            {
                public static readonly ID From = new ID("{8605948C-60FB-46B8-8AAA-4C52561B53BC}");
                public static readonly ID Subject = new ID("{0F45DF05-546F-462D-97C0-BA4FB2B02564}");
                public static readonly ID Body = new ID("{1519CCAD-ED26-4F60-82CA-22079AF44D16}");
            }
        }

       
       
    }
}