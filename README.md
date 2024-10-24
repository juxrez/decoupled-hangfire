# Overview
decoupled-hangfire is a proof-of-concept demonstrating how Hangfire Server and background jobs can be effectively separated into distinct projects, allowing for the deployment of multiple Hangfire servers.

# Key features

## Decoupled Architecture: Cleanly separates Hangfire Server and background jobs into individual projects.

## Multiple Hangfire Servers: Supports the deployment and management of more than one Hangfire server instance.

## Dockerized Environment: Each project is containerized using Docker for efficient deployment and isolation.

## Shared Resources: All projects connect to the same SQL server and database within a shared network.
