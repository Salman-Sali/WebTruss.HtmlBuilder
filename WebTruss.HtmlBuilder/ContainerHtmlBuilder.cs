using WebTruss.HtmlBuilder.Builders;
using WebTruss.HtmlBuilder.Builders.Tables;
using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder
{
    public class ContainerHtmlBuilder : HtmlBuilderWithText
    {
        protected ContainerHtmlBuilder(HtmlTag htmlTag, IndentationOption indentationOption) : base(htmlTag, indentationOption)
        {
        }

        public new void AppendInnerHtml(string html)
        {
            base.AppendInnerHtml(html);
        }

        public new void AppendInnerHtml(HtmlBuilderBase htmlBuilder)
        {
            base.AppendInnerHtml(htmlBuilder);
        }

        public new void AppendInnerHtml<T>(Action<T> action) where T : HtmlBuilderBase
        {
            base.AppendInnerHtml(action);
        }

        public new void AppendInnerHtml(IHtmlBuilder htmlBuilder)
        {
            base.AppendInnerHtml(htmlBuilder);
        }

        public void AddDiv(Action<DivBuilder> action)
        {
            AppendInnerHtml(action);
        }

        public void AddSpan(Action<SpanBuilder> action)
        {
            AppendInnerHtml(action);
        }

        public void AddSpan(string text)
        {
            AppendInnerHtml(SpanBuilder.Build(text));
        }

        public void AddComment(string comment)
            => AppendInnerHtml(CommentBuilder.Build(comment));


        public void AddComment(Action<CommentBuilder> action)
            => AppendInnerHtml(action);

        public void AddTable(Action<TableBuilder> action)
            => AppendInnerHtml(action);
    }
}
