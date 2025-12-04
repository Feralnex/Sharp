# About
Sharp is a collection of lightweight, reusable C# utilities designed to make everyday coding tasks cleaner, safer, and more expressive.  
This repository provides delegates, constants, extension methods, state abstractions, and helpers that can be easily integrated into any .NET project.

## Features

- **Delegates for safe operations** (`TryHandler`)
- **Constants** for common values and platform specifics
- **Byte array extensions** for inserting/reading primitives
- **Value type extensions** for endianness and byte conversions
- **Number extensions** with SIMD acceleration
- **Decimal extensions** for low‑level decimal manipulation
- **Gate** abstraction for binary state control
- **Pointer helpers** for unsafe memory operations
- **Library loader** for cross‑platform native interop
- **Lazy / ConcurrentLazy** for deferred initialization
- **Maybe / Option** for functional optional values
- **Settings** integration with ASP.NET Core DI

### Delegates.cs
Reusable delegate signatures for "try" operations, following the familiar TryParse pattern.

```csharp
public delegate bool TryHandler<TOutput>(out TOutput? output);
public delegate bool TryHandler<TInput, TOutput>(TInput source, out TOutput? output);
```

### Constants.cs
Centralized constants for bit sizes and platform-specific library naming.

```csharp
public static class Constants
{
    public const int ByteSizeInBits = 8;
    public const string LibraryPrefix = "lib";
    public const string WindowsLibraryExtension = ".dll";
    public const string LinuxLibraryExtension = ".so";
}
```

### Byte array extensions
Helpers for inserting and reading primitive values from byte[].

```csharp
byte[] buffer = new byte[sizeof(short)];
short number = 12345;
buffer.Insert(0, number);
short value = buffer.ToInt16(0);
```

Supports bool, short, int, long, float, double, decimal, nint, nuint, and unsigned variants. Includes safe (Insert, TryInsert, ToXxx, TryToXxx) and unsafe (DangerousInsert, DangerousToXxx) variants, with endianness support.

### Value type extensions
Value type extensions add helpers to primitive types (like int, short, double, etc.) so you can easily convert them to byte arrays and reverse their byte order for endianness handling. They simplify serialization, interop, and binary manipulation.

```csharp
short number = 12345;
byte[] bytes = number.ToBytes(bigEndian: true);
short reversed = number.Reverse();
```

Implemented for bool, Int16, Int32, Int64, UInt16, UInt32, UInt64, Single, Double, Decimal, nint, nuint.

### NumberExtensions.cs
SIMD-accelerated scanning of numeric sequences.

```csharp
int[] numbers = { 1, 1, 1, 2, 1 };
ref int start = ref numbers[0];
int index = start.DangerousIndexOfAnyNumberExcept(1, 0, numbers.Length);
Console.WriteLine(index); // 3
```

Uses Vector128, Vector256, or Vector512 when hardware acceleration is available.

### Gate.cs
Binary state abstraction (Open / Closed) with functional helpers.

```csharp
Gate gate = new Gate();
gate.IfClosed(() => Console.WriteLine("Closed"));
gate.Open();
gate.IfOpen(() => Console.WriteLine("Open"));
```

Supports IfOpen, IfClosed, Match, and TryMatch.

### Pointer.cs
Unsafe pointer-based equivalents of ByteArrayExtensions.

```csharp
unsafe
{
    byte* buffer = stackalloc byte[10];
    short number = 12345;
    Pointer.Insert(buffer, 10, 0, number);
    short value = Pointer.ToInt16(buffer, 10, 0);
}
```

Supports all primitive types with safe/unsafe and endianness variants.

### Library.cs
Cross-platform native library loader with caching.

```csharp
nint addPtr = Library.GetExport("mathlib", "add");
AddDelegate add = Marshal.GetDelegateForFunctionPointer<AddDelegate>(addPtr);
Console.WriteLine(add(2, 3)); // 5
```

Automatically appends .dll (Windows) or lib{name}.so (Linux).

### Lazy.cs / ConcurrentLazy.cs
Custom lazy initialization using Gate.

```csharp
Lazy<int> deferred = new Lazy<int>(() => 99);
Console.WriteLine(deferred.Value); // initializes on first access
```

ConcurrentLazy<T> adds thread-safety for multi-threaded scenarios.

### Maybe.cs / Option.cs
Functional abstraction for optional values.

```csharp
Reference<string> maybeName = "Tomasz";
maybeName.IfSome(name => Console.WriteLine($"Hello, {name}!"));
maybeName.Clear();
maybeName.IfNone(() => Console.WriteLine("No name set."));
```

- Maybe<T> → base abstraction (Some / None)
- Option<T> → mutable, with validation
- Reference<T> → for reference types
- Value<T> → for value types

### Settings.cs
Centralized settings cache with ASP.NET Core DI integration.

```csharp
builder.Services.ConfigureSettings<MySettings>(
    builder.Configuration.GetSection("MySettings")
);

if (Settings.TryGet<MySettings>(out var settings))
{
    Console.WriteLine(settings.SomeProperty);
}
```

- Stores settings keyed by type
- Clears on ProcessExit
- Integrates with IOptions<T> and IServiceCollection