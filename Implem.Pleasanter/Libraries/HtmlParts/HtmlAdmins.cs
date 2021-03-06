﻿using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Models;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Server;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlAdmins
    {
        public static string AdminsIndex(this HtmlBuilder hb)
        {
            var pt = Permissions.Admins();
            return hb.Template(
                pt: pt,
                methodType: Pleasanter.Models.BaseModel.MethodTypes.NotSet,
                allowAccess: Sessions.User().TenantAdmin,
                title: Displays.Admin(),
                verType: Versions.VerTypes.Latest,
                useNavigationMenu: false,
                action: () => hb
                    .Nav(css: "cf", action: () => hb
                        .Ul(css: "nav-sites", action: () => hb
                            .Li(css: "nav-site", action: () => hb
                                .A(
                                    attributes: new HtmlAttributes()
                                        .Href(Locations.Index("Depts")),
                                    action: () => hb
                                        .Div(action: () => hb
                                            .Text(Displays.Depts()))
                                        .Div(css: "stacking1")
                                        .Div(css: "stacking2")))
                            .Li(css: "nav-site", action: () => hb
                                .A(
                                    attributes: new HtmlAttributes()
                                        .Href(Locations.Index("Users")),
                                    action: () => hb
                                        .Div(action: () => hb
                                            .Text(Displays.Users()))
                                        .Div(css: "stacking1")
                                        .Div(css: "stacking2")))))
                    .MainCommands(
                        siteId: 0,
                        pt: pt,
                        verType: Versions.VerTypes.Latest))
                            .ToString();
        }
    }
}