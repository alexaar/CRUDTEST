CREATE PROCEDURE sp_update_actor  
@id INT
@nombres VARCHAR(25),  
@apellidos VARCHAR(25)
AS 
UPDATE ACTOR SET  
       [NOMBRES] = @nombres,
       [APELLIDOS] = @apellidos
       WHERE ID_ACTOR= @id
GO