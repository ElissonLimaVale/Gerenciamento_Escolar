using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SGIEscolar.Data.Extensions
{
    public static class HtmlHelperExtensions 
    {
        #region WidGet
        public static IDisposable BeginWidget(this IHtmlHelper helper, string titulo, string subtitle = "",  int id = 1, int colunas = 12)
        {
            var html = new StringBuilder();
            html.AppendLine($"<section class='widget-grid' class='no-padding'>");
            html.AppendLine($"<div class='text-center'>");
            html.AppendLine($"<h1 class='display-4'>{titulo}</h1>");
            html.AppendLine($"<p>{subtitle}</p>");
            html.AppendLine($"</div>");

            html.AppendLine($"<div id='wid-id-{id}' class='row'>");
            html.AppendLine($"<article class='col-xs-{colunas} col-sm-{colunas} col-md-{colunas} col-lg-{colunas}'>");
            html.AppendLine($"<div class='widget-body no-padding'>");

            var textWriter = helper.ViewContext.Writer;
            textWriter.Write(html);
            return new DivWidget(textWriter);
        }
        private class DivWidget : IDisposable
        {
            private readonly TextWriter writer;
            public DivWidget(TextWriter writer)
            {
                this.writer = writer;
            }
            public void Dispose()
            {
                writer.Write("</div></article></div></section>");
            }
        }
        #endregion

        #region Table
        public static IDisposable BeginTable(this IHtmlHelper helper, string width = "100%", string id = "datatable_fixed_column")
        {
            var html = new StringBuilder();
            html.AppendLine($"<table id='{id}' class='table table-striped table-hover' width='{width}'>");

            var textWriter = helper.ViewContext.Writer;
            textWriter.Write(html);

            return new TableContent(textWriter);
        }

        private class TableContent : IDisposable
        {
            private readonly TextWriter writer;
            public TableContent(TextWriter writer)
            {
                this.writer = writer;
            }
            public void Dispose()
            {
                writer.Write("</table>");
            }
        }
        #endregion

        #region Form
        public static IDisposable BeginFormCustom(this IHtmlHelper helper, string id, string titulo, string postURL)
        {
            var html = new StringBuilder();
            html.AppendLine($"<form id='{id}' class='smart-form' method='post' action='{postURL}' style='padding: 10px;' >");
            html.AppendLine($"<header>{titulo}</header>");

            var textWriter = helper.ViewContext.Writer;
            textWriter.Write(html);
            return new FormContent(textWriter);
        }
        private class FormContent : IDisposable
        {
            private readonly TextWriter writer;
            public FormContent(TextWriter writer)
            {
                this.writer = writer;
            }
            public void Dispose()
            {
                writer.Write("<footer><div class='right'><a href='javascript:history.go(-1)' class='btn btn-default margin-10'> <i class='fa fa-arrow-left'></i>  Voltar </a><button type='submit' class='btn btn-primary margin-10'><i class='fa fa-check'></i>  Salvar</button></div></footer></form>");
            }
        }
        #endregion

        #region FieldSet
        public static IDisposable BeginFieldSetCustom(this IHtmlHelper helper, string titulo = "")
        {
            var html = new StringBuilder();
            if (!string.IsNullOrEmpty(titulo))
                html.AppendLine($"<header>{titulo}</header>");

            html.AppendLine($"<fieldset>");
            html.AppendLine($"<div class='row'>");

            var textWriter = helper.ViewContext.Writer;
            textWriter.Write(html);

            return new FieldsetContent(textWriter);
        }

        private class FieldsetContent : IDisposable
        {
            private readonly TextWriter writer;
            public FieldsetContent(TextWriter writer)
            {
                this.writer = writer;
            }
            public void Dispose()
            {
                writer.Write("</fieldset></div>");
            }
        }
        #endregion

        #region Inputs
        public static IHtmlContent TextBoxCustomFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, int colunas = 3, object htmlAttributes = null, string icone = "", string mascara = "", bool criarow = false)
        {
            string html = "";
            TagBuilder div = new TagBuilder("section");
            div.MergeAttribute("class", $"col col-md-{colunas}");
            var label = helper.LabelFor(expression, new { @class = "" });
            div.InnerHtml.AppendHtml(label);
            IHtmlContent text = null;
            if(string.IsNullOrEmpty(icone))
                text = helper.TextBoxFor(expression, GetDictionary(htmlAttributes, "form-control", mascara));
            else
            {
                TagBuilder divgroup = new TagBuilder("div");
                divgroup.MergeAttribute("class", "input-group");
                divgroup.InnerHtml.AppendHtml($"<span class='input-group-addon'><i class='{icone}'></i></span>");
                divgroup.InnerHtml.AppendHtml(helper.TextBoxFor(expression, GetDictionary(htmlAttributes, "form-control", mascara)));
                text = divgroup;

            }
            div.InnerHtml.AppendHtml(text);
            var validation = helper.ValidationMessageFor(expression, "", new { @class = "text-danger" });
            div.InnerHtml.AppendHtml(validation);

            using (var sw = new StringWriter())
            {
                div.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                html = sw.ToString();
            }

            return new HtmlString(html);
        }
        public static IHtmlContent TextBosCustom(this IHtmlHelper helper, string id, string label, int colunas = 3, string value = "", string icone = "", string mascara = "", object htmlAttributes = null)
        {
            var html = new StringBuilder();
            html.AppendLine($"<section class='col-md-{colunas}'>");
            html.AppendLine($"<label class=''>{label}</label>");
            if (string.IsNullOrEmpty(icone))
            {
                html.AppendLine(helper.TextBox(id, value, htmlAttributes: GetDictionary(htmlAttributes, "form-control", mascara)).ToString());
            }else
            {
                html.AppendLine("<div class='input-group'>");
                html.AppendLine($"<span class='input-group-addon'><i class='{icone}'></i></span>");
                html.AppendLine(helper.TextBox(id, value, htmlAttributes: GetDictionary(htmlAttributes, "form-control", mascara)).ToString());
            }
            html.AppendLine("</section>");

            return new HtmlString(html.ToString());
        }
        #endregion

        #region TextArea
        public static IHtmlContent TextAreaCustomFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, int colunas = 12, int columns = 5, int rows = 4, object htmlAttributes = null)
        {
            string html = "";
            TagBuilder div = new TagBuilder("section");
            div.MergeAttribute("class", $"col-md-{colunas}");
            var label = helper.LabelFor(expression, new { @class = "" });
            div.InnerHtml.AppendHtml(label);
            var text = helper.TextAreaFor(expression, rows, columns, GetDictionary(htmlAttributes, "form-control"));
            div.InnerHtml.AppendHtml(text);
            var validation = helper.ValidationMessageFor(expression, "", new { @class = "text-danger" });
            div.InnerHtml.AppendHtml(validation);

            using(var sw = new StringWriter())
            {
                div.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                html = sw.ToString();
            }
            return new HtmlString(html);
        }
        #endregion

        #region Select
        public static IHtmlContent DropDownListCustomFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectListItem, int colunas = 3, object htmlAttributes = null, string classIcone = "", bool criaRow = false)
        {
            string html = "";
            TagBuilder div = new TagBuilder("section");
            div.MergeAttribute("class", $"col-md-{colunas}");
            var label = helper.LabelFor(expression, new { @class = "" });
            div.InnerHtml.AppendHtml(label);
            IHtmlContent text = null;
            if (string.IsNullOrEmpty(classIcone))
            {
                text = helper.DropDownListFor(expression, selectListItem ,GetDictionary(htmlAttributes, "form-control"));
            }
            else
            {
                TagBuilder divgroup = new TagBuilder("div");
                divgroup.MergeAttribute("class", "input-group");
                divgroup.InnerHtml.AppendHtml($"<span class='input-group-addon'><i class='{classIcone}'></i></span>");
                divgroup.InnerHtml.AppendHtml(helper.DropDownListFor(expression, selectListItem, GetDictionary(htmlAttributes, "form-control")));
                text = divgroup;

            }
            div.InnerHtml.AppendHtml("<i></i>");
            div.InnerHtml.AppendHtml(text);
            var validation = helper.ValidationMessageFor(expression, "", new { @class = "text-danger" });
            div.InnerHtml.AppendHtml(validation);

            using (var sw = new StringWriter())
            {
                div.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                html = sw.ToString();
            }

            return new HtmlString(html);

        }
        #endregion
        public static IDictionary<string, object> GetDictionary(object htmlAttributes, string classe = "", string mascara = "")
        {
            IDictionary<string, object> dictionary = htmlAttributes.ToDictionary();
            if (!string.IsNullOrEmpty(mascara))
                dictionary.Add("data-mask", mascara);
            if (dictionary.ContainsKey("class"))
                dictionary["class"] = String.Format("{0} {1}", dictionary["class"], classe);
            else if (!string.IsNullOrEmpty(classe))
                dictionary["class"] = classe;

            return dictionary;
        }

        public static IDictionary<String, object> ToDictionary(this object data)
        {
            Dictionary<String, object> dictionary = new Dictionary<string, object>();

            if(data != null)
            {
                BindingFlags publicAttributes = BindingFlags.Public | BindingFlags.Instance;
                foreach (PropertyInfo property in data.GetType().GetProperties(publicAttributes))
                {
                    if (property.CanRead)
                        dictionary.Add(property.Name, property.GetValue(data, null));
                }
            }

            return dictionary;
        }
     
    }
}
