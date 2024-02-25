using WebTruss.HtmlBuilder;

namespace WebTruss.HtmlBuilder.Tests
{
    public class HtmlBuilderTests
    {
        [Fact]
        public void HtmlBuilderShouldBuildHtml()
        {
            var result = HtmlBuilder.Build(head =>
            {
                
            },
            body =>
            {
                body.AddDiv(div =>
                {
                    div.AddDiv(div =>
                    {

                    });

                    div.AddDiv(div =>
                    {
                        div.AddDiv(div =>
                        {
                            div.AddDiv(div =>
                            {
                                div.AppendText("Hello");
                            });
                        });
                    });
                });

                body.AddDiv(div =>
                {

                });
            });


        }
    }
}
