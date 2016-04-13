﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Settings;
using Implem.Pleasanter.Libraries.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
namespace Implem.Pleasanter.Libraries.DataTypes
{
    public class ExportColumns
    {
        public string ReferenceType;
        public Dictionary<string, bool> Columns = new Dictionary<string, bool>();

        public ExportColumns()
        {
        }

        public ExportColumns(string referenceType)
        {
            ReferenceType = referenceType;
            Init();
        }

        public ExportColumns(ExportColumns source)
        {
            ReferenceType = source.ReferenceType;
            Columns = source.Columns;
        }

        private void Init()
        {
            UpdateExportSetting();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
            Init();
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext streamingContext)
        {
        }

        public string ToJson()
        {
            return Jsons.ToJson(new ExportColumns(this));
        }

        private void UpdateExportSetting()
        {
            Columns.AddRange(
                Def.ColumnDefinitionCollection
                    .Where(o => !Columns.Any(p => p.Key == o.ColumnName))
                    .Where(o => o.TableName == ReferenceType)
                    .Where(o => o.Export > 0)
                    .OrderBy(o => o.Export)
                    .ToDictionary(o => o.ColumnName, o => true));
            Columns.RemoveAll((key, value) =>
                !Def.ColumnDefinitionCollection.Any(p => p.ColumnName == key && p.Export > 0));
        }

        public Dictionary<string, string> ExportColumnHash(SiteSettings siteSettings)
        {
            return Columns.ToDictionary(
                o => o.Key,
                o => Displays.Get(ExportColumn(siteSettings, o.Key)) +
                    (o.Value ? " (" + Displays.Output() + ")" : string.Empty));
        }

        public string ExportColumn(SiteSettings siteSettings, string columnName)
        {
            return siteSettings.ColumnCollection
                .FirstOrDefault(o => o.ColumnName == columnName && o.Export).LabelText;
        }

        public void SetExport(
            Responses.ResponseCollection responseCollection,
            string controlId,
            IEnumerable<string> selectedValues,
            SiteSettings siteSettings)
        {
            var order = Columns.Keys.ToArray();
            if (controlId == "ColumnToDown")
            {
                Array.Reverse(order);
            }
            order.Select((o, i) => new { ColumnName = o, Index = i }).ForEach(data =>
            {
                if (selectedValues.Contains(data.ColumnName))
                {
                    switch (controlId)
                    {
                        case "ColumnToVisible":
                            Columns[data.ColumnName] = true;
                            break;
                        case "ColumnToHide":
                            Columns[data.ColumnName] = false;
                            break;
                        case "ColumnToUp":
                        case "ColumnToDown":
                            if (data.Index > 0 &&
                                selectedValues.Contains(
                                    order[data.Index - 1]) == false)
                            {
                                order = Arrays.Swap(
                                    order,
                                    data.Index,
                                    data.Index - 1);
                            }
                            break;
                    }
                }
            });
            if (controlId == "ColumnToDown")
            {
                Array.Reverse(order);
            }
            var newColumns = order.ToDictionary(o => o, o => Columns[o]);
            Columns.Clear();
            Columns.AddRange(newColumns);
            responseCollection.Html("#ExportSettings_Columns",
                Html.Builder().SelectableItems(
                    listItemCollection: ExportColumnHash(siteSettings),
                    selectedValueTextCollection: selectedValues));
        }

        public Dictionary<string, Column> ColumnHash(SiteSettings siteSettings)
        {
            return Columns.ToDictionary(o => o.Key, o => siteSettings.AllColumn(o.Key));
        }
    }
}