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
    public class ResultModel : BaseItemModel
    {
        public long Id { get { return ResultId; } }
        public override long UrlId { get { return ResultId; } }
        public long ResultId = 0;
        public Status Status = new Status();
        public User Manager = new User();
        public User Owner = new User();
        public string ClassA = string.Empty;
        public string ClassB = string.Empty;
        public string ClassC = string.Empty;
        public string ClassD = string.Empty;
        public string ClassE = string.Empty;
        public string ClassF = string.Empty;
        public string ClassG = string.Empty;
        public string ClassH = string.Empty;
        public string ClassI = string.Empty;
        public string ClassJ = string.Empty;
        public string ClassK = string.Empty;
        public string ClassL = string.Empty;
        public string ClassM = string.Empty;
        public string ClassN = string.Empty;
        public string ClassO = string.Empty;
        public string ClassP = string.Empty;
        public decimal NumA = 0;
        public decimal NumB = 0;
        public decimal NumC = 0;
        public decimal NumD = 0;
        public decimal NumE = 0;
        public decimal NumF = 0;
        public decimal NumG = 0;
        public decimal NumH = 0;
        public DateTime DateA = 0.ToDateTime();
        public DateTime DateB = 0.ToDateTime();
        public DateTime DateC = 0.ToDateTime();
        public DateTime DateD = 0.ToDateTime();
        public DateTime DateE = 0.ToDateTime();
        public DateTime DateF = 0.ToDateTime();
        public DateTime DateG = 0.ToDateTime();
        public DateTime DateH = 0.ToDateTime();
        public string DescriptionA = string.Empty;
        public string DescriptionB = string.Empty;
        public string DescriptionC = string.Empty;
        public string DescriptionD = string.Empty;
        public string DescriptionE = string.Empty;
        public string DescriptionF = string.Empty;
        public string DescriptionG = string.Empty;
        public string DescriptionH = string.Empty;
        public TitleBody TitleBody { get { return new TitleBody(ResultId, Title.Value, Title.DisplayValue, Body); } }
        public long SavedResultId = 0;
        public int SavedStatus = 100;
        public int SavedManager = 0;
        public int SavedOwner = 0;
        public string SavedClassA = string.Empty;
        public string SavedClassB = string.Empty;
        public string SavedClassC = string.Empty;
        public string SavedClassD = string.Empty;
        public string SavedClassE = string.Empty;
        public string SavedClassF = string.Empty;
        public string SavedClassG = string.Empty;
        public string SavedClassH = string.Empty;
        public string SavedClassI = string.Empty;
        public string SavedClassJ = string.Empty;
        public string SavedClassK = string.Empty;
        public string SavedClassL = string.Empty;
        public string SavedClassM = string.Empty;
        public string SavedClassN = string.Empty;
        public string SavedClassO = string.Empty;
        public string SavedClassP = string.Empty;
        public decimal SavedNumA = 0;
        public decimal SavedNumB = 0;
        public decimal SavedNumC = 0;
        public decimal SavedNumD = 0;
        public decimal SavedNumE = 0;
        public decimal SavedNumF = 0;
        public decimal SavedNumG = 0;
        public decimal SavedNumH = 0;
        public DateTime SavedDateA = 0.ToDateTime();
        public DateTime SavedDateB = 0.ToDateTime();
        public DateTime SavedDateC = 0.ToDateTime();
        public DateTime SavedDateD = 0.ToDateTime();
        public DateTime SavedDateE = 0.ToDateTime();
        public DateTime SavedDateF = 0.ToDateTime();
        public DateTime SavedDateG = 0.ToDateTime();
        public DateTime SavedDateH = 0.ToDateTime();
        public string SavedDescriptionA = string.Empty;
        public string SavedDescriptionB = string.Empty;
        public string SavedDescriptionC = string.Empty;
        public string SavedDescriptionD = string.Empty;
        public string SavedDescriptionE = string.Empty;
        public string SavedDescriptionF = string.Empty;
        public string SavedDescriptionG = string.Empty;
        public string SavedDescriptionH = string.Empty;
        public bool Status_Updated { get { return Status.Value != SavedStatus; } }
        public bool Manager_Updated { get { return Manager.Id != SavedManager; } }
        public bool Owner_Updated { get { return Owner.Id != SavedOwner; } }
        public bool ClassA_Updated { get { return ClassA != SavedClassA && ClassA != null; } }
        public bool ClassB_Updated { get { return ClassB != SavedClassB && ClassB != null; } }
        public bool ClassC_Updated { get { return ClassC != SavedClassC && ClassC != null; } }
        public bool ClassD_Updated { get { return ClassD != SavedClassD && ClassD != null; } }
        public bool ClassE_Updated { get { return ClassE != SavedClassE && ClassE != null; } }
        public bool ClassF_Updated { get { return ClassF != SavedClassF && ClassF != null; } }
        public bool ClassG_Updated { get { return ClassG != SavedClassG && ClassG != null; } }
        public bool ClassH_Updated { get { return ClassH != SavedClassH && ClassH != null; } }
        public bool ClassI_Updated { get { return ClassI != SavedClassI && ClassI != null; } }
        public bool ClassJ_Updated { get { return ClassJ != SavedClassJ && ClassJ != null; } }
        public bool ClassK_Updated { get { return ClassK != SavedClassK && ClassK != null; } }
        public bool ClassL_Updated { get { return ClassL != SavedClassL && ClassL != null; } }
        public bool ClassM_Updated { get { return ClassM != SavedClassM && ClassM != null; } }
        public bool ClassN_Updated { get { return ClassN != SavedClassN && ClassN != null; } }
        public bool ClassO_Updated { get { return ClassO != SavedClassO && ClassO != null; } }
        public bool ClassP_Updated { get { return ClassP != SavedClassP && ClassP != null; } }
        public bool NumA_Updated { get { return NumA != SavedNumA; } }
        public bool NumB_Updated { get { return NumB != SavedNumB; } }
        public bool NumC_Updated { get { return NumC != SavedNumC; } }
        public bool NumD_Updated { get { return NumD != SavedNumD; } }
        public bool NumE_Updated { get { return NumE != SavedNumE; } }
        public bool NumF_Updated { get { return NumF != SavedNumF; } }
        public bool NumG_Updated { get { return NumG != SavedNumG; } }
        public bool NumH_Updated { get { return NumH != SavedNumH; } }
        public bool DateA_Updated { get { return DateA != SavedDateA && DateA != null; } }
        public bool DateB_Updated { get { return DateB != SavedDateB && DateB != null; } }
        public bool DateC_Updated { get { return DateC != SavedDateC && DateC != null; } }
        public bool DateD_Updated { get { return DateD != SavedDateD && DateD != null; } }
        public bool DateE_Updated { get { return DateE != SavedDateE && DateE != null; } }
        public bool DateF_Updated { get { return DateF != SavedDateF && DateF != null; } }
        public bool DateG_Updated { get { return DateG != SavedDateG && DateG != null; } }
        public bool DateH_Updated { get { return DateH != SavedDateH && DateH != null; } }
        public bool DescriptionA_Updated { get { return DescriptionA != SavedDescriptionA && DescriptionA != null; } }
        public bool DescriptionB_Updated { get { return DescriptionB != SavedDescriptionB && DescriptionB != null; } }
        public bool DescriptionC_Updated { get { return DescriptionC != SavedDescriptionC && DescriptionC != null; } }
        public bool DescriptionD_Updated { get { return DescriptionD != SavedDescriptionD && DescriptionD != null; } }
        public bool DescriptionE_Updated { get { return DescriptionE != SavedDescriptionE && DescriptionE != null; } }
        public bool DescriptionF_Updated { get { return DescriptionF != SavedDescriptionF && DescriptionF != null; } }
        public bool DescriptionG_Updated { get { return DescriptionG != SavedDescriptionG && DescriptionG != null; } }
        public bool DescriptionH_Updated { get { return DescriptionH != SavedDescriptionH && DescriptionH != null; } }
        public List<long> SwitchTargets;

        public ResultModel(SiteSettings siteSettings)
        {
            SiteSettings = siteSettings;
        }

        public ResultModel(long resultId, long siteId, bool setByForm = false)
        {
            ResultId = resultId;
            SiteId = siteId;
            if (setByForm) SetByForm();
            Get();
        }

        public ResultModel()
        {
        }

        public ResultModel(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            bool setByForm = false,
            MethodTypes methodType = MethodTypes.NotSet)
        {
            OnConstructing();
            Manager = SiteInfo.User(Sessions.UserId());
            Owner = SiteInfo.User(Sessions.UserId());
            SiteSettings = siteSettings;
            PermissionType = permissionType;
            if (setByForm) SetByForm();
            MethodType = methodType;
            OnConstructed();
        }

        public ResultModel(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            long resultId,
            bool clearSessions = false,
            bool setByForm = false,
            List<long> switchTargets = null,
            MethodTypes methodType = MethodTypes.NotSet)
        {
            OnConstructing();
            SiteSettings = siteSettings;
            ResultId = resultId;
            PermissionType = permissionType;
            SiteId = SiteSettings.SiteId;
            Get();
            if (clearSessions) ClearSessions();
            if (setByForm) SetByForm();
            SwitchTargets = switchTargets;
            MethodType = methodType;
            OnConstructed();
        }

        public ResultModel(
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

        public ResultModel Get(
            Sqls.TableTypes tableType = Sqls.TableTypes.Normal,
            SqlColumnCollection column = null,
            SqlJoinCollection join = null,
            SqlWhereCollection where = null,
            SqlOrderByCollection orderBy = null,
            SqlParamCollection param = null,
            bool distinct = false,
            int top = 0)
        {
            Set(Rds.ExecuteTable(statements: Rds.SelectResults(
                tableType: tableType,
                column: column ?? Rds.ResultsColumnDefault(),
                join: join ??  Rds.ResultsJoinDefault(),
                where: where ?? Rds.ResultsWhereDefault(this),
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
            var newId = Rds.ExecuteScalar_long(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.InsertItems(
                        selectIdentity: true,
                        param: Rds.ItemsParam()
                            .ReferenceType("Results")
                            .SiteId(SiteId)
                            .Title(Title.Value)),
                    Rds.InsertResults(
                        tableType: tableType,
                        param: param ?? Rds.ResultsParamDefault(
                            this, setDefault: true, paramAll: paramAll)),
                    InsertLinks(SiteSettings, selectIdentity: true),
                });
            ResultId = newId != 0 ? newId : ResultId;
            SynchronizeSummary();
            Get();
            Rds.ExecuteNonQuery(statements:
                Rds.UpdateItems(
                    param: Rds.ItemsParam()
                        .Title(ResultsUtility.TitleDisplayValue(SiteSettings, this))
                        .Subset(Jsons.ToJson(new ResultSubset(this, SiteSettings))),
                    where: Rds.ItemsWhere().ReferenceId(ResultId)));
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
            if (!PermissionType.CanCreate())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            foreach(var controlId in Forms.Keys())
            {
                switch (controlId)
                {
                    case "Results_SiteId": if (!SiteSettings.AllColumn("SiteId").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_UpdatedTime": if (!SiteSettings.AllColumn("UpdatedTime").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ResultId": if (!SiteSettings.AllColumn("ResultId").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Ver": if (!SiteSettings.AllColumn("Ver").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Title": if (!SiteSettings.AllColumn("Title").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Body": if (!SiteSettings.AllColumn("Body").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_TitleBody": if (!SiteSettings.AllColumn("TitleBody").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Status": if (!SiteSettings.AllColumn("Status").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Manager": if (!SiteSettings.AllColumn("Manager").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Owner": if (!SiteSettings.AllColumn("Owner").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassA": if (!SiteSettings.AllColumn("ClassA").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassB": if (!SiteSettings.AllColumn("ClassB").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassC": if (!SiteSettings.AllColumn("ClassC").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassD": if (!SiteSettings.AllColumn("ClassD").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassE": if (!SiteSettings.AllColumn("ClassE").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassF": if (!SiteSettings.AllColumn("ClassF").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassG": if (!SiteSettings.AllColumn("ClassG").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassH": if (!SiteSettings.AllColumn("ClassH").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassI": if (!SiteSettings.AllColumn("ClassI").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassJ": if (!SiteSettings.AllColumn("ClassJ").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassK": if (!SiteSettings.AllColumn("ClassK").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassL": if (!SiteSettings.AllColumn("ClassL").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassM": if (!SiteSettings.AllColumn("ClassM").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassN": if (!SiteSettings.AllColumn("ClassN").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassO": if (!SiteSettings.AllColumn("ClassO").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassP": if (!SiteSettings.AllColumn("ClassP").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumA": if (!SiteSettings.AllColumn("NumA").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumB": if (!SiteSettings.AllColumn("NumB").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumC": if (!SiteSettings.AllColumn("NumC").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumD": if (!SiteSettings.AllColumn("NumD").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumE": if (!SiteSettings.AllColumn("NumE").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumF": if (!SiteSettings.AllColumn("NumF").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumG": if (!SiteSettings.AllColumn("NumG").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumH": if (!SiteSettings.AllColumn("NumH").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateA": if (!SiteSettings.AllColumn("DateA").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateB": if (!SiteSettings.AllColumn("DateB").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateC": if (!SiteSettings.AllColumn("DateC").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateD": if (!SiteSettings.AllColumn("DateD").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateE": if (!SiteSettings.AllColumn("DateE").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateF": if (!SiteSettings.AllColumn("DateF").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateG": if (!SiteSettings.AllColumn("DateG").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateH": if (!SiteSettings.AllColumn("DateH").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionA": if (!SiteSettings.AllColumn("DescriptionA").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionB": if (!SiteSettings.AllColumn("DescriptionB").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionC": if (!SiteSettings.AllColumn("DescriptionC").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionD": if (!SiteSettings.AllColumn("DescriptionD").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionE": if (!SiteSettings.AllColumn("DescriptionE").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionF": if (!SiteSettings.AllColumn("DescriptionF").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionG": if (!SiteSettings.AllColumn("DescriptionG").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionH": if (!SiteSettings.AllColumn("DescriptionH").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Comments": if (!SiteSettings.AllColumn("Comments").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Creator": if (!SiteSettings.AllColumn("Creator").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Updator": if (!SiteSettings.AllColumn("Updator").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_CreatedTime": if (!SiteSettings.AllColumn("CreatedTime").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_VerUp": if (!SiteSettings.AllColumn("VerUp").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Timestamp": if (!SiteSettings.AllColumn("Timestamp").CanCreate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
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
                    Rds.UpdateResults(
                        verUp: VerUp,
                        where: Rds.ResultsWhereDefault(this)
                            .UpdatedTime(timestamp, _using: timestamp.NotZero()),
                        param: param ?? Rds.ResultsParamDefault(this, paramAll: paramAll),
                        countRecord: true),
                    Rds.Conditions("@@rowcount = 1"),
                    Rds.UpdateItems(
                        where: Rds.ItemsWhere().ReferenceId(ResultId),
                        param: Rds.ItemsParam()
                            .SiteId(SiteId)
                            .Title(ResultsUtility.TitleDisplayValue(SiteSettings, this))
                            .Subset(Jsons.ToJson(new ResultSubset(this, SiteSettings)))
                            .UpdateTarget(true)),
                    Rds.PhysicalDeleteLinks(
                        where: Rds.LinksWhere().SourceId(ResultId)),
                    InsertLinks(SiteSettings),
                    Rds.End()
                });
            if (count == 0) return ResponseConflicts();
            SynchronizeSummary();
            Get();
            var responseCollection = new ResultsResponseCollection(this);
            OnUpdated(ref responseCollection);
            return ResponseByUpdate(responseCollection)
                .PrependComment(Comments, VerType)
                .ToJson();
        }

        private SqlInsert InsertLinks(
            SiteSettings siteSettings, bool selectIdentity = false)
        {
            var link = new Dictionary<long, long>();
            siteSettings.ColumnCollection.Where(o => o.Link.ToBool()).ForEach(column =>
            {
                switch (column.ColumnName)
                {
                    case "ClassA": if (ClassA.ToLong() != 0 && !link.ContainsKey(ClassA.ToLong())) link.Add(ClassA.ToLong(), ResultId); break;
                    case "ClassB": if (ClassB.ToLong() != 0 && !link.ContainsKey(ClassB.ToLong())) link.Add(ClassB.ToLong(), ResultId); break;
                    case "ClassC": if (ClassC.ToLong() != 0 && !link.ContainsKey(ClassC.ToLong())) link.Add(ClassC.ToLong(), ResultId); break;
                    case "ClassD": if (ClassD.ToLong() != 0 && !link.ContainsKey(ClassD.ToLong())) link.Add(ClassD.ToLong(), ResultId); break;
                    case "ClassE": if (ClassE.ToLong() != 0 && !link.ContainsKey(ClassE.ToLong())) link.Add(ClassE.ToLong(), ResultId); break;
                    case "ClassF": if (ClassF.ToLong() != 0 && !link.ContainsKey(ClassF.ToLong())) link.Add(ClassF.ToLong(), ResultId); break;
                    case "ClassG": if (ClassG.ToLong() != 0 && !link.ContainsKey(ClassG.ToLong())) link.Add(ClassG.ToLong(), ResultId); break;
                    case "ClassH": if (ClassH.ToLong() != 0 && !link.ContainsKey(ClassH.ToLong())) link.Add(ClassH.ToLong(), ResultId); break;
                    case "ClassI": if (ClassI.ToLong() != 0 && !link.ContainsKey(ClassI.ToLong())) link.Add(ClassI.ToLong(), ResultId); break;
                    case "ClassJ": if (ClassJ.ToLong() != 0 && !link.ContainsKey(ClassJ.ToLong())) link.Add(ClassJ.ToLong(), ResultId); break;
                    case "ClassK": if (ClassK.ToLong() != 0 && !link.ContainsKey(ClassK.ToLong())) link.Add(ClassK.ToLong(), ResultId); break;
                    case "ClassL": if (ClassL.ToLong() != 0 && !link.ContainsKey(ClassL.ToLong())) link.Add(ClassL.ToLong(), ResultId); break;
                    case "ClassM": if (ClassM.ToLong() != 0 && !link.ContainsKey(ClassM.ToLong())) link.Add(ClassM.ToLong(), ResultId); break;
                    case "ClassN": if (ClassN.ToLong() != 0 && !link.ContainsKey(ClassN.ToLong())) link.Add(ClassN.ToLong(), ResultId); break;
                    case "ClassO": if (ClassO.ToLong() != 0 && !link.ContainsKey(ClassO.ToLong())) link.Add(ClassO.ToLong(), ResultId); break;
                    case "ClassP": if (ClassP.ToLong() != 0 && !link.ContainsKey(ClassP.ToLong())) link.Add(ClassP.ToLong(), ResultId); break;
                    default: break;
                }
            });
            return LinksUtility.Insert(link, selectIdentity);
        }

        private void OnUpdating(ref SqlParamCollection param)
        {
        }

        private void OnUpdated(ref ResultsResponseCollection responseCollection)
        {
        }

        private string ValidateBeforeUpdate()
        {
            if (!PermissionType.CanUpdate())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            foreach(var controlId in Forms.Keys())
            {
                switch (controlId)
                {
                    case "Results_SiteId": if (!SiteSettings.AllColumn("SiteId").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_UpdatedTime": if (!SiteSettings.AllColumn("UpdatedTime").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ResultId": if (!SiteSettings.AllColumn("ResultId").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Ver": if (!SiteSettings.AllColumn("Ver").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Title": if (!SiteSettings.AllColumn("Title").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Body": if (!SiteSettings.AllColumn("Body").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_TitleBody": if (!SiteSettings.AllColumn("TitleBody").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Status": if (!SiteSettings.AllColumn("Status").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Manager": if (!SiteSettings.AllColumn("Manager").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Owner": if (!SiteSettings.AllColumn("Owner").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassA": if (!SiteSettings.AllColumn("ClassA").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassB": if (!SiteSettings.AllColumn("ClassB").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassC": if (!SiteSettings.AllColumn("ClassC").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassD": if (!SiteSettings.AllColumn("ClassD").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassE": if (!SiteSettings.AllColumn("ClassE").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassF": if (!SiteSettings.AllColumn("ClassF").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassG": if (!SiteSettings.AllColumn("ClassG").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassH": if (!SiteSettings.AllColumn("ClassH").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassI": if (!SiteSettings.AllColumn("ClassI").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassJ": if (!SiteSettings.AllColumn("ClassJ").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassK": if (!SiteSettings.AllColumn("ClassK").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassL": if (!SiteSettings.AllColumn("ClassL").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassM": if (!SiteSettings.AllColumn("ClassM").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassN": if (!SiteSettings.AllColumn("ClassN").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassO": if (!SiteSettings.AllColumn("ClassO").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_ClassP": if (!SiteSettings.AllColumn("ClassP").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumA": if (!SiteSettings.AllColumn("NumA").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumB": if (!SiteSettings.AllColumn("NumB").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumC": if (!SiteSettings.AllColumn("NumC").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumD": if (!SiteSettings.AllColumn("NumD").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumE": if (!SiteSettings.AllColumn("NumE").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumF": if (!SiteSettings.AllColumn("NumF").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumG": if (!SiteSettings.AllColumn("NumG").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_NumH": if (!SiteSettings.AllColumn("NumH").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateA": if (!SiteSettings.AllColumn("DateA").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateB": if (!SiteSettings.AllColumn("DateB").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateC": if (!SiteSettings.AllColumn("DateC").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateD": if (!SiteSettings.AllColumn("DateD").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateE": if (!SiteSettings.AllColumn("DateE").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateF": if (!SiteSettings.AllColumn("DateF").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateG": if (!SiteSettings.AllColumn("DateG").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DateH": if (!SiteSettings.AllColumn("DateH").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionA": if (!SiteSettings.AllColumn("DescriptionA").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionB": if (!SiteSettings.AllColumn("DescriptionB").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionC": if (!SiteSettings.AllColumn("DescriptionC").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionD": if (!SiteSettings.AllColumn("DescriptionD").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionE": if (!SiteSettings.AllColumn("DescriptionE").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionF": if (!SiteSettings.AllColumn("DescriptionF").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionG": if (!SiteSettings.AllColumn("DescriptionG").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_DescriptionH": if (!SiteSettings.AllColumn("DescriptionH").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Comments": if (!SiteSettings.AllColumn("Comments").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Creator": if (!SiteSettings.AllColumn("Creator").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Updator": if (!SiteSettings.AllColumn("Updator").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_CreatedTime": if (!SiteSettings.AllColumn("CreatedTime").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_VerUp": if (!SiteSettings.AllColumn("VerUp").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                    case "Results_Timestamp": if (!SiteSettings.AllColumn("Timestamp").CanUpdate(PermissionType)) return Messages.ResponseInvalidRequest().ToJson(); break;
                }
            }
            return null;
        }

        private ResponseCollection ResponseByUpdate(ResultsResponseCollection responseCollection)
        {
            return responseCollection
                .Ver()
                .Timestamp()
                .Val("#VerUp", false)
                .Disabled("#VerUp", false)
                .Html("#HeaderTitle", Title.DisplayValue + " - " + Displays.Edit())
                .Html("#RecordInfo", Html.Builder().RecordInfo(baseModel: this, tableName: "Results"))
                .Html("#RecordHistories", Html.Builder().RecordHistories(ver: Ver, verType: VerType))
                .Html("#Links", Html.Builder().Links(ResultId))
                .Message(Messages.Updated(Title.ToString()))
                .RemoveComment(DeleteCommentId, _using: DeleteCommentId != 0)
                .ClearFormData();
        }

        public string UpdateOrCreate(
            SqlWhereCollection where = null,
            SqlParamCollection param = null)
        {
            if (!PermissionType.CanUpdate())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            SetBySession();
            OnUpdatingOrCreating(ref where, ref param);
            var newId = Rds.ExecuteScalar_long(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.InsertItems(
                        selectIdentity: true,
                        param: Rds.ItemsParam()
                            .ReferenceType("Results")
                            .SiteId(SiteId)
                            .Title(Title.Value)),
                    Rds.UpdateOrInsertResults(
                        selectIdentity: true,
                        where: where ?? Rds.ResultsWhereDefault(this),
                        param: param ?? Rds.ResultsParamDefault(this, setDefault: true))
                });
            ResultId = newId != 0 ? newId : ResultId;
            Get();
            var responseCollection = new ResultsResponseCollection(this);
            OnUpdatedOrCreated(ref responseCollection);
            return responseCollection.ToJson();
        }

        private void OnUpdatingOrCreating(
            ref SqlWhereCollection where,
            ref SqlParamCollection param)
        {
        }

        private void OnUpdatedOrCreated(ref ResultsResponseCollection responseCollection)
        {
        }

        public string Copy()
        {
            ResultId = 0;
            if (SiteSettings.AllColumn("Title").EditorVisible.ToBool())
            {
                Title.Value += Displays.SuffixCopy();
            }
            if (!Forms.Data("Dialog_ConfirmCopy_WithComments").ToBool())
            {
                Comments.Clear();
            }
            return Create(paramAll: true);
        }

        public string Move()
        {
            var siteId = Forms.Long("Dialog_MoveTargets");
            if (siteId == 0 || !Permissions.CanMove(SiteId, siteId))
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            SiteId = siteId;
            Rds.ExecuteNonQuery(statements: new SqlStatement[]
            {
                Rds.UpdateItems(
                    where: Rds.ItemsWhere().ReferenceId(ResultId),
                    param: Rds.ItemsParam().SiteId(SiteId)),
                Rds.UpdateResults(
                    where: Rds.ResultsWhere().ResultId(ResultId),
                    param: Rds.ResultsParam().SiteId(SiteId))
            });
            return Editor();
        }

        public string Delete(bool redirect = true)
        {
            if (!PermissionType.CanDelete())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            OnDeleting();
            Rds.ExecuteNonQuery(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.DeleteItems(
                        where: Rds.ItemsWhere().ReferenceId(ResultId)),
                    Rds.DeleteResults(
                        where: Rds.ResultsWhere().SiteId(SiteId).ResultId(ResultId))
                });
            var responseCollection = new ResultsResponseCollection(this);
            OnDeleted(ref responseCollection);
            if (redirect)
            {
                responseCollection.Href(Navigations.ItemIndex(SiteId));
            }
            return responseCollection.ToJson();
        }

        private void OnDeleting()
        {
        }

        private void OnDeleted(ref ResultsResponseCollection responseCollection)
        {
        }

        public string Restore(long resultId)
        {
            if (!Permissions.Admins().CanEditTenant())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            ResultId = resultId;
            Rds.ExecuteNonQuery(
                connectionString: Def.Parameters.RdsOwnerConnectionString,
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.RestoreItems(
                        where: Rds.ItemsWhere().ReferenceId(ResultId)),
                    Rds.RestoreResults(
                        where: Rds.ResultsWhere().ResultId(ResultId))
                });
            return new ResponseCollection().ToJson();
        }

        public string PhysicalDelete(Sqls.TableTypes tableType = Sqls.TableTypes.Normal)
        {
            if (!PermissionType.CanDelete())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            OnPhysicalDeleting();
            Rds.ExecuteNonQuery(
                transactional: true,
                statements: Rds.PhysicalDeleteResults(
                    tableType: tableType,
                    param: Rds.ResultsParam().SiteId(SiteId).ResultId(ResultId)));
            var responseCollection = new ResultsResponseCollection(this);
            OnPhysicalDeleted(ref responseCollection);
            return responseCollection.ToJson();
        }

        private void OnPhysicalDeleting()
        {
        }

        private void OnPhysicalDeleted(ref ResultsResponseCollection responseCollection)
        {
        }

        private void SynchronizeSummary()
        {
            SiteSettings.SummaryCollection.ForEach(summary =>
            {
                var id = SynchronizeSummaryDestinationId(summary.LinkColumn);
                var savedId = SynchronizeSummaryDestinationId(summary.LinkColumn, saved: true);
                if (id != 0)
                {
                    SynchronizeSummary(summary, id);
                }
                if (savedId != 0 && id != savedId)
                {
                    SynchronizeSummary(summary, savedId);
                }
            });
        }

        private void SynchronizeSummary(Summary summary, long id)
        {
            Summaries.Synchronize(
                summary.SiteId,
                summary.DestinationReferenceType,
                summary.DestinationColumn,
                "Results",
                summary.LinkColumn,
                summary.Type,
                summary.SourceColumn,
                id);
        }

        private long SynchronizeSummaryDestinationId(string linkColumn, bool saved = false)
        {
            switch (linkColumn)
            {
                case "ClassA": return saved ? SavedClassA.ToLong() : ClassA.ToLong();
                case "ClassB": return saved ? SavedClassB.ToLong() : ClassB.ToLong();
                case "ClassC": return saved ? SavedClassC.ToLong() : ClassC.ToLong();
                case "ClassD": return saved ? SavedClassD.ToLong() : ClassD.ToLong();
                case "ClassE": return saved ? SavedClassE.ToLong() : ClassE.ToLong();
                case "ClassF": return saved ? SavedClassF.ToLong() : ClassF.ToLong();
                case "ClassG": return saved ? SavedClassG.ToLong() : ClassG.ToLong();
                case "ClassH": return saved ? SavedClassH.ToLong() : ClassH.ToLong();
                case "ClassI": return saved ? SavedClassI.ToLong() : ClassI.ToLong();
                case "ClassJ": return saved ? SavedClassJ.ToLong() : ClassJ.ToLong();
                case "ClassK": return saved ? SavedClassK.ToLong() : ClassK.ToLong();
                case "ClassL": return saved ? SavedClassL.ToLong() : ClassL.ToLong();
                case "ClassM": return saved ? SavedClassM.ToLong() : ClassM.ToLong();
                case "ClassN": return saved ? SavedClassN.ToLong() : ClassN.ToLong();
                case "ClassO": return saved ? SavedClassO.ToLong() : ClassO.ToLong();
                case "ClassP": return saved ? SavedClassP.ToLong() : ClassP.ToLong();
                default: return 0;
            }
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
                    new ResultCollection(
                        siteSettings: SiteSettings,
                        permissionType: PermissionType,
                        where: Rds.ResultsWhere().ResultId(ResultId),
                        orderBy: Rds.ResultsOrderBy().UpdatedTime(SqlOrderBy.Types.desc),
                        tableType: Sqls.TableTypes.NormalAndHistory).ForEach(resultModel => hb
                            .Tr(
                                attributes: Html.Attributes()
                                    .Class("grid-row not-link")
                                    .OnClick(Def.JavaScript.HistoryAndCloseDialog
                                        .Params(resultModel.Ver))
                                    .DataAction("History")
                                    .DataMethod("post")
                                    .Add("data-latest", 1, _using: resultModel.Ver == Ver),
                                action: () =>
                                    SiteSettings.HistoryGridColumnCollection().ForEach(column =>
                                        hb.TdValue(column, resultModel))));
                });
            return new ResultsResponseCollection(this).Html("#HistoriesForm", hb).ToJson();
        }

        public string History()
        {
            Get(
                where: Rds.ResultsWhere()
                    .ResultId(ResultId)
                    .Ver(Forms.Int("Ver")),
                tableType: Sqls.TableTypes.NormalAndHistory);
            VerType =  Forms.Bool("Latest")
                ? Versions.VerTypes.Latest
                : Versions.VerType(ResultId);
            SwitchTargets = ResultsUtility.GetSwitchTargets(SiteSettings, SiteId);
            return Editor();
        }

        public string PreviousHistory()
        {
            Get(
                where: Rds.ResultsWhere()
                    .ResultId(ResultId)
                    .Ver(Forms.Int("Ver"), _operator: "<"),
                orderBy: Rds.ResultsOrderBy()
                    .Ver(SqlOrderBy.Types.desc),
                tableType: Sqls.TableTypes.History,
                top: 1);
            SwitchTargets = ResultsUtility.GetSwitchTargets(SiteSettings, SiteId);
            switch (AccessStatus)
            {
                case Databases.AccessStatuses.Selected:
                    VerType = Versions.VerType(ResultId, Versions.DirectioTypes.Previous);
                    return Editor();
                default:
                    return new ResultsResponseCollection(this).ToJson();
            }
        }

        public string NextHistory()
        {
            Get(
                where: Rds.ResultsWhere()
                    .ResultId(ResultId)
                    .Ver(Forms.Int("Ver"), _operator: ">"),
                orderBy: Rds.ResultsOrderBy()
                    .Ver(SqlOrderBy.Types.asc),
                tableType: Sqls.TableTypes.History,
                top: 1);
            SwitchTargets = ResultsUtility.GetSwitchTargets(SiteSettings, SiteId);
            switch (AccessStatus)
            {
                case Databases.AccessStatuses.Selected:
                    VerType = Versions.VerType(ResultId, Versions.DirectioTypes.Next);
                    return Editor();
                default:
                    return new ResultsResponseCollection(this).ToJson();
            }
        }

        public string Previous()
        {
            var switchTargets = ResultsUtility.GetSwitchTargets(SiteSettings, SiteId);
            var resultModel = new ResultModel(
                siteSettings: SiteSettings,
                permissionType: PermissionType,
                resultId: switchTargets.Previous(ResultId),
                switchTargets: switchTargets);
            return RecordResponse(resultModel);
        }

        public string Next()
        {
            var switchTargets = ResultsUtility.GetSwitchTargets(SiteSettings, SiteId);
            var resultModel = new ResultModel(
                siteSettings: SiteSettings,
                permissionType: PermissionType,
                resultId: switchTargets.Next(ResultId),
                switchTargets: switchTargets);
            return RecordResponse(resultModel);
        }

        public string Reload()
        {
            SwitchTargets = ResultsUtility.GetSwitchTargets(SiteSettings, SiteId);
            return RecordResponse(this, pushState: false);
        }

        private string RecordResponse(
            ResultModel resultModel, Message message = null, bool pushState = true)
        {
            var siteModel = new SiteModel(SiteId);
            resultModel.MethodType = BaseModel.MethodTypes.Edit;
            return new ResultsResponseCollection(this)
                .Func("clearDialogs")
                .Html(
                    "#MainContainer",
                    resultModel.AccessStatus == Databases.AccessStatuses.Selected
                        ? ResultsUtility.Editor(siteModel, resultModel)
                        : ResultsUtility.Editor(siteModel, this))
                .Message(message)
                .PushState(
                    Navigations.ItemEdit(resultModel.ResultId),
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
                    case "Results_Title": Title = new Title(ResultId, Forms.Data(controlId)); break;
                    case "Results_Body": Body = Forms.Data(controlId).ToString(); break;
                    case "Results_Status": Status = new Status(Forms.Data(controlId).ToInt()); break;
                    case "Results_Manager": Manager = SiteInfo.User(Forms.Int(controlId)); break;
                    case "Results_Owner": Owner = SiteInfo.User(Forms.Int(controlId)); break;
                    case "Results_ClassA": ClassA = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassB": ClassB = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassC": ClassC = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassD": ClassD = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassE": ClassE = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassF": ClassF = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassG": ClassG = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassH": ClassH = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassI": ClassI = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassJ": ClassJ = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassK": ClassK = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassL": ClassL = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassM": ClassM = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassN": ClassN = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassO": ClassO = Forms.Data(controlId).ToString(); break;
                    case "Results_ClassP": ClassP = Forms.Data(controlId).ToString(); break;
                    case "Results_NumA": NumA = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumB": NumB = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumC": NumC = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumD": NumD = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumE": NumE = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumF": NumF = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumG": NumG = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_NumH": NumH = Forms.Data(controlId).ToDecimal(); break;
                    case "Results_DateA": DateA = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateB": DateB = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateC": DateC = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateD": DateD = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateE": DateE = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateF": DateF = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateG": DateG = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DateH": DateH = Forms.Data(controlId).ToDateTime().ToUniversal(); break;
                    case "Results_DescriptionA": DescriptionA = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionB": DescriptionB = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionC": DescriptionC = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionD": DescriptionD = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionE": DescriptionE = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionF": DescriptionF = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionG": DescriptionG = Forms.Data(controlId).ToString(); break;
                    case "Results_DescriptionH": DescriptionH = Forms.Data(controlId).ToString(); break;
                    case "Results_Timestamp": Timestamp = Forms.Data(controlId).ToString(); break;
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
                    case "SiteId": if (dataRow[name] != DBNull.Value) { SiteId = dataRow[name].ToLong(); SavedSiteId = SiteId; } break;
                    case "UpdatedTime": if (dataRow[name] != DBNull.Value) { UpdatedTime = new Time(dataRow, "UpdatedTime"); Timestamp = dataRow.Field<DateTime>("UpdatedTime").ToString("yyyy/M/d H:m:s.fff"); SavedUpdatedTime = UpdatedTime.Value; } break;
                    case "ResultId": if (dataRow[name] != DBNull.Value) { ResultId = dataRow[name].ToLong(); SavedResultId = ResultId; } break;
                    case "Ver": Ver = dataRow[name].ToInt(); SavedVer = Ver; break;
                    case "Title": Title = new Title(dataRow, "ResultId"); SavedTitle = Title.Value; break;
                    case "Body": Body = dataRow[name].ToString(); SavedBody = Body; break;
                    case "Status": Status = new Status(dataRow, "Status"); SavedStatus = Status.Value; break;
                    case "Manager": Manager = SiteInfo.User(dataRow.Int(name)); SavedManager = Manager.Id; break;
                    case "Owner": Owner = SiteInfo.User(dataRow.Int(name)); SavedOwner = Owner.Id; break;
                    case "ClassA": ClassA = dataRow[name].ToString(); SavedClassA = ClassA; break;
                    case "ClassB": ClassB = dataRow[name].ToString(); SavedClassB = ClassB; break;
                    case "ClassC": ClassC = dataRow[name].ToString(); SavedClassC = ClassC; break;
                    case "ClassD": ClassD = dataRow[name].ToString(); SavedClassD = ClassD; break;
                    case "ClassE": ClassE = dataRow[name].ToString(); SavedClassE = ClassE; break;
                    case "ClassF": ClassF = dataRow[name].ToString(); SavedClassF = ClassF; break;
                    case "ClassG": ClassG = dataRow[name].ToString(); SavedClassG = ClassG; break;
                    case "ClassH": ClassH = dataRow[name].ToString(); SavedClassH = ClassH; break;
                    case "ClassI": ClassI = dataRow[name].ToString(); SavedClassI = ClassI; break;
                    case "ClassJ": ClassJ = dataRow[name].ToString(); SavedClassJ = ClassJ; break;
                    case "ClassK": ClassK = dataRow[name].ToString(); SavedClassK = ClassK; break;
                    case "ClassL": ClassL = dataRow[name].ToString(); SavedClassL = ClassL; break;
                    case "ClassM": ClassM = dataRow[name].ToString(); SavedClassM = ClassM; break;
                    case "ClassN": ClassN = dataRow[name].ToString(); SavedClassN = ClassN; break;
                    case "ClassO": ClassO = dataRow[name].ToString(); SavedClassO = ClassO; break;
                    case "ClassP": ClassP = dataRow[name].ToString(); SavedClassP = ClassP; break;
                    case "NumA": NumA = dataRow[name].ToDecimal(); SavedNumA = NumA; break;
                    case "NumB": NumB = dataRow[name].ToDecimal(); SavedNumB = NumB; break;
                    case "NumC": NumC = dataRow[name].ToDecimal(); SavedNumC = NumC; break;
                    case "NumD": NumD = dataRow[name].ToDecimal(); SavedNumD = NumD; break;
                    case "NumE": NumE = dataRow[name].ToDecimal(); SavedNumE = NumE; break;
                    case "NumF": NumF = dataRow[name].ToDecimal(); SavedNumF = NumF; break;
                    case "NumG": NumG = dataRow[name].ToDecimal(); SavedNumG = NumG; break;
                    case "NumH": NumH = dataRow[name].ToDecimal(); SavedNumH = NumH; break;
                    case "DateA": DateA = dataRow[name].ToDateTime(); SavedDateA = DateA; break;
                    case "DateB": DateB = dataRow[name].ToDateTime(); SavedDateB = DateB; break;
                    case "DateC": DateC = dataRow[name].ToDateTime(); SavedDateC = DateC; break;
                    case "DateD": DateD = dataRow[name].ToDateTime(); SavedDateD = DateD; break;
                    case "DateE": DateE = dataRow[name].ToDateTime(); SavedDateE = DateE; break;
                    case "DateF": DateF = dataRow[name].ToDateTime(); SavedDateF = DateF; break;
                    case "DateG": DateG = dataRow[name].ToDateTime(); SavedDateG = DateG; break;
                    case "DateH": DateH = dataRow[name].ToDateTime(); SavedDateH = DateH; break;
                    case "DescriptionA": DescriptionA = dataRow[name].ToString(); SavedDescriptionA = DescriptionA; break;
                    case "DescriptionB": DescriptionB = dataRow[name].ToString(); SavedDescriptionB = DescriptionB; break;
                    case "DescriptionC": DescriptionC = dataRow[name].ToString(); SavedDescriptionC = DescriptionC; break;
                    case "DescriptionD": DescriptionD = dataRow[name].ToString(); SavedDescriptionD = DescriptionD; break;
                    case "DescriptionE": DescriptionE = dataRow[name].ToString(); SavedDescriptionE = DescriptionE; break;
                    case "DescriptionF": DescriptionF = dataRow[name].ToString(); SavedDescriptionF = DescriptionF; break;
                    case "DescriptionG": DescriptionG = dataRow[name].ToString(); SavedDescriptionG = DescriptionG; break;
                    case "DescriptionH": DescriptionH = dataRow[name].ToString(); SavedDescriptionH = DescriptionH; break;
                    case "Comments": Comments = dataRow["Comments"].ToString().Deserialize<Comments>() ?? new Comments(); SavedComments = Comments.ToJson(); break;
                    case "Creator": Creator = SiteInfo.User(dataRow.Int(name)); SavedCreator = Creator.Id; break;
                    case "Updator": Updator = SiteInfo.User(dataRow.Int(name)); SavedUpdator = Updator.Id; break;
                    case "CreatedTime": CreatedTime = new Time(dataRow, "CreatedTime"); SavedCreatedTime = CreatedTime.Value; break;
                }
            }
            if (SiteSettings != null)
            {
                Title.DisplayValue = ResultsUtility.TitleDisplayValue(SiteSettings, this);
            }
        }

        private string Editor()
        {
            var siteModel = new SiteModel(SiteId);
            return new ResultsResponseCollection(this)
                .Html("#MainContainer", ResultsUtility.Editor(siteModel, this))
                .ToJson();
        }

        private string ResponseConflicts()
        {
            Get();
            return AccessStatus == Databases.AccessStatuses.Selected
                ? Messages.ResponseUpdateConflicts(Updator.FullName).ToJson()
                : Messages.ResponseDeleteConflicts().ToJson();
        }
    }

    public class ResultSubset
    {
        public long SiteId;
        public string SiteId_LabelText;
        public long ResultId;
        public string ResultId_LabelText;
        public int Ver;
        public string Ver_LabelText;
        public Title Title;
        public string Title_LabelText;
        public string Body;
        public string Body_LabelText;
        public TitleBody TitleBody;
        public string TitleBody_LabelText;
        public Status Status;
        public string Status_LabelText;
        public User Manager;
        public string Manager_LabelText;
        public User Owner;
        public string Owner_LabelText;
        public string ClassA;
        public string ClassA_LabelText;
        public string ClassB;
        public string ClassB_LabelText;
        public string ClassC;
        public string ClassC_LabelText;
        public string ClassD;
        public string ClassD_LabelText;
        public string ClassE;
        public string ClassE_LabelText;
        public string ClassF;
        public string ClassF_LabelText;
        public string ClassG;
        public string ClassG_LabelText;
        public string ClassH;
        public string ClassH_LabelText;
        public string ClassI;
        public string ClassI_LabelText;
        public string ClassJ;
        public string ClassJ_LabelText;
        public string ClassK;
        public string ClassK_LabelText;
        public string ClassL;
        public string ClassL_LabelText;
        public string ClassM;
        public string ClassM_LabelText;
        public string ClassN;
        public string ClassN_LabelText;
        public string ClassO;
        public string ClassO_LabelText;
        public string ClassP;
        public string ClassP_LabelText;
        public decimal NumA;
        public string NumA_LabelText;
        public decimal NumB;
        public string NumB_LabelText;
        public decimal NumC;
        public string NumC_LabelText;
        public decimal NumD;
        public string NumD_LabelText;
        public decimal NumE;
        public string NumE_LabelText;
        public decimal NumF;
        public string NumF_LabelText;
        public decimal NumG;
        public string NumG_LabelText;
        public decimal NumH;
        public string NumH_LabelText;
        public DateTime DateA;
        public string DateA_LabelText;
        public DateTime DateB;
        public string DateB_LabelText;
        public DateTime DateC;
        public string DateC_LabelText;
        public DateTime DateD;
        public string DateD_LabelText;
        public DateTime DateE;
        public string DateE_LabelText;
        public DateTime DateF;
        public string DateF_LabelText;
        public DateTime DateG;
        public string DateG_LabelText;
        public DateTime DateH;
        public string DateH_LabelText;
        public string DescriptionA;
        public string DescriptionA_LabelText;
        public string DescriptionB;
        public string DescriptionB_LabelText;
        public string DescriptionC;
        public string DescriptionC_LabelText;
        public string DescriptionD;
        public string DescriptionD_LabelText;
        public string DescriptionE;
        public string DescriptionE_LabelText;
        public string DescriptionF;
        public string DescriptionF_LabelText;
        public string DescriptionG;
        public string DescriptionG_LabelText;
        public string DescriptionH;
        public string DescriptionH_LabelText;
        public Comments Comments;
        public string Comments_LabelText;
        public User Creator;
        public string Creator_LabelText;
        public User Updator;
        public string Updator_LabelText;

        public ResultSubset()
        {
        }

        public ResultSubset(ResultModel resultModel, SiteSettings siteSettings)
        {
            SiteId = resultModel.SiteId;
            SiteId_LabelText = siteSettings.EditorColumn("SiteId")?.LabelText;
            ResultId = resultModel.ResultId;
            ResultId_LabelText = siteSettings.EditorColumn("ResultId")?.LabelText;
            Ver = resultModel.Ver;
            Ver_LabelText = siteSettings.EditorColumn("Ver")?.LabelText;
            Title = resultModel.Title;
            Title_LabelText = siteSettings.EditorColumn("Title")?.LabelText;
            Body = resultModel.Body;
            Body_LabelText = siteSettings.EditorColumn("Body")?.LabelText;
            TitleBody = resultModel.TitleBody;
            TitleBody_LabelText = siteSettings.EditorColumn("TitleBody")?.LabelText;
            Status = resultModel.Status;
            Status_LabelText = siteSettings.EditorColumn("Status")?.LabelText;
            Manager = resultModel.Manager;
            Manager_LabelText = siteSettings.EditorColumn("Manager")?.LabelText;
            Owner = resultModel.Owner;
            Owner_LabelText = siteSettings.EditorColumn("Owner")?.LabelText;
            ClassA = resultModel.ClassA;
            ClassA_LabelText = siteSettings.EditorColumn("ClassA")?.LabelText;
            ClassB = resultModel.ClassB;
            ClassB_LabelText = siteSettings.EditorColumn("ClassB")?.LabelText;
            ClassC = resultModel.ClassC;
            ClassC_LabelText = siteSettings.EditorColumn("ClassC")?.LabelText;
            ClassD = resultModel.ClassD;
            ClassD_LabelText = siteSettings.EditorColumn("ClassD")?.LabelText;
            ClassE = resultModel.ClassE;
            ClassE_LabelText = siteSettings.EditorColumn("ClassE")?.LabelText;
            ClassF = resultModel.ClassF;
            ClassF_LabelText = siteSettings.EditorColumn("ClassF")?.LabelText;
            ClassG = resultModel.ClassG;
            ClassG_LabelText = siteSettings.EditorColumn("ClassG")?.LabelText;
            ClassH = resultModel.ClassH;
            ClassH_LabelText = siteSettings.EditorColumn("ClassH")?.LabelText;
            ClassI = resultModel.ClassI;
            ClassI_LabelText = siteSettings.EditorColumn("ClassI")?.LabelText;
            ClassJ = resultModel.ClassJ;
            ClassJ_LabelText = siteSettings.EditorColumn("ClassJ")?.LabelText;
            ClassK = resultModel.ClassK;
            ClassK_LabelText = siteSettings.EditorColumn("ClassK")?.LabelText;
            ClassL = resultModel.ClassL;
            ClassL_LabelText = siteSettings.EditorColumn("ClassL")?.LabelText;
            ClassM = resultModel.ClassM;
            ClassM_LabelText = siteSettings.EditorColumn("ClassM")?.LabelText;
            ClassN = resultModel.ClassN;
            ClassN_LabelText = siteSettings.EditorColumn("ClassN")?.LabelText;
            ClassO = resultModel.ClassO;
            ClassO_LabelText = siteSettings.EditorColumn("ClassO")?.LabelText;
            ClassP = resultModel.ClassP;
            ClassP_LabelText = siteSettings.EditorColumn("ClassP")?.LabelText;
            NumA = resultModel.NumA;
            NumA_LabelText = siteSettings.EditorColumn("NumA")?.LabelText;
            NumB = resultModel.NumB;
            NumB_LabelText = siteSettings.EditorColumn("NumB")?.LabelText;
            NumC = resultModel.NumC;
            NumC_LabelText = siteSettings.EditorColumn("NumC")?.LabelText;
            NumD = resultModel.NumD;
            NumD_LabelText = siteSettings.EditorColumn("NumD")?.LabelText;
            NumE = resultModel.NumE;
            NumE_LabelText = siteSettings.EditorColumn("NumE")?.LabelText;
            NumF = resultModel.NumF;
            NumF_LabelText = siteSettings.EditorColumn("NumF")?.LabelText;
            NumG = resultModel.NumG;
            NumG_LabelText = siteSettings.EditorColumn("NumG")?.LabelText;
            NumH = resultModel.NumH;
            NumH_LabelText = siteSettings.EditorColumn("NumH")?.LabelText;
            DateA = resultModel.DateA;
            DateA_LabelText = siteSettings.EditorColumn("DateA")?.LabelText;
            DateB = resultModel.DateB;
            DateB_LabelText = siteSettings.EditorColumn("DateB")?.LabelText;
            DateC = resultModel.DateC;
            DateC_LabelText = siteSettings.EditorColumn("DateC")?.LabelText;
            DateD = resultModel.DateD;
            DateD_LabelText = siteSettings.EditorColumn("DateD")?.LabelText;
            DateE = resultModel.DateE;
            DateE_LabelText = siteSettings.EditorColumn("DateE")?.LabelText;
            DateF = resultModel.DateF;
            DateF_LabelText = siteSettings.EditorColumn("DateF")?.LabelText;
            DateG = resultModel.DateG;
            DateG_LabelText = siteSettings.EditorColumn("DateG")?.LabelText;
            DateH = resultModel.DateH;
            DateH_LabelText = siteSettings.EditorColumn("DateH")?.LabelText;
            DescriptionA = resultModel.DescriptionA;
            DescriptionA_LabelText = siteSettings.EditorColumn("DescriptionA")?.LabelText;
            DescriptionB = resultModel.DescriptionB;
            DescriptionB_LabelText = siteSettings.EditorColumn("DescriptionB")?.LabelText;
            DescriptionC = resultModel.DescriptionC;
            DescriptionC_LabelText = siteSettings.EditorColumn("DescriptionC")?.LabelText;
            DescriptionD = resultModel.DescriptionD;
            DescriptionD_LabelText = siteSettings.EditorColumn("DescriptionD")?.LabelText;
            DescriptionE = resultModel.DescriptionE;
            DescriptionE_LabelText = siteSettings.EditorColumn("DescriptionE")?.LabelText;
            DescriptionF = resultModel.DescriptionF;
            DescriptionF_LabelText = siteSettings.EditorColumn("DescriptionF")?.LabelText;
            DescriptionG = resultModel.DescriptionG;
            DescriptionG_LabelText = siteSettings.EditorColumn("DescriptionG")?.LabelText;
            DescriptionH = resultModel.DescriptionH;
            DescriptionH_LabelText = siteSettings.EditorColumn("DescriptionH")?.LabelText;
            Comments = resultModel.Comments;
            Comments_LabelText = siteSettings.EditorColumn("Comments")?.LabelText;
            Creator = resultModel.Creator;
            Creator_LabelText = siteSettings.EditorColumn("Creator")?.LabelText;
            Updator = resultModel.Updator;
            Updator_LabelText = siteSettings.EditorColumn("Updator")?.LabelText;
        }

        public Dictionary<string, int> SearchIndexCollection()
        {
            var searchIndexHash = new Dictionary<string, int>();
            ResultId.SearchIndexes(searchIndexHash, 1);
            Title.SearchIndexes(searchIndexHash, 4);
            Body.SearchIndexes(searchIndexHash, 200);
            Manager.SearchIndexes(searchIndexHash, 100);
            Owner.SearchIndexes(searchIndexHash, 100);
            ClassA.SearchIndexes(searchIndexHash, 200);
            ClassB.SearchIndexes(searchIndexHash, 200);
            ClassC.SearchIndexes(searchIndexHash, 200);
            ClassD.SearchIndexes(searchIndexHash, 200);
            ClassE.SearchIndexes(searchIndexHash, 200);
            ClassF.SearchIndexes(searchIndexHash, 200);
            ClassG.SearchIndexes(searchIndexHash, 200);
            ClassH.SearchIndexes(searchIndexHash, 200);
            ClassI.SearchIndexes(searchIndexHash, 200);
            ClassJ.SearchIndexes(searchIndexHash, 200);
            ClassK.SearchIndexes(searchIndexHash, 200);
            ClassL.SearchIndexes(searchIndexHash, 200);
            ClassM.SearchIndexes(searchIndexHash, 200);
            ClassN.SearchIndexes(searchIndexHash, 200);
            ClassO.SearchIndexes(searchIndexHash, 200);
            ClassP.SearchIndexes(searchIndexHash, 200);
            Comments.SearchIndexes(searchIndexHash, 200);
            Creator.SearchIndexes(searchIndexHash, 100);
            Updator.SearchIndexes(searchIndexHash, 100);
            SearchIndexExtensions.OutgoingMailsSearchIndexes(searchIndexHash, "Results", ResultId);
            return searchIndexHash;
        }
    }

    public class ResultCollection : List<ResultModel>
    {
        public Databases.AccessStatuses AccessStatus = Databases.AccessStatuses.Initialized;
        public Aggregations Aggregations = new Aggregations();

        public ResultCollection(
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

        public ResultCollection(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            DataTable dataTable)
        {
            Set(siteSettings, permissionType, dataTable);
        }

        private ResultCollection Set(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Add(new ResultModel(siteSettings, permissionType, dataRow));
                }
                AccessStatus = Databases.AccessStatuses.Selected;
            }
            else
            {
                AccessStatus = Databases.AccessStatuses.NotFound;
            }
            return this;
        }

        public ResultCollection(
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
                Rds.SelectResults(
                    dataTableName: "Main",
                    column: column ?? Rds.ResultsColumnDefault(),
                    join: join ??  Rds.ResultsJoinDefault(),
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
                statements.AddRange(Rds.ResultsAggregations(aggregationCollection, where));
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
                statements: Rds.ResultsStatement(
                    commandText: commandText,
                    param: param ?? null));
        }
    }

    public static class ResultsUtility
    {
        public static string Index(SiteSettings siteSettings, Permissions.Types permissionType)
        {
            var hb = Html.Builder();
            var formData = DataViewFilters.SessionFormData(siteSettings.SiteId);
            var resultCollection = ResultCollection(siteSettings, permissionType, formData);
            var dataViewName = DataViewSelectors.Get(siteSettings.SiteId);
            return hb.Template(
                siteId: siteSettings.SiteId,
                modelName: "Result",
                title: siteSettings.Title + " - " + Displays.List(),
                permissionType: permissionType,
                verType: Versions.VerTypes.Latest,
                backUrl: Navigations.ItemIndex(siteSettings.ParentId),
                methodType: BaseModel.MethodTypes.Index,
                allowAccess: permissionType.CanRead(),
                script: IndexScript(
                    resultCollection: resultCollection,
                    siteSettings: siteSettings,
                    permissionType: permissionType,
                    formData: formData,
                    dataViewName: dataViewName),
                action: () => hb
                    .Form(
                        attributes: Html.Attributes()
                            .Id_Css("ResultsForm", "main-form")
                            .Action(Navigations.ItemAction(siteSettings.SiteId)),
                        action: () => hb
                            .DataViewSelector(
                                referenceType: "Results",
                                dataViewName: dataViewName)
                            .DataViewFilters(
                                siteSettings: siteSettings,
                                siteId: siteSettings.SiteId)
                            .Aggregations(
                                siteSettings: siteSettings,
                                aggregations: resultCollection.Aggregations)
                            .Div(id: "DataViewContainer", action: () => hb
                                .DataView(
                                    resultCollection: resultCollection,
                                    siteSettings: siteSettings,
                                    permissionType: permissionType,
                                    formData: formData,
                                    dataViewName: dataViewName))
                            .Div(css: "margin-bottom")
                            .Hidden(controlId: "TableName", value: "Results")
                            .Hidden(controlId: "BaseUrl", value: Navigations.BaseUrl()))
                    .Dialog_Move("items", siteSettings.SiteId, bulk: true)
                    .Dialog_ImportSettings()
                    .Div(attributes: Html.Attributes()
                        .Id_Css("Dialog_ExportSettings", "dialog")
                        .Title(Displays.ExportSettings()))).ToString();
        }

        private static ResultCollection ResultCollection(
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            FormData formData, int offset = 0)
        {
            return new ResultCollection(
                siteSettings: siteSettings,
                permissionType: permissionType,
                column: GridSqlColumnCollection(siteSettings),
                where: DataViewFilters.Get(
                    siteSettings: siteSettings,
                    tableName: "Results",
                    formData: formData,
                    where: Rds.ResultsWhere().SiteId(siteSettings.SiteId)),
                orderBy: GridSorters.Get(
                    formData, Rds.ResultsOrderBy().UpdatedTime(SqlOrderBy.Types.desc)),
                offset: offset,
                pageSize: siteSettings.GridPageSize.ToInt(),
                countRecord: true,
                aggregationCollection: siteSettings.AggregationCollection);
        }

        public static string IndexScript(
            ResultCollection resultCollection,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            FormData formData,
            string dataViewName)
        {
            return string.Empty;
        }

        public static HtmlBuilder DataView(
            this HtmlBuilder hb,
            ResultCollection resultCollection,
            SiteSettings siteSettings,
            Permissions.Types permissionType,
            FormData formData,
            string dataViewName)
        {
            switch (dataViewName)
            {
                default: return hb.Grid(
                    resultCollection: resultCollection,
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
            ResultCollection resultCollection,
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
                            resultCollection: resultCollection,
                            formData: formData))
                .Hidden(
                    controlId: "GridOffset",
                    value: siteSettings.GridPageSize.ToString())
                .MainCommands(
                    siteId: siteSettings.SiteId,
                    permissionType: permissionType,
                    verType: Versions.VerTypes.Latest,
                    backUrl: Navigations.ItemIndex(siteSettings.ParentId),
                    bulkMoveButton: true,
                    bulkDeleteButton: true,
                    importButton: true,
                    exportButton: true);
        }

        private static string Grid(SiteSettings siteSettings, Permissions.Types permissionType)
        {
            var formData = DataViewFilters.SessionFormData(siteSettings.SiteId);
            var resultCollection = ResultCollection(siteSettings, permissionType, formData);
            return new ResponseCollection()
                .Html("#DataViewContainer", resultCollection.Count > 0
                    ? Html.Builder().Grid(
                        siteSettings: siteSettings,
                        resultCollection: resultCollection,
                        permissionType: permissionType,
                        formData: formData)
                    : Html.Builder())
                .Html("#Aggregations", Html.Builder().Aggregations(
                    siteSettings: siteSettings,
                    aggregations: resultCollection.Aggregations,
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
            var formData = DataViewFilters.SessionFormData(siteSettings.SiteId);
            var resultCollection = ResultCollection(siteSettings, permissionType, formData, offset);
            return (responseCollection ?? new ResponseCollection())
                .Remove(".grid tr", _using: offset == 0)
                .ClearFormData("GridCheckAll", _using: clearCheck)
                .ClearFormData("GridUnCheckedItems", _using: clearCheck)
                .ClearFormData("GridCheckedItems", _using: clearCheck)
                .Message(message)
                .Append("#Grid", Html.Builder().GridRows(
                    siteSettings: siteSettings,
                    resultCollection: resultCollection,
                    formData: formData,
                    addHeader: offset == 0,
                    clearCheck: clearCheck))
                .Html("#Aggregations", Html.Builder().Aggregations(
                    siteSettings: siteSettings,
                    aggregations: resultCollection.Aggregations,
                    container: false))
                .Val("#GridOffset", siteSettings.NextPageOffset(offset, resultCollection.Count()))
                .Markup()
                .ToJson();
        }

        private static HtmlBuilder GridRows(
            this HtmlBuilder hb,
            SiteSettings siteSettings,
            ResultCollection resultCollection,
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
            resultCollection.ForEach(resultModel => hb
                .Tr(
                    attributes: Html.Attributes()
                        .Class("grid-row")
                        .DataId(resultModel.ResultId.ToString()),
                    action: () =>
                    {
                        hb.Td(action: () => hb
                            .CheckBox(
                                controlCss: "grid-check",
                                _checked: checkAll,
                                dataId: resultModel.ResultId.ToString()));
                        siteSettings.GridColumnCollection()
                            .ForEach(column => hb
                                .TdValue(
                                    column: column,
                                    resultModel: resultModel));
                    }));
            return hb;
        }

        private static SqlColumnCollection GridSqlColumnCollection(SiteSettings siteSettings)
        {
            var select = Rds.ResultsColumn()
                .SiteId()
                .ResultId()
                .Creator()
                .Updator();
            siteSettings.GridColumnCollection(withTitle: true).ForEach(columnGrid =>
            {
                switch (columnGrid.ColumnName)
                {
                    case "UpdatedTime": select.UpdatedTime(); break;
                    case "ResultId": select.ResultId(); break;
                    case "Ver": select.Ver(); break;
                    case "Title": select.Title(); break;
                    case "Body": select.Body(); break;
                    case "TitleBody": select.TitleBody(); break;
                    case "Status": select.Status(); break;
                    case "Manager": select.Manager(); break;
                    case "Owner": select.Owner(); break;
                    case "ClassA": select.ClassA(); break;
                    case "ClassB": select.ClassB(); break;
                    case "ClassC": select.ClassC(); break;
                    case "ClassD": select.ClassD(); break;
                    case "ClassE": select.ClassE(); break;
                    case "ClassF": select.ClassF(); break;
                    case "ClassG": select.ClassG(); break;
                    case "ClassH": select.ClassH(); break;
                    case "ClassI": select.ClassI(); break;
                    case "ClassJ": select.ClassJ(); break;
                    case "ClassK": select.ClassK(); break;
                    case "ClassL": select.ClassL(); break;
                    case "ClassM": select.ClassM(); break;
                    case "ClassN": select.ClassN(); break;
                    case "ClassO": select.ClassO(); break;
                    case "ClassP": select.ClassP(); break;
                    case "NumA": select.NumA(); break;
                    case "NumB": select.NumB(); break;
                    case "NumC": select.NumC(); break;
                    case "NumD": select.NumD(); break;
                    case "NumE": select.NumE(); break;
                    case "NumF": select.NumF(); break;
                    case "NumG": select.NumG(); break;
                    case "NumH": select.NumH(); break;
                    case "DateA": select.DateA(); break;
                    case "DateB": select.DateB(); break;
                    case "DateC": select.DateC(); break;
                    case "DateD": select.DateD(); break;
                    case "DateE": select.DateE(); break;
                    case "DateF": select.DateF(); break;
                    case "DateG": select.DateG(); break;
                    case "DateH": select.DateH(); break;
                    case "DescriptionA": select.DescriptionA(); break;
                    case "DescriptionB": select.DescriptionB(); break;
                    case "DescriptionC": select.DescriptionC(); break;
                    case "DescriptionD": select.DescriptionD(); break;
                    case "DescriptionE": select.DescriptionE(); break;
                    case "DescriptionF": select.DescriptionF(); break;
                    case "DescriptionG": select.DescriptionG(); break;
                    case "DescriptionH": select.DescriptionH(); break;
                    case "Comments": select.Comments(); break;
                    case "Creator": select.Creator(); break;
                    case "Updator": select.Updator(); break;
                    case "CreatedTime": select.CreatedTime(); break;
                }
            });
            return select;
        }

        public static HtmlBuilder TdValue(
            this HtmlBuilder hb, Column column, ResultModel resultModel)
        {
            switch (column.ColumnName)
            {
                case "SiteId": return hb.Td(column: column, value: resultModel.SiteId);
                case "UpdatedTime": return hb.Td(column: column, value: resultModel.UpdatedTime);
                case "ResultId": return hb.Td(column: column, value: resultModel.ResultId);
                case "Ver": return hb.Td(column: column, value: resultModel.Ver);
                case "Title": return hb.Td(column: column, value: resultModel.Title);
                case "Body": return hb.Td(column: column, value: resultModel.Body);
                case "TitleBody": return hb.Td(column: column, value: resultModel.TitleBody);
                case "Status": return hb.Td(column: column, value: resultModel.Status);
                case "Manager": return hb.Td(column: column, value: resultModel.Manager);
                case "Owner": return hb.Td(column: column, value: resultModel.Owner);
                case "ClassA": return hb.Td(column: column, value: resultModel.ClassA);
                case "ClassB": return hb.Td(column: column, value: resultModel.ClassB);
                case "ClassC": return hb.Td(column: column, value: resultModel.ClassC);
                case "ClassD": return hb.Td(column: column, value: resultModel.ClassD);
                case "ClassE": return hb.Td(column: column, value: resultModel.ClassE);
                case "ClassF": return hb.Td(column: column, value: resultModel.ClassF);
                case "ClassG": return hb.Td(column: column, value: resultModel.ClassG);
                case "ClassH": return hb.Td(column: column, value: resultModel.ClassH);
                case "ClassI": return hb.Td(column: column, value: resultModel.ClassI);
                case "ClassJ": return hb.Td(column: column, value: resultModel.ClassJ);
                case "ClassK": return hb.Td(column: column, value: resultModel.ClassK);
                case "ClassL": return hb.Td(column: column, value: resultModel.ClassL);
                case "ClassM": return hb.Td(column: column, value: resultModel.ClassM);
                case "ClassN": return hb.Td(column: column, value: resultModel.ClassN);
                case "ClassO": return hb.Td(column: column, value: resultModel.ClassO);
                case "ClassP": return hb.Td(column: column, value: resultModel.ClassP);
                case "NumA": return hb.Td(column: column, value: resultModel.NumA);
                case "NumB": return hb.Td(column: column, value: resultModel.NumB);
                case "NumC": return hb.Td(column: column, value: resultModel.NumC);
                case "NumD": return hb.Td(column: column, value: resultModel.NumD);
                case "NumE": return hb.Td(column: column, value: resultModel.NumE);
                case "NumF": return hb.Td(column: column, value: resultModel.NumF);
                case "NumG": return hb.Td(column: column, value: resultModel.NumG);
                case "NumH": return hb.Td(column: column, value: resultModel.NumH);
                case "DateA": return hb.Td(column: column, value: resultModel.DateA);
                case "DateB": return hb.Td(column: column, value: resultModel.DateB);
                case "DateC": return hb.Td(column: column, value: resultModel.DateC);
                case "DateD": return hb.Td(column: column, value: resultModel.DateD);
                case "DateE": return hb.Td(column: column, value: resultModel.DateE);
                case "DateF": return hb.Td(column: column, value: resultModel.DateF);
                case "DateG": return hb.Td(column: column, value: resultModel.DateG);
                case "DateH": return hb.Td(column: column, value: resultModel.DateH);
                case "DescriptionA": return hb.Td(column: column, value: resultModel.DescriptionA);
                case "DescriptionB": return hb.Td(column: column, value: resultModel.DescriptionB);
                case "DescriptionC": return hb.Td(column: column, value: resultModel.DescriptionC);
                case "DescriptionD": return hb.Td(column: column, value: resultModel.DescriptionD);
                case "DescriptionE": return hb.Td(column: column, value: resultModel.DescriptionE);
                case "DescriptionF": return hb.Td(column: column, value: resultModel.DescriptionF);
                case "DescriptionG": return hb.Td(column: column, value: resultModel.DescriptionG);
                case "DescriptionH": return hb.Td(column: column, value: resultModel.DescriptionH);
                case "Comments": return hb.Td(column: column, value: resultModel.Comments);
                case "Creator": return hb.Td(column: column, value: resultModel.Creator);
                case "Updator": return hb.Td(column: column, value: resultModel.Updator);
                case "CreatedTime": return hb.Td(column: column, value: resultModel.CreatedTime);
                default: return hb;
            }
        }

        public static string EditorNew(SiteModel siteModel, long siteId)
        {
            return Editor(
                siteModel,
                new ResultModel(
                    siteModel.ResultsSiteSettings(),
                    siteModel.PermissionType,
                    methodType: BaseModel.MethodTypes.New)
                {
                    SiteId = siteId
                });
        }

        public static string Editor(SiteModel siteModel, long resultId, bool clearSessions)
        {
            var siteSettings = siteModel.ResultsSiteSettings();
            var resultModel = new ResultModel(
                siteSettings: siteSettings,
                permissionType: siteModel.PermissionType,
                resultId: resultId,
                clearSessions: clearSessions,
                methodType: BaseModel.MethodTypes.Edit);
            resultModel.SwitchTargets = ResultsUtility.GetSwitchTargets(
                siteSettings, resultModel.SiteId);
            return Editor(siteModel, resultModel);
        }

        public static string Editor(SiteModel siteModel, ResultModel resultModel)
        {
            var hb = Html.Builder();
            resultModel.SiteSettings.SetLinks();
            return hb.Template(
                siteId: siteModel.SiteId,
                modelName: "Result",
                title: resultModel.MethodType != BaseModel.MethodTypes.New
                    ? resultModel.Title.DisplayValue + " - " + Displays.Edit()
                    : siteModel.Title.DisplayValue + " - " + Displays.New(),
                permissionType: resultModel.PermissionType,
                verType: resultModel.VerType,
                backUrl: Navigations.ItemIndex(resultModel.SiteId),
                methodType: resultModel.MethodType,
                allowAccess:
                    resultModel.PermissionType.CanRead() &&
                    resultModel.AccessStatus != Databases.AccessStatuses.NotFound,
                action: () =>
                {
                    hb
                        .Editor(
                            siteSettings: resultModel.SiteSettings,
                            resultModel: resultModel,
                            siteModel: siteModel)
                        .Hidden(controlId: "TableName", value: "Results")
                        .Hidden(controlId: "Id", value: resultModel.ResultId.ToString());
                }).ToString();
        }

        private static HtmlBuilder Editor(
            this HtmlBuilder hb,
            SiteModel siteModel,
            SiteSettings siteSettings,
            ResultModel resultModel)
        {
            return hb.Div(css: "edit-form", action: () => hb
                .Form(
                    attributes: Html.Attributes()
                        .Id_Css("ResultForm", "main-form")
                        .Action(Navigations.ItemAction(resultModel.ResultId != 0 
                            ? resultModel.ResultId
                            : siteModel.SiteId)),
                    action: () => hb
                        .RecordHeader(
                            id: resultModel.ResultId,
                            baseModel: resultModel,
                            tableName: "Results",
                            switchTargets: resultModel.SwitchTargets)
                        .Div(css: "edit-form-comments", action: () => hb
                            .Comments(
                                comments: resultModel.Comments,
                                verType: resultModel.VerType))
                        .Div(css: "edit-form-tabs", action: () => hb
                            .FieldTabs(resultModel: resultModel)
                            .Fields(
                                siteSettings: siteSettings,
                                permissionType: siteModel.PermissionType,
                                resultModel: resultModel)
                            .Div(id: "LinkCreations", css: "links", action: () => hb
                                .LinkCreations(
                                    siteSettings: siteSettings,
                                    linkId: resultModel.ResultId,
                                    methodType: resultModel.MethodType))
                            .Div(id: "Links", css: "links", action: () => hb
                                .Links(linkId: resultModel.ResultId))
                            .MainCommands(
                                siteId: siteModel.SiteId,
                                permissionType: siteModel.PermissionType,
                                verType: resultModel.VerType,
                                backUrl: Navigations.ItemIndex(siteSettings.SiteId),
                                referenceType: "items",
                                referenceId: resultModel.ResultId,
                                updateButton: true,
                                copyButton: true,
                                moveButton: true,
                                mailButton: true,
                                deleteButton: true,
                                extensions: () => hb
                                    .MainCommandExtensions(
                                        resultModel: resultModel,
                                        siteSettings: siteSettings)))
                        .Hidden(controlId: "BaseUrl", value: Navigations.BaseUrl())
                        .Hidden(
                            controlId: "Results_Timestamp",
                            css: "must-transport",
                            value: resultModel.Timestamp)
                        .Hidden(
                            controlId: "SwitchTargets",
                            css: "must-transport",
                            value: resultModel.SwitchTargets?.Join()))
                .OutgoingMailsForm("Results", resultModel.ResultId, resultModel.Ver)
                .Dialog_Copy("items", resultModel.ResultId)
                .Dialog_Move("items", resultModel.ResultId)
                .Dialog_Histories(Navigations.ItemAction(resultModel.ResultId))
                .Dialog_OutgoingMail()
                .EditorExtensions(resultModel: resultModel, siteSettings: siteSettings));
        }

        private static HtmlBuilder FieldTabs(this HtmlBuilder hb, ResultModel resultModel)
        {
            return hb.Ul(css: "field-tab", action: () => hb
                .Li(action: () => hb
                    .A(
                        href: "#FieldSetGeneral", 
                        text: Displays.Basic())));
        }

        private static HtmlBuilder Fields(
            this HtmlBuilder hb,
            ResultModel resultModel,
            Permissions.Types permissionType,
            SiteSettings siteSettings)
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
                            case "ResultId": hb.Field(siteSettings, column, resultModel.ResultId.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Ver": hb.Field(siteSettings, column, resultModel.Ver.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Title": hb.Field(siteSettings, column, resultModel.Title.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Body": hb.Field(siteSettings, column, resultModel.Body.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Status": hb.Field(siteSettings, column, resultModel.Status.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Manager": hb.Field(siteSettings, column, resultModel.Manager.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "Owner": hb.Field(siteSettings, column, resultModel.Owner.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassA": hb.Field(siteSettings, column, resultModel.ClassA.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassB": hb.Field(siteSettings, column, resultModel.ClassB.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassC": hb.Field(siteSettings, column, resultModel.ClassC.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassD": hb.Field(siteSettings, column, resultModel.ClassD.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassE": hb.Field(siteSettings, column, resultModel.ClassE.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassF": hb.Field(siteSettings, column, resultModel.ClassF.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassG": hb.Field(siteSettings, column, resultModel.ClassG.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassH": hb.Field(siteSettings, column, resultModel.ClassH.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassI": hb.Field(siteSettings, column, resultModel.ClassI.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassJ": hb.Field(siteSettings, column, resultModel.ClassJ.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassK": hb.Field(siteSettings, column, resultModel.ClassK.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassL": hb.Field(siteSettings, column, resultModel.ClassL.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassM": hb.Field(siteSettings, column, resultModel.ClassM.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassN": hb.Field(siteSettings, column, resultModel.ClassN.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassO": hb.Field(siteSettings, column, resultModel.ClassO.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "ClassP": hb.Field(siteSettings, column, resultModel.ClassP.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumA": hb.Field(siteSettings, column, resultModel.NumA.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumB": hb.Field(siteSettings, column, resultModel.NumB.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumC": hb.Field(siteSettings, column, resultModel.NumC.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumD": hb.Field(siteSettings, column, resultModel.NumD.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumE": hb.Field(siteSettings, column, resultModel.NumE.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumF": hb.Field(siteSettings, column, resultModel.NumF.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumG": hb.Field(siteSettings, column, resultModel.NumG.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "NumH": hb.Field(siteSettings, column, resultModel.NumH.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateA": hb.Field(siteSettings, column, resultModel.DateA.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateB": hb.Field(siteSettings, column, resultModel.DateB.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateC": hb.Field(siteSettings, column, resultModel.DateC.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateD": hb.Field(siteSettings, column, resultModel.DateD.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateE": hb.Field(siteSettings, column, resultModel.DateE.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateF": hb.Field(siteSettings, column, resultModel.DateF.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateG": hb.Field(siteSettings, column, resultModel.DateG.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DateH": hb.Field(siteSettings, column, resultModel.DateH.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionA": hb.Field(siteSettings, column, resultModel.DescriptionA.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionB": hb.Field(siteSettings, column, resultModel.DescriptionB.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionC": hb.Field(siteSettings, column, resultModel.DescriptionC.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionD": hb.Field(siteSettings, column, resultModel.DescriptionD.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionE": hb.Field(siteSettings, column, resultModel.DescriptionE.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionF": hb.Field(siteSettings, column, resultModel.DescriptionF.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionG": hb.Field(siteSettings, column, resultModel.DescriptionG.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                            case "DescriptionH": hb.Field(siteSettings, column, resultModel.DescriptionH.ToControl(column), column.ColumnPermissionType(permissionType)); break;
                        }
                    });
                hb.VerUpCheckBox(resultModel);
            });
        }

        private static HtmlBuilder MainCommandExtensions(
            this HtmlBuilder hb,
            ResultModel resultModel,
            SiteSettings siteSettings)
        {
            return hb;
        }

        private static HtmlBuilder EditorExtensions(
            this HtmlBuilder hb,
            ResultModel resultModel,
            SiteSettings siteSettings)
        {
            return hb;
        }

        public static List<long> GetSwitchTargets(SiteSettings siteSettings, long siteId)
        {
            var switchTargets = Forms.Data("SwitchTargets").Split(',')
                .Select(o => o.ToLong())
                .Where(o => o != 0)
                .ToList();
            if (switchTargets.Count() == 0)
            {
                var formData = DataViewFilters.SessionFormData(siteId);
                switchTargets = Rds.ExecuteTable(
                    transactional: false,
                    statements: Rds.SelectResults(
                        column: Rds.ResultsColumn().ResultId(),
                        where: DataViewFilters.Get(
                            siteSettings: siteSettings,
                            tableName: "Results",
                            formData: formData,
                            where: Rds.ResultsWhere().SiteId(siteId)),
                        orderBy: GridSorters.Get(
                            formData, Rds.ResultsOrderBy().UpdatedTime(SqlOrderBy.Types.desc))))
                                .AsEnumerable()
                                .Select(o => o["ResultId"].ToLong())
                                .ToList();    
            }
            return switchTargets;
        }

        public static string BulkMove(SiteSettings siteSettings, Permissions.Types permissionType)
        {
            var siteId = Forms.Long("Dialog_MoveTargets");
            if (Permissions.CanMove(siteSettings.SiteId, siteId))
            {
                var count = 0;
                if (Forms.Bool("GridCheckAll"))
                {
                    count = BulkMove(
                        siteId,
                        siteSettings,
                        GridItems("GridUnCheckedItems"),
                        negative: true);
                }
                else
                {
                    var checkedItems = GridItems("GridCheckedItems");
                    if (checkedItems.Count() > 0)
                    {
                        count = BulkMove(
                            siteId,
                            siteSettings,
                            checkedItems);
                    }
                    else
                    {
                        return Messages.ResponseSelectTargets().ToJson();
                    }
                }
                return GridRows(
                    siteSettings,
                    permissionType,
                    clearCheck: true,
                    message: Messages.BulkMoved(count.ToString()));
            }
            else
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
        }

        private static int BulkMove(
            long siteId,
            SiteSettings siteSettings,
            IEnumerable<long> checkedItems,
            bool negative = false)
        {
            return Rds.ExecuteScalar_int(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.UpdateResults(
                        where: DataViewFilters.Get(
                            siteSettings: siteSettings,
                            tableName: "Results",
                            formData: DataViewFilters.SessionFormData(siteSettings.SiteId),
                            where: Rds.ResultsWhere()
                                .SiteId(siteSettings.SiteId)
                                .ResultId_In(
                                    value: checkedItems,
                                    negative: negative,
                                    _using: checkedItems.Count() > 0)),
                        param: Rds.ResultsParam().SiteId(siteId),
                        countRecord: true),
                    Rds.UpdateItems(
                        where: Rds.ItemsWhere()
                            .ReferenceId_In(
                                sub: Rds.SelectResults(
                                    column: Rds.ResultsColumn().ResultId(),
                                    where: Rds.ResultsWhere().SiteId(siteId)))
                            .SiteId(siteId, _operator: "<>"),
                        param: Rds.ItemsParam().SiteId(siteId))
                });
        }

        public static string BulkDelete(
            Permissions.Types permissionType,
            SiteSettings siteSettings)
        {
            if (permissionType.CanDelete())
            {
                var count = 0;
                if (Forms.Bool("GridCheckAll"))
                {
                    count = BulkDelete(
                        siteSettings,
                        GridItems("GridUnCheckedItems"),
                        negative: true);
                }
                else
                {
                    var checkedItems = GridItems("GridCheckedItems");
                    if (checkedItems.Count() > 0)
                    {
                        count = BulkDelete(
                            siteSettings,
                            checkedItems);
                    }
                    else
                    {
                        return Messages.ResponseSelectTargets().ToJson();
                    }
                }
                return GridRows(
                    siteSettings,
                    permissionType,
                    clearCheck: true,
                    message: Messages.BulkDeleted(count.ToString()));
            }
            else
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
        }

        private static int BulkDelete(
            SiteSettings siteSettings,
            IEnumerable<long> checkedItems,
            bool negative = false)
        {
            var where = DataViewFilters.Get(
                siteSettings: siteSettings,
                tableName: "Results",
                formData: DataViewFilters.SessionFormData(siteSettings.SiteId),
                where: Rds.ResultsWhere()
                    .SiteId(siteSettings.SiteId)
                    .ResultId_In(
                        value: checkedItems,
                        negative: negative,
                        _using: checkedItems.Count() > 0));
            return Rds.ExecuteScalar_int(
                transactional: true,
                statements: new SqlStatement[]
                {
                    Rds.DeleteItems(
                        where: Rds.ItemsWhere()
                            .ReferenceId_In(
                                sub: Rds.SelectResults(
                                    column: Rds.ResultsColumn().ResultId(),
                                    where: where))),
                    Rds.DeleteResults(
                        where: where, 
                        countRecord: true)
                });
        }

        private static IEnumerable<long> GridItems(string name)
        {
            return Forms.Data(name)
                .Split(',')
                .Select(o => o.ToLong())
                .Where(o => o != 0)
                .Distinct();
        }

        public static string Import(SiteModel siteModel)
        {
            if (!siteModel.PermissionType.CanCreate())
            {
                return Messages.ResponseHasNotPermission().ToJson();
            }
            var responseCollection = new ResponseCollection();
            Csv csv;
            try
            {
                csv = new Csv(Forms.File("Import"), Forms.Data("Encoding"));
            }
            catch
            {
                return Messages.ResponseFailedReadFile().ToJson();
            }
            if (csv != null && csv.Rows.Count() != 0)
            {
                var siteSettings = siteModel.ResultsSiteSettings();
                var columnHash = new Dictionary<int, Column>();
                csv.Headers.Select((o, i) => new { Header = o, Index = i }).ForEach(data =>
                {
                    var column = siteSettings.ColumnCollection
                        .Where(o => o.LabelText == data.Header)
                        .FirstOrDefault();
                    if (column != null) columnHash.Add(data.Index, column);
                });
                var error = Imports.ColumnValidate(siteSettings, columnHash.Values
                    .Select(o => o.ColumnName));
                if (error != null) return error;
                var paramHash = new Dictionary<int, SqlParamCollection>();
                csv.Rows.Select((o, i) => new { Row = o, Index = i }).ForEach(data =>
                {
                    var param = Rds.ResultsParam();
                    param.ResultId(raw: Def.Sql.Identity);
                    param.SiteId(siteModel.SiteId);
                    columnHash.ForEach(column =>
                    {
                        var recordingData = ImportRecordingData(
                            column.Value, data.Row[column.Key], siteModel.InheritPermission);
                        if (!param.Any(o => o.Name == column.Value.ColumnName))
                        {
                            switch (column.Value.ColumnName)
                            {
                                case "Title": param.Title(recordingData, _using: recordingData != null); break;
                                case "Body": param.Body(recordingData, _using: recordingData != null); break;
                                case "Status": param.Status(recordingData, _using: recordingData != null); break;
                                case "Manager": param.Manager(recordingData, _using: recordingData != null); break;
                                case "Owner": param.Owner(recordingData, _using: recordingData != null); break;
                                case "ClassA": param.ClassA(recordingData, _using: recordingData != null); break;
                                case "ClassB": param.ClassB(recordingData, _using: recordingData != null); break;
                                case "ClassC": param.ClassC(recordingData, _using: recordingData != null); break;
                                case "ClassD": param.ClassD(recordingData, _using: recordingData != null); break;
                                case "ClassE": param.ClassE(recordingData, _using: recordingData != null); break;
                                case "ClassF": param.ClassF(recordingData, _using: recordingData != null); break;
                                case "ClassG": param.ClassG(recordingData, _using: recordingData != null); break;
                                case "ClassH": param.ClassH(recordingData, _using: recordingData != null); break;
                                case "ClassI": param.ClassI(recordingData, _using: recordingData != null); break;
                                case "ClassJ": param.ClassJ(recordingData, _using: recordingData != null); break;
                                case "ClassK": param.ClassK(recordingData, _using: recordingData != null); break;
                                case "ClassL": param.ClassL(recordingData, _using: recordingData != null); break;
                                case "ClassM": param.ClassM(recordingData, _using: recordingData != null); break;
                                case "ClassN": param.ClassN(recordingData, _using: recordingData != null); break;
                                case "ClassO": param.ClassO(recordingData, _using: recordingData != null); break;
                                case "ClassP": param.ClassP(recordingData, _using: recordingData != null); break;
                                case "NumA": param.NumA(recordingData, _using: recordingData != null); break;
                                case "NumB": param.NumB(recordingData, _using: recordingData != null); break;
                                case "NumC": param.NumC(recordingData, _using: recordingData != null); break;
                                case "NumD": param.NumD(recordingData, _using: recordingData != null); break;
                                case "NumE": param.NumE(recordingData, _using: recordingData != null); break;
                                case "NumF": param.NumF(recordingData, _using: recordingData != null); break;
                                case "NumG": param.NumG(recordingData, _using: recordingData != null); break;
                                case "NumH": param.NumH(recordingData, _using: recordingData != null); break;
                                case "DateA": param.DateA(recordingData, _using: recordingData != null); break;
                                case "DateB": param.DateB(recordingData, _using: recordingData != null); break;
                                case "DateC": param.DateC(recordingData, _using: recordingData != null); break;
                                case "DateD": param.DateD(recordingData, _using: recordingData != null); break;
                                case "DateE": param.DateE(recordingData, _using: recordingData != null); break;
                                case "DateF": param.DateF(recordingData, _using: recordingData != null); break;
                                case "DateG": param.DateG(recordingData, _using: recordingData != null); break;
                                case "DateH": param.DateH(recordingData, _using: recordingData != null); break;
                                case "DescriptionA": param.DescriptionA(recordingData, _using: recordingData != null); break;
                                case "DescriptionB": param.DescriptionB(recordingData, _using: recordingData != null); break;
                                case "DescriptionC": param.DescriptionC(recordingData, _using: recordingData != null); break;
                                case "DescriptionD": param.DescriptionD(recordingData, _using: recordingData != null); break;
                                case "DescriptionE": param.DescriptionE(recordingData, _using: recordingData != null); break;
                                case "DescriptionF": param.DescriptionF(recordingData, _using: recordingData != null); break;
                                case "DescriptionG": param.DescriptionG(recordingData, _using: recordingData != null); break;
                                case "DescriptionH": param.DescriptionH(recordingData, _using: recordingData != null); break;
                                case "Comments": param.Comments(recordingData, _using: recordingData != null); break;
                            }
                        }
                    });
                    paramHash.Add(data.Index, param);
                });
                paramHash.Values.ForEach(param =>
                    new ResultModel(siteSettings, siteModel.PermissionType)
                    {
                        SiteId = siteModel.SiteId,
                        Title = new Title(param.FirstOrDefault(o =>
                            o.Name == "Title").Value.ToString()),
                        SiteSettings = siteSettings
                    }.Create(param: param));
                return GridRows(siteSettings, siteModel.PermissionType, responseCollection
                    .WindowScrollTop()
                    .CloseDialog("#Dialog_ImportSettings")
                    .Message(Messages.Imported(csv.Rows.Count().ToString())));
            }
            else
            {
                return Messages.ResponseFileNotFound().ToJson();
            }
        }

        private static object ImportRecordingData(
            Column column, string value, long inheritPermission)
        {
            var recordingData = column.RecordingData(value, inheritPermission);
            return recordingData;
        }

        public static ResponseFile Export(
            SiteSettings siteSettings, 
            Permissions.Types permissionType,
            SiteModel siteModel)
        {
            siteModel.SiteSettings.SetLinks();
            var formData = DataViewFilters.SessionFormData(siteModel.SiteId);
            var resultCollection = new ResultCollection(
                siteSettings: siteSettings,
                permissionType: permissionType,
                where: DataViewFilters.Get(
                    siteSettings: siteModel.SiteSettings,
                    tableName: "Results",
                    formData: formData,
                    where: Rds.ResultsWhere().SiteId(siteModel.SiteId)),
                orderBy: GridSorters.Get(
                    formData, Rds.ResultsOrderBy().UpdatedTime(SqlOrderBy.Types.desc)));
            var csv = new StringBuilder();
            var exportColumns = (Sessions.PageSession(
                siteModel.Id, 
                "ExportSettings_ExportColumns").ToString().Deserialize<ExportColumns>());
            var columnHash = exportColumns.ColumnHash(siteModel.ResultsSiteSettings());
            if (Sessions.PageSession(siteModel.Id, "ExportSettings_AddHeader").ToBool())
            {
                var header = new List<string>();
                exportColumns
                    .Columns
                    .Where(o => o.Value)
                    .ForEach(exportColumn => header.Add(
                        "\"" + columnHash[exportColumn.Key].LabelText + "\""));
                csv.Append(header.Join(","), "\n");
            }
            resultCollection.ForEach(resultModel =>
            {
                var row = new List<string>();
                exportColumns
                    .Columns
                    .Where(o => o.Value)
                    .ForEach(exportColumn =>
                        row.Add(CsvColumn(
                            resultModel, 
                            exportColumn.Key, 
                            columnHash[exportColumn.Key])));
                csv.Append(row.Join(","), "\n");
            });
            return new ResponseFile(csv.ToString(), ResponseFileNames.Csv(siteModel));
        }

        private static string CsvColumn(
            ResultModel resultModel, string columnName, Column column)
        {
            var value = string.Empty;
            switch (columnName)
            {
                case "SiteId": value = resultModel.SiteId.ToExport(column); break;
                case "UpdatedTime": value = resultModel.UpdatedTime.ToExport(column); break;
                case "ResultId": value = resultModel.ResultId.ToExport(column); break;
                case "Ver": value = resultModel.Ver.ToExport(column); break;
                case "Title": value = resultModel.Title.ToExport(column); break;
                case "Body": value = resultModel.Body.ToExport(column); break;
                case "TitleBody": value = resultModel.TitleBody.ToExport(column); break;
                case "Status": value = resultModel.Status.ToExport(column); break;
                case "Manager": value = resultModel.Manager.ToExport(column); break;
                case "Owner": value = resultModel.Owner.ToExport(column); break;
                case "ClassA": value = resultModel.ClassA.ToExport(column); break;
                case "ClassB": value = resultModel.ClassB.ToExport(column); break;
                case "ClassC": value = resultModel.ClassC.ToExport(column); break;
                case "ClassD": value = resultModel.ClassD.ToExport(column); break;
                case "ClassE": value = resultModel.ClassE.ToExport(column); break;
                case "ClassF": value = resultModel.ClassF.ToExport(column); break;
                case "ClassG": value = resultModel.ClassG.ToExport(column); break;
                case "ClassH": value = resultModel.ClassH.ToExport(column); break;
                case "ClassI": value = resultModel.ClassI.ToExport(column); break;
                case "ClassJ": value = resultModel.ClassJ.ToExport(column); break;
                case "ClassK": value = resultModel.ClassK.ToExport(column); break;
                case "ClassL": value = resultModel.ClassL.ToExport(column); break;
                case "ClassM": value = resultModel.ClassM.ToExport(column); break;
                case "ClassN": value = resultModel.ClassN.ToExport(column); break;
                case "ClassO": value = resultModel.ClassO.ToExport(column); break;
                case "ClassP": value = resultModel.ClassP.ToExport(column); break;
                case "NumA": value = resultModel.NumA.ToExport(column); break;
                case "NumB": value = resultModel.NumB.ToExport(column); break;
                case "NumC": value = resultModel.NumC.ToExport(column); break;
                case "NumD": value = resultModel.NumD.ToExport(column); break;
                case "NumE": value = resultModel.NumE.ToExport(column); break;
                case "NumF": value = resultModel.NumF.ToExport(column); break;
                case "NumG": value = resultModel.NumG.ToExport(column); break;
                case "NumH": value = resultModel.NumH.ToExport(column); break;
                case "DateA": value = resultModel.DateA.ToExport(column); break;
                case "DateB": value = resultModel.DateB.ToExport(column); break;
                case "DateC": value = resultModel.DateC.ToExport(column); break;
                case "DateD": value = resultModel.DateD.ToExport(column); break;
                case "DateE": value = resultModel.DateE.ToExport(column); break;
                case "DateF": value = resultModel.DateF.ToExport(column); break;
                case "DateG": value = resultModel.DateG.ToExport(column); break;
                case "DateH": value = resultModel.DateH.ToExport(column); break;
                case "DescriptionA": value = resultModel.DescriptionA.ToExport(column); break;
                case "DescriptionB": value = resultModel.DescriptionB.ToExport(column); break;
                case "DescriptionC": value = resultModel.DescriptionC.ToExport(column); break;
                case "DescriptionD": value = resultModel.DescriptionD.ToExport(column); break;
                case "DescriptionE": value = resultModel.DescriptionE.ToExport(column); break;
                case "DescriptionF": value = resultModel.DescriptionF.ToExport(column); break;
                case "DescriptionG": value = resultModel.DescriptionG.ToExport(column); break;
                case "DescriptionH": value = resultModel.DescriptionH.ToExport(column); break;
                case "Comments": value = resultModel.Comments.ToExport(column); break;
                case "Creator": value = resultModel.Creator.ToExport(column); break;
                case "Updator": value = resultModel.Updator.ToExport(column); break;
                case "CreatedTime": value = resultModel.CreatedTime.ToExport(column); break;
                default: return string.Empty;
            }
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        public static string TitleDisplayValue(SiteSettings siteSettings, ResultModel resultModel)
        {
            var displayValue = siteSettings.ColumnCollection
                .Where(o => o.TitleVisible.ToBool())
                .OrderBy(o => siteSettings.TitleOrder.IndexOf(o.ColumnName))
                .Select(column => TitleDisplayValue(column, resultModel))
                .Where(o => o != string.Empty)
                .Join(siteSettings.TitleSeparator);
            return displayValue != string.Empty
                ? displayValue
                : Displays.NoTitle();
        }

        private static string TitleDisplayValue(Column column, ResultModel resultModel)
        {
            switch (column.ColumnName)
            {
                case "Title": return column.HasChoices()
                    ? column.Choice(resultModel.Title.Value).Text()
                    : resultModel.Title.Value;
                case "ClassA": return column.HasChoices()
                    ? column.Choice(resultModel.ClassA).Text()
                    : resultModel.ClassA;
                case "ClassB": return column.HasChoices()
                    ? column.Choice(resultModel.ClassB).Text()
                    : resultModel.ClassB;
                case "ClassC": return column.HasChoices()
                    ? column.Choice(resultModel.ClassC).Text()
                    : resultModel.ClassC;
                case "ClassD": return column.HasChoices()
                    ? column.Choice(resultModel.ClassD).Text()
                    : resultModel.ClassD;
                case "ClassE": return column.HasChoices()
                    ? column.Choice(resultModel.ClassE).Text()
                    : resultModel.ClassE;
                case "ClassF": return column.HasChoices()
                    ? column.Choice(resultModel.ClassF).Text()
                    : resultModel.ClassF;
                case "ClassG": return column.HasChoices()
                    ? column.Choice(resultModel.ClassG).Text()
                    : resultModel.ClassG;
                case "ClassH": return column.HasChoices()
                    ? column.Choice(resultModel.ClassH).Text()
                    : resultModel.ClassH;
                case "ClassI": return column.HasChoices()
                    ? column.Choice(resultModel.ClassI).Text()
                    : resultModel.ClassI;
                case "ClassJ": return column.HasChoices()
                    ? column.Choice(resultModel.ClassJ).Text()
                    : resultModel.ClassJ;
                case "ClassK": return column.HasChoices()
                    ? column.Choice(resultModel.ClassK).Text()
                    : resultModel.ClassK;
                case "ClassL": return column.HasChoices()
                    ? column.Choice(resultModel.ClassL).Text()
                    : resultModel.ClassL;
                case "ClassM": return column.HasChoices()
                    ? column.Choice(resultModel.ClassM).Text()
                    : resultModel.ClassM;
                case "ClassN": return column.HasChoices()
                    ? column.Choice(resultModel.ClassN).Text()
                    : resultModel.ClassN;
                case "ClassO": return column.HasChoices()
                    ? column.Choice(resultModel.ClassO).Text()
                    : resultModel.ClassO;
                case "ClassP": return column.HasChoices()
                    ? column.Choice(resultModel.ClassP).Text()
                    : resultModel.ClassP;
                default: return string.Empty;
            }
        }

        public static string TitleDisplayValue(SiteSettings siteSettings, DataRow dataRow)
        {
            var displayValue = siteSettings.ColumnCollection
                .Where(o => o.TitleVisible.ToBool())
                .OrderBy(o => siteSettings.TitleOrder.IndexOf(o.ColumnName))
                .Select(column => TitleDisplayValue(column, dataRow))
                .Where(o => o != string.Empty)
                .Join(siteSettings.TitleSeparator);
            return displayValue != string.Empty
                ? displayValue
                : Displays.NoTitle();
        }

        private static string TitleDisplayValue(Column column, DataRow dataRow)
        {
            switch (column.ColumnName)
            {
                case "Title": return column.HasChoices()
                    ? column.Choice(dataRow["Title"].ToString()).Text()
                    : dataRow["Title"].ToString();
                case "ClassA": return column.HasChoices()
                    ? column.Choice(dataRow["ClassA"].ToString()).Text()
                    : dataRow["ClassA"].ToString();
                case "ClassB": return column.HasChoices()
                    ? column.Choice(dataRow["ClassB"].ToString()).Text()
                    : dataRow["ClassB"].ToString();
                case "ClassC": return column.HasChoices()
                    ? column.Choice(dataRow["ClassC"].ToString()).Text()
                    : dataRow["ClassC"].ToString();
                case "ClassD": return column.HasChoices()
                    ? column.Choice(dataRow["ClassD"].ToString()).Text()
                    : dataRow["ClassD"].ToString();
                case "ClassE": return column.HasChoices()
                    ? column.Choice(dataRow["ClassE"].ToString()).Text()
                    : dataRow["ClassE"].ToString();
                case "ClassF": return column.HasChoices()
                    ? column.Choice(dataRow["ClassF"].ToString()).Text()
                    : dataRow["ClassF"].ToString();
                case "ClassG": return column.HasChoices()
                    ? column.Choice(dataRow["ClassG"].ToString()).Text()
                    : dataRow["ClassG"].ToString();
                case "ClassH": return column.HasChoices()
                    ? column.Choice(dataRow["ClassH"].ToString()).Text()
                    : dataRow["ClassH"].ToString();
                case "ClassI": return column.HasChoices()
                    ? column.Choice(dataRow["ClassI"].ToString()).Text()
                    : dataRow["ClassI"].ToString();
                case "ClassJ": return column.HasChoices()
                    ? column.Choice(dataRow["ClassJ"].ToString()).Text()
                    : dataRow["ClassJ"].ToString();
                case "ClassK": return column.HasChoices()
                    ? column.Choice(dataRow["ClassK"].ToString()).Text()
                    : dataRow["ClassK"].ToString();
                case "ClassL": return column.HasChoices()
                    ? column.Choice(dataRow["ClassL"].ToString()).Text()
                    : dataRow["ClassL"].ToString();
                case "ClassM": return column.HasChoices()
                    ? column.Choice(dataRow["ClassM"].ToString()).Text()
                    : dataRow["ClassM"].ToString();
                case "ClassN": return column.HasChoices()
                    ? column.Choice(dataRow["ClassN"].ToString()).Text()
                    : dataRow["ClassN"].ToString();
                case "ClassO": return column.HasChoices()
                    ? column.Choice(dataRow["ClassO"].ToString()).Text()
                    : dataRow["ClassO"].ToString();
                case "ClassP": return column.HasChoices()
                    ? column.Choice(dataRow["ClassP"].ToString()).Text()
                    : dataRow["ClassP"].ToString();
                default: return string.Empty;
            }
        }
    }
}