using System;
using System.Reflection;
using System.Web;
using WebTruss.HtmlBuilder.Attributes;
using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder
{//https://html.spec.whatwg.org/
    public class HtmlBuilderBase
    {
        private string Html = "";
        protected HtmlTag HtmlTag;
        protected bool IsSelfClosing = false;
        protected string TagStart = "";
        protected string? TagEnd = null;
        private readonly IndentationOption indentationOption;

        protected AttributeValueDictionary Attributes { get; set; } = new();

        protected HtmlBuilderBase(HtmlTag htmlTag, IndentationOption indentationOption)
        {
            HtmlTag = htmlTag;
            TagStart = $"<{HtmlTag}";
            this.indentationOption = indentationOption;
        }

        protected void AppendTextToHtml(string text)
        {
            if (string.IsNullOrEmpty(Html))
            {
                AppendNewHtmlLine();
                text = AddIndentation(text);
            }
            Html += HttpUtility.HtmlEncode(text);
        }

        protected void PrependTextToHtml(string text)
        {
            if (string.IsNullOrEmpty(Html))
            {
                PrependNewHtmlLine();
                text = AddIndentation(text);
            }
            Html = HttpUtility.HtmlEncode(text) + Html;
        }

        protected void AppendInnerHtml(string innerHtml)
        {
            AppendNewHtmlLine();
            innerHtml = AddIndentation(innerHtml);
            Html += innerHtml;
        }

        protected void AppendInnerHtml(HtmlBuilderBase htmlBuilder)
        {
            AppendInnerHtml(htmlBuilder.Build());
        }

        protected void AppendInnerHtml<T>(Action<T> action) where T : HtmlBuilderBase
        {
            T instance = (T)typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0].Invoke([indentationOption]);
            action.Invoke(instance);
            AppendInnerHtml(instance);
        }

        protected void AppendInnerHtml(IHtmlBuilder htmlBuilder)
        {
            AppendInnerHtml(htmlBuilder.BuildHtmlBuilder());
        }


        protected void PrependInnerHtml(string innerHtml)
        {
            PrependNewHtmlLine();
            innerHtml = AddIndentation(innerHtml);
            Html = innerHtml + Html;
        }

        protected void PrependInnerHtml(HtmlBuilderBase htmlBuilder)
        {
            PrependInnerHtml(htmlBuilder.Build());
        }

        protected void PrependInnerHtml<T>(Action<T> action) where T : HtmlBuilderBase
        {
            T instance = (T)typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0].Invoke([indentationOption]);
            action.Invoke(instance);
            PrependInnerHtml(instance);
        }

        protected void PrependInnerHtml(IHtmlBuilder htmlBuilder)
        {
            PrependInnerHtml(htmlBuilder.BuildHtmlBuilder());
        }

        protected string AddIndentation(string innerHtml)
        {
            if (indentationOption == IndentationOption.Minified)
            {
                return innerHtml;
            }

            string indentation = "";
            switch (indentationOption)
            {
                case IndentationOption.TwoSpace:
                    indentation = "  ";
                    break;

                case IndentationOption.OneSpace:
                    indentation = " ";
                    break;

                case IndentationOption.Tab:
                    indentation = "\t";
                    break;
            }

            innerHtml = string.Join('\n',
                innerHtml
                    .Split('\n')
                    .Select(x => $"{indentation}{x}"));
            return innerHtml;
        }

        protected void AppendNewHtmlLine()
        {
            if (indentationOption != IndentationOption.Minified && !IsSelfClosing)
            {
                Html += "\n";
            }
        }

        protected void PrependNewHtmlLine()
        {
            if (indentationOption != IndentationOption.Minified && !IsSelfClosing)
            {
                Html = "\n" + Html;
            }
        }

        public string Build()
        {
            StartBuild();
            return EndBuild();
        }

        private void StartBuild()
        {
            foreach (var attribute in Attributes.Attributes)
            {
                TagStart += $" {attribute.Name}=\"{attribute.Value}\"";
            }
            Html = IsSelfClosing ?
                TagStart + Html :
                TagStart + ">" + Html;

            if (HtmlTag == HtmlTag.html)
            {
                Html = "<!DOCTYPE html>\n" + Html;
            }
        }

        public void SetId(string? id)
        {
            Attributes.SetAttribute("id", id);
        }

        public void SetClass(string classes)
        {
            Attributes.SetAttribute("class", classes);
        }

        public void AddClass(string? _class)
        {
            if (string.IsNullOrEmpty(_class))
            {
                return;
            }

            var classAttribute = Attributes.GetAttribute("class");
            if (classAttribute == null)
            {
                Attributes.SetAttribute("class", _class);
            }
            else
            {
                classAttribute.Value += $" {_class}";
            }
        }

        public void RemoveClass(string _class)
        {
            if (string.IsNullOrEmpty(_class))
            {
                return;
            }
            var classAttribute = Attributes.GetAttribute("class");
            if (classAttribute != null)
            {
                classAttribute.Value = string.Join(" ", classAttribute
                    .Value.Split(" ")
                    .Where(x => x != _class).ToList());
            }
        }

        public void SetAttribute(string name, string value)
        {
            Attributes.SetAttribute(name, value);
        }

        private string EndBuild()
        {
            AppendNewHtmlLine();
            if (string.IsNullOrEmpty(TagEnd))
            {
                Html += IsSelfClosing ? "/>" : $"</{HtmlTag}>";
            }
            else
            {
                Html += TagEnd;
            }
            return Html;
        }

        protected static T BuildBuilder<T>(Action<T> action, IndentationOption indentationOption = IndentationOption.Minified)
            where T : HtmlBuilderBase
        {
            T instance = (T)typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0].Invoke([indentationOption]);
            action.Invoke(instance);
            return instance;
        }
    }
}