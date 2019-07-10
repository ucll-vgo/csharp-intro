---
layout: default
---
# Events

## Problem Statement

The [Observer design pattern](https://en.wikipedia.org/wiki/Observer_pattern) is
one of the most common one patterns in software development. For those who've
forgotten about it, its purpose is to make an object "observable", i.e.,
that one can be notified of and react to changes.

Take for example the file system. A simplified `FileSystem` class could look as follows:

```csharp
public class FileSystem
{
    public List<string> GetDirectoryContents(string directory);
    public void CreateFile(string path);
    public void DeleteFile(string path);
    public void WriteToFile(string path, string contents);
    public string ReadFile(string path);
}
```

Say we are writing an application that is interested in being
notified of all changes to the file system. For example:

* A virus scanner would like to know when files are written to, so that
  it can check the data does not contain anything suspicious.
* Cloud storage services such as OneDrive or DropBox need
  to know when any changes are made to the file system in order
  to be able to keep the online versions synchronized.

Writing such an application relying solely on the functionality
`FileSystem` currently provides is bound to be quite inefficient:
the only way to know whether a new file
has been created is to routinely call `GetDirectoryContents`:

```csharp
void WaitForNewFile(FileSystem fs, string directory)
{
    var oldList = fs.GetDirectoryContents(directory);

    while ( true )
    {
        var newList = fs.GetDirectoryContents(directory);

        if ( newList.Count > oldList.Count )
        {
            return;
        }

        oldList = newList;
    }
}
```

To put succinctly, the problem we are trying to solve
is: "We want to take certain actions whenever
a specific event occurs. How do we achieve this efficiently?"

## Observer Design Pattern

Let's extend `FileSystem` such that detecting
changes can be done more efficiently.
For the sake of simplicity,
let's focus solely on detecting the
creation of new files.

Instead of us having to repeatedly call `GetDirectoryContents`,
we'd like to turn things around and have `FileSystem` to
call us whenever a new file has been created.
We want to give `FileSystem` a bit of code that it should
execute on file creation. Conceptually, it would look something like this:

```csharp
// Pseudocode!
public void OnFileCreated(string path)
{
    Console.WriteLine("A new file has been created at " + path);
}

FileSystem fs;
fs.CallOnFileCreation(OnFileCreated);
```

This code should cause `A new file has been created at ...` to be printed
whenever a new file is created. Let's first implement it the "manual" way,
as one would do in Java.

```csharp
public interface IFileCreationObserver
{
    void OnFileCreated(string path);
}

public class FileSystem
{
    // Field to store the file creation observer
    private IFileCreationObserver fileCreationObserver;

    public void CreateFile(string path)
    {
        // ...

        // Notify the observer, if it exists
        fileCreationObserver?.OnFileCreated(path);
    }

    public void CallOnFileCreation(IFileCreationObserver observer)
    {
        // Store observer in field
        this.fileCreationObserver = observer;
    }

    // ...
}
```

Relying on this new functionality can be done as follows:

```csharp
public class FileCreationPrinter : IFileCreationObserver
{
    public void OnFileCreated(string path)
    {
        Console.WriteLine("A new file has been created at " + path);
    }
}

var fs = new FileSystem();
fs.CallOnFileCreation( new FileCreationPrinter() );
```

Make sure you understand the above code:

* `FileSystem`'s newest addition, `CallOnFileCreation`, takes
  an object which must have a method `OnFileCreated`.
  `FileSystem` will call this method every time a file is created.
* We define `FileCreationPrinter` whose `OnFileCreated` simply
  prints a message. We pass this object to `FileSystem`.

## C# Events

The Observer Pattern is *one* solution to the problem stated above.
One could say it is a bit clumsy:

* We want to give `FileSystem` a series of instructions to execute whenever
  a file is created.
* However, we can't just "take" instructions and pass them along.
  Instead, we need to bundle instructions together and put them in
  what is typically a *function*.
* However, in languages such as Java, there are no such things as functions.
  The closest thing to a function is a method.
* Ok, let's put our instructions in a method then.
  But a method must be part of an object...
* And in order to be able to create this object, we need a class.
* Lastly, we also need this class to implement an interface
  so that the compiler can typecheck everything.

You can see there's quite a gap between the idea of "passing a bunch of instructions"
on the one hand, and the implementation consisting of an object, class and interface
on the other. Now imagine that we also need to be notified of file deletion,
writes, and so on: the prospect of having to create all these additional interfaces,
classes and objects is not an enchanting one.

Given that the need for this Observer functionality is quite common,
the C# designers decided to have the language support it directly.

Let's update `FileSystem` so that it makes use of these events:

```csharp
public class FileSystem
{
    public void CreateFile(string path)
    {
        // ...

        // Signals the event OnFileCreated occurred
        FileCreated?.Invoke(path);
    }

    public event Action<string> FileCreated;
}

// Usage:
public void PrintCreatedFile(string path)
{
    Console.WriteLine("File created!");
}

var fs = new FileSystem();
fs.FileCreated += PrintCreatedFile;
```

* `FileSystem` has welcomed a new member: the event `FileCreated`.
  In essence, an event can be seen as a *list of functions*:
  whenever the event occurs, all functions in this list get called.
* The type `Action<string>` describes what kind of function
  can be added to the event. In this case, we want
  functions to have a single parameter of type `string`. If more parameters
  are needed, we can easily add them to the type, e.g., `Action<string, int, double>`.
  The functions are required to have return type `void`.
* The code that needs to be executed whenever a file is created
  can be put in a method, here `PrintCreatedFile`. Notice how
  it satisfies `Action<string>`: single `string` parameter, `void` return type.
  This method is added to the event using `fs.FileCreated += PrintCreatedFile`.

## Summary

```csharp
// Defining event
public event Action<T1, T2, ...> EventName;

// Raising the event (calling all functions in the list)
EventName?.Invoke(arg1, arg2, ...);

// Adding function to event list
EventName += MethodName;
```

## More Information

* [Events](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/index)
