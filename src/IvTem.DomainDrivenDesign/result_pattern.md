# Result Pattern — Design Requisites

This document defines the requisites for implementing a custom `Result` pattern in C#. The goal is to model success and failure outcomes in a clear, type-safe way, suitable for both synchronous and asynchronous operations, with a future path for API integration.

---

## 🌟 Purpose

Provide a lightweight, expressive pattern to:

- Replace exception-driven control flow with explicit error handling
- Improve clarity in **Domain Logic**
- Support fluent handling in **Asynchronous Operations**
- Allow future **API Controller integration** via extension methods

---

## 🧱 Type Hierarchy

### 1. `Result` (Non-Generic)

- Represents a success or failure for operations that do **not return data**
- Stores:
  - `Error? Error`
- No value is returned on success

### 2. `Result<T>` (Generic)

- Represents a success with a `T` value or a failure with an `Error`
- Stores:
  - `T? Data` (nullable, only set on success)
  - `Error? Error` (only set on failure)
- Direct access to `Data` and `Error` discouraged — enforced via extensions

---

## 🧹 Error Model

### `Error` (Base Class)

- Properties:
  - `string ErrorMessage`
  - `string ErrorCode`
- Designed for inheritance:
  - Example subclasses: `ExceptionError`, `ValidationError`, `AggregatedError`
- Extensible to store:
  - Exception details
  - Multiple validation errors
  - Metadata for error categorization

---

## 🔧 Extension Methods

### 1. Safe Access to Result Content

```csharp
public static bool IsSuccess<T>(
    this Result<T> result,
    [NotNullWhen(true)] out T? data,
    [NotNullWhen(false)] out Error? error
)
```

- Returns `true` if result is successful
- Populates `data` or `error` accordingly
- Prevents unsafe access to internal fields

### 2. Error Propagation Between Results

```csharp
public static Result<TTarget> PropagateError<TSource, TTarget>(this Result<TSource> source)
```

- Allows forwarding the error of one result into a result of a different type
- Useful when chaining operations that return different result types

---

## 🧠 Construction API

Static factory methods will be used to instantiate results:

```csharp
Result.Success();
Result.Failure(Error error);

Result<T>.Success(T data);
Result<T>.Failure(Error error);
```

---

## ⚙️ Async Compatibility

Design will support use with async methods:

```csharp
Task<Result> SomeVoidOperationAsync();
Task<Result<T>> SomeOperationReturningTAsync();
```

Optionally:

- Future `TryAsync(Func<Task<T>>)` helper
- Compose results with `Match`, `Bind`, `Map` in future phases

---

## 🚫 What’s Explicitly Out of Scope (for now)

- Implicit conversions between `T` and `Result<T>`
- LINQ-style support (`Select`, `Where`)
- Built-in logging or localization
- Direct serialization of the result types (can be added later)

---

## ✅ Summary

| Feature                        | Status    |
| ------------------------------ | --------- |
| Generic and non-generic Result | ✅ Planned |
| Safe extension-based access    | ✅ Planned |
| Extensible Error object        | ✅ Planned |
| Async-friendly design          | ✅ Planned |
| API Controller integration     | 🔜 Future |
| Error propagation support      | ✅ Planned |

---

## 📌 Next Steps

- Implement core types: `Result`, `Result<T>`, `Error`
- Add key extensions for access and propagation
- Unit test base behaviors
- Evaluate extension for API integration

