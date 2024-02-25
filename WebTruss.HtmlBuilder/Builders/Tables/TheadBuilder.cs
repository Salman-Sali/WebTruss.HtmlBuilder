using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class TheadBuilder : HtmlBuilderBase, IHtmlBuilderBuilder<TheadBuilder>
    {
        protected TheadBuilder(IndentationOption indentationOption) : base(HtmlTag.thead, indentationOption)
        {
        }

        public static TheadBuilder Build(Action<TheadBuilder> action)
            => BuildBuilder(action);

        public static TheadBuilder Build(IndentationOption option, Action<TheadBuilder> action)
            => BuildBuilder(action, option);

        public void AddTr(TrBuilder trBuilder)
            => AppendInnerHtml(trBuilder);

        public void AddTr(Action<TrBuilder> action)
            => AppendInnerHtml(action);
    }
}
