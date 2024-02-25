using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders
{
    public class SubBuilder : HtmlBuilderBase
    {
        protected SubBuilder() : base(HtmlTag.sub , IndentationOption.Minified)
        {
        }

        public static SubBuilder Build(string text)
        {
            var subBuilder = new SubBuilder();
            subBuilder.AppendInnerHtml(text);
            return subBuilder;
        }
    }
}
