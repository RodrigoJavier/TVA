create database TVA_Tienda;
use TVA_Tienda;

CREATE TABLE CLIENTE
(
CLIENTE_ID int primary key identity(1,1),
NOMBRE VARCHAR(500),
CLAVE VARCHAR(10),
MAIL VARCHAR(1000),
ESTATUS VARCHAR(1000)
);
CREATE TABLE PRODUCTO
(
PRODUCTO_ID int primary key identity(1,1),
DESCRIPCION VARCHAR(500),
COSTO_UNITARIO decimal,
ESTATUS VARCHAR(1000)
);
CREATE TABLE VENTA
(
VENTA_ID int primary key identity(1,1),
FECHA Datetime,
CLIENTE_ID int,
ESTATUS VARCHAR(100),
constraint FK_VENTA_CLIENTE foreign key(CLIENTE_ID)
REFERENCES CLIENTE(CLIENTE_ID)
);
create TABLE DETALLE_VENTA
(
VENTA_ID int identity(1,1),
PRODUCTO_ID int,
CANTIDAD int,
DESCUENTO decimal,
TOTAL decimal, 
CONSTRAINT FK_DETALLE_PRODUCTO FOREIGN KEY(PRODUCTO_ID)
REFERENCES PRODUCTO(PRODUCTO_ID)
);


DECLARE @CLIENTE INT = 1; -- Variable para controlar el bucle
BEGIN TRANSACTION;
WHILE @CLIENTE <= 10
BEGIN
    -- Insertar cliente
    INSERT INTO CLIENTE (NOMBRE, CLAVE, MAIL, ESTATUS)
    VALUES ('CLIENTE ' + CAST(@CLIENTE AS VARCHAR(10)), 
            'CLIE_' + CAST(@CLIENTE AS VARCHAR(10)),
            'cliente' + CAST(@CLIENTE AS VARCHAR(10)) + '@clie.com',
            'ACTIVO');
    
    -- Incrementar el contador
    SET @CLIENTE = @CLIENTE + 1;
END;
-- Actualizar algunos clientes a INACTIVO
UPDATE CLIENTE
SET ESTATUS = 'INACTIVO'
WHERE CLIENTE_ID IN (3, 7, 10);
COMMIT;



DECLARE @PRODUCTO INT = 1;  -- Variable para controlar el bucle
DECLARE @COSTO_UNITARIO DECIMAL(10, 2);  -- Variable para el costo aleatorio
BEGIN TRANSACTION;
WHILE @PRODUCTO <= 15
BEGIN
    -- Generar un valor aleatorio entre 1 y 9999 con dos decimales
    SET @COSTO_UNITARIO = ROUND((RAND() * (9999 - 1) + 1), 2);

    -- Insertar producto
    INSERT INTO PRODUCTO (DESCRIPCION, COSTO_UNITARIO, ESTATUS)
    VALUES ('PRODUCTO ' + CAST(@PRODUCTO AS VARCHAR(10)), @COSTO_UNITARIO, 'ACTIVO');
    
    -- Incrementar el contador
    SET @PRODUCTO = @PRODUCTO + 1;
END;
-- Actualizar el estatus de algunos productos a 'INACTIVO'
UPDATE PRODUCTO
SET ESTATUS = 'INACTIVO'
WHERE PRODUCTO_ID IN (5, 11, 13);
COMMIT;

select * from cliente;


--procedimientos almacenados
create proc pa_obtener_clientes
as
begin 
	select * from CLIENTE;
end
---productos activos
create proc pa_obtener_productos_activos
as
begin 
	select * from PRODUCTO WHERE ESTATUS='ACTIVO';
end

exec ObtenerDetalleVentasPorCliente
CREATE PROCEDURE ObtenerDetalleVentasPorCliente
AS
BEGIN
    SELECT 
        C.CLAVE,
        C.NOMBRE,
        C.MAIL,
        V.FECHA,
        SUM(DV.TOTAL) AS TOTAL
    FROM 
        CLIENTE C
    INNER JOIN 
        VENTA V ON C.CLIENTE_ID = V.CLIENTE_ID
    INNER JOIN 
        DETALLE_VENTA DV ON V.VENTA_ID = DV.VENTA_ID
    GROUP BY 
        C.CLAVE, C.NOMBRE, C.MAIL, V.FECHA
    ORDER BY 
        V.FECHA;
END;


select * from detalle_venta
CREATE PROCEDURE pa_insertar_venta
    @Fecha DATETIME,
    @ClienteID INT,
    @Estatus VARCHAR(100)
AS
BEGIN
    -- Inicio de la transacción (opcional si se desea garantizar atomicidad)
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Inserción de los datos en la tabla VENTA
        INSERT INTO VENTA (FECHA, CLIENTE_ID, ESTATUS)
        VALUES (@Fecha, @ClienteID, @Estatus);

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, se hace rollback
        ROLLBACK TRANSACTION;

        -- Manejo de errores: devolver el error que ocurrió
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT @ErrorMessage = ERROR_MESSAGE(),
               @ErrorSeverity = ERROR_SEVERITY(),
               @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;



select * from DETALLE_VENTA
create PROCEDURE pa_insertar_detalle_venta
    @ProductoID INT,
    @Cantidad INT,
    @Descuento DECIMAL(18, 2),
    @Total DECIMAL(18, 2)
AS
BEGIN
    -- Inicio de la transacción (opcional)
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Inserción de los datos en la tabla DETALLE_VENTA
        INSERT INTO DETALLE_VENTA (PRODUCTO_ID, CANTIDAD, DESCUENTO, TOTAL)
        VALUES ( @ProductoID, @Cantidad, @Descuento, @Total);

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, se revierte la transacción
        ROLLBACK TRANSACTION;

        -- Manejo de errores: devolver el error que ocurrió
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT @ErrorMessage = ERROR_MESSAGE(),
               @ErrorSeverity = ERROR_SEVERITY(),
               @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
