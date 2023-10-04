using Microsoft.AspNetCore.DataProtection;

namespace Loja_Games.Security
{
    public class Settings
    {
        private static string secret = "b9448e1ccb3a2330537fea57b35b352134485e98cb6744b3c80d4eddca70eb5a";

            public static string Secret { get => secret; set => secret = value; }

    }
}
