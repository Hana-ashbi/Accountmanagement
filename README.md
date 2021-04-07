# Accountmanagement

...What is this about?...

This project is to build an API to be used for opening a new “current account” of already existing customers.

...How is it built?...

The project is using onion architecture to separate the layers, CQRS for separating read/write and Mediator pattern using MediatR library.
The solution is made up from 2 services with one presentation layer and shared project.
The structure for each service is the following:
- Core (application / domain)
- Infrastructure (persistence)

...But there is more into it...

Communication between services (Account & Transaction) is made via Http calls.
Persistence layer is using entity framework (in memory under the file names "dependencyInjection.cs").
The users can be seeded in the class Seed [Account.Persistence/Context/Seed.cs] at the moment one user is seeded with id="1"
The swagger was added to provide a UI to test all the api calls.
Incase swagger isn't working, adding it to WebAPI Project properties under build/output/xml document file add: 'AccountManager.xml'




