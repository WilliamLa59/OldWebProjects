# PortfolioTemplate

A barebones portfolio template that allows the user to perform CRUD operations for their projects.

Created using ASP.Net, Razor Pages, and Entity Framework for database manipulations.

An admin account is seeded into the account table with the password being encrypted with a salted hash.
When logged in as a admin, the user is able to add, edit and delete projects as well as upload images.
Anonymous users are only able to view the projects saved on the database.
The idea for this project was to allow the user to revise and alter the projects on their portfolio without having to change any code.

## Default Admin Credentials
    Username: admin
    Password: password
*Remember to change your password after first login*

## Theme/Appearance 
Currently uses the default scaffolding CSS and layout, but my hope is to create several themes useres can select from or users can just edit the css and html to create their own themes.

Includes both a black and white github logo PNG

## To-Do List
<sup>will add more things as they come to mind<sup>
- ~~CRUD operations with project data~~ COMPLETE
- ~~Add image upload and implementation with CRUD operations~~ COMPLETE
- ~~Add Admin Authorization for CRUD operation~~ COMPLETE
- ~~Seed default admin credentials~~ COMPLETE
- ~~Implement password hashing for admin account~~ COMPLETE
- ~~Add verification for hashed password~~ COMPLETE
- ~~Implement ability to change admin password~~ COMPLETE
- ~~Add ability to include github repository link for projects~~ COMPLETE
