﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Interfaces;
using Implem.Pleasanter.Libraries.Converts;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.HtmlParts;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Settings;
using System;
using System.Data;
namespace Implem.Pleasanter.Libraries.DataTypes
{
    public class WorkValue : IConvertable
    {
        public decimal Value;
        public decimal ProgressRate;

        public WorkValue()
        {
        }

        public WorkValue(
            DataRow dataRow,
            string progressRateColumnName = "ProgressRate",
            string valueColumnName = "WorkValue")
        {
            ProgressRate = dataRow.Decimal(progressRateColumnName);
            Value = dataRow.Decimal(valueColumnName);
        }

        public WorkValue(decimal value, decimal progressRate)
        {
            Value = value;
            ProgressRate = progressRate;
        }

        public string ToControl(Column column, Permissions.Types pt)
        {
            return column.Display(Value, pt);
        }

        public string ToResponse()
        {
            return Value.ToString();
        }

        public HtmlBuilder Td(HtmlBuilder hb, Column column)
        {
            return hb.Td(action: () => Svg(hb, column));
        }

        private HtmlBuilder Svg(HtmlBuilder hb, Column column)
        {
            var width = column.Max != null
                ? Convert.ToInt32(Value / column.Max.ToInt() * 100)
                : 0;
            return hb.Svg(css: "svg-work-value", action: () => hb
                .SvgText(
                    text: column.Display(Value, unit: true),
                    x: 0,
                    y: Parameters.General.WorkValueTextTop)
                .Rect(
                    x: 0,
                    y: Parameters.General.WorkValueHeight / 2,
                    width: width,
                    height: Parameters.General.WorkValueHeight / 2)
                .Rect(
                    x: 0,
                    y: Parameters.General.WorkValueHeight / 2,
                    width: ProgressRate != 0
                        ? (int)(width * (ProgressRate / 100))
                        : 0,
                    height: Parameters.General.WorkValueHeight / 2));
        }

        public string GridText(Column column)
        {
            return column.Display(Value, unit: true);
        }

        public string ToExport(Column column)
        {
            return Value.ToString();
        }

        public string ToNotice(
            decimal saved,
            Column column,
            bool updated,
            bool update)
        {
            return column.Display(Value, unit: true).ToNoticeLine(
                column.Display(saved, unit: true),
                column,
                updated,
                update);
        }
    }
}