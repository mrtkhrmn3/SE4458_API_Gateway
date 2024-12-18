SE4458 Assignment 2,

Youtube Video Link: https://www.youtube.com/watch?v=f_pBdEjosEA

Design:

- Implemented a microservices architecture consisting of AdminService, FlightService, TicketService, and API Gateway for central routing.
- Used Ocelot as the API Gateway for request routing and load balancing.
- The required services are configured with RESTful endpoints and communicate over HTTP.
- The Gateway uses ocelot.json for route configuration and supports upstream path templates for client requests.

