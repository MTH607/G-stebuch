USE
master
IF exists(SELECT *
FROM sysdatabases
WHERE name='Gästebuch')
BEGIN
	RAISERROR('Die Datenbank existiert bereits, aber wurde gedropt und neu erstellt.',0,1)
	DROP DATABASE Gästebuch
	CHECKPOINT
END
GO
CREATE DATABASE Gästebuch
GO
CHECKPOINT
USE Gästebuch
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Table tbl_Einträge
(
	rowguid UNIQUEIDENTIFIER PRIMARY KEY default newid(),
	Nachname NVARCHAR(20) NOT NULL,
	Vorname NVARCHAR(20) NOT NULL,
	Bewertung NVARCHAR NOT NULL CHECK (Bewertung IN('1', '2', '3', '4', '5')),
	Verbesserungsvorschläge NVARCHAR(255) NOT NULL,
	Zeitpunkt DATETIME NOT NULL,
	Autorisiert BIT,
)
GO
CREATE UNIQUE INDEX Gästebuch ON tbl_Einträge (Nachname);
GO
Create Table tbl_Admin
(
	rowguid UNIQUEIDENTIFIER PRIMARY KEY default newid(),
	Username NVARCHAR(8) NOT NULL,
	Passwort NVARCHAR(max) NOT NULL
)
GO
INSERT INTO tbl_Admin
	(Username, Passwort)
VALUES
	('Admin', 'Admin');
GO
CREATE TRIGGER backup_objects
ON DATABASE
FOR CREATE_PROCEDURE, 
    ALTER_PROCEDURE, 
    DROP_PROCEDURE,
    CREATE_TABLE, 
    ALTER_TABLE, 
    DROP_TABLE,
    CREATE_FUNCTION,
    ALTER_FUNCTION, 
    DROP_FUNCTION,
    CREATE_VIEW,
    ALTER_VIEW,
    DROP_VIEW
AS
SET NOCOUNT ON
DECLARE @data XML
SET @data = EVENTDATA()
INSERT INTO tbl_ChangeLog
	(DatabaseName, EventType, ObjectName, ObjectType, SqlCommand, LoginName)
VALUES(
		@data.value('(/EVENT_INSTANCE/DatabaseName)[1]', 'varchar(256)'),
		@data.value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)'),
		@data.value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(256)'),
		@data.value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(25)'),
		@data.value('(/EVENT_INSTANCE/TSQLCommand)[1]', 'varchar(max)'),
		@data.value('(/EVENT_INSTANCE/LoginName)[1]', 'varchar(256)')
)
GO
ENABLE TRIGGER [backup_objects] ON DATABASE
GO