using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class TrBuilder : HtmlBuilderBase, IHtmlBuilderBuilder<TrBuilder>
    {
        protected TrBuilder(IndentationOption indentationOption) : base(HtmlTag.tr, indentationOption)
        {
        }

        public static TrBuilder Build(Action<TrBuilder> action)
            => BuildBuilder(action);

        public static TrBuilder Build(IndentationOption option, Action<TrBuilder> action)
            => BuildBuilder(action, option);

        public void AddTd(TdBuilder tdBuilder)
            => AppendInnerHtml(tdBuilder);

        public void AddTd(Action<TdBuilder> action)
            => AppendInnerHtml(action);

        public void AddTh(ThBuilder thBuilder)
            => AppendInnerHtml(thBuilder);

        public void AddTh(Action<ThBuilder> action)
            => AppendInnerHtml(action);
    }
}
