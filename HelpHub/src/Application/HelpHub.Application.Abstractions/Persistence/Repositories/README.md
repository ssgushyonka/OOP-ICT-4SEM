Folder for defining repository interfaces.

For query methods use `IAsyncEnumerable<>` return type.

```csharp
IAsyncEnumerable<Entity> QueryAsync(EntityQuery query, CancellationToken cancellationToken);
```