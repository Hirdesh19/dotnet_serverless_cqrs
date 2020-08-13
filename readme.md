# Serverless CQRS

# .NET Core 3.1 – AWS Serverless Lambda

# Warm-up

* __What is Serverless?__
  * Serverless computing is a method of providing backend services on an as\-used basis\.  Typical offerings allow for amazing scaling for a fraction of the cost\.
* __Why AWS Lambda for Serverless?__
  * Let me be frank\, it is a preference now\.  Azure and Google Cloud Platform are perfectly fine and acceptable \(GCP doesn’t support\.net\)

* __What is CQRS?__
  * Command and Query Responsibility Segregation\.  Solves the problem of over\-complicating models

# When (or not) to use Serverless

Pros

Cons

* __Heavy Processing__
  * If you are running some genome calculations\, don’t use serverless\!
    * Although\, triggering through serverless is fine\!  Imagine spinning up those hunk vertical scaled machines only when needed via some trigger that YOU control\.
* __Long Runtimes__
  * There are limits to serverless\, similar problem above

* __Typically easy deployment__
  * In any cloud offering\, serverless is getting easy to deploy
* __Cost__
  * Typically much cheaper than dedicated hardware running when not needed
* __Cool Factor__
  * It is just cool to say\!

# When (or not) to use CQRS

Pros

Cons

* Too simple
  * This is for complicated systems\.
    * If your problem set is simple\, do the easiest solution\!
* Simple CRUD is sufficient
  * Again\, don’t over\-complicate things just because you can

* Collaborative domains
  * users access data in parallel
* Task\-based user interfaces
  * users are guided through complex processes
  * Think some complicated wizard
* Performance needs
  * Read times need to differ from writes
* Team separation
  * Separate responsibilities from reading and writing
* Easier Evolution and Integration

# Some Prerequisites

* Obviously have \.netcore 3\.1 \(sdket\. al\.\) installed
* Get the AWS Toolkit
  * AWS Toolkit for Visual Studio
  * AWS Toolkit for Visual Studio Code
* Some RDMS \(for this example I am using MySQL\)
* Drink Coffee
* Start Coding\!
