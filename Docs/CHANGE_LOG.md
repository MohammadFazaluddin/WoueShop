# 09/01/2024 
- Project setup.
- Setting up EF core.

# 10/01/2024
- Trying to add some abstraction for Error handling and API return response.
- Added Custom error class and result class, will implement after basic crud operation is completed.

# 11/01/2024
- Database context setup complete.
- Applied migration for products and media tables.
- added Controller for products.

# 12/01/2024 
- Working on Crud operation for Products, adding works, reading not working (Issue: no data found in dbContext).
- Got Crud operations working for view add and delete (no data found issue was the wrong query filter).

# 13/01/2024 
- Fixed some structure issues.
- Using Tailwind for styling 
- started working on UI.

# 14/01/2024 
- Working on Authentication and Authorization for the application. (using Identity)
- Added Identity tables.
- Started working on User management.
- Set up the result pattern and Proper Api Exception response using result pattern.
- Custom Error class implementation.
- Result Class implementation

# 17/01/2024
- Working on Authentication and Authorization.
- Created a login page.
- made user sign in handler to login from backend front end needs some work.
- On authorization there seem to be an issue that I can't seem to have found the solution to use a different URL then default one ('Accounts/login?ReturnUrl')

# 17/01/2024
- Got the Authorization working Sign in Successfully.
- User still remains registered as Unauthorized even after the Cookie successfully being stored. need to fix this first.
- Needs to start working on Login page UI design.

# 18/01/2024
- User Authentication and Authorization implementation complete
- user Authentication works with Remember me feature.
- user sign in complete.
- Authentication is based on Cookie authentication.
- Sign in and Signout implemented on UI aswell.