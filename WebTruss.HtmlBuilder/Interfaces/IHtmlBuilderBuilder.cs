namespace WebTruss.HtmlBuilder.Interfaces
{
    public interface IHtmlBuilderBuilder<T> where T : HtmlBuilderBase
    {
        public abstract static T Build(Action<T> action);
        public abstract static T Build(IndentationOption option, Action<T> action);
    }
}