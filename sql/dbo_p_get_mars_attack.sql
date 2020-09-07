

USE [master]
GO


CREATE LOGIN [mars_attack_user]
	WITH PASSWORD = N'film2merde'
		,DEFAULT_DATABASE = [AdventureWorks2016]
		,DEFAULT_LANGUAGE = [us_english]
		,CHECK_EXPIRATION = OFF
		,CHECK_POLICY = OFF
GO

CREATE USER [mars_attack_user] FOR LOGIN [mars_attack_user]
GO

USE AdventureWorks2016
GO

/*
EXEC p_get_mars_attack;
EXEC p_get_mars_attack @nb_result = 2;
EXEC p_get_mars_attack @nb_result = 3;
*/
CREATE
	OR

ALTER PROCEDURE p_get_mars_attack (@nb_result TINYINT = 1)
AS
BEGIN
	SELECT TOP 10 AddressID
		,AddressLine1
		,AddressLine2
		,City
	FROM [Person].[Address];

	IF @nb_result > 1
	BEGIN
		SELECT TOP 10 BusinessEntityID
			,PersonType
			,NameStyle
		FROM [Person].[Person];
	END

	IF @nb_result > 2
	BEGIN
		SELECT TOP 10 ProductID
			,Name
		FROM [Production].[Product]
	END
END
GO

GRANT EXECUTE ON p_get_mars_attack TO [mars_attack_user];
