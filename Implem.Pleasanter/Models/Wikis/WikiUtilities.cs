﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Classes;
using Implem.Libraries.DataSources.SqlServer;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Converts;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.DataTypes;
using Implem.Pleasanter.Libraries.General;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.HtmlParts;
using Implem.Pleasanter.Libraries.Models;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Server;
using Implem.Pleasanter.Libraries.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Implem.Pleasanter.Models
{
    public static class WikiUtilities
    {
        public static HtmlBuilder TdValue(
            this HtmlBuilder hb, SiteSettings ss, Column column, WikiModel wikiModel)
        {
            if (!column.GridDesign.IsNullOrEmpty())
            {
                return hb.TdCustomValue(
                    ss: ss,
                    gridDesign: column.GridDesign,
                    wikiModel: wikiModel);
            }
            else
            {
                switch (column.ColumnName)
                {
                    case "SiteId": return hb.Td(column: column, value: wikiModel.SiteId);
                    case "UpdatedTime": return hb.Td(column: column, value: wikiModel.UpdatedTime);
                    case "WikiId": return hb.Td(column: column, value: wikiModel.WikiId);
                    case "Ver": return hb.Td(column: column, value: wikiModel.Ver);
                    case "Title": return hb.Td(column: column, value: wikiModel.Title);
                    case "Body": return hb.Td(column: column, value: wikiModel.Body);
                    case "TitleBody": return hb.Td(column: column, value: wikiModel.TitleBody);
                    case "Comments": return hb.Td(column: column, value: wikiModel.Comments);
                    case "Creator": return hb.Td(column: column, value: wikiModel.Creator);
                    case "Updator": return hb.Td(column: column, value: wikiModel.Updator);
                    case "CreatedTime": return hb.Td(column: column, value: wikiModel.CreatedTime);
                    default: return hb;
                }
            }
        }

        public static HtmlBuilder TdCustomValue(
            this HtmlBuilder hb, SiteSettings ss, string gridDesign, WikiModel wikiModel)
        {
            ss.IncludedColumns(gridDesign).ForEach(column =>
            {
                var value = string.Empty;
                switch (column.ColumnName)
                {
                    case "SiteId": value = wikiModel.SiteId.GridText(column: column); break;
                    case "UpdatedTime": value = wikiModel.UpdatedTime.GridText(column: column); break;
                    case "WikiId": value = wikiModel.WikiId.GridText(column: column); break;
                    case "Ver": value = wikiModel.Ver.GridText(column: column); break;
                    case "Title": value = wikiModel.Title.GridText(column: column); break;
                    case "Body": value = wikiModel.Body.GridText(column: column); break;
                    case "TitleBody": value = wikiModel.TitleBody.GridText(column: column); break;
                    case "Comments": value = wikiModel.Comments.GridText(column: column); break;
                    case "Creator": value = wikiModel.Creator.GridText(column: column); break;
                    case "Updator": value = wikiModel.Updator.GridText(column: column); break;
                    case "CreatedTime": value = wikiModel.CreatedTime.GridText(column: column); break;
                }
                gridDesign = gridDesign.Replace("[" + column.ColumnName + "]", value);
            });
            return hb.Td(action: () => hb
                .Div(css: "markup", action: () => hb
                    .Text(text: gridDesign)));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string EditorNew(SiteModel siteModel)
        {
            var wikiId = Rds.ExecuteScalar_long(statements:
                Rds.SelectWikis(
                    column: Rds.WikisColumn().WikiId(),
                    where: Rds.WikisWhere().SiteId(siteModel.SiteId)));
            return wikiId == 0
                ? Editor(siteModel, new WikiModel(
                    siteModel.WikisSiteSettings(), methodType: BaseModel.MethodTypes.New))
                : new HtmlBuilder().NotFoundTemplate().ToString();
        }

        public static string Editor(SiteModel siteModel, long wikiId, bool clearSessions)
        {
            var ss = siteModel.WikisSiteSettings();
            var wikiModel = new WikiModel(
                ss: ss,
                wikiId: wikiId,
                clearSessions: clearSessions,
                methodType: BaseModel.MethodTypes.Edit);
            return Editor(siteModel, wikiModel);
        }

        public static string Editor(SiteModel siteModel, WikiModel wikiModel)
        {
            var hb = new HtmlBuilder();
            return hb.Template(
                pt: siteModel.PermissionType,
                verType: wikiModel.VerType,
                methodType: wikiModel.MethodType,
                allowAccess:
                    siteModel.PermissionType.CanRead() &&
                    wikiModel.AccessStatus != Databases.AccessStatuses.NotFound,
                siteId: siteModel.SiteId,
                referenceType: "Wikis",
                title: wikiModel.MethodType == BaseModel.MethodTypes.New
                    ? siteModel.Title.DisplayValue + " - " + Displays.New()
                    : wikiModel.Title.DisplayValue,
                userScript: wikiModel.MethodType == BaseModel.MethodTypes.New
                    ? wikiModel.SiteSettings.NewScript
                    : wikiModel.SiteSettings.EditScript,
                userStyle: wikiModel.MethodType == BaseModel.MethodTypes.New
                    ? wikiModel.SiteSettings.NewStyle
                    : wikiModel.SiteSettings.EditStyle,
                action: () =>
                {
                    hb
                        .Editor(
                            ss: wikiModel.SiteSettings,
                            siteModel: siteModel,
                            wikiModel: wikiModel)
                        .Hidden(controlId: "TableName", value: "Wikis")
                        .Hidden(controlId: "Id", value: wikiModel.WikiId.ToString());
                }).ToString();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder Editor(
            this HtmlBuilder hb,
            SiteSettings ss,
            SiteModel siteModel,
            WikiModel wikiModel)
        {
            return hb.Div(id: "Editor", action: () => hb
                .Form(
                    attributes: new HtmlAttributes()
                        .Id("WikiForm")
                        .Class("main-form")
                        .Action(Locations.ItemAction(wikiModel.WikiId != 0
                            ? wikiModel.WikiId
                            : siteModel.SiteId)),
                    action: () => hb
                        .RecordHeader(
                            pt: siteModel.PermissionType,
                            baseModel: wikiModel,
                            tableName: "Wikis")
                        .Div(id: "EditorComments", action: () => hb
                            .Comments(
                                comments: wikiModel.Comments,
                                verType: wikiModel.VerType))
                        .Div(id: "EditorTabsContainer", action: () => hb
                            .EditorTabs(wikiModel: wikiModel)
                            .FieldSetGeneral(
                                wikiModel: wikiModel,
                                pt: siteModel.PermissionType,
                                ss: ss)
                            .FieldSet(
                                attributes: new HtmlAttributes()
                                    .Id("FieldSetHistories")
                                    .DataAction("Histories")
                                    .DataMethod("get"),
                                _using: wikiModel.MethodType != BaseModel.MethodTypes.New)
                            .MainCommands(
                                siteId: siteModel.SiteId,
                                pt: siteModel.PermissionType,
                                verType: wikiModel.VerType,
                                referenceType: "items",
                                referenceId: wikiModel.WikiId,
                                updateButton: true,
                                copyButton: false,
                                moveButton: false,
                                mailButton: true,
                                deleteButton: true))
                        .Hidden(controlId: "BaseUrl", value: Locations.BaseUrl())
                        .Hidden(controlId: "MethodType", value: "edit")
                        .Hidden(
                            controlId: "Wikis_Timestamp",
                            css: "must-transport",
                            value: wikiModel.Timestamp)
                        .Hidden(
                            controlId: "SwitchTargets",
                            css: "must-transport",
                            value: wikiModel.WikiId.ToString(),
                            _using: !Request.IsAjax() || Routes.Action() == "create"))
                .OutgoingMailsForm("Wikis", wikiModel.WikiId, wikiModel.Ver)
                .CopyDialog("items", wikiModel.WikiId)
                .MoveDialog()
                .OutgoingMailDialog());
        }

        private static HtmlBuilder EditorTabs(this HtmlBuilder hb, WikiModel wikiModel)
        {
            return hb.Ul(id: "EditorTabs", action: () => hb
                .Li(action: () => hb
                    .A(
                        href: "#FieldSetGeneral", 
                        text: Displays.Basic()))
                .Li(
                    _using: wikiModel.MethodType != BaseModel.MethodTypes.New,
                    action: () => hb
                        .A(
                            href: "#FieldSetHistories",
                            text: Displays.Histories())));
        }

        private static HtmlBuilder FieldSetGeneral(
            this HtmlBuilder hb,
            SiteSettings ss,
            Permissions.Types pt,
            WikiModel wikiModel)
        {
            return hb.FieldSet(id: "FieldSetGeneral", action: () =>
            {
                ss.EditorColumnCollection().ForEach(column =>
                {
                    switch (column.ColumnName)
                    {
                        case "WikiId": hb.Field(ss, column, wikiModel.MethodType, wikiModel.WikiId.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Ver": hb.Field(ss, column, wikiModel.MethodType, wikiModel.Ver.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Title": hb.Field(ss, column, wikiModel.MethodType, wikiModel.Title.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Body": hb.Field(ss, column, wikiModel.MethodType, wikiModel.Body.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                    }
                });
                hb.VerUpCheckBox(wikiModel);
            });
        }

        private static HtmlBuilder MainCommandExtensions(
            this HtmlBuilder hb,
            SiteSettings ss,
            WikiModel wikiModel)
        {
            return hb;
        }

        private static HtmlBuilder EditorExtensions(
            this HtmlBuilder hb,
            SiteSettings ss,
            WikiModel wikiModel)
        {
            return hb;
        }

        public static string EditorJson(
            SiteSettings ss, Permissions.Types pt, long wikiId)
        {
            return EditorResponse(new WikiModel(ss, wikiId))
                .ToJson();
        }

        private static ResponseCollection EditorResponse(
            WikiModel wikiModel, Message message = null, string switchTargets = null)
        {
            var siteModel = new SiteModel(wikiModel.SiteId);
            wikiModel.MethodType = BaseModel.MethodTypes.Edit;
            return new WikisResponseCollection(wikiModel)
                .Invoke("clearDialogs")
                .ReplaceAll("#MainContainer", Editor(siteModel, wikiModel))
                .Val("#SwitchTargets", switchTargets, _using: switchTargets != null)
                .Invoke("setCurrentIndex")
                .Message(message)
                .ClearFormData();
        }

        public static ResponseCollection FormResponse(
            this ResponseCollection res,
            Permissions.Types pt,
            WikiModel wikiModel)
        {
            Forms.All().Keys.ForEach(key =>
            {
                switch (key)
                {
                    default: break;
                }
            });
            return res;
        }

        public static ResponseCollection Formula(
            this ResponseCollection res,
            Permissions.Types pt,
            WikiModel wikiModel)
        {
            wikiModel.SiteSettings.FormulaHash?.Keys.ForEach(columnName =>
            {
                var column = wikiModel.SiteSettings.GetColumn(columnName);
                switch (columnName)
                {
                    default: break;
                }
            });
            return res;
        }

        public static string Update(SiteSettings ss, Permissions.Types pt, long wikiId)
        {
            var wikiModel = new WikiModel(ss, wikiId, setByForm: true);
            var invalid = WikiValidators.OnUpdating(ss, pt, wikiModel);
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return new ResponseCollection().Message(invalid.Message()).ToJson();
            }
            if (wikiModel.AccessStatus != Databases.AccessStatuses.Selected)
            {
                return Messages.ResponseDeleteConflicts().ToJson();
            }
            var error = wikiModel.Update(notice: true);
            if (error.Has())
            {
                return error == Error.Types.UpdateConflicts
                    ? Messages.ResponseUpdateConflicts(wikiModel.Updator.FullName()).ToJson()
                    : new ResponseCollection().Message(error.Message()).ToJson();
            }
            else
            {
                var res = new WikisResponseCollection(wikiModel);
                res.ReplaceAll("#Breadcrumb", new HtmlBuilder()
                    .Breadcrumb(ss.SiteId));
                return ResponseByUpdate(pt, res, wikiModel)
                    .PrependComment(wikiModel.Comments, wikiModel.VerType)
                    .ToJson();
            }
        }

        private static ResponseCollection ResponseByUpdate(
            Permissions.Types pt, WikisResponseCollection res, WikiModel wikiModel)
        {
            return res
                .Ver()
                .Timestamp()
                .Val("#VerUp", false)
                .FormResponse(pt, wikiModel)
                .Formula(pt, wikiModel)
                .Disabled("#VerUp", false)
                .Html("#HeaderTitle", wikiModel.Title.DisplayValue)
                .Html("#RecordInfo", new HtmlBuilder().RecordInfo(
                    baseModel: wikiModel, tableName: "Wikis"))
                .Html("#Links", new HtmlBuilder().Links(wikiModel.WikiId))
                .Message(Messages.Updated(wikiModel.Title.ToString()))
                .RemoveComment(wikiModel.DeleteCommentId, _using: wikiModel.DeleteCommentId != 0)
                .ClearFormData();
        }

        public static string Delete(
            SiteSettings ss, Permissions.Types pt, long wikiId)
        {
            var wikiModel = new WikiModel(ss, wikiId);
            var invalid = WikiValidators.OnDeleting(ss, pt, wikiModel);
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return invalid.MessageJson();
            }
            var error = wikiModel.Delete(notice: true);
            if (error.Has())
            {
                return error.MessageJson();
            }
            else
            {
                Sessions.Set("Message", Messages.Deleted(wikiModel.Title.Value).Html);
                var res = new WikisResponseCollection(wikiModel);
                res.Href(Locations.ItemIndex(Rds.ExecuteScalar_long(statements:
                    Rds.SelectSites(
                        tableType: Sqls.TableTypes.Deleted,
                        column: Rds.SitesColumn().ParentId(),
                        where: Rds.SitesWhere()
                            .TenantId(Sessions.TenantId())
                            .SiteId(wikiModel.SiteId)))));
                return res.ToJson();
            }
        }

        public static string Restore(long wikiId)
        {
            var wikiModel = new WikiModel();
            var invalid = WikiValidators.OnRestoring();
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return invalid.MessageJson();
            }
            var error = wikiModel.Restore(wikiId);
            if (error.Has())
            {
                return error.MessageJson();
            }
            else
            {
                var res = new WikisResponseCollection(wikiModel);
                return res.ToJson();
            }
        }

        public static string Histories(
            SiteSettings ss, Permissions.Types pt, long wikiId)
        {
            var wikiModel = new WikiModel(ss, wikiId);
            var columns = ss.HistoryColumnCollection();
            var hb = new HtmlBuilder();
            hb.Table(
                attributes: new HtmlAttributes().Class("grid"),
                action: () => hb
                    .THead(action: () => hb
                        .GridHeader(
                            columnCollection: columns,
                            sort: false,
                            checkRow: false))
                    .TBody(action: () =>
                        new WikiCollection(
                            ss: ss,
                            pt: pt,
                            where: Rds.WikisWhere().WikiId(wikiModel.WikiId),
                            orderBy: Rds.WikisOrderBy().Ver(SqlOrderBy.Types.desc),
                            tableType: Sqls.TableTypes.NormalAndHistory)
                                .ForEach(wikiModelHistory => hb
                                    .Tr(
                                        attributes: new HtmlAttributes()
                                            .Class("grid-row history not-link")
                                            .DataAction("History")
                                            .DataMethod("post")
                                            .DataVer(wikiModelHistory.Ver)
                                            .DataLatest(1, _using:
                                                wikiModelHistory.Ver == wikiModel.Ver),
                                        action: () => columns
                                            .ForEach(column => hb
                                                .TdValue(
                                                    ss: ss,
                                                    column: column,
                                                    wikiModel: wikiModelHistory))))));
            return new WikisResponseCollection(wikiModel)
                .Html("#FieldSetHistories", hb).ToJson();
        }

        public static string History(
            SiteSettings ss, Permissions.Types pt, long wikiId)
        {
            var wikiModel = new WikiModel(ss, wikiId);
            wikiModel.Get(
                where: Rds.WikisWhere()
                    .WikiId(wikiModel.WikiId)
                    .Ver(Forms.Int("Ver")),
                tableType: Sqls.TableTypes.NormalAndHistory);
            wikiModel.VerType =  Forms.Bool("Latest")
                ? Versions.VerTypes.Latest
                : Versions.VerTypes.History;
            return EditorResponse(wikiModel).ToJson();
        }

        public static string TitleDisplayValue(SiteSettings ss, WikiModel wikiModel)
        {
            var displayValue = ss.TitleColumnCollection()
                .Select(column => TitleDisplayValue(column, wikiModel))
                .Where(o => o != string.Empty)
                .Join(ss.TitleSeparator);
            return displayValue != string.Empty
                ? displayValue
                : Displays.NoTitle();
        }

        private static string TitleDisplayValue(Column column, WikiModel wikiModel)
        {
            switch (column.ColumnName)
            {
                case "Title": return column.HasChoices()
                    ? column.Choice(wikiModel.Title.Value).Text
                    : wikiModel.Title.Value;
                default: return string.Empty;
            }
        }

        public static string TitleDisplayValue(SiteSettings ss, DataRow dataRow)
        {
            var displayValue = ss.TitleColumnCollection()
                .Select(column => TitleDisplayValue(column, dataRow))
                .Where(o => o != string.Empty)
                .Join(ss.TitleSeparator);
            return displayValue != string.Empty
                ? displayValue
                : Displays.NoTitle();
        }

        private static string TitleDisplayValue(Column column, DataRow dataRow)
        {
            switch (column.ColumnName)
            {
                case "Title": return column.HasChoices()
                    ? column.Choice(dataRow["Title"].ToString()).Text
                    : dataRow["Title"].ToString();
                default: return string.Empty;
            }
        }
    }
}
