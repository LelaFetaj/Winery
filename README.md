# Winery
Create a .NET Core (5.0 or 6.0) Web API application that uses Entity Framework (code first) and SQL
Server database for the situation below:

In a winery we have tanks (containers of wine), these tanks are positioned in a specific sector.
You will have 2 tables in database:

**1. Tanks**
 <br /> - id
 <br /> - code
 <br /> - type
 <br /> - volume
 <br /> - quantity

**2. Sectors**
<br />- id
<br />- code
<br />- isActive
  
* These 2 tables are related, a tank can only be part of a sector.
* We cannot have records with the same code.
* We cannot delete a sector if it has tanks related.
  
Create all endpoints for CRUD operations for both tables and a custom endpoint that receives sector
id as parameter and shows all tanks of it.
