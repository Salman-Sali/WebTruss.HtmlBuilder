using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders.Links
{
    public class LinkBuilder : HtmlBuilderBase
    {
        protected LinkBuilder() : base(HtmlTag.link, IndentationOption.Minified)
        {
            IsSelfClosing = true;
        }

        public static LinkBuilder Build(LinkRelValue rel, string href, string type)
        {
            var linkBuilder = new LinkBuilder();
            linkBuilder.SetRel(rel);
            linkBuilder.SetHref(href);
            linkBuilder.SetType(type);
            return linkBuilder;
        }

        public void SetRel(LinkRelValue rel)
        {
            Attributes.SetAttribute(HtmlAttribute.rel, rel);
        }

        public void SetHref(string href)
        {
            Attributes.SetAttribute(HtmlAttribute.href, href);
        }

        public void SetType(string type)
        {
            Attributes.SetAttribute(HtmlAttribute.type, type);
        }
    }
}
