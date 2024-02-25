using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders
{
    public class SupBuilder : HtmlBuilderBase
    {
        protected SupBuilder() : base(HtmlTag.sup, IndentationOption.Minified)
        {
        }

        public static SupBuilder Build(string text)
        {
            var supBuilder = new SupBuilder();
            supBuilder.AppendTextToHtml(text);
            return supBuilder;
        }
    }
}
