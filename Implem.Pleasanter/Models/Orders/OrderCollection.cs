﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Classes;
using Implem.Libraries.DataSources.SqlServer;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Converts;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.DataTypes;
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
    public class OrderCollection : List<OrderModel>
    {
        public Databases.AccessStatuses AccessStatus = Databases.AccessStatuses.Initialized;
        public Aggregations Aggregations = new Aggregations();

        public OrderCollection(
            SiteSettings ss, 
            Permissions.Types pt,
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
            IEnumerable<Aggregation> aggregationCollection = null,
            bool get = true)
        {
            if (get)
            {
                Set(ss, pt, Get(
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
        }

        public OrderCollection(
            SiteSettings ss, 
            Permissions.Types pt,
            DataTable dataTable)
        {
            Set(ss, pt, dataTable);
        }

        private OrderCollection Set(
            SiteSettings ss, 
            Permissions.Types pt,
            DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Add(new OrderModel(ss, pt, dataRow));
                }
                AccessStatus = Databases.AccessStatuses.Selected;
            }
            else
            {
                AccessStatus = Databases.AccessStatuses.NotFound;
            }
            return this;
        }

        public OrderCollection(
            SiteSettings ss, 
            Permissions.Types pt,
            string commandText,
            SqlParamCollection param = null)
        {
            Set(ss, pt, Get(commandText, param));
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
                Rds.SelectOrders(
                    dataTableName: "Main",
                    column: column ?? Rds.OrdersDefaultColumns(),
                    join: join ??  Rds.OrdersJoinDefault(),
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
                statements.AddRange(Rds.OrdersAggregations(aggregationCollection, where));
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
                statements: Rds.OrdersStatement(
                    commandText: commandText,
                    param: param ?? null));
        }
    }
}
