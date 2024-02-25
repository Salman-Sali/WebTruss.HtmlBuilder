using WebTruss.HtmlBuilder.Builders.Links;
using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders
{
    public class HeadBuilder : HtmlBuilderBase
    {
        private HeadBuilder(IndentationOption indentationOption) : base(HtmlTag.head, indentationOption)
        {
        }

        public static string Build(Action<HeadBuilder> headerAction)
        {
            return Build(IndentationOption.FourSpace, headerAction);
        }

        public static string Build(IndentationOption indentationOption, Action<HeadBuilder> headerAction)
        {
            var headerBuilder = new HeadBuilder(indentationOption);
            headerAction(headerBuilder);
            return headerBuilder.Build();
        }

        public void AddStylesheetLink(string href)
        {
            var linkBuilder = LinkBuilder.Build(LinkRelValue.stylesheet, href, LinkType.Text_Css);
            base.AppendInnerHtml(linkBuilder);
        }

        public void AddComment(string comment)
        {
            AppendInnerHtml(
                CommentBuilder.Build(comment));
        }

        public void AddComment(Action<CommentBuilder> action)
        {
            AppendInnerHtml(action);
        }
    }
}
