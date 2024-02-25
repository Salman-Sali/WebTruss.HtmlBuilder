using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders
{
    //Heh
    public class BodyBuilder : ContainerHtmlBuilder
    {
        private BodyBuilder(IndentationOption indentationOption) : base(HtmlTag.body, indentationOption)
        {
        }
    }
}
