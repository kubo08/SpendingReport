using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using spending_report.L10n;


namespace Support
{
    public static class EnumExtensions
    {
        private static readonly ResourceManager _enumResourceManager = enumsL10n.ResourceManager;
        public static string Localise(this Enum e)
        {
            return _enumResourceManager.GetString(e.ToString());
        }
    }
}