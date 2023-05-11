# Claims Are Us - Claims Management

## Requirements

* The output must be in json format
* We need an endpoint that will give me a single company. We need a property to be returned that will tell us if the company has an active insurance policy
* We need an endpoint that will give me a list of claims for one company
* We need an endpoint that will give me the details of one claim. We need a property to be returned that tells us how old the claim is in days
* We need an endpoint that will allow us to update a claim
* We need at least one unit test to be created

```
CREATE TABLE Claims
(
	UCR VARCHAR(20),
	CompanyId INT,
	ClaimDate DATETIME,
	LossDate DATETIME,
	[Assured Name] VARCHAR(100),
	[Incurred Loss] DECIMAL(15,2),
	Closed BIT
)
```

```
CREATE TABLE ClaimType
(
	Id INT,
	Name VARCHAR(20)
)
```

```
CREATE TABLE Company
(
	Id INT,
	Name VARCHAR(200),
	Address1 VARCHAR(100),
	Address2 VARCHAR(100),
	Address3 VARCHAR(100),
	Postcode VARCHAR(20),
	Country VARCHAR(50),
	Active BIT,
	InsuranceEndDate DATETIME
)
```

## Thoughts on requirements

- Obvious ommission of linking (many to one) from Claims table to ClaimsType
  - Plan to implement as is. Code to enable the linkage described above is there but commented out
  - Ids and Navigation properties also commented out to stop EF conventions from taking over
  
# Plan

- Latest version of .net (currently 7)
  - Full controllers instead of minimal API. I'm an old man.
- Vertical slices
  - All features defined in their own directory and all supporting elements of that feature (code, DTO, validation, etc there along side each other)
  - Adopt a Command / Query style implemented with Mediatr. This is a nice approach for spiking vertical slices as it allows relatve ease of shifting to a true event-driven model with external message busses. It's not a perfect fit but it gets you a lot of the way there.
  - Even so, it ensures true decoupling of caller from handler. Replacement of handlers becomes a breeze.
- Swagger documentation
  - Ensuring public facing controllers and DTO models have XML Documentation Comments a good candidate for meeting the testing requirement
  - API version support, with swagger playing ball too
- Runs in a docker container
- SQL Server deployed with
- Structured logging for relative ease of machine parsing (Grafana et al, though using SEQ instead of Loki)
- All routes exposed in a REST fashion with proper relationship between resources, HTTP verbs, etc

I have a lot of this burnt into my brain and quickly available to me. Implementation will however push me over the guide time limit. However:

> While this is a test exercise, the level of detail and quality should represent something that is fit for production.

Say no more...

# How to run

On a docker capable machine, from the base directory of the repository:

```
docker-compose up
```

This will download all necessary images, build the project in its own container and run all tests defined within the solution.

The database will be seeded with three companies (id 1, 2 and 3) the first two of which each have a number of claims.

Swagger is available at: http://localhost:51770/swagger/index.html

Each of the routes requested in the above requirements has been implemented.

Logging occurs to console, but is also available in SEQ here: http://localhost/#/events. Structured logging has been implemented via Serilog. 