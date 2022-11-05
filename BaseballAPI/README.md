--apologies if this seems like a lecture. I'm suffering from insomnia. Cut me some slack.

# The What

This is a C# Microservice written in .NET 6. It uses the Web API template. It currently connects to a SQL table, but uses the repository pattern and thus the code can be updated to accomodate other data stores such as Oracle or MongoDB.

Right now the endpoints are returning the same object type as the data context, but this will need to change as we want to return a different object structure than is retrieved from the database.

There is no unit tests project yet but there should be one soon written with NUnit and Moq.

# The Why

## Project Structure

### Controller
Controllers contain our endpoints. UIs and other APIS access our endpoints. Our controllers should be kept small. There should be minimal buisness logic in our controllers. We should simply accept HTTP Requests and return them with an appropriate HTTP Status Code.

- HTTP Status Codes - https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
- HTTP and REST APIs - See https://restfulapi.net/ and https://aws.amazon.com/what-is/restful-api/

### Services
Our service classes contain most of the business logic such as validation or any thing special that might come up.

### Repository
We use a repository interface to 1. mock data for future unit testing and 2. to be able to create new repostories for different data store. This way we can both test without being connected to a live database. Also if the data store changes (say from MS SQL to Oracle or even to a NoSQL database like MongoDB, we can just create a new repo implementing the interface. Our controllers and service classes will not need to change.

We are currently using EF Core to connect to the database.

### What shouldn't be in the project/solution
Views, store procedures, tables, and other database objects should never be part of the microservice project, except as references. You want to make sure that the API is independent of the data store used (as much as possible). This allows greater flexbility.

UI projects should not be in the solution. Use Swagger or Postman to test. An API or microservice is a separate deployable unit than the UI, or whatever else may call this API. You may have hundreds of microservices. They should all be independently deployable and testable.

### Coding standards guideline
This is a guideline not a hard and fast rule. But if you start to have more than 500 lines of code in a single class, it may be time to reevaluate and rethink how you are organizing your class structure. Keep a single class per file. Resist putting multiple classes into a single file.

Don't use fancy new patterns or syntax simply because they are neat or fun or you are trying to impress people. You will end up punishing yourself when you have to look at the code 6 months later. Use code that is as universal and as easy to understand as possible.

### Complex, but not complicated
Classes and methods should be small and easy to read. If a method/function has a lot of code,  or if you find yourself repeating the same code over and over again, consider creating a single method for the code you are repeating. Only repeat code in multipe places if you are doing so for an express purpose. 

Small methods are much easier to unit test. 
See the SOLID principles - https://en.wikipedia.org/wiki/SOLID

### Unit Tests
Unit tests may seem like a lot of pointless work at first. But they can save you a lot of pain and frustration. Good engineers find ways to automate repititive and mudane tasks. If you can automate some of the basic tests of your code, you will be able to find bugs that you didn't even realize.

Also, if you change your code and your tests start to fail, it may be that you just need to update the tests, or it may be that something is wrong and you introduced a bug that you need to fix. Unit tests allow you to do this in a development enviornment, before QA or Prod Support or the business have to ask you why your code failed.

### Thougts on software engineering as a discipline
Software engineering almost has more in common with art than science. There are few rules and absolutes that apply universaly. Different concepts may apply to different situations. In certain situations everything written above may be completely wrong and inappropriate. Apply what you know and you learn to each situation as you deem appropriate. You will often find that many best practices aren't even good practices in certian situations. Good engineers are not too rigid, and know how to adapt. Good software engineers have doubts and ask themselves why. While software engineering can almost be treated as art, there are verifiable results. The end result of the creative process should be something that works and people can use. Essentially be wary of be overly dogmatic, but be willing to learn and demanding of the quality of your work.

### Microsevers, Monoliths
### NoSQL vs SQL/Relational Databases
