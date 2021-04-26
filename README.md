# ProblemDetails.Helpers [![Build Status](https://dev.azure.com/christianacca/ProblemDetails.Helpers/_apis/build/status/christianacca.ProblemDetails.Helpers?branchName=master)](https://dev.azure.com/christianacca/ProblemDetails.Helpers/_build/latest?definitionId=7&branchName=master)

## Overview

Utility code for working with ProblemDetails.

* [HttpContentExtensions](src/CcAcca.ProblemDetails.Helpers/HttpContentExtensions.cs): extension methods for reading the HTTP content as a `ProblemDetails`
* [HttpResponseMessageExtensions](src/CcAcca.ProblemDetails.Helpers/HttpResponseMessageExtensions.cs): drop-in replacement for `EnsureSuccessStatusCode` that will throw a `ProblemDetailsException`
* [JsonProblemDetailsConverter](src/CcAcca.ProblemDetails.Helpers/JsonProblemDetailsConverter.cs): convenience class for serializing/deserializing `ProblemDetails`
* [ProblemDetailsExtensions](src/CcAcca.ProblemDetails.Helpers/ProblemDetailsExtensions.cs): extension methods for `ProblemDetails`

## Usage

Install package

   ```cmd
   Install-Package CcAcca.ProblemDetails.Helpers
   ```

## Develop

To build and run tests you can use:

* the dotnet cli tool
* any IDE/editor that understands MSBuild eg Visual Studio or Visual Studio Code

### Recommended workflow

* Develop on a feature branch created from master:
  * create a branch from *master*.
  * perform all the code changes into the newly created branch.
  * merge *master* into your branch, then run tests locally (eg `dotnet test tests/CcAcca.ProblemDetails.Helpers.Tests`)
  * on the new branch, bump the version number in [CcAcca.ProblemDetails.Helpers.csproj](src/CcAcca.ProblemDetails.Helpers/CcAcca.ProblemDetails.Helpers.csproj); follow [semver](https://semver.org/)
  * update [CHANGELOG.md](./CHANGELOG.md)
  * raise the PR (pull request) for code review & merge request to master branch.
  * PR will auto trigger a limited CI build (compile and test only)
  * approval of the PR will merge your branch code changes into the *master*

## CI server

[Azure Devops](https://dev.azure.com/christianacca/ProblemDetails.Helpers) is used to run the dotnet cli tool to perform the build and test. See the [yaml build definition](azure-pipelines.yml) for details.

Notes:

* The CI build is configured to run on every commit to any branch
* PR completion to master will also publish the nuget package for CcAcca.ProblemDetails.Helpers to [Nuget gallery](https://www.nuget.org/packages/CcAcca.ProblemDetails.Helpers/)
