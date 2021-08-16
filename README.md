# HelloWorldApp
## How to deploy to Heroku
1.Login to heroku
```
heroku login
heroku container:login
```
2. Build container

Build docker image:
```
docker build -t teonahelloworldapp
```

3. Create and run docker container
```
docker run -d -p 8081:80 --name teonahelloworldapp_container teonahelloworldapp
```

4. Push container
```
heroku container:push -a app-helloworld-teona web
```

5. Release the container
```
heroku container:release -a app-helloworld-teona web
```