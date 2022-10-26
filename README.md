ASP.NET Core 6 Web API with Controller
Entity Framework Core 6 Setup

1. Download EFCore in NuGet (Make sure EntityFrameworkCore are all in same version)
	a. Microsoft.EntityFrameworkCore
	b. Microsoft.EntityFrameworkCore.SqlServer
	c. Microsoft.EntityFrameworkCore.Tools

2. Create Model
	a. Set all necessary property
	b. All definition must same as ResultSet from DB

3. Create DbContext
	a. Make sure DBSet<Model> is declare public

2. Open Program.CS
	a. Add using statement
		code:	
		using Microsoft.EntityFrameworkCore;
	b. Dependency Injection to builder.services, add before call for builder.Build();
		code:
		services.AddDbContext<CupcakeContext>(options =>options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

3. Add Connection string in appsetting.json "DefaultConnection" can be any name you like.
	code: (change value for server, db, etc)
	"ConnectionStrings": {
    		"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  	}

4. EFCore Done Setup

5. Start creating controllers
	a. Please check for source code for implementation
	b. ProcedureWithResultSet
		code:
		await _context.ProcedureReturn.FromSqlRaw(StoredProc).ToListAsync();
	c. ProcedureWithOutReturn
		code
		await _context.Database.ExecuteSqlRawAsync(StoredProc,new SqlParameter("@Name",input.Name));