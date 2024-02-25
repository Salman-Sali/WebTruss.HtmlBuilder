using WebTruss.HtmlBuilder.Enums;
using WebTruss.HtmlBuilder.Interfaces;

namespace WebTruss.HtmlBuilder.Builders
{
    public class DivBuilder : ContainerHtmlBuilder
    {
        private DivBuilder(IndentationOption indentationOption) : base(HtmlTag.div, indentationOption)
        {
        }

        public static DivBuilder Build(Action<DivBuilder> builderAction)
        {
            return Build(IndentationOption.Minified, builderAction);
        }

        public static DivBuilder Build(IndentationOption indentationOption, Action<DivBuilder> divBuilderAction)
        {
            var divBuilder = new DivBuilder(indentationOption);
            divBuilderAction.Invoke(divBuilder);
            return divBuilder;
        }
    }
}
