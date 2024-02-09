# ProjectKlinMilkMethod
Gerador de API Mínima, que pode ser usado como base para geração de outras automações no desenvolvimento de sistemas.

SCRIPTS DE BANCO DE DADOS:

-- Create a new table called '[Param]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Param]', 'U') IS NOT NULL
DROP TABLE [dbo].[Param]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Param]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY, -- Primary Key column 
    [ExpiraUsuario] SMALLINT NOT NULL,
);
GO

/*
INSERT INTO Param (ExpiraUsuario) Values (2);
UPDATE Param SET ExpiraUsuario = 365
SELECT * FROM Param
*/

-- Create a new table called '[Estrutura]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Estrutura]', 'U') IS NOT NULL
DROP TABLE [dbo].[Estrutura]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Estrutura]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY, -- Primary Key column
    [ChaveAcesso] NCHAR(36) NOT NULL,
    [ChaveEstrutura] NCHAR(36) NOT NULL,
    [Conteudo] NVARCHAR(MAX) NOT NULL,
    [Entidades] NVARCHAR(255) NOT NULL,
    [MesAno] NCHAR(4),
    [Tipo] NCHAR(3)
);
GO
 
-- Select * From Estrutura


-- Create a new table called '[Acesso]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Acesso]', 'U') IS NOT NULL
DROP TABLE [dbo].[Acesso]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Acesso]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY, -- Primary Key column
    [Chave] NCHAR(36) NOT NULL,
    [Ip] NCHAR(15) NOT NULL,
    [Autorizado] BIT DEFAULT(0),
    [Logon] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [Dias] SMALLINT NOT NULL,
    [TipoPlano] SMALLINT NOT NULL,
    [DataExpiracao] DATETIME NOT NULL
);
GO

/*
SELECT GETDATE()+30
INSERT INTO Acesso Values('b7019f22-bd08-4e05-aa5d-0b1a3975faa2', '999.999.9.99', 1, 'System', 'klinmilk.comercial@devaiinaction.net', 1, 5, '2024-01-22 23:59:59')
UPDATE Acesso SET Dias = 2, DataExpiracao = '2023-12-26 16:12:14'  where Id = 2
UPDATE Acesso SET Dias = 1 where Id = 1
UPDATE Acesso SET AUTORIZADO = 1 where Id = 2
SELECT * FROM Acesso
*/

-- Create a new table called '[Plano]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Plano]', 'U') IS NOT NULL
DROP TABLE [dbo].[Plano]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Plano]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY, -- Primary Key column
    [Nome] NCHAR(15) NOT NULL,
    [Valor] DECIMAL(12,2) NOT NULL,
    [Ativo] BIT NOT NULL DEFAULT 1
);
GO

Select * from Plano

-- Create a new table called '[Recurso]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Recurso]', 'U') IS NOT NULL
DROP TABLE [dbo].[Recurso]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Recurso]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY, -- Primary Key column
    [IdPlano] INT NOT NULL,
    [Nome] NVARCHAR(150) NOT NULL,
    [Dias] SMALLINT NOT NULL,
    [Ativo] BIT NOT NULL DEFAULT 1
);
GO

INSERT INTO Recurso VALUES(1,'API', 10, 1);
INSERT INTO Recurso VALUES(1,'DDD', 10, 0);
INSERT INTO Recurso VALUES(1,'Agenda Inteligente', 10, 0);
INSERT INTO Recurso VALUES(1,'Orçamento Doméstico', 10, 0);
INSERT INTO Recurso VALUES(1,'O.S com AI', 10, 0);

INSERT INTO Recurso VALUES(2,'API', 20, 1);
INSERT INTO Recurso VALUES(2,'DDD', 20, 0);
INSERT INTO Recurso VALUES(2,'Agenda Inteligente', 20, 0);
INSERT INTO Recurso VALUES(2,'Orçamento Doméstico', 20, 0);
INSERT INTO Recurso VALUES(2,'O.S com AI', 20, 0);

INSERT INTO Recurso VALUES(3,'API', 30, 1);
INSERT INTO Recurso VALUES(3,'DDD', 30, 0);
INSERT INTO Recurso VALUES(3,'Agenda Inteligente', 30, 0);
INSERT INTO Recurso VALUES(3,'Orçamento Doméstico', 30, 0);
INSERT INTO Recurso VALUES(3,'O.S com AI', 30, 0);

INSERT INTO Recurso VALUES(3,'API', 30, 1);
INSERT INTO Recurso VALUES(3,'DDD', 30, 0);
INSERT INTO Recurso VALUES(3,'Agenda Inteligente', 30, 0);
INSERT INTO Recurso VALUES(3,'Orçamento Doméstico', 30, 0);
INSERT INTO Recurso VALUES(3,'O.S com AI', 30, 0);

INSERT INTO Recurso VALUES(4,'API', 60, 1);
INSERT INTO Recurso VALUES(4,'DDD', 60, 0);
INSERT INTO Recurso VALUES(4,'Agenda Inteligente', 60, 0);
INSERT INTO Recurso VALUES(4,'Orçamento Doméstico', 60, 0);
INSERT INTO Recurso VALUES(4,'O.S com AI', 60, 0);

