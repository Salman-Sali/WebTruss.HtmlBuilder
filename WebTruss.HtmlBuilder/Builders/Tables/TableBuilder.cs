using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class TableBuilder : HtmlBuilderBase, IHtmlBuilderBuilder<TableBuilder>
    {
        protected TableBuilder(IndentationOption indentationOption) : base(HtmlTag.table, indentationOption)
        {
        }

        //caption
        //colgroup
        
        public void AddThead(Action<TheadBuilder> action)
            => AppendInnerHtml(action);

        public void AddThead(TheadBuilder thead)
            => AppendInnerHtml(thead);

        public void AddTbody(Action<TbodyBuilder> action) 
            => AppendInnerHtml(action);

        public void AddTbody(TbodyBuilder tbody)
            => AppendInnerHtml(tbody);

        public void AddTr(Action<TrBuilder> action)
            => AppendInnerHtml(action);

        public void AddTfoot(Action<TfootBuilder> action)
            => AppendInnerHtml(action);

        public void AddTfoot(TfootBuilder tfoot)
            => AppendInnerHtml(tfoot);

        public static TableBuilder Build(Action<TableBuilder> action)
            => BuildBuilder(action);

        public static TableBuilder Build(IndentationOption option, Action<TableBuilder> action)
            => BuildBuilder(action, option);
    }
}