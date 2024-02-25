using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders
{
    public class SpanBuilder : ContainerHtmlBuilder
    {
        protected SpanBuilder(IndentationOption indentationOption) : base(HtmlTag.span, indentationOption)
        {
        }


        public static SpanBuilder Build(Action<SpanBuilder> builderAction, IndentationOption indentationOption = IndentationOption.Minified)
        {
            var spanBuilder = new SpanBuilder(indentationOption);
            builderAction.Invoke(spanBuilder);
            return spanBuilder;
        }



        public static SpanBuilder Build(string text, IndentationOption indentationOption = IndentationOption.Minified)
        {
            var spanBuilder = new SpanBuilder(indentationOption);
            spanBuilder.AppendText(text);
            return spanBuilder;
        }
    }
}
