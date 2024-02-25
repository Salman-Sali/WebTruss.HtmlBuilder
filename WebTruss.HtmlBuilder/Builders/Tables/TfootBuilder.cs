using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class TfootBuilder : HtmlBuilderBase, IHtmlBuilderBuilder<TfootBuilder>
    {
        protected TfootBuilder(IndentationOption indentationOption) : base(HtmlTag.tfoot, indentationOption)
        {
        }

        public static TfootBuilder Build(Action<TfootBuilder> action)
            => BuildBuilder(action);

        public static TfootBuilder Build(IndentationOption option, Action<TfootBuilder> action)
            => BuildBuilder(action, option);

        public void AddTr(Action<TrBuilder> action) 
            => AppendInnerHtml(action);
    }
}
