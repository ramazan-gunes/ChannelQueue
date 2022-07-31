
# Basic Using Channels In C# .NET
Contains a simple example of the .net channel system.

# What Are Channels?
At it’s heart, a Channel is essentially a new collection type in .NET that acts very much like the existing Queue<T> type (And it’s siblings like ConcurrentQueue), but with additional benefits. The problem I found when really trying to research the subject is that many existing external queuing technologies (IBM MQ, Rabbit MQ etc) have a concept of a “channel” and they range from describing it as a completely abstract thought process vs being an actual physical type in their system.

Now maybe I’m completely off base here, but if you think about a Channel in .NET as simply being a Queue with additional logic around it to allow it to wait on new messages, tell the producer to hold up because the queue is getting large and the consumer can’t keep up, and great threadsafe support, I think it’s hard to go wrong.

Now I mentioned a bit of a keyword there, Producer/Consumer. You might have heard of this before and it’s sibling Pub/Sub. They are not interchangeable.

Pub/Sub describes that act of someone publishing a message, and one or many “subscribers” listening into that message and acting on it. There is no distributing of load because as you add subscribers, they essentially get a copy of the same messages as everyone else.