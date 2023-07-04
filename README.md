# Schneider Technical Assessment

This repo is to demonstrate my Solution for the Technical Assessment.

## Tech Stack used

+ Frontend: Blazor Server
+ Backend: ASP.NET Core 7
+ Hosted in Docker

## How to Run

> You need to have [Docker Compose](https://www.docker.com/products/docker-desktop/) installed to be able to run the solution.

+ Clone the repo
+ Navigate to the root of the Solution Directory
+ Run `docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d` to spin up the Stack

You can view the Backend at [http://localhost:7001/swagger/index.html](http://localhost:7001/swagger/index.html) and frontend at [https://localhost:7004](https://localhost:7004/)
