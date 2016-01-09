# TangyFruitMapper
An simple, old school solve it with plain code approach to mapping a Model object to a Dto object using code generation.

##Overview
Tangy Fruit Mapper generates mappers to map to and from [DTO](https://en.wikipedia.org/wiki/Data_transfer_object) objects. It works best by following as closely as possible to a few conventions.  The better the conventions are following the easier things will be.

The code generator is not designed to be generating code in your project on every build (although you can do that), rather the idea is to generate the code as needed and keep it. Possibly just generate it once, let the generator do the donkey work and then treat the generated code as a full class in your project.

##Why?
I'm a long time user of (AutoMapper)[http://automapper.org/], and its a fantastic tool with an extremely rich feature set.  Its also very flexible, which unfortunately leads to complexity.  In some of my projects I got tired of coming back to some mapping code I wrote some months or years ago and spending hours and days sometimes remembering how it works and debugging issues.  I often thought the cost of debugging and 'come-back' time outweighed the initial code implementation cost. "Wouldn't this be easier to maintain just with plain old code?".

Tangy Fruit Mapper was born.  Rather than write many mappers that are inconsistent and often are straighforward, let a generator write those parts for you. The result is still plain, simple, old-school code. All this adds up to low cost of ownership.

##The Conventions
1.  DTO's must only use public getters and setters.
2.  Property names must use Pascal casing with no underscores.
4.  Class names must be unique. No two classes can have the same class-name regardless of namespace.
5.  Only writeable properties (properties with a setter) will be assigned a value, these can be any accessibility.
  5. Properties with no setter will not be set even if a backing field is available.
6.  Any property that cannot be matched will produce a comment and a todo in the generated code.
7.  All DTO's and Models should have a default constructor either public or internal.
8.  All DTO collections must be List<T>.
9.  Dictionaries are currently not supported.

##Examples
See the unit test project for examples and how-tos.  All unit tests are real usage scenarios.

Feedback and contributions welcome.
