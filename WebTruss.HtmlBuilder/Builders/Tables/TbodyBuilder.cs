using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class TbodyBuilder : HtmlBuilderBase, IHtmlBuilderBuilder<TbodyBuilder>
    {
        protected TbodyBuilder(IndentationOption indentationOption) : base(HtmlTag.tbody, indentationOption)
        {
        }

        public static TbodyBuilder Build(Action<TbodyBuilder> action)
            => BuildBuilder(action);

        public static TbodyBuilder Build(IndentationOption option, Action<TbodyBuilder> action)
            => BuildBuilder(action, option);

        public void AddTr(Action<TrBuilder> action)
            => AppendInnerHtml(action);

        public void AddTr(TrBuilder trBuilder)
            => AppendInnerHtml(trBuilder);
    }
}
