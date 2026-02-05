# BlogCommunity API

A RESTful Web API built with **ASP.NET Core** for a simple blog community.

Users can register, create blog posts, comment on posts, and organize posts using categories.
The API is documented with **Swagger**.

---

## Features

### User
- Register a new user
- Login with username and password
- Get all users (passwords are never exposed)
- Update user information
- Delete a user

### Post
- Create a blog post (requires a valid user)
- Get all posts
- Get post by id
- Search posts by title
- Search posts by category
- Update a post (only the owner can update)
- Delete a post (only the owner can delete)

### Comment
- Add a comment to a post
- User must exist
- Users cannot comment on their own posts

### Category
- Create categories
- Get all categories
- Categories are used to organize blog posts

---

## Authentication

This project does **not** use JWT authentication.
Instead, `userId` is sent as a query parameter for endpoints that require a logged-in user.

---

## API Documentation

Swagger is available at:

```
/swagger
```

---

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

---

## Author

School assignment – Web API development
