# Api crud users and login

## Project description
An api was developed with users crud and login functionality, the CQRS standard was used along with the mediator to reduce dependencies between objects.
 In addition, the unit tests of the application were created.
 
 ## Documentation
 https://localhost:5001/swagger/index.html
 
 ### Login
 
 - `POST` url_base/v1/login
 
 Request
 `{
  "userLoginName": "string",
  "password": "string"
 }`
 
 Response 200 SUCCESS
 
 ### User
 
 - `POST` url_base/v1/user
 
 Request
 `{
  "document": "string",
  "name": "string",
  "email": "string",
  "userNameLogin": "string",
  "password": "string"
 }`
 
 Response 201 SUCCESS 
 `{
  "document": "string",
  "name": "string",
  "email": "string",
  "userNameLogin": "string",
  "id": "string"
 }`
 
 - `GET` url_base/v1/user
 
 Response 200
 `[
  {
    "document": "222222222",
    "name": "admin",
    "email": "admin@admin",
    "userNameLogin": "admin",
    "id": "7875e3d5-fc0d-493f-b7c7-8654cc1a30d2"
   }
 ]`
 
  - `PATCH` url_base/v1/user/{userid}
 
 Request
 
 `{
  "name": "string",
  "email": "string",
  "userNameLogin": "string"
 }`
 
 Response 200
 
 `{
  "document": "string",
  "name": "string",
  "email": "string",
  "userNameLogin": "string",
  "id": "string"
 }`
 
  - `DELETE` url_base/v1/user/{userid}
 
 Response 200
 
   - `GET` url_base/v1/user/{userid}
 
 Response 200
 `{
  "document": "string",
  "name": "string",
  "email": "string",
  "userNameLogin": "string",
  "id": "string"
 }`
 
 
