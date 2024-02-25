using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders.Tables
{
    public class ThBuilder : ContainerHtmlBuilder, IHtmlBuilderBuilder<ThBuilder>
    {
        protected ThBuilder(IndentationOption indentationOption) : base(HtmlTag.th, indentationOption)
        {
        }

        public static ThBuilder Build(Action<ThBuilder> action)
            => BuildBuilder(action);

        public static ThBuilder Build(IndentationOption option, Action<ThBuilder> action)
            => BuildBuilder(action, option);
    }
}
