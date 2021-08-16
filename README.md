# HelloWorldApp
## How to deploy to Heroku
Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a borys-internship-class web
```

Release the container
```
heroku container:release -a borys-internship-class web
```