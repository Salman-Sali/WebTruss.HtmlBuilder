# WebTruss.HtmlBuilder
 A C# HTML Builder Library

```csharp
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
```
