using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder
{
    public class HtmlBuilderWithText : HtmlBuilderBase
    {
        protected HtmlBuilderWithText(HtmlTag htmlTag, IndentationOption indentationOption) : base(htmlTag, indentationOption)
        {
        }

        public void AppendText(string text)
        {
            base.AppendTextToHtml(text);
        }

        public void AppendNewLineText(string text)
        {
            base.AppendTextToHtml($"\n{text}");
        }

        public void PrependText(string text)
        {
            base.PrependTextToHtml(text);
        }

        public void PrependNewLineText(string text)
        {
            base.PrependTextToHtml($"{text}\n");
        }
    }
}
