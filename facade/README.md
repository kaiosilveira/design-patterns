# Facade

The facade pattern provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.

## Working example

As our working example, we're going to implement a Home Theater application with classes that represents various commonly used devices in this space, such as a DVD player and a projector. Our facade, in this example, will be responsible for encapsulating all the complexity in setting up those devices to watch a movie, which otherwise would be daunting because of the number of devices. Make sure to check out [HomeTheater](./HomeTheater/) for the full implementation details.
