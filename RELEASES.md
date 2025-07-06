README: https://github.com/mshimshon/CoreMap

# v0.9.5 (Initial Release)
- **Synchronous object-to-object mapping** with minimal overhead  
- **Dependency Injection friendly**: register and resolve mappers via DI containers  
- **Support for custom mapping handlers** with full control over conversion logic  
- **Nested mapping support** (e.g., mapping child objects via injected mappers)  
- **Mapping collections**: easily map `IEnumerable<TSource>` to `ICollection<TDest>`  
- **Clear separation of mapping concerns** through `ICoreMapHandler<TSource, TDest>` interfaces  
- **Designed for extensibility**: add or override mapping handlers easily  
- **No runtime reflection or dynamic code generation** — fully explicit and testable  
- **Lightweight and performant**: suitable for enterprise and high-throughput scenarios  
- **Compatibility** with .NET Standard/.NET 6+ environments