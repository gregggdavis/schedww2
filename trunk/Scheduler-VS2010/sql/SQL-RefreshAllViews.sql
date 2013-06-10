DECLARE @view AS VARCHAR(255) ;
DECLARE ListOfViews CURSOR FOR 

 SELECT  TABLE_SCHEMA + '.' +TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 

    WHERE TABLE_TYPE = 'VIEW' 

    AND OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'IsMsShipped') = 0 

    ORDER BY TABLE_SCHEMA,TABLE_NAME 

OPEN ListOfViews 

FETCH NEXT FROM ListOfViews 

into @view 

WHILE (@@FETCH_STATUS <> -1) 

 BEGIN FETCH NEXT FROM ListOfViews 

INTO @view 

 BEGIN TRY

     EXEC sp_refreshview @view;

     PRINT @view;

END TRY

BEGIN CATCH

     PRINT 'recorded error in this refreshView on : ' + @view;

END CATCH;

END 

CLOSE ListOfViews; 
DEALLOCATE ListOfViews;