-- Create a new table called '[Snippet]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Snippet]', 'U') IS NOT NULL
DROP TABLE [dbo].[Snippet]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Snippet]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY, -- Primary Key column
    [Nome] NVARCHAR(50) NOT NULL,
    [Conteudo] NVARCHAR(MAX) NOT NULL
);
GO

DECLARE @Conteudo VARCHAR(MAX);
SET @Conteudo =  'using $mapinamespace$.$FolderData$;\n';
SET @Conteudo += 'using $mapinamespace$.$FolderModels$;\n';
SET @Conteudo += 'using Microsoft.EntityFrameworkCore;\n';
SET @Conteudo += 'using MiniValidation;\n';
SET @Conteudo += '\n';
SET @Conteudo += '    var builder = WebApplication.CreateBuilder(args);\n';
SET @Conteudo += '\n';
SET @Conteudo += '    // Add services to the container.\n';
SET @Conteudo += '    builder.Services.AddAuthorization();\n';
SET @Conteudo += '\n';
SET @Conteudo += '    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle\n';
SET @Conteudo += '    builder.Services.AddEndpointsApiExplorer();\n';
SET @Conteudo += '    builder.Services.AddSwaggerGen();\n';
SET @Conteudo += '\n';
SET @Conteudo += '    builder.Services.AddDbContext<APIContext>(options =>\n';
SET @Conteudo += '    options.UseSqlServer(builder.Configuration.GetConnectionString("$DbConnectionName$")));\n';
SET @Conteudo += '\n';
SET @Conteudo += '    var app = builder.Build();\n';
SET @Conteudo += '\n';
SET @Conteudo += '    if (app.Environment.IsDevelopment())\n';
SET @Conteudo += '    {\n';
SET @Conteudo += '        app.UseSwagger();\n';
SET @Conteudo += '        app.UseSwaggerUI();\n';
SET @Conteudo += '    }\n';
SET @Conteudo += '\n';
SET @Conteudo += '    // Configure the HTTP request pipeline.\n';
SET @Conteudo += '    // app.UseAuthorization();\n';
SET @Conteudo += '\n';
SET @Conteudo += '    //Usar apenas quando o projeto for criado com Https\n';        
SET @Conteudo += '    //app.UseHttpsRedirection();\n';
SET @Conteudo += '\n';
SET @Conteudo += '    app.MapGet("/$VariableRoot$", async ($YourDbContextName$ context) =>\n';
SET @Conteudo += '    await context.$PluralizeType$.ToListAsync())\n';
SET @Conteudo += '    .WithName("Get$Tag$")\n';
SET @Conteudo += '    .WithTags("$Tag$");\n';
SET @Conteudo += '\n';
SET @Conteudo += '    app.MapGet("/$VariableRoot$/{id}",\n';
SET @Conteudo += '    async (int id, $YourDbContextName$ context) =>\n';
SET @Conteudo += '    await context.$PluralizeType$.FindAsync(id)\n';
SET @Conteudo += '    is $Type$ $VariableType$\n';
SET @Conteudo += '    ? Results.Ok($VariableType$)\n';
SET @Conteudo += '    : Results.NotFound()\n'; 
SET @Conteudo += '    )\n';
SET @Conteudo += '    .Produces<$Type$>(StatusCodes.Status200OK)\n';
SET @Conteudo += '    .Produces(StatusCodes.Status404NotFound)\n';
SET @Conteudo += '    .WithName("Get$Tag$Id")\n';
SET @Conteudo += '    .WithTags("$Tag$");\n';
SET @Conteudo += '\n';
SET @Conteudo += '    app.MapPost("/$VariableRoot$", async ($YourDbContextName$ context, $Type$ $VariableType$) =>\n';
SET @Conteudo += '    {\n';
SET @Conteudo += '        if (!MiniValidator.TryValidate($VariableType$, out var errors))\n';
SET @Conteudo += '            return Results.ValidationProblem(errors);\n';
SET @Conteudo += '\n';
SET @Conteudo += '            context.$PluralizeType$.Add($VariableType$);\n';
SET @Conteudo += '            var result = await context.SaveChangesAsync();\n';
SET @Conteudo += '\n';
SET @Conteudo += '            return result > 0\n';
SET @Conteudo += '            ? Results.CreatedAtRoute("Get$Tag$Id", new {id = $VariableType$.Id}, $VariableType$)\n';
SET @Conteudo += '            : Results.BadRequest("Houve um problema ao salvar o registro");\n';
SET @Conteudo += '\n';
SET @Conteudo += '    }).ProducesValidationProblem()\n';
SET @Conteudo += '    .Produces<$Type$>(StatusCodes.Status201Created)\n';
SET @Conteudo += '    .Produces(StatusCodes.Status400BadRequest)\n';
SET @Conteudo += '    .WithName("Post$Tag$")\n';
SET @Conteudo += '    .WithTags("$Tag$");\n';
SET @Conteudo += '\n';
SET @Conteudo += '    app.MapPut("/$VariableRoot$", async (\n';
SET @Conteudo += '    $YourDbContextName$ context,\n';
SET @Conteudo += '    $Type$ $VariableType$) =>\n';
SET @Conteudo += '    {\n';
SET @Conteudo += '        if (!MiniValidator.TryValidate($VariableType$, out var errors))\n';
SET @Conteudo += '            return Results.ValidationProblem(errors);\n';
SET @Conteudo += '\n';
SET @Conteudo += '        var fornecedorBanco = await context.$PluralizeType$.AsNoTracking<$Type$>().FirstOrDefaultAsync(f => f.Id == $VariableType$.Id);\n';
SET @Conteudo += '        if (fornecedorBanco == null) return Results.NotFound();\n';
SET @Conteudo += '\n';
SET @Conteudo += '        context.$PluralizeType$.Update($VariableType$);\n';
SET @Conteudo += '        var result = await context.SaveChangesAsync();\n';
SET @Conteudo += '\n';
SET @Conteudo += '        return result > 0\n';
SET @Conteudo += '        ? Results.NoContent()\n';
SET @Conteudo += '        : Results.BadRequest("Houve um problema ao salvar o registro");\n';
SET @Conteudo += '        })\n';
SET @Conteudo += '        .ProducesValidationProblem()\n';
SET @Conteudo += '        .Produces<$Type$>(StatusCodes.Status204NoContent)\n';
SET @Conteudo += '        .Produces(StatusCodes.Status400BadRequest)\n';
SET @Conteudo += '        .WithName("Put$Tag$")\n';
SET @Conteudo += '        .WithTags("$Tag$");\n';
SET @Conteudo += '\n';
SET @Conteudo += '        app.MapDelete("/$VariableRoot$/{id}", async (\n';
SET @Conteudo += '        int id,\n';
SET @Conteudo += '        $YourDbContextName$ context) =>\n';
SET @Conteudo += '        {\n';
SET @Conteudo += '            var $VariableType$ = await context.$PluralizeType$.FindAsync(id);\n';
SET @Conteudo += '            if ($VariableType$ == null) return Results.NotFound();\n';
SET @Conteudo += '\n';
SET @Conteudo += '            context.$PluralizeType$.Remove($VariableType$);\n';
SET @Conteudo += '            var result = await context.SaveChangesAsync();\n';
SET @Conteudo += '\n';
SET @Conteudo += '            return result > 0\n';
SET @Conteudo += '            ? Results.NoContent()\n';
SET @Conteudo += '            : Results.BadRequest("Houve um problema ao salvar o registro");\n';
SET @Conteudo += '     })\n';
SET @Conteudo += '     .Produces(StatusCodes.Status400BadRequest)\n';
SET @Conteudo += '     .Produces(StatusCodes.Status204NoContent)\n';
SET @Conteudo += '     .Produces(StatusCodes.Status404NotFound)\n';
SET @Conteudo += '     .WithName("Delete$Tag$")\n';
SET @Conteudo += '     .WithTags("$Tag$");\n';
SET @Conteudo += '\n';
SET @Conteudo += '     app.Run();\n';

