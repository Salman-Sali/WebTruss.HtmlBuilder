using WebTruss.HtmlBuilder.Builders;
using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder
{
    public class HtmlBuilder : HtmlBuilderBase
    {
        private HtmlBuilder(IndentationOption indentationOption) : base(HtmlTag.html, indentationOption)
        {
        }
        
        public static string Build(Action<HeadBuilder> headAction, Action<BodyBuilder> bodyAction)
        {
            return Build(IndentationOption.Minified, headAction, bodyAction);
        }

        public static string Build(IndentationOption indentationOption, Action<HeadBuilder> headerAction, Action<BodyBuilder> bodyAction)
        {
            var htmlBuilder = new HtmlBuilder(indentationOption);
            htmlBuilder.AppendInnerHtml(headerAction);
            htmlBuilder.AppendInnerHtml(bodyAction);
            return htmlBuilder.Build();
        }
    }
}
