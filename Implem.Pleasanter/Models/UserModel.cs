﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Classes;
using Implem.Libraries.DataSources.SqlServer;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Interfaces;
using Implem.Pleasanter.Libraries.Analysis;
using Implem.Pleasanter.Libraries.Converts;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.DataTypes;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.ServerData;
using Implem.Pleasanter.Libraries.Settings;
using Implem.Pleasanter.Libraries.Styles;
using Implem.Pleasanter.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
namespace Implem.Pleasanter.Models
{
    public class UserModel : BaseModel, IConvertable
    {
        public int TenantId = Sessions.TenantId();
        public int UserId = 0;
        public string LoginId = string.Empty;
        public bool Disabled = false;
        public string UserCode = string.Empty;
        public string Password = string.Empty;
        public string PasswordValidate = string.Empty;
        public string PasswordDummy = string.Empty;
        public bool RememberMe = false;
        public string LastName = string.Empty;
        public string FirstName = string.Empty;
        public Time Birthday = null;
        public string Sex = "1";
        public string Language = "ja";
        public string TimeZone = "Tokyo Standard Time";
        public int DeptId = 0;
        public Names.FirstAndLastNameOrders FirstAndLastNameOrder = (Names.FirstAndLastNameOrders)2;
        public Time LastLoginTime = null;
        public Time PasswordChangeTime = null;
        public int NumberOfLogins = 0;
        public int NumberOfDenial = 0;
        public bool TenantAdmin = false;
        public bool ServiceAdmin = false;
        public bool Developer = false;
        public string OldPassword = string.Empty;
        public string ChangedPassword = string.Empty;
        public string ChangedPasswordValidator = string.Empty;
        public string AfterResetPassword = string.Empty;
        public string AfterResetPasswordValidator = string.Empty;
        public string SessionGuid = string.Empty;
        public string FullName1 { get { return FirstName + " " + LastName; } }
        public string FullName2 { get { return LastName + " " + FirstName; } }
        public TimeZoneInfo TimeZoneInfo { get { return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.Id == TimeZone); } }
        public DeptModel Dept { get { return SiteInfo.DeptModel(DeptId); } }
        public Title Title { get { return new Title(UserId, FullName()); } }
        public int SavedTenantId = Sessions.TenantId();
        public int SavedUserId = 0;
        public string SavedLoginId = string.Empty;
        public bool SavedDisabled = false;
        public string SavedUserCode = string.Empty;
        public string SavedPassword = string.Empty;
        public string SavedPasswordValidate = string.Empty;
        public string SavedPasswordDummy = string.Empty;
        public bool SavedRememberMe = false;
        public string SavedLastName = string.Empty;
        public string SavedFirstName = string.Empty;
        public DateTime SavedBirthday = 0.ToDateTime();
        public string SavedSex = "1";
        public string SavedLanguage = "ja";
        public string SavedTimeZone = "Tokyo Standard Time";
        public int SavedDeptId = 0;
        public int SavedFirstAndLastNameOrder = 2;
        public DateTime SavedLastLoginTime = 0.ToDateTime();
        public DateTime SavedPasswordChangeTime = 0.ToDateTime();
        public int SavedNumberOfLogins = 0;
        public int SavedNumberOfDenial = 0;
        public bool SavedTenantAdmin = false;
        public bool SavedServiceAdmin = false;
        public bool SavedDeveloper = false;
        public string SavedOldPassword = string.Empty;
        public string SavedChangedPassword = string.Empty;
        public string SavedChangedPasswordValidator = string.Empty;
        public string SavedAfterResetPassword = string.Empty;
        public string SavedAfterResetPasswordValidator = string.Empty;
        public string SavedSessionGuid = string.Empty;
        public bool TenantId_Updated { get { return TenantId != SavedTenantId; } }
        public bool UserId_Updated { get { return UserId != SavedUserId; } }
        public bool LoginId_Updated { get { return LoginId != SavedLoginId && LoginId != null; } }
        public bool Disabled_Updated { get { return Disabled != SavedDisabled; } }
        public bool UserCode_Updated { get { return UserCode != SavedUserCode && UserCode != null; } }
        public bool Password_Updated { get { return Password != SavedPassword && Password != null; } }
        public bool LastName_Updated { get { return LastName != SavedLastName && LastName != null; } }
        public bool FirstName_Updated { get { return FirstName != SavedFirstName && FirstName != null; } }
        public bool Birthday_Updated { get { return Birthday.Value != SavedBirthday && Birthday.Value != null; } }
        public bool Sex_Updated { get { return Sex != SavedSex && Sex != null; } }
        public bool Language_Updated { get { return Language != SavedLanguage && Language != null; } }
        public bool TimeZone_Updated { get { return TimeZone != SavedTimeZone && TimeZone != null; } }
        public bool DeptId_Updated { get { return DeptId != SavedDeptId; } }
        public bool FirstAndLastNameOrder_Updated { get { return FirstAndLastNameOrder.ToInt() != SavedFirstAndLastNameOrder; } }
        public bool LastLoginTime_Updated { get { return LastLoginTime.Value != SavedLastLoginTime && LastLoginTime.Value != null; } }
        public bool PasswordChangeTime_Updated { get { return PasswordChangeTime.Value != SavedPasswordChangeTime && PasswordChangeTime.Value != null; } }
        public bool NumberOfLogins_Updated { get { return NumberOfLogins != SavedNumberOfLogins; } }
        public bool NumberOfDenial_Updated { get { return NumberOfDenial != SavedNumberOfDenial; } }
        public bool TenantAdmin_Updated { get { return TenantAdmin != SavedTenantAdmin; } }
        public bool ServiceAdmin_Updated { get { return ServiceAdmin != SavedServiceAdmin; } }
        public bool Developer_Updated { get { return Developer != SavedDeveloper; } }
        public List<int> SwitchTargets;

        public UserModel()
        {
        }

        public UserModel(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            bool setByForm = false,
            MethodTypes methodType = MethodTypes.NotSet)
        {
            OnConstructing();
            SiteSettings = siteSettings;
            PermissionType = permissionType;
            if (setByForm) SetByForm();
            MethodType = methodType;
            OnConstructed();
        }

        public UserModel(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            int userId,
            bool clearSessions = false,
            bool setByForm = false,
            List<int> switchTargets = null,
            MethodTypes methodType = MethodTypes.NotSet)
        {
            OnConstructing();
            SiteSettings = siteSettings;
            UserId = userId;
            PermissionType = permissionType;
            Get();
            if (clearSessions) ClearSessions();
            if (setByForm) SetByForm();
            SwitchTargets = switchTargets;
            MethodType = methodType;
            OnConstructed();
        }

        public UserModel(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            DataRow dataRow)
        {
            OnConstructing();
            SiteSettings = siteSettings;
            Set(dataRow);
            OnConstructed();
        }

        private void OnConstructing()
        {
        }

        private void OnConstructed()
        {
        }

        public void ClearSessions()
        {
        }

        public UserModel Get(
            Sqls.TableTypes tableType = Sqls.TableTypes.Normal,
            SqlColumnCollection column = null,
            SqlJoinCollection join = null,
            SqlWhereCollection where = null,
            SqlOrderByCollection orderBy = null,
            SqlParamCollection param = null,
            bool distinct = false,
            int top = 0)
        {
            Set(Rds.ExecuteTable(statements: Rds.SelectUsers(
                tableType: tableType,
                column: column ?? Rds.UsersColumnDefault(),
                join: join ??  Rds.UsersJoinDefault(),
                where: where ?? Rds.UsersWhereDefault(this),
                orderBy: orderBy ?? null,
                param: param ?? null,
                distinct: distinct,
                top: top)));
            return this;
        }

