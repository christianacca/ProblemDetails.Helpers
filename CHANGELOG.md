# Changelog

All notable changes to this project will be documented in this file.

## [2.3.1] - 2021-09-27

### Fixed

- `HttpClientJsonExtensions`: `EnsurePatchJsonAsync` default serialization options should ignore null values

## [2.3.0] - 2021-09-23

### Added

- `HttpClientJsonExtensions`: new `EnsurePatchJsonAsync` overloads

## [2.2.0] - 2021-07-15

### Added

- `HttpClientJsonExtensions`: new `EnsureSendAsync` overloads

### Fixed

- `HttpClientJsonExtensions`: ambiguous overloads

## [2.1.0] - 2021-07-11

### Added

- `HttpClientJsonExtensions`: new non-generic overloads
- `HttpClientJsonExtensions`: new `EnsureSendAsync` extension method

## [2.0.1] - 2021-07-11

### Refactor

- simplify overloads that accept `CancellationToken`

### Fixed

- `HttpClientJsonExtensions`: avoid ambiguous reference with System.Net.Http.Json methods + ensure disposal of failed response
- `HttpClientJsonExtensions`: ensure disposal of failed response

## [2.0.0] - 2021-07-10

### Added

- Support `CancellationToken` on any async method
- New `HttpClient` Get,Put,Post,Delete extension methods inspired by System.Net.Http.Json

### Fixed

- should use `ConfigureAwait(false)` on any async method
- `EnsureNotProblemDetailAsync`: the `Content` on a problematic response should be disposed

## [1.0.4] - 2021-05-05

### Fixed

- `IsProblemDetail` throws when no ContentType header

## [1.0.2] - 2021-04-27

### Fixed

- `EnsureNotProblemDetailAsync` should use configured casing for CorrelationId key name
- `ReadAsProblemDetailsAsync` should fallback to a ProblemDetails rather than throwing

## [1.0.0] - 2021-04-27

### Added

- Initial release
