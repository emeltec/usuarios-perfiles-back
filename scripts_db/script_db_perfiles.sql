USE [master]
GO
/****** Object:  Database [DB_USUARIOS_PERFILES]    Script Date: 13/01/2024 22:57:09 ******/
CREATE DATABASE [DB_USUARIOS_PERFILES]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_USUARIOS_PERFILES', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_USUARIOS_PERFILES.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_USUARIOS_PERFILES_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_USUARIOS_PERFILES_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_USUARIOS_PERFILES].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET  MULTI_USER 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_USUARIOS_PERFILES]
GO
/****** Object:  Table [dbo].[MODULOS]    Script Date: 13/01/2024 22:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MODULOS](
	[mod_id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[mod_titulo] [varchar](50) NULL,
	[mod_url] [varchar](50) NULL,
	[mod_icono] [varchar](120) NULL,
	[mod_orden] [int] NULL,
	[mod_indica_sub_menu] [int] NULL,
	[mod_indica_visible] [int] NULL,
	[mod_estado_registro] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPCIONES]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPCIONES](
	[opc_id_opcion] [int] IDENTITY(1,1) NOT NULL,
	[opc_id_modulo] [int] NOT NULL,
	[opc_titulo] [varchar](50) NULL,
	[opc_descripcion] [varchar](150) NULL,
	[opc_url] [varchar](100) NULL,
	[opc_icono] [varchar](20) NULL,
	[opc_orden] [int] NULL,
	[opc_indica_visible] [int] NULL,
	[opc_estado_registro] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFIL_OPCION]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERFIL_OPCION](
	[peopc_id_perfil_opcion] [int] IDENTITY(1,1) NOT NULL,
	[peopc_id_perfil] [int] NOT NULL,
	[peopc_id_opcion] [int] NOT NULL,
	[peopc_estado_registro] [int] NULL,
	[peopc_acceso_visualizar] [int] NULL,
	[peopc_acceso_crear] [int] NULL,
	[peopc_acceso_actualizar] [int] NULL,
	[peopc_acceso_eliminar] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFILES]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERFILES](
	[per_id_perfil] [int] IDENTITY(1,1) NOT NULL,
	[per_nombre_perfil] [varchar](40) NULL,
	[per_descripcion_perfil] [varchar](120) NULL,
	[per_estado_registro] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[usu_id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usu_nombres] [varchar](120) NULL,
	[usu_apellido_paterno] [varchar](120) NULL,
	[usu_apellido_materno] [varchar](20) NULL,
	[usu_numero_documento] [varchar](15) NULL,
	[usu_clave] [varchar](2000) NULL,
	[usu_id_perfil] [int] NULL,
	[usu_correo_electronico] [varchar](40) NULL,
	[usu_numero_telefonico] [varchar](120) NULL,
	[usu_estado_registro] [int] NULL,
	[usu_cantidad_intentos] [int] NULL,
	[usu_tipo_documento] [int] NULL,
	[usu_indica_bloqueo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_PERFIL_LISTAR]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in

-- [dbo].[SP_PERFIL_LISTAR]

CREATE PROCEDURE [dbo].[SP_PERFIL_LISTAR] 
(
@p_nombre_perfil VARCHAR(50) = ''
)
AS
BEGIN

	SELECT
		per.per_id_perfil AS id_perfil
	   ,per.per_nombre_perfil AS nombre_perfil
	   ,per.per_descripcion_perfil AS descripcion_perfil
	   ,per.per_estado_registro AS estado_registro
	   ,COUNT(per.per_id_perfil) OVER() AS totalRecord
	FROM PERFILES per
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PERFIL_OPCION_LISTAR]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--USE DB_USUARIOS_PERFILES
-- [dbo].[SP_PERFIL_OPCION_LISTAR] 3 

CREATE PROCEDURE [dbo].[SP_PERFIL_OPCION_LISTAR] 
(
	@p_id_perfil int
)
AS
BEGIN
	DECLARE @tbl AS TABLE (
		id INT IDENTITY(1,1),
		id_perfil_opcion INT,
		id_modulo INT,
		id_perfil INT,
		id_opcion INT,

		modulo_titulo VARCHAR(50),
		opcion_titulo VARCHAR(50),
		opcion_url VARCHAR(50),
		nombre_perfil VARCHAR(50),

		acceso_visualizar INT,
		acceso_crear INT,
		acceso_actualizar INT,
		acceso_eliminar INT
	)

	INSERT INTO @tbl SELECT
		0,
		0,
		0,
		ISNULL(op.opc_id_opcion, 0) AS id_opcion,

		mo.mod_titulo AS modulo_titulo,
		op.opc_titulo AS opcion_titulo,
		op.opc_url AS opcion_url,
		'' AS nombre_perfil,

		CAST(0 AS BIT) AS acceso_visualizar,
		CAST(0 AS BIT) AS acceso_crear,
		CAST(0 AS BIT) AS acceso_actualizar,
		CAST(0 AS BIT) AS acceso_eliminar

		FROM OPCIONES op
		INNER JOIN MODULOS mo ON op.opc_id_modulo = mo.mod_id_modulo
		WHERE op.opc_estado_registro NOT IN(0)
		AND mo.mod_estado_registro NOT IN (0)

	DECLARE @v_count INT = 1

	DECLARE @v_id_perfil_opcion INT = 0,
			@v_id_modulo INT = 0,
			@v_id_perfil INT = 0,
			@v_id_opcion INT = 0,

			@v_opcion_titulo VARCHAR(50),
			@v_nombre_perfil VARCHAR(50),

			@v_visualizar INT = 0,
			@v_crear INT = 0,
			@v_actualizar INT = 0,
			@v_eliminar INT = 0

	WHILE(@v_count <= (SELECT COUNT(id) FROM @tbl))
	BEGIN
		SELECT
			@v_id_perfil_opcion = peop.peopc_id_perfil_opcion,
			@v_id_modulo = mo.mod_id_modulo,
			@v_id_perfil = peop.peopc_id_perfil,
			@v_id_opcion = op.opc_id_opcion,

			@v_opcion_titulo = op.opc_titulo,
			@v_nombre_perfil = pe.per_nombre_perfil,

			@v_visualizar = peop.peopc_acceso_visualizar,
			@v_crear = peop.peopc_acceso_crear,
			@v_actualizar = peop.peopc_acceso_actualizar,
			@v_eliminar = peop.peopc_acceso_eliminar

			FROM PERFIL_OPCION peop
			LEFT JOIN PERFILES pe ON peop.peopc_id_perfil = pe.per_id_perfil
			LEFT JOIN OPCIONES op ON peop.peopc_id_opcion = op.opc_id_opcion
			LEFT JOIN MODULOS mo ON op.opc_id_modulo = mo.mod_id_modulo
			WHERE
			peop.peopc_id_perfil = @p_id_perfil
			AND peop.peopc_id_opcion IN(SELECT id_opcion FROM @tbl WHERE id = @v_count)
			AND (peop.peopc_estado_registro NOT IN(0))
			AND (pe.per_estado_registro NOT IN(0))
			AND (op.opc_estado_registro NOT IN(0))
			AND (mo.mod_estado_registro NOT IN(0))

			UPDATE t1
			SET 
			id_perfil_opcion = @v_id_perfil_opcion,
			id_modulo = @v_id_modulo,
			id_perfil = @p_id_perfil,
			nombre_perfil = @v_nombre_perfil,

			acceso_visualizar = CAST(ISNULL(@v_visualizar, 0) AS BIT),
			acceso_crear = CAST(ISNULL(@v_crear, 0) AS BIT),
			acceso_actualizar = CAST(ISNULL(@v_actualizar, 0) AS BIT),
			acceso_eliminar = CAST(ISNULL(@v_eliminar, 0) AS BIT)

			FROM @tbl t1
			WHERE id_opcion = @v_id_opcion

			SET @v_count = @v_count + 1
	END

	SELECT *, 
	COUNT(t2.id_perfil_opcion) OVER() AS totalrecord 
	FROM @tbl t2 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PERFIL_OPCION_LISTAR_2]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[SP_PERFIL_OPCION_LISTAR_2] 2

CREATE PROCEDURE [dbo].[SP_PERFIL_OPCION_LISTAR_2] 
(
	@p_id_perfil int
)
AS
BEGIN
	SELECT
		peop.peopc_id_perfil_opcion AS id_perfil_opcion,
		mo.mod_id_modulo AS id_modulo,
		peop.peopc_id_perfil AS id_perfil,
		op.opc_id_opcion AS id_opcion,

		mo.mod_titulo AS modulo_titulo,
		op.opc_titulo AS opcion_titulo,
		op.opc_url AS opcion_url,
		pe.per_nombre_perfil AS nombre_perfil,

		CAST(ISNULL(peop.peopc_acceso_visualizar, 0) AS BIT) AS acceso_visualizar,
		CAST(ISNULL(peop.peopc_acceso_crear, 0) AS BIT) AS acceso_crear,
		CAST(ISNULL(peop.peopc_acceso_actualizar, 0) AS BIT) AS acceso_actualizar,
		CAST(ISNULL(peop.peopc_acceso_eliminar, 0) AS BIT) AS acceso_eliminar,

		COUNT(peop.peopc_id_perfil_opcion) OVER() AS totalrecord

		--FROM PERFIL_OPCION peop
		--	LEFT JOIN PERFILES pe ON peop.peopc_id_perfil = pe.per_id_perfil
		--	LEFT JOIN OPCIONES op ON peop.peopc_id_opcion = op.opc_id_opcion
		--	LEFT JOIN MODULOS mo ON op.opc_id_modulo = mo.mod_id_modulo
		FROM OPCIONES op 
			LEFT JOIN PERFIL_OPCION peop ON peop.peopc_id_opcion = op.opc_id_opcion
			LEFT JOIN PERFILES pe ON pe.per_id_perfil = peop.peopc_id_perfil
			LEFT JOIN MODULOS mo ON op.opc_id_modulo = mo.mod_id_modulo
			WHERE
			peop.peopc_id_perfil = @p_id_perfil
			AND peop.peopc_estado_registro NOT IN(0)
			AND pe.per_estado_registro NOT IN(0)
			AND op.opc_estado_registro NOT IN(0)
			AND mo.mod_estado_registro NOT IN(0)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_PERFIL_OPCION_NUEVO_LISTAR]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- [dbo].[SP_PERFIL_OPCION_NUEVO_LISTAR] 2

CREATE PROCEDURE [dbo].[SP_PERFIL_OPCION_NUEVO_LISTAR] 
(
	@p_id_perfil INT = -1
)
AS
BEGIN
	SELECT 
	op.opc_id_opcion AS id_perfil_opcion,
	mo.mod_id_modulo AS id_modulo,
	0 AS id_perfil,
	op.opc_id_opcion AS id_opcion,
	mo.mod_titulo AS modulo_titulo,
	op.opc_titulo AS opcion_titulo,
	op.opc_url AS opcion_url,
	'' AS nombre_perfil,
	CAST(0 AS BIT) AS acceso_visualizar,
	CAST(0 AS BIT) AS acceso_crear,
	CAST(0 AS BIT) AS acceso_actualizar,
	CAST(0 AS BIT) AS acceso_eliminar,

	COUNT(op.opc_id_opcion) OVER() AS totalRecord

	FROM MODULOS mo
	INNER JOIN OPCIONES op ON mo.mod_id_modulo = op.opc_id_modulo
	WHERE 
	mo.mod_estado_registro NOT IN(0)
	AND op.opc_estado_registro NOT IN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PERFIL_OPCION_REGISTAR]    Script Date: 13/01/2024 22:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- [dbo].[SP_PERFIL_OPCION_REGISTAR]

CREATE PROCEDURE [dbo].[SP_PERFIL_OPCION_REGISTAR] 
(
	@p_id_perfil_opcion INT,
	@p_id_perfil INT,
	@p_id_opcion INT,
	@p_acceso_crear INT,
	@p_acceso_actualizar INT,
	@p_acceso_eliminar INT,
	@p_acceso_visualizar INT
)
AS
BEGIN
	IF(@p_id_perfil_opcion = 0)
	BEGIN
		IF (NOT EXISTS(SELECT 1 FROM PERFIL_OPCION po))
		BEGIN
			SET @p_id_perfil_opcion = 1
		END
		ELSE 
		BEGIN
			SELECT TOP 1 @p_id_perfil_opcion = peopc_id_perfil_opcion + 1 FROM PERFIL_OPCION ORDER BY peopc_id_perfil_opcion DESC
		END

		INSERT INTO PERFIL_OPCION
			(
				peopc_id_perfil_opcion
				,peopc_id_perfil
				,peopc_id_opcion
				,peopc_estado_registro
				,peopc_acceso_visualizar
				,peopc_acceso_crear
				,peopc_acceso_actualizar
				,peopc_acceso_eliminar
			)
			VALUES
			(
				@p_id_perfil_opcion,
				@p_id_perfil,
				@p_id_opcion,
				1,
				@p_acceso_visualizar,
				@p_acceso_crear,
				@p_acceso_actualizar,
				@p_acceso_eliminar
			);

			SELECT @p_id_perfil_opcion AS id 
	END

	ELSE 
		BEGIN 
			UPDATE PERFIL_OPCION SET
				peopc_id_perfil = @p_id_perfil,
				peopc_id_opcion = @p_id_opcion,
				peopc_estado_registro = 1,
				peopc_acceso_visualizar = @p_acceso_visualizar,
				peopc_acceso_crear = @p_acceso_crear,
				peopc_acceso_actualizar = @p_acceso_actualizar,
				peopc_acceso_eliminar = @p_acceso_eliminar
			WHERE peopc_id_perfil_opcion = @p_id_perfil_opcion

			SELECT @p_id_perfil_opcion AS id
		END
END
GO
USE [master]
GO
ALTER DATABASE [DB_USUARIOS_PERFILES] SET  READ_WRITE 
GO
