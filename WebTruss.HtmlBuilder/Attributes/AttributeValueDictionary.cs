namespace WebTruss.HtmlBuilder.Attributes
{
    public class AttributeValueDictionary
    {
        public List<AttributeValue> Attributes { get; set; } = new();

        public void SetAttribute(string name, string? value)
        {
            var attribute = Attributes.FirstOrDefault(x => x.Name == name);
            if (attribute == null && !string.IsNullOrEmpty(value))
            {
                attribute = new AttributeValue(name, value);
                Attributes.Add(attribute);
            }
            else if (attribute != null)
            {
                if (string.IsNullOrEmpty(value))
                {
                    Attributes.Remove(attribute);
                }
                else
                {
                    attribute.Value = value;
                }
            }
        }
        public void SetAttribute(Enum name, string value)
        {
            string _name = GetEnumString(name);
            SetAttribute(_name, value);
        }

        private string GetEnumString(Enum value)
        {
            return string.Join("-",
                value.ToString().Split("_").Where(x => !string.IsNullOrEmpty(x))); ;
        }

        public void SetAttribute(Enum name, Enum value)
        {
            string _name = GetEnumString(name);
            string _value = GetEnumString(value);
            SetAttribute(_name, _value);
        }

        public AttributeValue? GetAttribute(string name)
        {
            return Attributes.FirstOrDefault(x => x.Name == name);
        }
    }
}
