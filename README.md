# DesignPatterns.Prototype
This is a demonstration from my DesignPattern series.

I could not think of a real example where I'd use Prototype in C#, so I just went with a small example.
Here we have an User object, containg a Role.

When you need to create a copy of an object, you might be tempted to use MemberwiseClone() from IClonable.
However, this approach will only create a shallow copy of it. In this specific case, a User Clone will reference the same Role as the Original User.

The solution is offered by Prototype pattern. Which will basically entirely recreate the object you need, with no strings attached (see what I did there?).
In this example I used JSON serialization and deserialization to achieve Deep Cloning. However, there are more ways to do this.
