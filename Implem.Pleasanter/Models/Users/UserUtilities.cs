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
    public static class UserUtilities
    {
        /// <summary>
        /// Fixed:
        /// </summary>
        public static string Index(SiteSettings ss, Permissions.Types pt)
        {
            var hb = new HtmlBuilder();
            var view = Views.GetBySession(ss);
            var userCollection = UserCollection(
                ss,
                Permissions.Admins(),
                view);
            return hb.Template(
                pt: pt,
                verType: Versions.VerTypes.Latest,
                methodType: BaseModel.MethodTypes.Index,
                allowAccess: Sessions.User().TenantAdmin,
                referenceType: "Users",
                title: Displays.Users() + " - " + Displays.List(),
                action: () =>
                {
                    hb
                        .Form(
                            attributes: new HtmlAttributes()
                                .Id("UserForm")
                                .Class("main-form")
                                .Action(Locations.Action("Users")),
                            action: () => hb
                                .ViewFilters(ss: ss, view: view)
                                .Aggregations(
                                    ss: ss,
                                    aggregations: userCollection.Aggregations)
                                .Div(id: "ViewModeContainer", action: () => hb
                                    .Grid(
                                        userCollection: userCollection,
                                        pt: pt,
                                        ss: ss,
                                        view: view))
                                .MainCommands(
                                    siteId: ss.SiteId,
                                    pt: pt,
                                    verType: Versions.VerTypes.Latest)
                                .Div(css: "margin-bottom")
                                .Hidden(controlId: "TableName", value: "Users")
                                .Hidden(controlId: "BaseUrl", value: Locations.BaseUrl())
                                .Hidden(
                                    controlId: "GridOffset",
                                    value: Parameters.General.GridPageSize.ToString()))
                        .Div(attributes: new HtmlAttributes()
                            .Id("ImportSettingsDialog")
                            .Class("dialog")
                            .Title(Displays.Import()))
                        .Div(attributes: new HtmlAttributes()
                            .Id("ExportSettingsDialog")
                            .Class("dialog")
                            .Title(Displays.ExportSettings()));
                }).ToString();
        }

        private static string ViewModeTemplate(
            this HtmlBuilder hb,
            SiteSettings ss,
            Permissions.Types pt,
            UserCollection userCollection,
            View view,
            string viewMode,
            Action viewModeBody)
        {
            return hb.Template(
                pt: pt,
                verType: Versions.VerTypes.Latest,
                methodType: BaseModel.MethodTypes.Index,
                allowAccess: pt.CanRead(),
                siteId: ss.SiteId,
                parentId: ss.ParentId,
                referenceType: "Users",
                script: Libraries.Scripts.JavaScripts.ViewMode(
                    ss: ss, pt: pt, viewMode: viewMode),
                userScript: ss.GridScript,
                userStyle: ss.GridStyle,
                action: () => hb
                    .Form(
                        attributes: new HtmlAttributes()
                            .Id("UsersForm")
                            .Class("main-form")
                            .Action(Locations.ItemAction(ss.SiteId)),
                        action: () => hb
                            .ViewSelector(ss: ss, view: view)
                            .ViewFilters(ss: ss, view: view)
                            .Aggregations(
                                ss: ss,
                                aggregations: userCollection.Aggregations)
                            .Div(id: "ViewModeContainer", action: () => viewModeBody())
                            .MainCommands(
                                siteId: ss.SiteId,
                                pt: pt,
                                verType: Versions.VerTypes.Latest,
                                bulkMoveButton: true,
                                bulkDeleteButton: true,
                                importButton: true,
                                exportButton: true)
                            .Div(css: "margin-bottom")
                            .Hidden(controlId: "TableName", value: "Users")
                            .Hidden(controlId: "BaseUrl", value: Locations.BaseUrl()))
                    .MoveDialog(bulk: true)
                    .Div(attributes: new HtmlAttributes()
                        .Id("ExportSettingsDialog")
                        .Class("dialog")
                        .Title(Displays.ExportSettings())))
                    .ToString();
        }

        public static string IndexJson(SiteSettings ss, Permissions.Types pt)
        {
            var view = Views.GetBySession(ss);
            var userCollection = UserCollection(ss, pt, view);
            return new ResponseCollection()
                .Html("#ViewModeContainer", new HtmlBuilder().Grid(
                    ss: ss,
                    userCollection: userCollection,
                    pt: pt,
                    view: view))
                .View(ss: ss, view: view)
                .ReplaceAll("#Aggregations", new HtmlBuilder().Aggregations(
                    ss: ss,
                    aggregations: userCollection.Aggregations))
                .ToJson();
        }

        private static UserCollection UserCollection(
            SiteSettings ss,
            Permissions.Types pt,
            View view,
            int offset = 0)
        {
            return new UserCollection(
                ss: ss,
                pt: pt,
                column: GridSqlColumnCollection(ss),
                where: view.Where(ss, Rds.UsersWhere().TenantId(Sessions.TenantId())),
                orderBy: view.OrderBy(ss, Rds.UsersOrderBy()
                    .UpdatedTime(SqlOrderBy.Types.desc)),
                offset: offset,
                pageSize: ss.GridPageSize.ToInt(),
                countRecord: true,
                aggregationCollection: ss.AggregationCollection);
        }

        private static HtmlBuilder Grid(
            this HtmlBuilder hb,
            SiteSettings ss,
            Permissions.Types pt,
            UserCollection userCollection,
            View view)
        {
            return hb
                .Table(
                    attributes: new HtmlAttributes()
                        .Id("Grid")
                        .Class("grid")
                        .DataAction("GridRows")
                        .DataMethod("post"),
                    action: () => hb
                        .GridRows(
                            ss: ss,
                            userCollection: userCollection,
                            view: view))
                .Hidden(
                    controlId: "GridOffset",
                    value: ss.GridNextOffset(
                        0,
                        userCollection.Count(),
                        userCollection.Aggregations.TotalCount)
                            .ToString())
                .Button(
                    controlId: "ViewSorter",
                    controlCss: "hidden",
                    action: "GridRows",
                    method: "post")
                .Button(
                    controlId: "ViewSorters_Reset",
                    controlCss: "hidden",
                    action: "GridRows",
                    method: "post");
        }

        public static string GridRows(
            SiteSettings ss,
            Permissions.Types pt,
            ResponseCollection res = null,
            int offset = 0,
            bool clearCheck = false,
            Message message = null)
        {
            var view = Views.GetBySession(ss);
            var userCollection = UserCollection(ss, pt, view, offset);
            return (res ?? new ResponseCollection())
                .Remove(".grid tr", _using: offset == 0)
                .ClearFormData("GridCheckAll", _using: clearCheck)
                .ClearFormData("GridUnCheckedItems", _using: clearCheck)
                .ClearFormData("GridCheckedItems", _using: clearCheck)
                .Message(message)
                .Append("#Grid", new HtmlBuilder().GridRows(
                    ss: ss,
                    userCollection: userCollection,
                    view: view,
                    addHeader: offset == 0,
                    clearCheck: clearCheck))
                .Val("#GridOffset", ss.GridNextOffset(
                    offset,
                    userCollection.Count(),
                    userCollection.Aggregations.TotalCount))
                .ToJson();
        }

        private static HtmlBuilder GridRows(
            this HtmlBuilder hb,
            SiteSettings ss,
            UserCollection userCollection,
            View view,
            bool addHeader = true,
            bool clearCheck = false)
        {
            var checkAll = clearCheck ? false : Forms.Bool("GridCheckAll");
            var columns = ss.GridColumnCollection();
            return hb
                .THead(
                    _using: addHeader,
                    action: () => hb
                        .GridHeader(
                            columnCollection: columns, 
                            view: view,
                            checkAll: checkAll))
                .TBody(action: () => userCollection
                    .ForEach(userModel => hb
                        .Tr(
                            attributes: new HtmlAttributes()
                                .Class("grid-row")
                                .DataId(userModel.UserId.ToString()),
                            action: () =>
                            {
                                hb.Td(action: () => hb
                                    .CheckBox(
                                        controlCss: "grid-check",
                                        _checked: checkAll,
                                        dataId: userModel.UserId.ToString()));
                                columns
                                    .ForEach(column => hb
                                        .TdValue(
                                            ss: ss,
                                            column: column,
                                            userModel: userModel));
                            })));
        }

        private static SqlColumnCollection GridSqlColumnCollection(SiteSettings ss)
        {
            var sqlColumnCollection = Rds.UsersColumn();
            new List<string> { "UserId", "Creator", "Updator" }
                .Concat(ss.GridColumns)
                .Concat(ss.IncludedColumns())
                .Concat(ss.TitleColumns)
                    .Distinct().ForEach(column =>
                        sqlColumnCollection.UsersColumn(column));
            return sqlColumnCollection;
        }

        public static HtmlBuilder TdValue(
            this HtmlBuilder hb, SiteSettings ss, Column column, UserModel userModel)
        {
            if (!column.GridDesign.IsNullOrEmpty())
            {
                return hb.TdCustomValue(
                    ss: ss,
                    gridDesign: column.GridDesign,
                    userModel: userModel);
            }
            else
            {
                switch (column.ColumnName)
                {
                    case "UserId": return hb.Td(column: column, value: userModel.UserId);
                    case "Ver": return hb.Td(column: column, value: userModel.Ver);
                    case "LoginId": return hb.Td(column: column, value: userModel.LoginId);
                    case "Disabled": return hb.Td(column: column, value: userModel.Disabled);
                    case "LastName": return hb.Td(column: column, value: userModel.LastName);
                    case "FirstName": return hb.Td(column: column, value: userModel.FirstName);
                    case "Birthday": return hb.Td(column: column, value: userModel.Birthday);
                    case "Gender": return hb.Td(column: column, value: userModel.Gender);
                    case "Language": return hb.Td(column: column, value: userModel.Language);
                    case "TimeZoneInfo": return hb.Td(column: column, value: userModel.TimeZoneInfo);
                    case "Dept": return hb.Td(column: column, value: userModel.Dept);
                    case "LastLoginTime": return hb.Td(column: column, value: userModel.LastLoginTime);
                    case "PasswordExpirationTime": return hb.Td(column: column, value: userModel.PasswordExpirationTime);
                    case "PasswordChangeTime": return hb.Td(column: column, value: userModel.PasswordChangeTime);
                    case "NumberOfLogins": return hb.Td(column: column, value: userModel.NumberOfLogins);
                    case "NumberOfDenial": return hb.Td(column: column, value: userModel.NumberOfDenial);
                    case "Comments": return hb.Td(column: column, value: userModel.Comments);
                    case "Creator": return hb.Td(column: column, value: userModel.Creator);
                    case "Updator": return hb.Td(column: column, value: userModel.Updator);
                    case "CreatedTime": return hb.Td(column: column, value: userModel.CreatedTime);
                    case "UpdatedTime": return hb.Td(column: column, value: userModel.UpdatedTime);
                    default: return hb;
                }
            }
        }

        public static HtmlBuilder TdCustomValue(
            this HtmlBuilder hb, SiteSettings ss, string gridDesign, UserModel userModel)
        {
            ss.IncludedColumns(gridDesign).ForEach(column =>
            {
                var value = string.Empty;
                switch (column.ColumnName)
                {
                    case "UserId": value = userModel.UserId.GridText(column: column); break;
                    case "Ver": value = userModel.Ver.GridText(column: column); break;
                    case "LoginId": value = userModel.LoginId.GridText(column: column); break;
                    case "Disabled": value = userModel.Disabled.GridText(column: column); break;
                    case "LastName": value = userModel.LastName.GridText(column: column); break;
                    case "FirstName": value = userModel.FirstName.GridText(column: column); break;
                    case "Birthday": value = userModel.Birthday.GridText(column: column); break;
                    case "Gender": value = userModel.Gender.GridText(column: column); break;
                    case "Language": value = userModel.Language.GridText(column: column); break;
                    case "TimeZoneInfo": value = userModel.TimeZoneInfo.GridText(column: column); break;
                    case "Dept": value = userModel.Dept.GridText(column: column); break;
                    case "LastLoginTime": value = userModel.LastLoginTime.GridText(column: column); break;
                    case "PasswordExpirationTime": value = userModel.PasswordExpirationTime.GridText(column: column); break;
                    case "PasswordChangeTime": value = userModel.PasswordChangeTime.GridText(column: column); break;
                    case "NumberOfLogins": value = userModel.NumberOfLogins.GridText(column: column); break;
                    case "NumberOfDenial": value = userModel.NumberOfDenial.GridText(column: column); break;
                    case "Comments": value = userModel.Comments.GridText(column: column); break;
                    case "Creator": value = userModel.Creator.GridText(column: column); break;
                    case "Updator": value = userModel.Updator.GridText(column: column); break;
                    case "CreatedTime": value = userModel.CreatedTime.GridText(column: column); break;
                    case "UpdatedTime": value = userModel.UpdatedTime.GridText(column: column); break;
                }
                gridDesign = gridDesign.Replace("[" + column.ColumnName + "]", value);
            });
            return hb.Td(action: () => hb
                .Div(css: "markup", action: () => hb
                    .Text(text: gridDesign)));
        }

        public static string EditorNew()
        {
            return Editor(new UserModel(
                SiteSettingsUtility.UsersSiteSettings(),
                methodType: BaseModel.MethodTypes.New));
        }

        public static string Editor(int userId, bool clearSessions)
        {
            var userModel = new UserModel(
                SiteSettingsUtility.UsersSiteSettings(),
                userId: userId,
                clearSessions: clearSessions,
                methodType: BaseModel.MethodTypes.Edit);
            userModel.SwitchTargets = GetSwitchTargets(
                SiteSettingsUtility.UsersSiteSettings(), userModel.UserId);
            return Editor(userModel);
        }

        public static string Editor(UserModel userModel)
        {
            var hb = new HtmlBuilder();
            var pt = Permissions.Admins();
            return hb.Template(
                pt: pt,
                verType: userModel.VerType,
                methodType: userModel.MethodType,
                allowAccess:
                    pt.CanEditTenant() || userModel.Self() &&
                    userModel.AccessStatus != Databases.AccessStatuses.NotFound,
                referenceType: "Users",
                title: userModel.MethodType == BaseModel.MethodTypes.New
                    ? Displays.Users() + " - " + Displays.New()
                    : userModel.Title.Value,
                action: () =>
                {
                    hb
                        .Editor(
                            ss: userModel.SiteSettings,
                            pt: pt,
                            userModel: userModel)
                        .Hidden(controlId: "TableName", value: "Users")
                        .Hidden(controlId: "Id", value: userModel.UserId.ToString());
                }).ToString();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder Editor(
            this HtmlBuilder hb,
            SiteSettings ss,
            Permissions.Types pt,
            UserModel userModel)
        {
            return hb.Div(id: "Editor", action: () => hb
                .Form(
                    attributes: new HtmlAttributes()
                        .Id("UserForm")
                        .Class("main-form")
                        .Action(userModel.UserId != 0
                            ? Locations.Action("Users", userModel.UserId)
                            : Locations.Action("Users")),
                    action: () => hb
                        .RecordHeader(
                            pt: pt,
                            baseModel: userModel,
                            tableName: "Users")
                        .Div(id: "EditorComments", action: () => hb
                            .Comments(
                                comments: userModel.Comments,
                                verType: userModel.VerType))
                        .Div(id: "EditorTabsContainer", action: () => hb
                            .EditorTabs(userModel: userModel)
                            .FieldSetGeneral(
                                ss: ss,
                                pt: pt,
                                userModel: userModel)
                            .FieldSetMailAddresses(userModel: userModel)
                            .FieldSet(
                                attributes: new HtmlAttributes()
                                    .Id("FieldSetHistories")
                                    .DataAction("Histories")
                                    .DataMethod("get"),
                                _using: userModel.MethodType != BaseModel.MethodTypes.New)
                            .MainCommands(
                                siteId: 0,
                                pt: pt,
                                verType: userModel.VerType,
                                referenceType: "Users",
                                referenceId: userModel.UserId,
                                updateButton: true,
                                mailButton: true,
                                deleteButton: true,
                                extensions: () => hb
                                    .MainCommandExtensions(
                                        userModel: userModel,
                                        ss: ss)))
                        .Hidden(controlId: "BaseUrl", value: Locations.BaseUrl())
                        .Hidden(
                            controlId: "MethodType",
                            value: userModel.MethodType.ToString().ToLower())
                        .Hidden(
                            controlId: "Users_Timestamp",
                            css: "must-transport",
                            value: userModel.Timestamp)
                        .Hidden(
                            controlId: "SwitchTargets",
                            css: "must-transport",
                            value: userModel.SwitchTargets?.Join(),
                            _using: !Request.IsAjax()))
                .OutgoingMailsForm("Users", userModel.UserId, userModel.Ver)
                .CopyDialog("Users", userModel.UserId)
                .OutgoingMailDialog()
                .EditorExtensions(userModel: userModel, ss: ss));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder EditorTabs(this HtmlBuilder hb, UserModel userModel)
        {
            return hb.Ul(id: "EditorTabs", action: () => hb
                .Li(action: () => hb
                    .A(
                        href: "#FieldSetGeneral",
                        text: Displays.Basic()))
                .Li(action: () => hb
                    .A(
                        href: "#FieldSetMailAddresses",
                        text: Displays.MailAddresses(),
                        _using: userModel.MethodType != BaseModel.MethodTypes.New))
                .Li(
                    _using: userModel.MethodType != BaseModel.MethodTypes.New,
                    action: () => hb
                        .A(
                            href: "#FieldSetHistories",
                            text: Displays.Histories())));
        }

        private static HtmlBuilder FieldSetGeneral(
            this HtmlBuilder hb,
            SiteSettings ss,
            Permissions.Types pt,
            UserModel userModel)
        {
            return hb.FieldSet(id: "FieldSetGeneral", action: () =>
            {
                ss.EditorColumnCollection().ForEach(column =>
                {
                    switch (column.ColumnName)
                    {
                        case "UserId": hb.Field(ss, column, userModel.MethodType, userModel.UserId.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Ver": hb.Field(ss, column, userModel.MethodType, userModel.Ver.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "LoginId": hb.Field(ss, column, userModel.MethodType, userModel.LoginId.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Disabled": hb.Field(ss, column, userModel.MethodType, userModel.Disabled.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Password": hb.Field(ss, column, userModel.MethodType, userModel.Password.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "PasswordValidate": hb.Field(ss, column, userModel.MethodType, userModel.PasswordValidate.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "PasswordDummy": hb.Field(ss, column, userModel.MethodType, userModel.PasswordDummy.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "RememberMe": hb.Field(ss, column, userModel.MethodType, userModel.RememberMe.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "LastName": hb.Field(ss, column, userModel.MethodType, userModel.LastName.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "FirstName": hb.Field(ss, column, userModel.MethodType, userModel.FirstName.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Birthday": hb.Field(ss, column, userModel.MethodType, userModel.Birthday?.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Gender": hb.Field(ss, column, userModel.MethodType, userModel.Gender.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "Language": hb.Field(ss, column, userModel.MethodType, userModel.Language.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "TimeZone": hb.Field(ss, column, userModel.MethodType, userModel.TimeZone.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "DeptId": hb.Field(ss, column, userModel.MethodType, userModel.DeptId.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "FirstAndLastNameOrder": hb.Field(ss, column, userModel.MethodType, userModel.FirstAndLastNameOrder.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "LastLoginTime": hb.Field(ss, column, userModel.MethodType, userModel.LastLoginTime?.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "PasswordExpirationTime": hb.Field(ss, column, userModel.MethodType, userModel.PasswordExpirationTime?.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "PasswordChangeTime": hb.Field(ss, column, userModel.MethodType, userModel.PasswordChangeTime?.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "NumberOfLogins": hb.Field(ss, column, userModel.MethodType, userModel.NumberOfLogins.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "NumberOfDenial": hb.Field(ss, column, userModel.MethodType, userModel.NumberOfDenial.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "TenantAdmin": hb.Field(ss, column, userModel.MethodType, userModel.TenantAdmin.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "OldPassword": hb.Field(ss, column, userModel.MethodType, userModel.OldPassword.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "ChangedPassword": hb.Field(ss, column, userModel.MethodType, userModel.ChangedPassword.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "ChangedPasswordValidator": hb.Field(ss, column, userModel.MethodType, userModel.ChangedPasswordValidator.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "AfterResetPassword": hb.Field(ss, column, userModel.MethodType, userModel.AfterResetPassword.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "AfterResetPasswordValidator": hb.Field(ss, column, userModel.MethodType, userModel.AfterResetPasswordValidator.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                        case "DemoMailAddress": hb.Field(ss, column, userModel.MethodType, userModel.DemoMailAddress.ToControl(column, pt), column.ColumnPermissionType(pt)); break;
                    }
                });
                hb.VerUpCheckBox(userModel);
            });
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder MainCommandExtensions(
            this HtmlBuilder hb,
            SiteSettings ss,
            UserModel userModel)
        {
            if (userModel.VerType == Versions.VerTypes.Latest &&
                userModel.MethodType != BaseModel.MethodTypes.New &&
                Parameters.Authentication.Provider == null)
            {
                if (userModel.Self())
                {
                    hb.Button(
                        text: Displays.ChangePassword(),
                        controlCss: "button-icon",
                        onClick: "$p.openDialog($(this));",
                        icon: "ui-icon-person",
                        selector: "#ChangePasswordDialog");
                }
                if (Sessions.User().TenantAdmin)
                {
                    hb.Button(
                        text: Displays.ResetPassword(),
                        controlCss: "button-icon",
                        onClick: "$p.openDialog($(this));",
                        icon: "ui-icon-person",
                        selector: "#ResetPasswordDialog");
                }
            }
            return hb;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder EditorExtensions(
            this HtmlBuilder hb,
            UserModel userModel,
            SiteSettings ss)
        {
            return hb
                .ChangePasswordDialog(userId: userModel.UserId, ss: ss)
                .ResetPasswordDialog(userId: userModel.UserId, ss: ss);
        }

        public static string EditorJson(
            SiteSettings ss, Permissions.Types pt, int userId)
        {
            return EditorResponse(new UserModel(ss, userId))
                .ToJson();
        }

        private static ResponseCollection EditorResponse(
            UserModel userModel, Message message = null, string switchTargets = null)
        {
            userModel.MethodType = BaseModel.MethodTypes.Edit;
            return new UsersResponseCollection(userModel)
                .Invoke("clearDialogs")
                .ReplaceAll("#MainContainer", Editor(userModel))
                .Val("#SwitchTargets", switchTargets, _using: switchTargets != null)
                .Invoke("setCurrentIndex")
                .Message(message)
                .ClearFormData();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static List<int> GetSwitchTargets(SiteSettings ss, int userId)
        {
            if (Permissions.Admins().CanEditTenant())
            {
                var view = Views.GetBySession(ss);
                var switchTargets = Rds.ExecuteTable(
                    transactional: false,
                    statements: Rds.SelectUsers(
                        column: Rds.UsersColumn().UserId(),
                        where: view.Where(ss, Rds.UsersWhere().TenantId(Sessions.TenantId())),
                        orderBy: view.OrderBy(
                            ss, Rds.UsersOrderBy().UpdatedTime(SqlOrderBy.Types.desc))))
                                .AsEnumerable()
                                .Select(o => o["UserId"].ToInt())
                                .ToList();
                if (!switchTargets.Contains(userId))
                {
                    switchTargets.Add(userId);
                }
                return switchTargets;
            }
            else
            {
                return new List<int> { userId };
            }
        }

        public static ResponseCollection FormResponse(
            this ResponseCollection res,
            Permissions.Types pt,
            UserModel userModel)
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

        public static string Create(SiteSettings ss, Permissions.Types pt)
        {
            var userModel = new UserModel(ss, 0, setByForm: true);
            var invalid = UserValidators.OnCreating(ss, pt, userModel);
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return invalid.MessageJson();
            }
            var error = userModel.Create();
            if (error.Has())
            {
                return error.MessageJson();
            }
            else
            {
                return EditorResponse(
                    userModel,
                    Messages.Created(userModel.Title.Value),
                    GetSwitchTargets(ss, userModel.UserId).Join()).ToJson();
            }
        }

        public static string Update(SiteSettings ss, Permissions.Types pt, int userId)
        {
            var userModel = new UserModel(ss, userId, setByForm: true);
            var invalid = UserValidators.OnUpdating(ss, pt, userModel);
            switch (invalid)
            {
                case Error.Types.None: break;
                case Error.Types.PermissionNotSelfChange:
                    return Messages.ResponsePermissionNotSelfChange()
                        .Val("#Users_TenantAdmin", userModel.SavedTenantAdmin)
                        .ClearFormData("Users_TenantAdmin")
                        .ToJson();
                default: return new ResponseCollection().Message(invalid.Message()).ToJson();
            }
            if (userModel.AccessStatus != Databases.AccessStatuses.Selected)
            {
                return Messages.ResponseDeleteConflicts().ToJson();
            }
            var error = userModel.Update();
            if (error.Has())
            {
                return error == Error.Types.UpdateConflicts
                    ? Messages.ResponseUpdateConflicts(userModel.Updator.FullName()).ToJson()
                    : new ResponseCollection().Message(error.Message()).ToJson();
            }
            else
            {
                var res = new UsersResponseCollection(userModel);
                return ResponseByUpdate(pt, res, userModel)
                    .PrependComment(userModel.Comments, userModel.VerType)
                    .ToJson();
            }
        }

        private static ResponseCollection ResponseByUpdate(
            Permissions.Types pt, UsersResponseCollection res, UserModel userModel)
        {
            return res
                .Ver()
                .Timestamp()
                .Val("#VerUp", false)
                .FormResponse(pt, userModel)
                .Disabled("#VerUp", false)
                .Html("#HeaderTitle", userModel.Title.Value)
                .Html("#RecordInfo", new HtmlBuilder().RecordInfo(
                    baseModel: userModel, tableName: "Users"))
                .Message(Messages.Updated(userModel.Title.ToString()))
                .RemoveComment(userModel.DeleteCommentId, _using: userModel.DeleteCommentId != 0)
                .ClearFormData();
        }

        public static string Delete(
            SiteSettings ss, Permissions.Types pt, int userId)
        {
            var userModel = new UserModel(ss, userId);
            var invalid = UserValidators.OnDeleting(ss, pt, userModel);
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return invalid.MessageJson();
            }
            var error = userModel.Delete();
            if (error.Has())
            {
                return error.MessageJson();
            }
            else
            {
                Sessions.Set("Message", Messages.Deleted(userModel.Title.Value).Html);
                var res = new UsersResponseCollection(userModel);
                res.Href(Locations.Index("Users"));
                return res.ToJson();
            }
        }

        public static string Restore(int userId)
        {
            var userModel = new UserModel();
            var invalid = UserValidators.OnRestoring();
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return invalid.MessageJson();
            }
            var error = userModel.Restore(userId);
            if (error.Has())
            {
                return error.MessageJson();
            }
            else
            {
                var res = new UsersResponseCollection(userModel);
                return res.ToJson();
            }
        }

        public static string Histories(
            SiteSettings ss, Permissions.Types pt, int userId)
        {
            var userModel = new UserModel(ss, userId);
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
                        new UserCollection(
                            ss: ss,
                            pt: pt,
                            where: Rds.UsersWhere().UserId(userModel.UserId),
                            orderBy: Rds.UsersOrderBy().Ver(SqlOrderBy.Types.desc),
                            tableType: Sqls.TableTypes.NormalAndHistory)
                                .ForEach(userModelHistory => hb
                                    .Tr(
                                        attributes: new HtmlAttributes()
                                            .Class("grid-row history not-link")
                                            .DataAction("History")
                                            .DataMethod("post")
                                            .DataVer(userModelHistory.Ver)
                                            .DataLatest(1, _using:
                                                userModelHistory.Ver == userModel.Ver),
                                        action: () => columns
                                            .ForEach(column => hb
                                                .TdValue(
                                                    ss: ss,
                                                    column: column,
                                                    userModel: userModelHistory))))));
            return new UsersResponseCollection(userModel)
                .Html("#FieldSetHistories", hb).ToJson();
        }

        public static string History(
            SiteSettings ss, Permissions.Types pt, int userId)
        {
            var userModel = new UserModel(ss, userId);
            userModel.Get(
                where: Rds.UsersWhere()
                    .UserId(userModel.UserId)
                    .Ver(Forms.Int("Ver")),
                tableType: Sqls.TableTypes.NormalAndHistory);
            userModel.VerType =  Forms.Bool("Latest")
                ? Versions.VerTypes.Latest
                : Versions.VerTypes.History;
            return EditorResponse(userModel).ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string AddMailAddresses(
            SiteSettings ss, Permissions.Types pt, int userId)
        {
            var userModel = new UserModel(SiteSettingsUtility.UsersSiteSettings(), userId);
            var mailAddress = Forms.Data("MailAddress").Trim();
            var selected = Forms.Data("MailAddresses").Split(';');
            var badMailAddress = string.Empty;
            var invalid = UserValidators.OnAddingMailAddress(
                pt, userModel, mailAddress, out badMailAddress);
            switch (invalid)
            {
                case Error.Types.None:
                    break;
                case Error.Types.BadMailAddress:
                    return invalid.MessageJson(badMailAddress);
                default:
                    return invalid.MessageJson();
            }
            var error = userModel.AddMailAddress(mailAddress, selected);
            return error.Has()
                ? error.MessageJson()
                : ResponseMailAddresses(userModel, selected);
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string DeleteMailAddresses(
            SiteSettings ss, Permissions.Types pt, int userId)
        {
            var userModel = new UserModel(SiteSettingsUtility.UsersSiteSettings(), userId);
            var invalid = UserValidators.OnUpdating(ss, pt, userModel);
            switch (invalid)
            {
                case Error.Types.None: break;
                default: return invalid.MessageJson();
            }
            var selected = Forms.Data("MailAddresses").Split(';');
            var error = userModel.DeleteMailAddresses(selected);
            return error.Has()
                ? error.MessageJson()
                : ResponseMailAddresses(userModel, selected);
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static string ResponseMailAddresses(
            UserModel userModel, IEnumerable<string> selected)
        {
            return new ResponseCollection()
                .Html(
                    "#MailAddresses",
                    new HtmlBuilder().SelectableItems(
                        listItemCollection: userModel.MailAddresses.ToDictionary(o => o, o => o),
                        selectedValueTextCollection: selected))
                .Val("#MailAddress", string.Empty)
                .Focus("#MailAddress")
                .ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static HtmlBuilder ChangePasswordDialog(
            this HtmlBuilder hb, long userId, SiteSettings ss)
        {
            return hb.Div(
                attributes: new HtmlAttributes()
                    .Id("ChangePasswordDialog")
                    .Class("dialog")
                    .Title(Displays.ChangePassword()),
                action: () => hb
                    .Form(
                        attributes: new HtmlAttributes()
                            .Id("ChangePasswordForm")
                            .Action(Locations.Action("Users", userId)),
                        action: () => hb
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("OldPassword"))
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("ChangedPassword"))
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("ChangedPasswordValidator"))
                            .P(css: "message-dialog")
                            .Div(css: "command-center", action: () => hb
                                .Button(
                                    text: Displays.Change(),
                                    controlCss: "button-icon validate",
                                    onClick: "$p.send($(this));",
                                    icon: "ui-icon-disk",
                                    action: "ChangePassword",
                                    method: "post")
                                .Button(
                                    text: Displays.Cancel(),
                                    controlCss: "button-icon",
                                    onClick: "$p.closeDialog($(this));",
                                    icon: "ui-icon-cancel"))));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder ResetPasswordDialog(
            this HtmlBuilder hb, long userId, SiteSettings ss)
        {
            return hb.Div(
                attributes: new HtmlAttributes()
                    .Id("ResetPasswordDialog")
                    .Class("dialog")
                    .Title(Displays.ResetPassword()),
                action: () => hb
                    .Form(
                        attributes: new HtmlAttributes()
                            .Id("ResetPasswordForm")
                            .Action(Locations.Action("Users", userId)),
                        action: () => hb
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("AfterResetPassword"))
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("AfterResetPasswordValidator"))
                            .P(css: "hidden", action: () => hb
                                .TextBox(
                                    textType: HtmlTypes.TextTypes.Password,
                                    controlCss: " dummy not-transport"))
                            .P(css: "message-dialog")
                            .Div(css: "command-center", action: () => hb
                                .Button(
                                    text: Displays.Reset(),
                                    controlCss: "button-icon validate",
                                    onClick: "$p.send($(this));",
                                    icon: "ui-icon-disk",
                                    action: "ResetPassword",
                                    method: "post")
                                .Button(
                                    text: Displays.Cancel(),
                                    controlCss: "button-icon",
                                    onClick: "$p.closeDialog($(this));",
                                    icon: "ui-icon-cancel"))));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string GridRows()
        {
            return GridRows(
                SiteSettingsUtility.UsersSiteSettings(),
                Permissions.Admins(),
                offset: DataViewGrid.Offset());
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string HtmlLogin(string returnUrl)
        {
            var hb = new HtmlBuilder();
            var ss = SiteSettingsUtility.UsersSiteSettings();
            return hb.Template(
                pt: Permissions.Admins(),
                verType: Versions.VerTypes.Latest,
                useBreadcrumb: false,
                useTitle: false,
                useSearch: false,
                useNavigationMenu: false,
                methodType: BaseModel.MethodTypes.Edit,
                allowAccess: true,
                referenceType: "Users",
                title: string.Empty,
                action: () => hb
                    .Form(
                        attributes: new HtmlAttributes()
                            .Id("UserForm")
                            .Class("main-form")
                            .Action(Locations.Get("users", "_action_?ReturnUrl="
                                + Url.Encode(returnUrl))),
                        action: () => hb
                            .FieldSet(id: "Login", action: () => hb
                                .Div(action: () => hb
                                    .Field(
                                        ss: ss,
                                        column: ss.GetColumn("LoginId"),
                                        controlCss: " must-transport focus")
                                    .Field(
                                        ss: ss,
                                        column: ss.GetColumn("Password"),
                                        fieldCss: "field-wide",
                                        controlCss: " must-transport")
                                    .Field(
                                        ss: ss,
                                        column: ss.GetColumn("RememberMe")))
                                .Div(id: "LoginCommands cf", action: () => hb
                                    .Button(
                                        controlCss: "button-icon button-right-justified validate",
                                        text: Displays.Login(),
                                        onClick: "$p.send($(this));",
                                        icon: "ui-icon-unlocked",
                                        action: "Authenticate",
                                        method: "post",
                                        type: "submit"))))
                    .Form(
                        attributes: new HtmlAttributes()
                            .Id("DemoForm")
                            .Action(Locations.Get("demos", "_action_")),
                        _using: Parameters.Service.Demo,
                        action: () => hb
                            .Div(id: "Demo", action: () => hb
                                .FieldSet(
                                    legendText: Displays.ViewDemoEnvironment(),
                                    css: " enclosed-thin",
                                    action: () => hb
                                        .Div(id: "DemoFields", action: () => hb
                                            .Field(
                                                ss: ss,
                                                column: ss.GetColumn("DemoMailAddress"))
                                            .Button(
                                                text: Displays.Register(),
                                                controlCss: "button-icon validate",
                                                onClick: "$p.send($(this));",
                                                icon: "ui-icon-mail-closed",
                                                action: "Register",
                                                method: "post")))))
                    .P(id: "Message", css: "message-form-bottom")
                    .ChangePasswordAtLoginDialog(ss: ss)
                    .Hidden(controlId: "ReturnUrl", value: QueryStrings.Data("ReturnUrl")))
                    .ToString();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static HtmlBuilder ChangePasswordAtLoginDialog(
            this HtmlBuilder hb, SiteSettings ss)
        {
            return hb.Div(
                attributes: new HtmlAttributes()
                    .Id("ChangePasswordDialog")
                    .Class("dialog")
                    .Title(Displays.ChangePassword()),
                action: () => hb
                    .Form(
                        attributes: new HtmlAttributes()
                            .Id("ChangePasswordForm")
                            .Action(Locations.Action("Users")),
                        action: () => hb
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("ChangedPassword"))
                            .Field(
                                ss: ss,
                                column: ss.GetColumn("ChangedPasswordValidator"))
                            .P(css: "message-dialog")
                            .Div(css: "command-center", action: () => hb
                                .Button(
                                    text: Displays.Change(),
                                    controlCss: "button-icon validate",
                                    onClick: "$p.changePasswordAtLogin($(this));",
                                    icon: "ui-icon-disk",
                                    action: "ChangePasswordAtLogin",
                                    method: "post")
                                .Button(
                                    text: Displays.Cancel(),
                                    controlCss: "button-icon",
                                    onClick: "$p.closeDialog($(this));",
                                    icon: "ui-icon-cancel"))));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static HtmlBuilder FieldSetMailAddresses(this HtmlBuilder hb, UserModel userModel)
        {
            if (userModel.MethodType == BaseModel.MethodTypes.New) return hb;
            var listItemCollection = Rds.ExecuteTable(statements:
                Rds.SelectMailAddresses(
                    column: Rds.MailAddressesColumn()
                        .MailAddressId()
                        .MailAddress(),
                    where: Rds.MailAddressesWhere()
                        .OwnerId(userModel.UserId)
                        .OwnerType("Users")))
                            .AsEnumerable()
                            .ToDictionary(
                                o => o["MailAddress"].ToString(),
                                o => o["MailAddress"].ToString());
            userModel.Session_MailAddresses(listItemCollection.Values.ToList<string>());
            return hb.FieldSet(id: "FieldSetMailAddresses", action: () => hb
                .FieldSelectable(
                    controlId: "MailAddresses",
                    fieldCss: "field-vertical w500",
                    controlContainerCss: "container-selectable",
                    controlWrapperCss: " h350",
                    labelText: Displays.MailAddresses(),
                    listItemCollection: listItemCollection,
                    commandOptionAction: () => hb
                        .Div(css: "command-left", action: () => hb
                            .TextBox(
                                controlId: "MailAddress",
                                controlCss: " w200")
                            .Button(
                                text: Displays.Add(),
                                controlCss: "button-icon",
                                onClick: "$p.send($(this));",
                                icon: "ui-icon-disk",
                                action: "AddMailAddress",
                                method: "post")
                            .Button(
                                controlId: "DeleteMailAddresses",
                                controlCss: "button-icon",
                                text: Displays.Delete(),
                                onClick: "$p.send($(this));",
                                icon: "ui-icon-image",
                                action: "DeleteMailAddresses",
                                method: "put"))));
        }
    }
}
