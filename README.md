# Testing Application #

***First open appsettings.json and update databse connection string in `dbModelConnection`.***

### Once Connection string is set run below commands in nuget package manager console ### 

Add-Migration <Your_Migration_Name> -o Model/migrations

update-database

## after this navigate to ClientApp folder in terminal and run npm install
