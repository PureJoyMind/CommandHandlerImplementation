## What Does It Do?
This project is an implementation of a command handler. You would usually use tools like MediatR for such things but I wanted to understand the underlying system of command handlers a little better. 
### Steps
1. Dynamically searches the assemblies for commands
2. Adds them as a scoped service
3. When asked for a handler, the service finds the requested one and creates a custom scope for it and returns it
