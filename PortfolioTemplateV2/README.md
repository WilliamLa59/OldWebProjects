# PortfolioTemplate

A barebones portfolio template that allows the user to perform CRUD operations for their projects.

Created using ASP.Net, Razor Pages, and Entity Framework for database manipulations.

An admin account is seeded into the account table with the password being encrypted with a salted hash.
When logged in as a admin, the user is able to add, edit and delete projects as well as upload images.
Anonymous users are only able to view the projects saved on the database.
The idea for this project was to allow the user to revise and alter the projects on their portfolio without having to change any code.

## The default Admin credentials
Username: admin
Password: password

## To-Do List
- ~~CRUD operations with project data~~ COMPLETE
- ~~Add image upload and implementation with CRUD operations~~ COMPLETE
- ~~Add Admin Authorization for CRUD operation~~ COMPLETE
- ~~Seed default admin credentials~~ COMPLETE
- ~~Implement password hashing for admin account~~ COMPLETE
- ~~Add verification for hashed password~~ COMPLETE
- ~~Implement ability to change admin password~~ COMPLETE
