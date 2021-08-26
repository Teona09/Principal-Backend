# HelloWorldApp
[![.NET](https://github.com/Teona09/Principal-Backend/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Teona09/Principal-Backend/actions/workflows/dotnet.yml)
## How to run/deploy

### Locally (using Docker)

1.Build container image
```
docker build -t teonahelloworldapp .
```
2. Create and run docker container
```
docker run -d -p {external_port}:80 --name teonahelloworldapp_container teonahelloworldapp
```
Replace `external_port` with the desired port on the host machine. *(E.g. 8081)*

### On Heroku

1.Login to heroku
```
heroku login
```
2.Check if Docker is running correctly. You should see output when you run this command.
```
docker ps
```
3.Sign in into Container Registry
```
heroku container:login
```
4. Push the Docker-based app
Build the Dockerfile in the current directory and push the Docker image.
```
heroku container:push -a app-helloworld-teona web
```
5. Deploy the changes
Release the pushed image to deploy the app
```
heroku container:release -a app-helloworld-teona web
```
