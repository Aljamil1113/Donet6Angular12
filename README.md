# Donet6Angular12
E-Commerce using dotnet 6 and Angular 12


#EF CORE COMMAND FOR VS 2022
/*
    Add-Migration
    Bundle-Migration
    Drop-Database
    Get-DbContext
    Get-Migration
    Optimize-DbContext
    Remove-Migration
    Scaffold-DbContext
    Script-DbContext
    Script-Migration
    Update-Database */
	
-Add-Migration InitialMigrate -OutputDir Data/Migrations
-Update-Database

#Revert Migration After applied in Db
-Update-Database -Migration 0
Update-Database -Migration 0 -p Infrastructure -s API

Add-Migration InitialCreate -p Infrastructure -s API -o Data/Migrations
Update-Database -p Infrastructure -s API 


# Angular
-ng new client

# Bootstrap
ng add ngx-bootstrap
npm install ngx-toastr


