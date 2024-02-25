using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class TdBuilder : ContainerHtmlBuilder, IHtmlBuilderBuilder<TdBuilder>
    {
        protected TdBuilder(IndentationOption indentationOption) : base(HtmlTag.td, indentationOption)
        {
        }

        public static TdBuilder Build(Action<TdBuilder> action)
            => BuildBuilder(action);

        public static TdBuilder Build(IndentationOption option, Action<TdBuilder> action)
            => BuildBuilder(action, option);
    }
}
