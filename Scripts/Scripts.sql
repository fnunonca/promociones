USE [Promociones]
GO
/****** Object:  Table [dbo].[promocion]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promocion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](500) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[estado] [tinyint] NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[usuarioModificacion] [varchar](50) NOT NULL,
	[fechaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_promocion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[promocionById]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
------------------------------------------------------------------------------------------------------------------------------
 
CREATE PROCEDURE [dbo].[promocionById]
(
    @id int
)
AS
BEGIN
 
    SET NOCOUNT ON;
 
    SELECT
        id,
        nombre,
        email,
        estado,
        codigo,
        usuarioModificacion,
        fechaModificacion
    FROM
        dbo.promocion
    WHERE
        id = @id;
 
    IF @@ROWCOUNT = 0
    BEGIN
        --+Return=NotFound
        RETURN 0;
    END;
 
    --+Return=Ok
    RETURN 1;
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionCanjearCodigo]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
------------------------------------------------------------------------------------------------------------------------------
 
CREATE PROCEDURE [dbo].[promocionCanjearCodigo]
(
    @codigo varchar(50),
    @estado tinyint,
    @usuarioModificacion varchar(50),
    @fechaModificacion datetime
)
AS
BEGIN
 
    SET NOCOUNT ON;
 
    UPDATE [dbo].[promocion] SET
        estado = @estado,
        usuarioModificacion = @usuarioModificacion,
        fechaModificacion = @fechaModificacion
    WHERE
        codigo = @codigo
 
    IF @@ROWCOUNT = 0
    BEGIN
        --+Return=NotFound
        SELECT 0;
    END;
 
    --+Return=Ok
    SELECT 1;
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionCheckCodigo]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[promocionCheckCodigo]
(
    @codigo varchar(50)
)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF EXISTS(
               SELECT id
               FROM promocion
               WHERE codigo = RTRIM(LTRIM(@codigo))
               AND estado > 0
              )
    BEGIN
        SELECT 1
    END
    ELSE
    BEGIN
        SELECT 0
    END
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionCheckEmail]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[promocionCheckEmail]
(
    @email varchar(200)
)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF EXISTS(
               SELECT id
               FROM promocion
               WHERE email = RTRIM(LTRIM(@email))
              )
    BEGIN
        SELECT 1
    END
    ELSE
    BEGIN
        SELECT 0
    END
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionDelete]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
------------------------------------------------------------------------------------------------------------------------------
 
CREATE PROCEDURE [dbo].[promocionDelete]
(
    @id int
)
AS
BEGIN
 
    SET NOCOUNT ON;
 
    DELETE FROM dbo.promocion
    WHERE
        id = @id;
 
    IF @@ROWCOUNT = 0
    BEGIN
        --+Return=NotFound
        SELECT 0;
    END;
 
    --+Return=Ok
    SELECT 1;
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionInsert]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[promocionInsert]
(
    @nombre varchar(500),
    @email varchar(200),
    @estado tinyint,
    @codigo varchar(50),
    @usuarioModificacion varchar(50),
    @fechaModificacion datetime
 
)
AS
BEGIN
 
    SET NOCOUNT ON;
 
    INSERT INTO [dbo].[promocion]
    (
        nombre,
        email,
        estado,
        codigo,
        usuarioModificacion,
        fechaModificacion
    )
    VALUES
    (
        @nombre,
        @email,
        @estado,
        @codigo,
        @usuarioModificacion,
        @fechaModificacion
    );
 
    IF(scope_identity() > 0)
    BEGIN
        SELECT 1
    END
    ELSE
    BEGIN
        SELECT 0
    END
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionQuery]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[promocionQuery]
(
    @nombre varchar(500) NULL,
    @email varchar(200) NULL
 
)
AS
BEGIN
 
    SET NOCOUNT ON;
 
    SELECT
        id,
        nombre,
        email,
        estado,
        codigo,
        usuarioModificacion,
        fechaModificacion
    FROM
        dbo.promocion
    WHERE
        (@nombre IS NULL OR nombre = @nombre OR @nombre = '') AND
        (@email IS NULL OR email = @email OR @nombre = '')
    IF @@ROWCOUNT = 0
    BEGIN
        --+Return=NotFound
        RETURN 0;
    END;
 
    --+Return=Ok
    RETURN 1;
 
END;
GO
/****** Object:  StoredProcedure [dbo].[promocionUpdate]    Script Date: 18/10/2021 10:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
------------------------------------------------------------------------------------------------------------------------------
 
CREATE PROCEDURE [dbo].[promocionUpdate]
(
    @id int,
    @nombre varchar(500),
    @email varchar(200),
    @estado tinyint,
    @codigo varchar(50),
    @usuarioModificacion varchar(50),
    @fechaModificacion datetime
 
)
AS
BEGIN
 
    SET NOCOUNT ON;
 
    UPDATE [dbo].[promocion] SET
        nombre = @nombre,
        email = @email,
        estado = @estado,
        codigo =@codigo,
        usuarioModificacion = @usuarioModificacion,
        fechaModificacion = @fechaModificacion
    WHERE
        id = @id
 
    IF @@ROWCOUNT = 0
    BEGIN
        --+Return=NotFound
        SELECT 0;
    END;
 
    --+Return=Ok
    SELECT 1;
 
END;
GO
