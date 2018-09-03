using System;
using System.Collections.Generic;
using System.Linq;

namespace KorDevAus
{
    public class AssetFiles
    {
        public static List<string> CssFiles { get; set; } = new List<string>() 
            {
                "lib/bootstrap/css/bootstrap.css",
                "lib/animate.css/animate.css",
                "css/site.scss"
            };

        public static string CssBundleFilePath = "/css/bundle.min.css";

    }
}
