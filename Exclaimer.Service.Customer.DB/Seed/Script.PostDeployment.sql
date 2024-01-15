BEGIN TRY
    BEGIN TRANSACTION; -- Start a new transaction

    -- Insert sample data into the Customer table
    INSERT INTO [dbo].[Customer] (FirstName, LastName, Email, PhoneNumber, Address, City, State, PostalCode, Country, DateOfBirth)
    VALUES
        ('John', 'Doe', 'john.doe@example.com', '123-456-7890', '123 Main St', 'Anytown', 'CA', '12345', 'USA', '1985-01-15'),
        ('Jane', 'Smith', 'jane.smith@example.com', '987-654-3210', '456 Elm St', 'Somewhere', 'NY', '54321', 'USA', '1990-03-20'),
        ('Bob', 'Johnson', 'bob.johnson@example.com', '555-123-4567', '789 Oak St', 'Nowhere', 'TX', '67890', 'USA', '1978-09-10');

    -- Check for errors and decide whether to commit or rollback the transaction
    IF @@ERROR = 0
    BEGIN
        COMMIT; -- If no errors occurred, commit the transaction
        PRINT 'Transaction committed.';
    END
    ELSE
    BEGIN
        ROLLBACK; -- If an error occurred, rollback the transaction
        PRINT 'Transaction rolled back due to an error.';
    END
END TRY
BEGIN CATCH
    ROLLBACK; -- Rollback the transaction if an exception is caught
    PRINT 'Transaction rolled back due to an exception.';
END CATCH;