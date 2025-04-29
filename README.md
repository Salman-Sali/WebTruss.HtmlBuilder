# WebTruss.HtmlBuilder
 A C# HTML Builder Library
 Unfinished. Probably will not pick it up again.

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
