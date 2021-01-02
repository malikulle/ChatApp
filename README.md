# Getting started

- This project is developed by `Mehmet Ali Külle` to understand using `.Net Core MVC and SignalR`

# Code Overview

- `ChatApplication.Entities` is Entity Layer of project
    * `ChatApplication.Entities/Domain` is database folder of project.
    * `ChatApplication.Entities/Trackable` is base entity folder.
- `ChatApplication.Shared` is Shared project.
- `ChatApplication.Core` is Data access Layer of project.
    * `ChatApplication.Core/Abstract` is Repositories folder. This folder contains UnitOfWork pattern.
    * `ChatApplication.Core/Concrete` contains repositories implements , database context , and mapping.
- `ChatApplication.WebUI` is UI folder of project.
    - `ChatApplication.WebUI/Controllers` contains controllers.
    - `ChatApplication.WebUI/Hubs` contains SingalR Hub Class.
    - `ChatApplication.WebUI/ViewComponents` contains view components.
    - `ChatApplication.WebUI/Views` contains views and layouts.


# Project Pictures 

## Login Screen
![LoginScreen](https://github.com/malikulle/ChatApp/blob/master/images/1.png?raw=true)

## Register Screen
![RegisterScreen](https://github.com/malikulle/ChatApp/blob/master/images/2.png?raw=true)

## You can find rooms in find section.
![Home](https://github.com/malikulle/ChatApp/blob/master/images/3.png?raw=true)

## Chat Screen
![Home](https://github.com/malikulle/ChatApp/blob/master/images/4.png?raw=true)

## You can send private message
![Home](https://github.com/malikulle/ChatApp/blob/master/images/5.png?raw=true)
