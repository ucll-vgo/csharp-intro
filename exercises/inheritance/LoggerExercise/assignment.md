# Assignment

While writing code, it's often practical to keep logs
of what you're doing. When something goes wrong,
you can check them to see what went wrong;
it can give you a starting point for debugging.

For this exercise, you'll implement a number of `Logger` classes.
A logger is in essence a very simple thing:
it's an object you can send `string` messages to using a `Log` method.
What a `Logger` does with this message depends on the actual
type of logger. You can imagine the following loggers would exist:

* A logger that writes all messages to a log file.
* A logger that sends all messages to a GUI window.
* A logger that sends all messages over a network connection.

Create the following class hierarchy:

* Abstract superclass `Logger`
* `StreamLogger` subclasses `Logger`
* `FileLogger` subclasses `StreamLogger`
* `NullLogger` subclasses `Logger`
* `LogBroadcaster` subclasses `Logger`

## Logger

`Logger` defines two methods:

* An abstract `void Log(string message)`.
* An overrideable method `Close()`. In `Logger`, this method is empty.

## NullLogger

The `NullLogger` does absolutely nothing with the given message.
Having such a class is often very useful. In our case,
we can rely on `NullLogger` in case we are not interested
in the log messages.

## StreamLogger

A `StreamLogger` is initialized with a `StreamWriter` (which is part
of the .NET standard library). Every time a message reaches the
`StreamLogger`, it passes it along to the `StreamWriter`.

* You might need to flush... (Google is your friend)

## FileLogger

A `FileLogger` is a specialized version of the `StreamLogger`:
it assumes the stream the `StreamWriter` writes to, is a file.

This class is a bit trickier to implement:

* Have the constructor accept a `FileStream` (existing type.)
* Create a static factory method `Create` that accepts a `string filename` parameter,
  opens a file (`File.OpenWrite`) and uses the returned `FileStream` to create
  a `FileLogger` object.
* Have the `Close()` method call `Close` on the `FileStream` object.

## LogBroadcaster

A `LogBroadcaster` is useful when you have multiple logs, e.g.,
you want messages written both to file and shown on screen.
A `LogBroadcaster` is initialized with a `List<Logger>`.
Whenever it receives a messages, it passes it along
to all `Logger`s in the list.