INSERT INTO SNIPPET VALUES ('SnippetMinimalAPI', @Conteudo)
SELECT * FROM SNIPPET

SELECT ROW_NUMBER() OVER (ORDER BY TABLE_NAME) AS Id, TABLE_NAME AS Tabela, COLUMN_NAME AS Coluna, DATA_TYPE AS Tipo FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_CATALOG = 'DbKMilkFastDev'
AND   TABLE_SCHEMA = 'dbo';

CREATE VIEW TabelasBanco AS
SELECT ROW_NUMBER() OVER (ORDER BY TABLE_NAME) AS Id, TABLE_NAME as Nome
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
GO
/*
SELECT * from TabelasBanco
drop view TabelasBanco
*/

CREATE VIEW ColunasTabelasParaJson AS
SELECT ROW_NUMBER() OVER (ORDER BY TABLE_NAME) AS Id, TABLE_NAME AS Tabela, COLUMN_NAME AS Coluna, DATA_TYPE AS Tipo, JsonIgnore = 'false'  FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_CATALOG = 'DbKMilkFastDev'
AND   TABLE_SCHEMA = 'dbo'
GO

CREATE PROCEDURE ColunasTabelas AS
SELECT Id, Tabela, Coluna, Tipo, JsonIgnore
FROM ColunasTabelasParaJson
FOR JSON AUTO;
GO

exec ColunasTabelas

DECLARE @JSON NVARCHAR(MAX)
SET @JSON = (
SELECT Id, Tabela, Coluna, Tipo, JsonIgnore
FROM ColunasTabelasParaJson
FOR JSON AUTO
)
SELECT @JSON AS 'JSON'

EXEC ColunasTabelas

/*
SELECT * from ColunasTabelasParaJson order by Tabela
drop proc dbo.ColunasTabelas
drop view dbo.ColunasTabelasParaJson
*/


