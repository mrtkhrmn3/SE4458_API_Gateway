SE4458 Assignment 2,

Youtube Video Link: https://www.youtube.com/watch?v=f_pBdEjosEA

Design:

- Implemented a microservices architecture consisting of AdminService, FlightService, TicketService, and API Gateway for central routing.
- Used Ocelot as the API Gateway for request routing and load balancing.
- Each service is structured with RESTful endpoints and communicates via HTTP.
- The Gateway uses ocelot.json for route configuration and supports upstream path templates for client requests.

