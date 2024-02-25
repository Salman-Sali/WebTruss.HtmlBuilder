using WebTruss.HtmlBuilder.Enums;

namespace WebTruss.HtmlBuilder.Builders
{
    public class CommentBuilder : HtmlBuilderWithText
    {
        protected CommentBuilder(IndentationOption indentationOption) : base(HtmlTag.HtmlBuilderCustom, indentationOption)
        {
            IsSelfClosing = true;
            TagStart = "<!-- ";
            TagEnd = " -->";
        }

        public static CommentBuilder Build(string comment)
        {
            return Build(_comment =>
            {
                _comment.AppendText(comment);
            });
        }

        public static CommentBuilder Build(Action<CommentBuilder> action)
        {
            return Build(IndentationOption.Minified, action);
        }

        public static CommentBuilder Build(IndentationOption indentationOption, Action<CommentBuilder> action)
        {
            var builder = new CommentBuilder(indentationOption);
            action.Invoke(builder);
            return builder;
        }
    }
}
