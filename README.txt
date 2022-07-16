# SQL SERVER

In order to add a model to a sql database.
1.	Make sure you have the connection string set in appsettings
2. Ensure your model is filled with a database structure
3. In the file ApplicationDbContext, type the following:
	-> public DbSet<Product> Products { get; set; }
4. Open a package manage console and type the following:
	-> add-migration AddProductModelToDb (this can be changed to another name)
	-> update-database
5. To add seed data add it into the file ApplicationDbContext in the method OnModelCreating()