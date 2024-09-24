# Bee.MySQL
A very simple way to work with a MySQL database

## Help, Feedback, Contribute
If you have any issues or feedback, please file an issue here in Github. We'd love to have you help by contributing code for new features, optimization to the existing codebase, ideas for future releases, or fixes!

## Dependencies
	MySql.Data.MySqlClient

## Examples

### Select with out parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
    var result = MySQL.select(connectionString, "select id, name, lastname, age from users");
	
	foreach(var row in result.data)
	{
		Console.WriteLine("id:" + row["id"] + ", name:" + row["name"] + ", lastname:" + row["lastname"] + ", age:" + row["age"]);
	}
}
```

### Select with parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.select(connectionString, "select id, name, lastname, age from users where id = @user_id", new Dictionary<string, object>{{"@user_id", 1}});
	
	foreach(var row in result.data)
	{
		Console.WriteLine("id:" + row["id"] + ", name:" + row["name"] + ", lastname:" + row["lastname"] + ", age:" + row["age"]);
	}
}
```

### Select row with out parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
    var result = MySQL.selectRow(connectionString, "select id, name, lastname, age from users");
	
	Console.WriteLine("id:" + result.data["id"] + ", name:" + result.data["name"] + ", lastname:" + result.data["lastname"] + ", age:" + result.data["age"]);
}
```

### Select row with parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.selectRow(connectionString, "select id, name, lastname, age from users where id = @user_id", new Dictionary<string, object>{{"@user_id", 1}});
	
	Console.WriteLine("id:" + result.data["id"] + ", name:" + result.data["name"] + ", lastname:" + result.data["lastname"] + ", age:" + result.data["age"]);
}
```

### Select value
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.selectValue(connectionString, "select id from users where id = @user_id", new Dictionary<string, object>{{"@user_id", 1}});
	
	Console.WriteLine("id:" + result.value);
}
```

### Sample result check
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.select(connectionString, "select id, name, lastname, age from users");
	
	if(result.execute)
	{
		foreach(var row in result.data)
		{
			Console.WriteLine("id:" + row["id"] + ", name:" + row["name"] + ", lastname:" + row["lastname"] + ", age:" + row["age"]);
		}
	}
	else
	{
		Console.WriteLine("No result! " + result.message);
	}
}
```

### Insert example
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.query(connectionString, "insert into users(name, lastname, age) values('Gholibjon', 'Madiyarov', 29)");
	
	if(result.execute)
	{
		Console.WriteLine("Request completed successfully " + result.message);
	}
	else
	{
		Console.WriteLine("Request failed " + result.message);
	}
}
```

### Insert example with parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.query(connectionString, "insert into users(name, lastname, age) values(@name, @lastname, @age)", new Dictionary<string, object>{{"@name", "Gholibjon"}, {"@lastname", "Madiyarov"}, {"@age", 29}});
	
	if(result.execute)
	{
		Console.WriteLine("Request completed successfully " + result.message);
	}
	else
	{
		Console.WriteLine("Request failed " + result.message);
	}
}
```

### Insert example with transaction
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	
	var queries = new List<string>(){
		"insert into users(name, lastname, age) values('Gholibjon', 'Madiyarov', 29)",
		"insert into cities(name, description) values('Hujand', 'This is one of the most civilized and hospitable cities in Central Asia.')",
		"insert into cars(name, description) values('Mercedes Benz', 'One of the most perfect and friendly cars in the world.')"
	};
	
	var result = MySQL.query(connectionString, queries);
	
	if(result.execute)
	{
		Console.WriteLine("Request completed successfully " + result.message);
	}
	else
	{
		Console.WriteLine("Request failed " + result.message);
	}
}
```

### Insert example with transaction, with parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	
	var queries = new List<string>(){
		"insert into users(name, lastname, age) values(@name, @lastname, @age)",
		"insert into cities(name, description) values(@name, @description)",
		"insert into cars(name, description) values(@name, @description)"
	};
	
	var parameters = new List<Dictionary<string, object>>{
		new Dictionary<string, object>{{"@name", "Gholibjon"}, {"@lastname", "Madiyaov"}, {"@age", 29}},
		new Dictionary<string, object>{{"@name", "Hujand"}, {"@description", "This is one of the most civilized and hospitable cities in Central Asia."}},
		new Dictionary<string, object>{{"@name", "Mercedes Benz"}, {"@description", "One of the most perfect and friendly cars in the world."}},
	};
	
	var result = MySQL.query(connectionString, queries, parameters);
	
	if(result.execute)
	{
		Console.WriteLine("Request completed successfully " + result.message);
	}
	else
	{
		Console.WriteLine("Request failed " + result.message);
	}
}
```

### Insert example with transaction, with null parameters
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	
	var queries = new List<string>(){
		"insert into users(name, lastname, age) values(@name, @lastname, @age)",
		"insert into cities(name, description) values('Hujand', 'This is one of the most civilized and hospitable cities in Central Asia.')",
		"insert into cars(name, description) values(@name, @description)"
	};
	
	var parameters = new List<Dictionary<string, object>>{
		new Dictionary<string, object>{{"@name", "Gholibjon"}, {"@lastname", "Madiyaov"}, {"@age", 29}},
		null,
		new Dictionary<string, object>{{"@name", "Mercedes Benz"}, {"@description", "One of the most perfect and friendly cars in the world."}},
	};
	
	var result = MySQL.query(connectionString, queries, parameters);
	
	if(result.execute)
	{
		Console.WriteLine("Request completed successfully " + result.message);
	}
	else
	{
		Console.WriteLine("Request failed " + result.message);
	}
}
```

## Stored Procedures

### For result (select)
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.executeSelect(connectionString, "ProcedureName");
	
	if(result.execute)
	{
		foreach(var row in result.data)
		{
			//Console.WriteLine();
		}
	}
	else
	{
		Console.WriteLine("No result! " + result.message);
	}
}
```

### For any query (insert, update, delete...)
```csharp
using Bee.MySQL;

static void Main(string[] args)
{
	var connectionString = "server=127.0.0.1; port=3306; username=UserName; password=Password; database=DatabaseName; character set=utf8; pooling=true; Connect Timeout=15";
	var result = MySQL.executeQuery(connectionString, "ProcedureName");
	
	if(result.execute)
	{
		Console.WriteLine(result.data);
	}
	else
	{
		Console.WriteLine("No result! " + result.message);
	}
}
```