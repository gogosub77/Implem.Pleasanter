﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Server;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlScripts
    {
        public static HtmlBuilder Scripts(
            this HtmlBuilder hb,
            string script,
            string userScript,
            string referenceType)
        {
            return !Request.IsAjax()
                ? hb
                    .Script(src: Locations.Get("Scripts/Plugins/jquery-3.1.0.min.js"))
                    .Script(src: Locations.Get("Scripts/Plugins/jquery-ui.min.js"))
                    .Script(src: Locations.Get("Scripts/Plugins/jquery.multiselect.min.js"))
                    .Script(src: Locations.Get("Scripts/Plugins/jquery.multiselect.filter.min.js"))
                    .Script(src: Locations.Get("Scripts/Plugins/jquery.validate.min.js"))
                    .Script(src: Locations.Get("Scripts/Plugins/d3.min.js"))
                    .Script(src: Locations.Get("Scripts/Plugins/marked.min.js"))
                    .Generals()
                    .Script(script: script, _using: !script.IsNullOrEmpty())
                    .Script(script: userScript, _using: !userScript.IsNullOrEmpty())
                    .ItemValidator(referenceType: referenceType)
                    .Script(src: Src("OutgoingMails"))
                    .Internationalization()
                : hb;
        }

        public static HtmlBuilder Generals(this HtmlBuilder hb)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                hb.Script(src: ResolveBundleUrl("~/bundles/Generals"));
            }
            else
            {
                BundleConfig.Generals().ForEach(path =>
                    hb.Script(src: VirtualPathUtility.ToAbsolute(path)));
            }
            return hb;
        }

        public static HtmlBuilder ItemValidator(this HtmlBuilder hb, string referenceType)
        {
            return hb.Script(id: "ItemValidator", src: Src(referenceType));
        }

        private static string Src(string referenceType)
        {
            switch (referenceType)
            {
                case "Tenants": return ResolveBundleUrl("~/bundles/TenantsValidator");
                case "Demos": return ResolveBundleUrl("~/bundles/DemosValidator");
                case "Depts": return ResolveBundleUrl("~/bundles/DeptsValidator");
                case "Users": return ResolveBundleUrl("~/bundles/UsersValidator");
                case "OutgoingMails": return ResolveBundleUrl("~/bundles/OutgoingMailsValidator");
                case "Sites": return ResolveBundleUrl("~/bundles/SitesValidator");
                case "Issues": return ResolveBundleUrl("~/bundles/IssuesValidator");
                case "Results": return ResolveBundleUrl("~/bundles/ResultsValidator");
                case "Wikis": return ResolveBundleUrl("~/bundles/WikisValidator");
                default: return string.Empty;
            }
        }

        private static string ResolveBundleUrl(string url)
        {
            return BundleTable.Bundles.ResolveBundleUrl(url);
        }

        private static HtmlBuilder Internationalization(this HtmlBuilder hb)
        {
            switch (Sessions.Language())
            {
                case "ja": return hb
                    .Script(src: Locations.Get(
                        "Scripts/Plugins/jquery-ui/i18n/datepicker-ja.js"));
                default: return hb;
            }
        }

        private static string Validator(string referenceType)
        {
            switch (referenceType)
            {
                case "Tenants": return ResolveBundleUrl("~/bundles/TenantsValidator");
                case "Demos": return ResolveBundleUrl("~/bundles/DemosValidator");
                case "SysLogs": return ResolveBundleUrl("~/bundles/SysLogsValidator");
                case "Depts": return ResolveBundleUrl("~/bundles/DeptsValidator");
                case "Users": return ResolveBundleUrl("~/bundles/UsersValidator");
                case "MailAddresses": return ResolveBundleUrl("~/bundles/MailAddressesValidator");
                case "Permissions": return ResolveBundleUrl("~/bundles/PermissionsValidator");
                case "OutgoingMails": return ResolveBundleUrl("~/bundles/OutgoingMailsValidator");
                case "SearchIndexes": return ResolveBundleUrl("~/bundles/SearchIndexesValidator");
                case "Items": return ResolveBundleUrl("~/bundles/ItemsValidator");
                case "Sites": return ResolveBundleUrl("~/bundles/SitesValidator");
                case "Orders": return ResolveBundleUrl("~/bundles/OrdersValidator");
                case "ExportSettings": return ResolveBundleUrl("~/bundles/ExportSettingsValidator");
                case "Links": return ResolveBundleUrl("~/bundles/LinksValidator");
                case "Binaries": return ResolveBundleUrl("~/bundles/BinariesValidator");
                case "Issues": return ResolveBundleUrl("~/bundles/IssuesValidator");
                case "Results": return ResolveBundleUrl("~/bundles/ResultsValidator");
                case "Wikis": return ResolveBundleUrl("~/bundles/WikisValidator");
                default: return string.Empty;
            }
        }
    }
}
