namespace WebTruss.HtmlBuilder.Attributes
{
    public class AttributeValue
    {
        public AttributeValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