        public string Create(
            Sqls.TableTypes tableType = Sqls.TableTypes.Normal,
            SqlParamCollection param = null,
            bool paramAll = false)
        {
            var error = ValidateBeforeCreate();
            if (error != null) return error;
            OnCreating();
            var newId = Rds.ExecuteScalar_int(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.InsertUsers(
                        tableType: tableType,
                        selectIdentity: true,
                        param: param ?? Rds.UsersParamDefault(
                            this, setDefault: true, paramAll: paramAll))
                });
            UserId = newId != 0 ? newId : UserId;
            Get();
            OnCreated();
            return RecordResponse(this, Messages.Created(Title.ToString()));
        }

        private void OnCreating()
        {
        }

        private void OnCreated()
        {
        }

        private string ValidateBeforeCreate()
        {
            if (!PermissionType.CanEditTenant() && !Self())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            foreach(var controlId in Forms.Keys())
            {
                switch (controlId)
                {
                    case "Users_TenantId": if (!SiteSettings.AllColumn("TenantId").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_UserId": if (!SiteSettings.AllColumn("UserId").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Ver": if (!SiteSettings.AllColumn("Ver").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_LoginId": if (!SiteSettings.AllColumn("LoginId").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Disabled": if (!SiteSettings.AllColumn("Disabled").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_UserCode": if (!SiteSettings.AllColumn("UserCode").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Password": if (!SiteSettings.AllColumn("Password").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_PasswordValidate": if (!SiteSettings.AllColumn("PasswordValidate").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_PasswordDummy": if (!SiteSettings.AllColumn("PasswordDummy").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_RememberMe": if (!SiteSettings.AllColumn("RememberMe").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_LastName": if (!SiteSettings.AllColumn("LastName").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FirstName": if (!SiteSettings.AllColumn("FirstName").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FullName1": if (!SiteSettings.AllColumn("FullName1").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FullName2": if (!SiteSettings.AllColumn("FullName2").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Birthday": if (!SiteSettings.AllColumn("Birthday").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Sex": if (!SiteSettings.AllColumn("Sex").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Language": if (!SiteSettings.AllColumn("Language").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_TimeZone": if (!SiteSettings.AllColumn("TimeZone").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_TimeZoneInfo": if (!SiteSettings.AllColumn("TimeZoneInfo").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_DeptId": if (!SiteSettings.AllColumn("DeptId").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Dept": if (!SiteSettings.AllColumn("Dept").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FirstAndLastNameOrder": if (!SiteSettings.AllColumn("FirstAndLastNameOrder").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Title": if (!SiteSettings.AllColumn("Title").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_LastLoginTime": if (!SiteSettings.AllColumn("LastLoginTime").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_PasswordChangeTime": if (!SiteSettings.AllColumn("PasswordChangeTime").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_NumberOfLogins": if (!SiteSettings.AllColumn("NumberOfLogins").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_NumberOfDenial": if (!SiteSettings.AllColumn("NumberOfDenial").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_TenantAdmin": if (!SiteSettings.AllColumn("TenantAdmin").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_ServiceAdmin": if (!SiteSettings.AllColumn("ServiceAdmin").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Developer": if (!SiteSettings.AllColumn("Developer").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_OldPassword": if (!SiteSettings.AllColumn("OldPassword").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_ChangedPassword": if (!SiteSettings.AllColumn("ChangedPassword").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_ChangedPasswordValidator": if (!SiteSettings.AllColumn("ChangedPasswordValidator").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_AfterResetPassword": if (!SiteSettings.AllColumn("AfterResetPassword").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_AfterResetPasswordValidator": if (!SiteSettings.AllColumn("AfterResetPasswordValidator").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_SessionGuid": if (!SiteSettings.AllColumn("SessionGuid").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Comments": if (!SiteSettings.AllColumn("Comments").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Creator": if (!SiteSettings.AllColumn("Creator").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Updator": if (!SiteSettings.AllColumn("Updator").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_CreatedTime": if (!SiteSettings.AllColumn("CreatedTime").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_UpdatedTime": if (!SiteSettings.AllColumn("UpdatedTime").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_VerUp": if (!SiteSettings.AllColumn("VerUp").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Timestamp": if (!SiteSettings.AllColumn("Timestamp").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                }
            }
            return null;
        }

        public string Update(SqlParamCollection param = null, bool paramAll = false)
        {
            var error = ValidateBeforeUpdate();
            if (error != null) return error;
            SetBySession();
            OnUpdating(ref param);
            var timestamp = Timestamp.ToDateTime();
            var count = Rds.ExecuteScalar_int(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.UpdateUsers(
                        verUp: VerUp,
                        where: Rds.UsersWhereDefault(this)
                            .UpdatedTime(timestamp, _using: timestamp.NotZero()),
                        param: param ?? Rds.UsersParamDefault(this, paramAll: paramAll),
                        countRecord: true)
                });
            if (count == 0) return ResponseConflicts();
            Get();
            var responseCollection = new UsersResponseCollection(this);
            OnUpdated(ref responseCollection);
            return ResponseByUpdate(responseCollection)
                .PrependComment(Comments, VerType)
                .ToJson();
        }

        private void OnUpdating(ref SqlParamCollection param)
        {
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private void OnUpdated(ref UsersResponseCollection responseCollection)
        {
            SiteInfo.SetUser(User());
            if (Self()) SetSession();
        }

        private string ValidateBeforeUpdate()
        {
            if (!PermissionType.CanEditTenant() && !Self())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            foreach(var controlId in Forms.Keys())
            {
                switch (controlId)
                {
                    case "Users_TenantId": if (!SiteSettings.AllColumn("TenantId").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_UserId": if (!SiteSettings.AllColumn("UserId").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Ver": if (!SiteSettings.AllColumn("Ver").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_LoginId": if (!SiteSettings.AllColumn("LoginId").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Disabled": if (!SiteSettings.AllColumn("Disabled").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_UserCode": if (!SiteSettings.AllColumn("UserCode").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Password": if (!SiteSettings.AllColumn("Password").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_PasswordValidate": if (!SiteSettings.AllColumn("PasswordValidate").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_PasswordDummy": if (!SiteSettings.AllColumn("PasswordDummy").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_RememberMe": if (!SiteSettings.AllColumn("RememberMe").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_LastName": if (!SiteSettings.AllColumn("LastName").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FirstName": if (!SiteSettings.AllColumn("FirstName").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FullName1": if (!SiteSettings.AllColumn("FullName1").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FullName2": if (!SiteSettings.AllColumn("FullName2").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Birthday": if (!SiteSettings.AllColumn("Birthday").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Sex": if (!SiteSettings.AllColumn("Sex").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Language": if (!SiteSettings.AllColumn("Language").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_TimeZone": if (!SiteSettings.AllColumn("TimeZone").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_TimeZoneInfo": if (!SiteSettings.AllColumn("TimeZoneInfo").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_DeptId": if (!SiteSettings.AllColumn("DeptId").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Dept": if (!SiteSettings.AllColumn("Dept").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_FirstAndLastNameOrder": if (!SiteSettings.AllColumn("FirstAndLastNameOrder").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Title": if (!SiteSettings.AllColumn("Title").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_LastLoginTime": if (!SiteSettings.AllColumn("LastLoginTime").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_PasswordChangeTime": if (!SiteSettings.AllColumn("PasswordChangeTime").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_NumberOfLogins": if (!SiteSettings.AllColumn("NumberOfLogins").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_NumberOfDenial": if (!SiteSettings.AllColumn("NumberOfDenial").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_TenantAdmin": if (!SiteSettings.AllColumn("TenantAdmin").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_ServiceAdmin": if (!SiteSettings.AllColumn("ServiceAdmin").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Developer": if (!SiteSettings.AllColumn("Developer").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_OldPassword": if (!SiteSettings.AllColumn("OldPassword").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_ChangedPassword": if (!SiteSettings.AllColumn("ChangedPassword").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_ChangedPasswordValidator": if (!SiteSettings.AllColumn("ChangedPasswordValidator").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_AfterResetPassword": if (!SiteSettings.AllColumn("AfterResetPassword").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_AfterResetPasswordValidator": if (!SiteSettings.AllColumn("AfterResetPasswordValidator").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_SessionGuid": if (!SiteSettings.AllColumn("SessionGuid").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Comments": if (!SiteSettings.AllColumn("Comments").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Creator": if (!SiteSettings.AllColumn("Creator").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Updator": if (!SiteSettings.AllColumn("Updator").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_CreatedTime": if (!SiteSettings.AllColumn("CreatedTime").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_UpdatedTime": if (!SiteSettings.AllColumn("UpdatedTime").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_VerUp": if (!SiteSettings.AllColumn("VerUp").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Users_Timestamp": if (!SiteSettings.AllColumn("Timestamp").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                }
            }
            return null;
        }

        private ResponseCollection ResponseByUpdate(UsersResponseCollection responseCollection)
        {
            return responseCollection
                .Ver()
                .Timestamp()
                .Val("#VerUp", false)
                .Disabled("#VerUp", false)
                .Html("#HeaderTitle", Title.DisplayValue + " - " + Displays.Edit())
                .Html("#RecordInfo", Html.Builder().RecordInfo(baseModel: this, tableName: "Users"))
                .Html("#RecordHistories", Html.Builder().RecordHistories(ver: Ver, verType: VerType))
                .Message(Messages.Updated(Title.ToString()))
                .RemoveComment(DeleteCommentId, _using: DeleteCommentId != 0)
                .ClearFormData();
        }

        public string UpdateOrCreate(
            SqlWhereCollection where = null,
            SqlParamCollection param = null)
        {
            if (!PermissionType.CanEditTenant())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            SetBySession();
            OnUpdatingOrCreating(ref where, ref param);
            var newId = Rds.ExecuteScalar_int(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.UpdateOrInsertUsers(
                        selectIdentity: true,
                        where: where ?? Rds.UsersWhereDefault(this),
                        param: param ?? Rds.UsersParamDefault(this, setDefault: true))
                });
            UserId = newId != 0 ? newId : UserId;
            Get();
            var responseCollection = new UsersResponseCollection(this);
            OnUpdatedOrCreated(ref responseCollection);
            return responseCollection.ToJson();
        }

        private void OnUpdatingOrCreating(
            ref SqlWhereCollection where,
            ref SqlParamCollection param)
        {
        }

        private void OnUpdatedOrCreated(ref UsersResponseCollection responseCollection)
        {
        }

        public string Delete(bool redirect = true)
        {
            if (!PermissionType.CanEditTenant())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            OnDeleting();
            Rds.ExecuteNonQuery(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.DeleteUsers(
                        where: Rds.UsersWhere().UserId(UserId))
                });
            var responseCollection = new UsersResponseCollection(this);
            OnDeleted(ref responseCollection);
            if (redirect)
            {
                responseCollection.Href(Navigations.Index("Users"));
            }
            return responseCollection.ToJson();
        }

        private void OnDeleting()
        {
        }

        private void OnDeleted(ref UsersResponseCollection responseCollection)
        {
        }

        public string Restore(int userId)
        {
            if (!Permissions.Admins().CanEditTenant())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            UserId = userId;
            Rds.ExecuteNonQuery(
                connectionString: Def.Parameters.RdsOwnerConnectionString,
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.RestoreUsers(
                        where: Rds.UsersWhere().UserId(UserId))
                });
            return new ResponseCollection().ToJson();
        }

        public string PhysicalDelete(Sqls.TableTypes tableType = Sqls.TableTypes.Normal)
        {
            if (!PermissionType.CanEditTenant())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            OnPhysicalDeleting();
            Rds.ExecuteNonQuery(
                transactional: true,
                statements: Rds.PhysicalDeleteUsers(
                    tableType: tableType,
                    param: Rds.UsersParam().UserId(UserId)));
            var responseCollection = new UsersResponseCollection(this);
            OnPhysicalDeleted(ref responseCollection);
            return responseCollection.ToJson();
        }

        private void OnPhysicalDeleting()
        {
        }

        private void OnPhysicalDeleted(ref UsersResponseCollection responseCollection)
        {
        }

        public string Histories()
        {
            var hb = Html.Builder();
            hb.Table(
                attributes: Html.Attributes().Class("grid"),
                action: () =>
                {
                    hb.GridHeader(
                        columnCollection: SiteSettings.HistoryGridColumnCollection(),
                        sort: false,
                        checkRow: false);
                    new UserCollection(
                        siteSettings: SiteSettings,
                        permissionType: PermissionType,
                        where: Rds.UsersWhere().UserId(UserId),
                        orderBy: Rds.UsersOrderBy().UpdatedTime(SqlOrderBy.Types.desc),
                        tableType: Sqls.TableTypes.NormalAndHistory).ForEach(userModel => hb
                            .Tr(
                                attributes: Html.Attributes()
                                    .Class("grid-row not-link")
                                    .OnClick(Def.JavaScript.HistoryAndCloseDialog
                                        .Params(userModel.Ver))
                                    .DataAction("History")
                                    .DataMethod("post")
                                    .Add("data-latest", 1, _using: userModel.Ver == Ver),
                                action: () =>
                                    SiteSettings.HistoryGridColumnCollection().ForEach(column =>
                                        hb.TdValue(column, userModel))));
                });
            return new UsersResponseCollection(this).Html("#HistoriesForm", hb).ToJson();
        }

        public string History()
        {
            Get(
                where: Rds.UsersWhere()
                    .UserId(UserId)
                    .Ver(Forms.Int("Ver")),
                tableType: Sqls.TableTypes.NormalAndHistory);
            VerType =  Forms.Bool("Latest")
                ? Versions.VerTypes.Latest
                : Versions.VerType(UserId);
            SwitchTargets = UsersUtility.GetSwitchTargets(SiteSettings);
            return Editor();
        }

        public string PreviousHistory()
        {
            Get(
                where: Rds.UsersWhere()
                    .UserId(UserId)
                    .Ver(Forms.Int("Ver"), _operator: "<"),
                orderBy: Rds.UsersOrderBy()
                    .Ver(SqlOrderBy.Types.desc),
                tableType: Sqls.TableTypes.History,
                top: 1);
            SwitchTargets = UsersUtility.GetSwitchTargets(SiteSettings);
            switch (AccessStatus)
            {
                case Databases.AccessStatuses.Selected:
                    VerType = Versions.VerType(UserId, Versions.DirectioTypes.Previous);
                    return Editor();
                default:
                    return new UsersResponseCollection(this).ToJson();
            }
        }

        public string NextHistory()
        {
            Get(
                where: Rds.UsersWhere()
                    .UserId(UserId)
                    .Ver(Forms.Int("Ver"), _operator: ">"),
                orderBy: Rds.UsersOrderBy()
                    .Ver(SqlOrderBy.Types.asc),
                tableType: Sqls.TableTypes.History,
                top: 1);
            SwitchTargets = UsersUtility.GetSwitchTargets(SiteSettings);
            switch (AccessStatus)
            {
                case Databases.AccessStatuses.Selected:
                    VerType = Versions.VerType(UserId, Versions.DirectioTypes.Next);
                    return Editor();
                default:
                    return new UsersResponseCollection(this).ToJson();
            }
        }

        public string Previous()
        {
            var switchTargets = UsersUtility.GetSwitchTargets(SiteSettings);
            var userModel = new UserModel(
                siteSettings: SiteSettings,
                permissionType: PermissionType,
                userId: switchTargets.Previous(UserId),
                switchTargets: switchTargets);
            return RecordResponse(userModel);
        }

        public string Next()
        {
            var switchTargets = UsersUtility.GetSwitchTargets(SiteSettings);
            var userModel = new UserModel(
                siteSettings: SiteSettings,
                permissionType: PermissionType,
                userId: switchTargets.Next(UserId),
                switchTargets: switchTargets);
            return RecordResponse(userModel);
        }

        public string Reload()
        {
            SwitchTargets = UsersUtility.GetSwitchTargets(SiteSettings);
            return RecordResponse(this, pushState: false);
        }

        private string RecordResponse(
            UserModel userModel, Message message = null, bool pushState = true)
        {
            userModel.MethodType = BaseModel.MethodTypes.Edit;
            return new UsersResponseCollection(this)
                .Func("clearDialogs")
                .Html(
                    "#MainContainer",
                    userModel.AccessStatus == Databases.AccessStatuses.Selected
                        ? UsersUtility.Editor(userModel)
                        : UsersUtility.Editor(this))
                .Message(message)
                .PushState(
                    Navigations.Edit("Users", userModel.UserId),
                    _using: pushState)
                .ClearFormData()
                .ToJson();
        }

        private void SetByForm()
        {
            Forms.Keys().ForEach(controlId =>
            {
                switch (controlId)
                {
                    case "Users_LoginId": LoginId = Forms.Data(controlId).ToString(); break;
                    case "Users_Disabled": Disabled = Forms.Data(controlId).ToBool(); break;
                    case "Users_UserCode": UserCode = Forms.Data(controlId).ToString(); break;
                    case "Users_Password": Password = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_PasswordValidate": PasswordValidate = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_PasswordDummy": PasswordDummy = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_RememberMe": RememberMe = Forms.Data(controlId).ToBool(); break;
                    case "Users_LastName": LastName = Forms.Data(controlId).ToString(); break;
                    case "Users_FirstName": FirstName = Forms.Data(controlId).ToString(); break;
                    case "Users_Birthday": Birthday = new Time(Forms.Data(controlId).ToDateTime(), byForm: true); break;
                    case "Users_Sex": Sex = Forms.Data(controlId).ToString(); break;
                    case "Users_Language": Language = Forms.Data(controlId).ToString(); break;
                    case "Users_TimeZone": TimeZone = Forms.Data(controlId).ToString(); break;
                    case "Users_DeptId": DeptId = Forms.Data(controlId).ToInt(); break;
                    case "Users_FirstAndLastNameOrder": FirstAndLastNameOrder = (Names.FirstAndLastNameOrders)Forms.Data(controlId).ToInt(); break;
                    case "Users_LastLoginTime": LastLoginTime = new Time(Forms.Data(controlId).ToDateTime(), byForm: true); break;
                    case "Users_PasswordChangeTime": PasswordChangeTime = new Time(Forms.Data(controlId).ToDateTime(), byForm: true); break;
                    case "Users_NumberOfLogins": NumberOfLogins = Forms.Data(controlId).ToInt(); break;
                    case "Users_NumberOfDenial": NumberOfDenial = Forms.Data(controlId).ToInt(); break;
                    case "Users_TenantAdmin": TenantAdmin = Forms.Data(controlId).ToBool(); break;
                    case "Users_OldPassword": OldPassword = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_ChangedPassword": ChangedPassword = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_ChangedPasswordValidator": ChangedPasswordValidator = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_AfterResetPassword": AfterResetPassword = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_AfterResetPasswordValidator": AfterResetPasswordValidator = Forms.Data(controlId).ToString().Sha512Cng(); break;
                    case "Users_SessionGuid": SessionGuid = Forms.Data(controlId).ToString(); break;
                    case "Users_Timestamp": Timestamp = Forms.Data(controlId).ToString(); break;
                    case "Comments": Comments = Comments.Prepend(Forms.Data("Comments")); break;
                    case "VerUp": VerUp = Forms.Data(controlId).ToBool(); break;
                    default: break;
                }
            });
            if (Routes.Action() == "deletecomment")
            {
                DeleteCommentId = Forms.Data("ControlId").Split(',')._2nd().ToInt();
                Comments.RemoveAll(o => o.CommentId == DeleteCommentId);
            }
            Forms.FileKeys().ForEach(controlId =>
            {
                switch (controlId)
                {
                    default: break;
                }
            });
        }

        private void SetBySession()
        {
        }

        private void Set(DataTable dataTable)
        {
            switch (dataTable.Rows.Count)
            {
                case 1: Set(dataTable.Rows[0]); break;
                case 0: AccessStatus = Databases.AccessStatuses.NotFound; break;
                default: AccessStatus = Databases.AccessStatuses.Overlap; break;
            }
        }

        private void Set(DataRow dataRow)
        {
            AccessStatus = Databases.AccessStatuses.Selected;
            foreach(DataColumn dataColumn in dataRow.Table.Columns)
            {
                var name = dataColumn.ColumnName;
                switch(name)
                {
                    case "TenantId": if (dataRow[name] != DBNull.Value) { TenantId = dataRow[name].ToInt(); SavedTenantId = TenantId; } break;
                    case "UserId": if (dataRow[name] != DBNull.Value) { UserId = dataRow[name].ToInt(); SavedUserId = UserId; } break;
                    case "Ver": Ver = dataRow[name].ToInt(); SavedVer = Ver; break;
                    case "LoginId": LoginId = dataRow[name].ToString(); SavedLoginId = LoginId; break;
                    case "Disabled": Disabled = dataRow[name].ToBool(); SavedDisabled = Disabled; break;
                    case "UserCode": UserCode = dataRow[name].ToString(); SavedUserCode = UserCode; break;
                    case "Password": Password = dataRow[name].ToString(); SavedPassword = Password; break;
                    case "LastName": LastName = dataRow[name].ToString(); SavedLastName = LastName; break;
                    case "FirstName": FirstName = dataRow[name].ToString(); SavedFirstName = FirstName; break;
                    case "Birthday": Birthday = new Time(dataRow, "Birthday"); SavedBirthday = Birthday.Value; break;
                    case "Sex": Sex = dataRow[name].ToString(); SavedSex = Sex; break;
                    case "Language": Language = dataRow[name].ToString(); SavedLanguage = Language; break;
                    case "TimeZone": TimeZone = dataRow[name].ToString(); SavedTimeZone = TimeZone; break;
                    case "DeptId": DeptId = dataRow[name].ToInt(); SavedDeptId = DeptId; break;
                    case "FirstAndLastNameOrder": FirstAndLastNameOrder = (Names.FirstAndLastNameOrders)dataRow[name].ToInt(); SavedFirstAndLastNameOrder = FirstAndLastNameOrder.ToInt(); break;
                    case "LastLoginTime": LastLoginTime = new Time(dataRow, "LastLoginTime"); SavedLastLoginTime = LastLoginTime.Value; break;
                    case "PasswordChangeTime": PasswordChangeTime = new Time(dataRow, "PasswordChangeTime"); SavedPasswordChangeTime = PasswordChangeTime.Value; break;
                    case "NumberOfLogins": NumberOfLogins = dataRow[name].ToInt(); SavedNumberOfLogins = NumberOfLogins; break;
                    case "NumberOfDenial": NumberOfDenial = dataRow[name].ToInt(); SavedNumberOfDenial = NumberOfDenial; break;
                    case "TenantAdmin": TenantAdmin = dataRow[name].ToBool(); SavedTenantAdmin = TenantAdmin; break;
                    case "ServiceAdmin": ServiceAdmin = dataRow[name].ToBool(); SavedServiceAdmin = ServiceAdmin; break;
                    case "Developer": Developer = dataRow[name].ToBool(); SavedDeveloper = Developer; break;
                    case "Comments": Comments = dataRow["Comments"].ToString().Deserialize<Comments>() ?? new Comments(); SavedComments = Comments.ToJson(); break;
                    case "Creator": Creator = SiteInfo.User(dataRow.Int(name)); SavedCreator = Creator.Id; break;
                    case "Updator": Updator = SiteInfo.User(dataRow.Int(name)); SavedUpdator = Updator.Id; break;
                    case "CreatedTime": CreatedTime = new Time(dataRow, "CreatedTime"); SavedCreatedTime = CreatedTime.Value; break;
                    case "UpdatedTime": UpdatedTime = new Time(dataRow, "UpdatedTime"); Timestamp = dataRow.Field<DateTime>("UpdatedTime").ToString("yyyy/M/d H:m:s.fff"); SavedUpdatedTime = UpdatedTime.Value; break;
                }
            }
        }

        private string Editor()
        {
            return new UsersResponseCollection(this)
                .Html("#MainContainer", UsersUtility.Editor(this))
                .ToJson();
        }

        private string ResponseConflicts()
        {
            Get();
            return AccessStatus == Databases.AccessStatuses.Selected
                ? Messages.ResponseUpdateConflicts(Updator.FullName).ToJson()
                : Messages.ResponseDeleteConflicts().ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public User User()
        {
            return new User()
            {
                Id = UserId,
                DeptId = DeptId,
                FullName = FullName(),
                TenantAdmin = TenantAdmin,
                ServiceAdmin = ServiceAdmin
            };
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public RdsUser RdsUser()
        {
            return new RdsUser()
            {
                UserId = UserId,
                DeptId = DeptId
            };
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public UserModel(RdsUser.UserTypes userType)
        {
            OnConstructing();
            UserId = userType.ToInt();
            Get();
            OnConstructed();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public bool Self()
        {
            return Sessions.UserId() == UserId;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string FullName()
        {
            return Names.FullName(FirstAndLastNameOrder, FullName1, FullName2);
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string Authenticate(string returnUrl)
        {
            return Authenticate() ? Allow(returnUrl) : Deny();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private bool Authenticate()
        {
            var ret = false;
            switch (Def.Parameters.AuthenticationProvider)
            {
                case "LDAP":
                    ret = Ldap.Authenticate();
                    if (ret) Get(where: Rds.UsersWhere().LoginId(LoginId));
                    break;
                default:
                    ret = GetByCredentials();
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private bool GetByCredentials()
        {
            Get(where: Rds.UsersWhere()
                .LoginId(LoginId)
                .Password(Password)
                .Disabled(0));
            return AccessStatus == Databases.AccessStatuses.Selected;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private string Allow(string returnUrl)
        {
            Rds.ExecuteNonQuery(statements: Rds.UpdateUsers(
                where: Rds.UsersWhereDefault(this),
                param: Rds.UsersParam()
                    .NumberOfLogins(raw: "[NumberOfLogins] + 1")
                    .LastLoginTime(DateTime.Now)));
            SetFormsAuthentication(returnUrl);
            return new UsersResponseCollection(this)
                .Message(Messages.LoginIn())
                .Href(returnUrl == string.Empty
                    ? Navigations.Top()
                    : returnUrl).ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private string Deny()
        {
            Rds.ExecuteNonQuery(statements: Rds.UpdateUsers(
                param: Rds.UsersParam()
                    .NumberOfDenial(raw: "[NumberOfDenial] + 1"),
                where: Rds.UsersWhere()
                    .LoginId(LoginId)));
            return Messages.ResponseAuthentication().Focus("#Password").ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public void SetFormsAuthentication(string returnUrl)
        {
            System.Web.Security.FormsAuthentication.SetAuthCookie(
                UserId.ToString(), 
                HttpContext.Current.Request.Form["Users_RememberMe"].ToBool());
            SetSession();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public void SetSession()
        {
            HttpContext.Session["UserId"] = UserId;
            HttpContext.Session["Language"] = Language;
            HttpContext.Session["Developer"] = Developer;
            HttpContext.Session["TimeZoneInfo"] = TimeZoneInfo;
            HttpContext.Session["RdsUser"] = RdsUser();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string ChangePassword()
        {
            var responseCollection = new UsersResponseCollection(this);
            var siteSettings = SiteSettingsUtility.UsersSiteSettings();
            if (UserId == Sessions.UserId())
            {
                Password = OldPassword;
                if (GetByCredentials())
                {
                    Rds.ExecuteNonQuery(statements: Rds.UpdateUsers(
                        where: Rds.UsersWhereDefault(this),
                        param: Rds.UsersParam()
                            .PasswordChangeTime(raw: "getdate()")
                            .Password(ChangedPassword)));
                    responseCollection
                        .PasswordChangeTime(PasswordChangeTime.ToString())
                        .UpdatedTime(UpdatedTime.ToString())
                        .OldPassword(string.Empty)
                        .ChangedPassword(string.Empty)
                        .ChangedPasswordValidator(string.Empty)
                        .ClearFormData()
                        .CloseDialog()
                        .Message(Messages.ChangingPasswordComplete());
                }
                else
                {
                    responseCollection.Message(Messages.IncorrectCurrentPassword());
                }
            }
            else
            {
                responseCollection.Message(Messages.HasNotPermission());
            }
            return responseCollection.ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string ResetPassword()
        {
            var responseCollection = new UsersResponseCollection(this);
            var siteSettings = SiteSettingsUtility.UsersSiteSettings();
            if (Permissions.Admins().CanEditTenant())
            {
                Rds.ExecuteNonQuery(statements: Rds.UpdateUsers(
                    where: Rds.UsersWhereDefault(this),
                    param: Rds.UsersParam()
                        .PasswordChangeTime(raw: "getdate()")
                        .Password(AfterResetPassword)));
                responseCollection
                    .PasswordChangeTime(PasswordChangeTime.ToString())
                    .UpdatedTime(UpdatedTime.ToString())
                    .AfterResetPassword(string.Empty)
                    .AfterResetPasswordValidator(string.Empty)
                    .ClearFormData()
                    .CloseDialog()
                    .Message(Messages.PasswordResetCompleted());
            }
            else
            {
                responseCollection.Message(Messages.HasNotPermission());
            }
            return responseCollection.ToJson();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string ToControl(Column column)
        {
            return UserId.ToString();
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string ToResponse()
        {
            return string.Empty;
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public HtmlBuilder Td(HtmlBuilder hb, Column column)
        {
            return UserId != 0 ?
                hb.Td(action: () => hb
                    .HtmlUser(UserId)) :
                hb.Td(action: () => { });
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public string ToExport(Column column)
        {
            return SiteInfo.UserFullName(UserId);
        }
    }

    public class UserCollection : List<UserModel>
    {
        public Databases.AccessStatuses AccessStatus = Databases.AccessStatuses.Initialized;
        public Aggregations Aggregations = new Aggregations();

        public UserCollection(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            SqlColumnCollection column = null,
            SqlJoinCollection join = null,
            SqlWhereCollection where = null,
            SqlOrderByCollection orderBy = null,
            SqlParamCollection param = null,
            Sqls.TableTypes tableType = Sqls.TableTypes.Normal,
            bool distinct = false,
            int top = 0,
            int offset = 0,
            int pageSize = 0,
            bool countRecord = false,
            IEnumerable<Aggregation> aggregationCollection = null)
        {
            Set(siteSettings, permissionType, Get(
                column: column,
                join: join,
                where: where,
                orderBy: orderBy,
                param: param,
                tableType: tableType,
                distinct: distinct,
                top: top,
                offset: offset,
                pageSize: pageSize,
                countRecord: countRecord,
                aggregationCollection: aggregationCollection));
        }

        public UserCollection(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            DataTable dataTable)
        {
            Set(siteSettings, permissionType, dataTable);
        }

        private UserCollection Set(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Add(new UserModel(siteSettings, permissionType, dataRow));
                }
                AccessStatus = Databases.AccessStatuses.Selected;
            }
            else
            {
                AccessStatus = Databases.AccessStatuses.NotFound;
            }
            return this;
        }

        public UserCollection(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            string commandText,
            SqlParamCollection param = null)
        {
            Set(siteSettings, permissionType, Get(commandText, param));
        }

        private DataTable Get(
            SqlColumnCollection column = null,
            SqlJoinCollection join = null,
            SqlWhereCollection where = null,
            SqlOrderByCollection orderBy = null,
            SqlParamCollection param = null,
            Sqls.TableTypes tableType = Sqls.TableTypes.Normal,
            bool distinct = false,
            int top = 0,
            int offset = 0,
            int pageSize = 0,
            bool history = false,
            bool countRecord = false,
            IEnumerable<Aggregation> aggregationCollection = null)
        {
            var statements = new List<SqlStatement>
            {
                Rds.SelectUsers(
                    dataTableName: "Main",
                    column: column ?? Rds.UsersColumnDefault(),
                    join: join ??  Rds.UsersJoinDefault(),
                    where: where ?? null,
                    orderBy: orderBy ?? null,
                    param: param ?? null,
                    tableType: tableType,
                    distinct: distinct,
                    top: top,
                    offset: offset,
                    pageSize: pageSize,
                    countRecord: countRecord)
            };
            if (aggregationCollection != null)
            {
                statements.AddRange(Rds.UsersAggregations(aggregationCollection, where));
            }
            var dataSet = Rds.ExecuteDataSet(
                transactional: false,
                statements: statements.ToArray());
            Aggregations.Set(dataSet, aggregationCollection);
            return dataSet.Tables["Main"];
        }

        private DataTable Get(string commandText, SqlParamCollection param = null)
        {
            return Rds.ExecuteTable(
                transactional: false,
                statements: Rds.UsersStatement(
                    commandText: commandText,
                    param: param ?? null));
        }
    }

    public static class UsersUtility
    {
        /// <summary>
        /// Fixed:
        /// </summary>
        public static string Index(SiteSettings siteSettings, Permissions.Types permissionType)
        {
            var hb = Html.Builder();
            var formData = DataViewFilters.SessionFormData();
            var userCollection = UserCollection(
                siteSettings,
                Permissions.Admins(),
                formData);
            return hb.Template(
                siteId: 0,
                modelName: "User",
                title: Displays.Users() + " - " + Displays.List(),
                permissionType: permissionType,
                verType: Versions.VerTypes.Latest,
                backUrl: Navigations.Index("Admins"),
                methodType: BaseModel.MethodTypes.Index,
                allowAccess: Sessions.User().TenantAdmin,
                action: () =>
                {
                    hb
                        .Form(
                            attributes: Html.Attributes()
                                .Id("UserForm")
                                .Action(Navigations.Action("Users")),
                            action: () => hb
                                .DataViewFilters(siteSettings)
                                .Aggregations(
                                    siteSettings: siteSettings,
                                    aggregations: userCollection.Aggregations)
                                .Div(id: "DataViewContainer", action: () => hb
                                    .Grid(
                                        userCollection: userCollection,
                                        permissionType: permissionType,
                                        siteSettings: siteSettings,
                                        formData: formData))
                                .Div(css: "margin-bottom")
                                .Hidden(controlId: "TableName", value: "Users")
                                .Hidden(controlId: "BaseUrl", value: Navigations.BaseUrl())
                                .Hidden(
                                    controlId: "GridOffset",
                                    value: Def.Parameters.GridPageSize.ToString()))
                        .Div(attributes: Html.Attributes()
                            .Id_Css("Dialog_ImportSettings", "dialog")
                            .Title(Displays.Import()))
                        .Div(attributes: Html.Attributes()
                            .Id_Css("Dialog_ExportSettings", "dialog")
                            .Title(Displays.ExportSettings()));
                }).ToString();
        }

        private static UserCollection UserCollection(
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            FormData formData, int offset = 0)
        {
            return new UserCollection(
                siteSettings: siteSettings,
                permissionType: permissionType,
                column: GridSqlColumnCollection(siteSettings),
                where: DataViewFilters.Get(
                    siteSettings: siteSettings,
                    tableName: "Users",
                    formData: formData,
                    where: Rds.UsersWhere().TenantId(Sessions.TenantId())),
                orderBy: GridSorters.Get(
                    formData, Rds.UsersOrderBy().UpdatedTime(SqlOrderBy.Types.desc)),
                offset: offset,
                pageSize: siteSettings.GridPageSize.ToInt(),
                countRecord: true,
                aggregationCollection: siteSettings.AggregationCollection);
        }

        public static string IndexScript(
            UserCollection userCollection,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            FormData formData,
            string dataViewName)
        {
            return string.Empty;
        }

        public static HtmlBuilder DataView(
            this HtmlBuilder hb,
            UserCollection userCollection,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            FormData formData,
            string dataViewName)
        {
            switch (dataViewName)
            {
                default: return hb.Grid(
                    userCollection: userCollection,
                    siteSettings: siteSettings,
                    permissionType: permissionType,
                    formData: formData);
            }
        }

        public static string DataView(
            SiteSettings siteSettings, Permissions.Types permissionType)
        {
            switch (DataViewSelectors.Get(siteSettings.SiteId))
            {
                default: return Grid(siteSettings: siteSettings, permissionType: permissionType);
            }
        }

        private static HtmlBuilder Grid(
            this HtmlBuilder hb,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            UserCollection userCollection,
            FormData formData)
        {
            return hb
                .Table(
                    attributes: Html.Attributes()
                        .Id_Css("Grid", "grid")
                        .DataAction("GridRows")
                        .DataMethod("post"),
                    action: () => hb
                        .GridRows(
                            siteSettings: siteSettings,
                            userCollection: userCollection,
                            formData: formData))
                .Hidden(
                    controlId: "GridOffset",
                    value: siteSettings.GridPageSize.ToString())
                .MainCommands(
                    siteId: siteSettings.SiteId,
                    permissionType: permissionType,
                    verType: Versions.VerTypes.Latest,
                    backUrl: Navigations.Index("Admins"),
                    bulkMoveButton: true,
                    bulkDeleteButton: true,
                    importButton: true,
                    exportButton: true);
        }

        private static string Grid(SiteSettings siteSettings, Permissions.Types permissionType)
        {
            var formData = DataViewFilters.SessionFormData();
            var userCollection = UserCollection(siteSettings, permissionType, formData);
            return new ResponseCollection()
                .Html("#DataViewContainer", userCollection.Count > 0
                    ? Html.Builder().Grid(
                        siteSettings: siteSettings,
                        userCollection: userCollection,
                        permissionType: permissionType,
                        formData: formData)
                    : Html.Builder())
                .Html("#Aggregations", Html.Builder().Aggregations(
                    siteSettings: siteSettings,
                    aggregations: userCollection.Aggregations,
                    container: false))
                .WindowScrollTop().ToJson();
        }

        public static string GridRows(
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            ResponseCollection responseCollection = null,
            int offset = 0,
            bool clearCheck = false,
            Message message = null)
        {
            var formData = DataViewFilters.SessionFormData();
            var userCollection = UserCollection(siteSettings, permissionType, formData, offset);
            return (responseCollection ?? new ResponseCollection())
                .Remove(".grid tr", _using: offset == 0)
                .ClearFormData("GridCheckAll", _using: clearCheck)
                .ClearFormData("GridUnCheckedItems", _using: clearCheck)
                .ClearFormData("GridCheckedItems", _using: clearCheck)
                .Message(message)
                .Append("#Grid", Html.Builder().GridRows(
                    siteSettings: siteSettings,
                    userCollection: userCollection,
                    formData: formData,
                    addHeader: offset == 0,
                    clearCheck: clearCheck))
                .Html("#Aggregations", Html.Builder().Aggregations(
                    siteSettings: siteSettings,
                    aggregations: userCollection.Aggregations,
                    container: false))
                .Val("#GridOffset", siteSettings.NextPageOffset(offset, userCollection.Count()))
                .Markup()
                .ToJson();
        }

        private static HtmlBuilder GridRows(
            this HtmlBuilder hb,
            SiteSettings siteSettings,
            UserCollection userCollection,
            FormData formData,
            bool addHeader = true,
            bool clearCheck = false)
        {
            var checkAll = clearCheck ? false : Forms.Bool("GridCheckAll");
            if (addHeader)
            {
                hb.GridHeader(
                    columnCollection: siteSettings.GridColumnCollection(), 
                    formData: formData,
                    checkAll: checkAll);
            }
            userCollection.ForEach(userModel => hb
                .Tr(
                    attributes: Html.Attributes()
                        .Class("grid-row")
                        .DataId(userModel.UserId.ToString()),
                    action: () =>
                    {
                        hb.Td(action: () => hb
                            .CheckBox(
                                controlCss: "grid-check",
                                _checked: checkAll,
                                dataId: userModel.UserId.ToString()));
                        siteSettings.GridColumnCollection()
                            .ForEach(column => hb
                                .TdValue(
                                    column: column,
                                    userModel: userModel));
                    }));
            return hb;
        }

        private static SqlColumnCollection GridSqlColumnCollection(SiteSettings siteSettings)
        {
            var select = Rds.UsersColumn()
                .UserId()
                .Creator()
                .Updator();
            siteSettings.GridColumnCollection(withTitle: true).ForEach(columnGrid =>
            {
                switch (columnGrid.ColumnName)
                {
                    case "TenantId": select.TenantId(); break;
                    case "UserId": select.UserId(); break;
                    case "Ver": select.Ver(); break;
                    case "LoginId": select.LoginId(); break;
                    case "Disabled": select.Disabled(); break;
                    case "UserCode": select.UserCode(); break;
                    case "Password": select.Password(); break;
                    case "LastName": select.LastName(); break;
                    case "FirstName": select.FirstName(); break;
                    case "Birthday": select.Birthday(); break;
                    case "Sex": select.Sex(); break;
                    case "Language": select.Language(); break;
                    case "TimeZone": select.TimeZone(); break;
                    case "DeptId": select.DeptId(); break;
                    case "Dept": select.Dept(); break;
                    case "FirstAndLastNameOrder": select.FirstAndLastNameOrder(); break;
                    case "LastLoginTime": select.LastLoginTime(); break;
                    case "PasswordChangeTime": select.PasswordChangeTime(); break;
                    case "NumberOfLogins": select.NumberOfLogins(); break;
                    case "NumberOfDenial": select.NumberOfDenial(); break;
                    case "TenantAdmin": select.TenantAdmin(); break;
                    case "ServiceAdmin": select.ServiceAdmin(); break;
                    case "Developer": select.Developer(); break;
                    case "Comments": select.Comments(); break;
                    case "Creator": select.Creator(); break;
                    case "Updator": select.Updator(); break;
                    case "CreatedTime": select.CreatedTime(); break;
                    case "UpdatedTime": select.UpdatedTime(); break;
                }
            });
            return select;
        }

        public static HtmlBuilder TdValue(
            this HtmlBuilder hb, Column column, UserModel userModel)
        {
            switch (column.ColumnName)
            {
                case "UserId": return hb.Td(column: column, value: userModel.UserId);
                case "Ver": return hb.Td(column: column, value: userModel.Ver);
                case "LoginId": return hb.Td(column: column, value: userModel.LoginId);
                case "Disabled": return hb.Td(column: column, value: userModel.Disabled);
                case "Birthday": return hb.Td(column: column, value: userModel.Birthday);
                case "Sex": return hb.Td(column: column, value: userModel.Sex);
                case "Language": return hb.Td(column: column, value: userModel.Language);
                case "TimeZoneInfo": return hb.Td(column: column, value: userModel.TimeZoneInfo);
                case "Dept": return hb.Td(column: column, value: userModel.Dept);
                case "LastLoginTime": return hb.Td(column: column, value: userModel.LastLoginTime);
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

        public static string EditorNew()
        {
            return Editor(new UserModel(
                SiteSettingsUtility.UsersSiteSettings(),
                Permissions.Admins(),
                methodType: BaseModel.MethodTypes.New));
        }

        public static string Editor(int userId, bool clearSessions)
        {
            var userModel = new UserModel(
                SiteSettingsUtility.UsersSiteSettings(),
                Permissions.Admins(),
                userId: userId,
                clearSessions: clearSessions,
                methodType: BaseModel.MethodTypes.Edit);
            userModel.SwitchTargets = UsersUtility.GetSwitchTargets(
                SiteSettingsUtility.UsersSiteSettings());
            return Editor(userModel);
        }

        public static string Editor(UserModel userModel)
        {
            var hb = Html.Builder();
            var permissionType = Permissions.Admins();
            var siteSettings = SiteSettingsUtility.UsersSiteSettings();
            return hb.Template(
                siteId: 0,
                modelName: "User",
                title: userModel.MethodType != BaseModel.MethodTypes.New
                    ? userModel.Title.DisplayValue + " - " + Displays.Edit()
                    : Displays.Users() + " - " + Displays.New(),
                permissionType: permissionType,
                verType: userModel.VerType,
                backUrl: Navigations.ItemIndex(0),
                methodType: userModel.MethodType,
                allowAccess:
                    permissionType.CanEditTenant() || userModel.Self() &&
                    userModel.AccessStatus != Databases.AccessStatuses.NotFound,
                action: () =>
                {
                    permissionType = Permissions.Types.Manager | Permissions.Types.EditProfile;
                    hb
                        .Editor(
                            userModel: userModel,
                            permissionType: permissionType,
                            siteSettings: siteSettings)
                        .Hidden(controlId: "TableName", value: "Users")
                        .Hidden(controlId: "Id", value: userModel.UserId.ToString());
                }).ToString();
        }

        private static HtmlBuilder Editor(
            this HtmlBuilder hb,
            UserModel userModel,
            Permissions.Types permissionType,
            SiteSettings siteSettings)
        {
            return hb.Div(css: "edit-form", action: () => hb
                .Form(
                    attributes: Html.Attributes()
                        .Id_Css("UserForm", "main-form")
                        .Action(userModel.UserId != 0
                            ? Navigations.Action("Users", userModel.UserId)
                            : Navigations.Action("Users")),
                    action: () => hb
                        .RecordHeader(
                            id: userModel.UserId,
                            baseModel: userModel,
                            tableName: "Users",
                            switchTargets: userModel.SwitchTargets?
                                .Select(o => o.ToLong()).ToList())
                        .Div(css: "edit-form-comments", action: () => hb
                            .Comments(
                                comments: userModel.Comments,
                                verType: userModel.VerType))
                        .Div(css: "edit-form-tabs", action: () => hb
                            .FieldTabs(userModel: userModel)
                            .Fields(
                                siteSettings: siteSettings,
                                permissionType: permissionType,
                                userModel: userModel)
                            .MainCommands(
                                siteId: 0,
                                permissionType: permissionType,
                                verType: userModel.VerType,
                                backUrl: Permissions.Admins().CanEditTenant() ? Navigations.Index("Users") : Navigations.Top(),
                                referenceType: "Users",
                                referenceId: userModel.UserId,
                                updateButton: true,
                                mailButton: true,
                                deleteButton: true,
                                extensions: () => hb
                                    .MainCommandExtensions(
                                        userModel: userModel,
                                        siteSettings: siteSettings)))
                        .Hidden(
                            controlId: "Users_Timestamp",
                            css: "must-transport",
                            value: userModel.Timestamp)
                        .Hidden(
                            controlId: "SwitchTargets",
                            css: "must-transport",
                            value: userModel.SwitchTargets?.Join()))
                .OutgoingMailsForm("Users", userModel.UserId, userModel.Ver)
                .Dialog_Copy("Users", userModel.UserId)
                .Dialog_Histories(Navigations.Action("Users", userModel.UserId))
                .Dialog_OutgoingMail()
                .EditorExtensions(userModel: userModel, siteSettings: siteSettings));
        }

        private static HtmlBuilder FieldTabs(this HtmlBuilder hb, UserModel userModel)
        {
            return hb.Ul(css: "field-tab", action: () => hb
                .Li(action: () => hb
                    .A(
                        href: "#FieldSetGeneral", 
                        text: Displays.Basic())));
        }

        private static HtmlBuilder Fields(
            this HtmlBuilder hb,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            UserModel userModel)
        {
            return hb.FieldSet(id: "FieldSetGeneral", action: () =>
            {
                siteSettings.ColumnCollection
                    .Where(o => o.EditorVisible.ToBool())
                    .OrderBy(o => siteSettings.EditorOrder.IndexOf(o.ColumnName))
                    .ForEach(column =>
                    {
                        switch (column.ColumnName)
                        {
                            case "UserId": hb.Field(siteSettings, column, userModel.UserId.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Ver": hb.Field(siteSettings, column, userModel.Ver.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "LoginId": hb.Field(siteSettings, column, userModel.LoginId.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Disabled": hb.Field(siteSettings, column, userModel.Disabled.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Password": hb.Field(siteSettings, column, userModel.Password.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "PasswordValidate": hb.Field(siteSettings, column, userModel.PasswordValidate.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "PasswordDummy": hb.Field(siteSettings, column, userModel.PasswordDummy.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "RememberMe": hb.Field(siteSettings, column, userModel.RememberMe.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "LastName": hb.Field(siteSettings, column, userModel.LastName.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "FirstName": hb.Field(siteSettings, column, userModel.FirstName.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Birthday": hb.Field(siteSettings, column, userModel.Birthday?.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Sex": hb.Field(siteSettings, column, userModel.Sex.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Language": hb.Field(siteSettings, column, userModel.Language.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "TimeZone": hb.Field(siteSettings, column, userModel.TimeZone.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DeptId": hb.Field(siteSettings, column, userModel.DeptId.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "FirstAndLastNameOrder": hb.Field(siteSettings, column, userModel.FirstAndLastNameOrder.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "LastLoginTime": hb.Field(siteSettings, column, userModel.LastLoginTime?.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "PasswordChangeTime": hb.Field(siteSettings, column, userModel.PasswordChangeTime?.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumberOfLogins": hb.Field(siteSettings, column, userModel.NumberOfLogins.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumberOfDenial": hb.Field(siteSettings, column, userModel.NumberOfDenial.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "TenantAdmin": hb.Field(siteSettings, column, userModel.TenantAdmin.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "OldPassword": hb.Field(siteSettings, column, userModel.OldPassword.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ChangedPassword": hb.Field(siteSettings, column, userModel.ChangedPassword.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ChangedPasswordValidator": hb.Field(siteSettings, column, userModel.ChangedPasswordValidator.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "AfterResetPassword": hb.Field(siteSettings, column, userModel.AfterResetPassword.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "AfterResetPasswordValidator": hb.Field(siteSettings, column, userModel.AfterResetPasswordValidator.ToControl(column), column.ColumnPermissionType(permissionType)); break;
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
            UserModel userModel,
            SiteSettings siteSettings)
        {
            if (userModel.VerType == Versions.VerTypes.Latest &&
                userModel.MethodType != BaseModel.MethodTypes.New)
            {
                if (userModel.Self())
                {
                    hb.Button(
                        text: Displays.ChangePassword(),
                        controlCss: "button-person",
                        onClick: Def.JavaScript.OpenDialog,
                        selector: "#Dialog_ChangePassword");
                }
                if (Sessions.User().TenantAdmin)
                {
                    hb.Button(
                        text: Displays.ResetPassword(),
                        controlCss: "button-person",
                        onClick: Def.JavaScript.OpenDialog,
                        selector: "#Dialog_ResetPassword");
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
            SiteSettings siteSettings)
        {
            return hb
                .Dialog_ChangePassword(userId: userModel.UserId, siteSettings: siteSettings)
                .Dialog_ResetPassword(userId: userModel.UserId, siteSettings: siteSettings);
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static List<int> GetSwitchTargets(SiteSettings siteSettings)
        {
            if (Permissions.Admins().CanEditTenant())
            {
                var switchTargets = Forms.Data("SwitchTargets").Split(',')
                    .Select(o => o.ToInt())
                    .Where(o => o != 0)
                    .ToList();
                if (switchTargets.Count() == 0)
                {
                    var formData = DataViewFilters.SessionFormData();
                    switchTargets = Rds.ExecuteTable(
                        transactional: false,
                        statements: Rds.SelectUsers(
                            column: Rds.UsersColumn().UserId(),
                            where: DataViewFilters.Get(
                                siteSettings: siteSettings,
                                tableName: "Users",
                                formData: formData,
                                where: Rds.UsersWhere().TenantId(Sessions.TenantId())),
                            orderBy: GridSorters.Get(
                                formData, Rds.UsersOrderBy().UpdatedTime(SqlOrderBy.Types.desc))))
                                    .AsEnumerable()
                                    .Select(o => o["UserId"].ToInt())
                                    .ToList();
                }
                return switchTargets;
            }
            else
            {
                return new List<int>();
            }
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder Dialog_ChangePassword(
            this HtmlBuilder hb, long userId, SiteSettings siteSettings)
        {
            return hb.Div(
                attributes: Html.Attributes()
                    .Id_Css("Dialog_ChangePassword", "dialog")
                    .Title(Displays.ChangePassword()),
                action: () => hb
                    .Form(
                        attributes: Html.Attributes()
                            .Id("ChangePasswordForm")
                            .Action(Navigations.Action("Users", userId)),
                        action: () => hb
                            .Field(
                                siteSettings: siteSettings,
                                column: siteSettings.AllColumn("OldPassword"))
                            .Field(
                                siteSettings: siteSettings,
                                column: siteSettings.AllColumn("ChangedPassword"))
                            .Field(
                                siteSettings: siteSettings,
                                column: siteSettings.AllColumn("ChangedPasswordValidator"))
                            .P(css: "message-dialog")
                            .Div(css: "command-center", action: () => hb
                                .Button(
                                    text: Displays.Change(),
                                    controlCss: "button-save validate",
                                    onClick: Def.JavaScript.Submit,
                                    action: "ChangePassword",
                                    method: "post")
                                .Button(
                                    text: Displays.Cancel(),
                                    controlCss: "button-cancel",
                                    onClick: Def.JavaScript.CancelDialog))));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        private static HtmlBuilder Dialog_ResetPassword(
            this HtmlBuilder hb, long userId, SiteSettings siteSettings)
        {
            return hb.Div(
                attributes: Html.Attributes()
                    .Id_Css("Dialog_ResetPassword", "dialog")
                    .Title(Displays.ResetPassword()),
                action: () => hb
                    .Form(
                        attributes: Html.Attributes()
                            .Id("ResetPasswordForm")
                            .Action(Navigations.Action("Users", userId)),
                        action: () => hb
                            .Field(
                                siteSettings: siteSettings,
                                column: siteSettings.AllColumn("AfterResetPassword"))
                            .Field(
                                siteSettings: siteSettings,
                                column: siteSettings.AllColumn("AfterResetPasswordValidator"))
                            .P(css: "hidden", action: () => hb
                                .TextBox(
                                    textStyle: HtmlControls.TextStyles.Password,
                                    controlCss: " dummy not-transport"))
                            .P(css: "message-dialog")
                            .Div(css: "command-center", action: () => hb
                                .Button(
                                    text: Displays.Reset(),
                                    controlCss: "button-save validate",
                                    onClick: Def.JavaScript.Submit,
                                    action: "ResetPassword",
                                    method: "post")
                                .Button(
                                    text: Displays.Cancel(),
                                    controlCss: "button-cancel",
                                    onClick: Def.JavaScript.CancelDialog))));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string GridRows()
        {
            return GridRows(
                SiteSettingsUtility.UsersSiteSettings(),
                Permissions.Admins(),
                offset:
                    Forms.Data("ControlId").StartsWith("DataViewFilters_") ||
                    Forms.Data("ControlId").StartsWith("GridSorters_")
                        ? 0
                        : Forms.Int("GridOffset"));
        }

        /// <summary>
        /// Fixed:
        /// </summary>
        public static string HtmlLogin(string returnUrl)
        {
            var hb = Html.Builder();
            var siteSettings = SiteSettingsUtility.UsersSiteSettings();
            return hb.Template(
                siteId: 0,
                modelName: "User",
                title: string.Empty,
                permissionType: Permissions.Admins(),
                verType: Versions.VerTypes.Latest,
                backUrl: string.Empty,
                useBreadCrumbs: false,
                useTitle: false,
                useSearch: false,
                useNavigationButtons: false,
                methodType: BaseModel.MethodTypes.Edit,
                allowAccess: true,
                action: () => hb
                    .Form(
                        attributes: Html.Attributes()
                            .Id("UserForm")
                            .Action(Navigations.Get("users", "_action_?ReturnUrl="
                                + HttpUtility.UrlEncode(returnUrl))),
                        action: () => hb
                            .FieldSet(css: "login", action: () => hb
                                .Div(action: () => hb
                                    .Field(
                                        siteSettings: siteSettings,
                                        column: siteSettings.AllColumn("LoginId"))
                                    .Field(
                                        siteSettings: siteSettings,
                                        column: siteSettings.AllColumn("Password"),
                                        fieldCss: "field-wide")
                                    .Field(
                                        siteSettings: siteSettings,
                                        column: siteSettings.AllColumn("RememberMe")))
                                .Div(css: "login-commands cf", action: () => hb
                                    .Button(
                                        controlCss: "button-authenticate button-right-justified validate",
                                        text: Displays.Login(),
                                        onClick: Def.JavaScript.Submit,
                                        action: "Authenticate",
                                        method: "post",
                                        type: "submit")))
                            .P(id: "Message", css: "message-form-bottom"))).ToString();
        }
    }
}