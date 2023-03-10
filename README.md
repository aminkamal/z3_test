# z3_test

A RESTful game backend written in C# .NET 7.0 supporting routing, middlewares, JSON and authentication.

Game functionality includes: create new user, login a user, get/add/delete user friends, get user items, get shop items and ability to purchase items using virtual (gems) currency.

Easy support for additional data stores (e.g. PostgreSQL, MongoDB...etc) instead of the in-memory store.

No external libraries! pure C# only.

TODO:
- Fix warnings
- Add unit/automated tests

# Routes

|Method & path|
|---|
|POST /login|
POST /users
GET /users/:userID
POST /users/:userID/friends
GET /users/:userID/friends
DELETE /users/:userID/friends
POST /users/:userID/items
GET /users/:userID/items
GET /purchasable-items

# How to run

Make sure you have .NET 7.0 installed, then run:

```
dotnet build && dotnet run
```

# Sample requests

User signup

```
curl -X POST http://localhost:8000/users -d '{"username":"user", "password": "123"}'
```

User login
```
curl -X POST http://localhost:8000/login -d '{"username":"user", "password": "123"}'
```

Get user
```
curl http://localhost:8000/users/<USER_ID> -H "Authorization: <ACCESS_TOKEN>"
```

Get user items
```
curl http://localhost:8000/users/<USER_ID>/items -H "Authorization: <ACCESS_TOKEN>"
```

Get friends
```
curl http://localhost:8000/users/<USER_ID>/friends -H "Authorization: <ACCESS_TOKEN>"
```

Add a friend

```
curl -X POST http://localhost:8000/users/<USER_ID>/friends -d '{"friend_id": "a50b961e-1899-4eef-9841-6aea90ea258b"}' -H "Authorization: <ACCESS_TOKEN>"
```

Remove a friend

```
curl -X DELETE http://localhost:8000/users/<USER_ID>/friends -d '{"friend_id": "a50b961e-1899-4eef-9841-6aea90ea258b"}' -H "Authorization: <ACCESS_TOKEN>"
```

List shop items:

```
curl http://localhost:8000/purchasable-items
```

Purchae an item

```
curl -X POST http://localhost:8000/users/<USER_ID>/items -d '{"item_id": "200"}' -H "Authorization: <ACCESS_TOKEN>"
```

# Example response with a purchased item

```
{
    "ID": "93b0d806-923c-48ed-8460-4330a379065d",
    "Name": "user",
    "IsBanned": false,
    "Platform": "WEB",
    "RegisteredOn": "2023-03-10T04:15:02.9257402+03:00",
    "Items": [
        {
            "ID": "gems",
            "Type": "GEM",
            "Description": "The amount of premium currency you currently have",
            "Rarity": 1,
            "AcquiredOn": "2023-03-10T04:15:02.9183388+03:00",
            "Quantity":500
        },
        {
            "ID": "200",
            "Type": "GEM",
            "Description": "Warrior (Melee)",
            "Rarity": 1,
            "AcquiredOn": "2023-03-10T04:19:45.9394494+03:00",
            "Quantity": 1
        }
    ],
    "Friends": ["3f440f07-dca3-4a86-aed6-300714fa4a94"]
}
```
