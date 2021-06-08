# Clean-API-Tests
Example project illustrating an approach to writing API/component tests in .NET 5. Using this approach, all logic within an API can be automatically tested, injecting fakes where appropriate. In this specific example, a suite of tests is run against an API using fake authentication as well as fake repositories to avoid any dependency against data storage. For more details, see the tests under `CleanTestsApiExample\CleanTestsApiExample.Tests\ComponentTests\Tests`.

## Prerequisites

Requires .NET 5 to be installed: https://dotnet.microsoft.com/download/dotnet/5.0.

## Running the tests

### Within an IDE

In an IDE such as Visual Studio, simply build the solution and run all tests using the built-in test runner.

### Command line

Run `dotnet test` in the repository root folder.
