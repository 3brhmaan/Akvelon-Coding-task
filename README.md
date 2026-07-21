# FizzBuzz Detector

## Overview

Implements `FizzBuzzDetector.getOverlappings(string input)`, which replaces every
3rd alphanumeric word with "Fizz", every 5th with "Buzz", and every 15th with
"FizzBuzz" (both conditions), returning a `FizzBuzzResult` with the transformed
string and count of replaced words.

## Requirements

- .NET 8.0 SDK
- Visual Studio 2022 (or `dotnet` CLI)

## Project structure

- `src/` — console application containing `FizzBuzzDetector`
- `tests/` — xUnit test project (7 tests covering the spec example, boundary
  conditions, null input, invalid length, punctuation handling, and
  alphanumeric words)

## How to build and run

```bash
dotnet build
dotnet run --project src
```

## How to run tests

```bash
dotnet test tests
```
