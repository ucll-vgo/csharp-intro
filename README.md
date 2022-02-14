# Introduction

This repo contains a quick introduction to C#.
Proceed as follows:

* Clone this repository. You'll need it to make the exercises.Cancel changes
* Let yourself be guided by the [companion text](https://ucll-vgo.github.io/csharp-intro/). *Make sure to follow it!* It contains valuable information to solve the exercises.

## User's Guide

* To start working on an exercise, open the `.sln` file in the exercise's directory.
* To run the tests, open the Test Explorer (under the Test > Windows menu).

## Problems with .NET Versions

.NET constantly evolves and new versions come out every year.
Students who install Visual Studio now typically only get the latest version, whereas the exercises use an older version.
If you encounter errors regarding missing SDKs, here's how to solve them:

* In the Solution Explorer, right click on the project.
* Select Properties.
* Change the target framework to something you have installed.
  Typically, the version at the very top will work.

## Running Tests Without Visual Studio

* Make sure you have the [].NET CLI](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) installed
* Inside the exercise's directory, write `dotnet test`.