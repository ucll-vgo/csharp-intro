---
layout: default
---
# Inheritance

Conceptually, inheritance in C# works mostly the same as in Java:
subclasses that override methods in the superclass, etc.
Below, we highlight the small differences between the two languages.

## Inheritance Syntax

Java opted to use a relatively verbose syntax to specify superclasses and
interface implementations:

```java
// Java
class Foo extends Bar implements Baz
{

}
```

C# preferred to keep it short:

```csharp
// C#
class Foo : Bar, IBaz
{

}
```

Note that the superclass has to come first, followed by the interfaces.

## Superconstructor

In Java, the superclass's constructor is called as follows:

```java
// Java
class Foo extends Bar
{
    public Foo()
    {
        super();
    }
}
```

Here, `super()` must come first in the constructor's body, which makes sense:
the subclass "builds on top" of the superclass, meaning that the foundations
have to be build before being able to add something on top of it.

C# enforces this rule by using a syntax that gives the programmer
no choice but to but the call to the superconstructor first:

```csharp
// C#
class Foo : Bar
{
    public Foo() : base()
    {

    }
}
```

C# uses slightly different terminology: the superclass is called the *base class*,
hence the keyword `base`.

## Virtual

In Java, every method is overrideable by default. C# does not agree with this
choice: according to its designers, making a method overrideable
should be a well thought out decision. For this reason,
methods in C# are *not* overrideable by default, except if you
explicitly make them so by adding the `virtual` keyword. This way
you can clearly distinguish between methods that form the core
structure of the class and those that are meant
to be customized in subclasses.

```csharp
public class Foo
{
    public void NonoverrideableMethod() { ... }

    public virtual OverrideableMethod() { ... }
}
```

## Override

Java 1.5 introduced annotations which allow programmers
to "annotate" parts of their code. For example,
it is possible to define an `@author` annotation
that you can add to classes to indicate who wrote it.
This is not a particularly useful application:
the version control system is probably a much better choice
to keep track of who wrote what.

An annotation that comes predefined with Java 1.5
is `@Override`. When attached to a method,
it expresses it is intended to override one of the superclass's methods.

```java
// Java
public class Foo
{
    public void bar() { ... }
    public void qux() { ... }
}

public class extends Foo
{
    @Override
    public void bar() { ... }

    @Override
    public void quks() { ... }
}
```

Thanks to the `@Override` annotation, the compiler can
see that something's wrong with `quks` amd will give
you an error message. Without `@Override`, the compiler
would simply assume you meant to define an extra method, unrelated
to `qux`. While optional in Java, making use of `@Override` is
highly recommended as it lets the compiler catch more bugs.

Java could not make `@Override` mandatory lest all existing code be broken.
However, C# has the luxury of making it mandatory since
this feature has been present since C#'s inception.

```csharp
// C#
public class Foo
{
    public virtual void bar() { ... }
    public virtual void qux() { ... }
}

public class extends Foo
{
    public override void bar() { ... }

    public override void quks() { ... }
}
```

