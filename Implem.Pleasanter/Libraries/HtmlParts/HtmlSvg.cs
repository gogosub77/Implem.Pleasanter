﻿using Implem.Pleasanter.Libraries.Html;
using System;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlSvg
    {
        public static HtmlBuilder Svg(
            this HtmlBuilder hb,
            string id = null,
            string css = null,
            Action action = null)
        {
            return hb.Append(
                tag: "svg",
                id: id,
                css: css,
                attributes: new HtmlAttributes()
                    .Id(id)
                    .Class(css)
                    .Add("xmlns", "http://www.w3.org/2000/svg"),
                action: action);
        }

        public static HtmlBuilder Rect(
            this HtmlBuilder hb,
            int? x = null,
            int? y = null,
            int? width = null,
            int? height = null,
            string fill = null)
        {
            return hb.Append(
                tag: "rect",
                id: null,
                css: null,
                attributes: new HtmlAttributes()
                    .Add("x", x.ToString(), _using: x != null)
                    .Add("y", y.ToString(), _using: y != null)
                    .Add("width", width.ToString(), _using: width != null)
                    .Add("height", height.ToString(), _using: height != null)
                    .Add("fill", fill, _using: fill != null),
                action: () => { });
        }

        public static HtmlBuilder SvgText(
            this HtmlBuilder hb,
            string text,
            int? x = null,
            int? y = null)
        {
            return hb.Append(
                tag: "text",
                id: null,
                css: null,
                attributes: new HtmlAttributes()
                    .Add("x", x.ToString(), _using: x != null)
                    .Add("y", y.ToString(), _using: y != null),
                action: () => hb
                    .Text(text: text));
        }
    }
}