# SQL Identity Adventure

The goal with this project is to show how to connect to a database and perform some simple CRUD operations on a SQL Azure instance using Managed Identities.

## Prerequisites
Installed the following nuget packages:

```
[Microsoft.Data.SqlCLient] (https://www.nuget.org/packages/Microsoft.Data.SqlClient)
```

## Getting Started

1. Create a SQL Azure instance and a database.

2. Creae the following table:

```
CREATE TABLE [dbo].[Cities]([Id] [int] NOT NULL, [City] [varchar](50) NULL, [Population] [int] NULL, CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([Id] ASC)
```

3. Update the code in the Program.cs file with the connection string to your SQL Azure instance.

4. Run the code.