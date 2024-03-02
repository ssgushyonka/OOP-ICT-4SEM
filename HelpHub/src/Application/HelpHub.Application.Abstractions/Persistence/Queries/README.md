Folder for repository queries.

Use `record`s for defining query types. Add `[GenerateBuilder]` attribute for source generator to generate builder class for this query.

## Sample

```csharp
[GenerateBuilder]
public sealed partial record Query(Guid[] Ids); 
```

```csharp
var query = Query.Build(x => x.WithId(Guid.NewGuid()));
```