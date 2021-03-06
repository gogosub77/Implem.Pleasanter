﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using System.Web;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlBack
    {
        public static HtmlBuilder BackUrl(
            this HtmlBuilder hb,
            long siteId,
            long parentId,
            string referenceType,
            string siteReferenceType)
        {
            return !Request.IsAjax()
                ? hb.Hidden(
                    controlId: "BackUrl",
                    rawValue: BackUrl(siteId, parentId, referenceType, siteReferenceType))
                : hb;
        }

        private static string BackUrl(
            long siteId, long parentId, string referenceType, string siteReferenceType)
        {
            var controller = Routes.Controller();
            var referer = HttpUtility.UrlDecode(new Request(HttpContext.Current).UrlReferrer());
            switch (controller)
            {
                case "admins":
                    return Locations.Top();
                case "depts":
                case "users":
                    switch (Routes.Action())
                    {
                        case "new":
                        case "edit":
                            return Strings.CoalesceEmpty(
                                referer, Locations.Get(controller));
                        default:
                            return Locations.Get("Admins");
                    }
                default:
                    switch (referenceType)
                    {
                        case "Sites":
                            switch (Routes.Action())
                            {
                                case "new":
                                    return Locations.ItemIndex(siteId);
                                case "edit":
                                    switch (siteReferenceType)
                                    {
                                        case "Wikis":
                                            return Locations.ItemIndex(parentId);
                                        default:
                                            return Locations.ItemIndex(siteId);
                                    }
                                default:
                                    return Locations.ItemIndex(parentId);
                            }
                        default:
                            switch (Routes.Action())
                            {
                                case "new":
                                case "edit":
                                    return Strings.CoalesceEmpty(
                                        referer, Locations.ItemIndex(siteId));
                                default:
                                    return Locations.ItemIndex(parentId);
                            }
                    }
            }
        }
    }
}