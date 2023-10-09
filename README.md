# Testing Application #

***First open appsettings.json and update databse settings in `dbModelConnection`.***



### Once Connection String is Set Run below commands in nuget package manager console ### 

Add-Migration Initial -o Model/migrations

update-database
