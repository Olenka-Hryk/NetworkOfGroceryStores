--Додавання продукту в таблицю Products
--INSERT INTO Products
--VALUES (10, 'Окунь', 'Західний Буг');

--Вибірка продуктів
--SELECT pr.Name, pr.Firm, res.BarCode, res.Quantity, res.Price, res.ExpirationDate
--FROM Products pr, Reserve res
--WHERE res.ID_product=pr.ID_product AND
--       res.ExpirationDate < GETDATE();

--Додавання знижок
--INSERT INTO Sale
--VALUES(10116, 2, 'Акція дня', '2017-04-29', '2017-04-30');

--Зчитування наявних знижок на товари
--SELECT prd.Name, prd.Firm, sal.Percents
--FROM Products prd, Sale sal
--WHERE sal.ID_products = prd.ID_product
--ORDER BY sal.Percents DESC;

--Додавання нового клієнта
--INSERT INTO Customers
--VALUES ('Урбанська', 'Надія', 'Романівна', '1997-10-19', '+38067488908', 2500009754456, 0);

--Зчитування інформації про продукт за штрих-кодом
--SELECT pr.Name, pr.Firm, res.BarCode, res.Quantity, res.Price, res.ExpirationDate
--FROM Products pr, Reserve res
--WHERE res.ID_product=pr.ID_product AND
--       res.BarCode = 5997207710014;

--Додавання нового замовлення за відомим штрих-кодом та прізвищем продавця:
--INSERT INTO Orders (ID_sale,ID_reserve,ID_workers,TotalSum)
--VALUES((SELECT sal.ID_sale FROM Sale sal, Reserve res WHERE res.BarCode = 5997207710014 AND sal.ID_products=res.ID_product), (SELECT ID_reserve FROM Reserve WHERE BarCode = 5997207710014), (SELECT ID_workers  FROM Workers WHERE Surname = 'Носаль'), 123.98)

--Оновлення інформації про клієнта
--UPDATE Customers 
--SET PhoneNumder ='+38067488908'  WHERE NumberCard = 2500009754456

--Видалення інформації про клієнта
--DELETE * FROM Customers cus
--WHERE ID_customers = (SELECT ID_customers FROM Cheque WHERE ID_customers = cus.ID_customers);


--Видалення інформації про знижку
--DELETE 
--FROM Sale 
--WHERE DateOfFinish < GETDATE();

--Додавання інформації про магазин
--INSERT INTO Store
--VALUES ('ТзОВ ТВК "Львівхолод" Магазин "Рукавичка" м.Львів, вул.Шота Руставелі, 40', 1)

--Редагування інформації про продукт
--UPDATE Reserve
--SET Price = 89.95
--WHERE
--  BarCode= 5997289942214

--Редагування інформації про працівника
--UPDATE Timetable
--SET Salary = 600
--WHERE ID_workers = (SELECT ID_workers FROM Workers WHERE Surname = 'Марцінко' AND Name = 'Надія')

--Редагування кінцевої суми в замовленні
--UPDATE Orders
--SET TotalSum = (SELECT Price FROM Reserve WHERE Orders.ID_reserve = Reserve.ID_reserve) /
--               (SELECT Percents FROM Sale WHERE Orders.ID_sale = Sale.ID_sale)

--Вивід списку продуктів по торгових відділах
--DECLARE @NAME_SUBTYPE VARCHAR(35),
--        @ID INT,
--        @NAME_PRODUCT VARCHAR(80),
--		@FIRM VARCHAR(50),
--		@PRICES FLOAT,
--        @BARCODE VARCHAR(13),       
--        @message  VARCHAR(100)

--PRINT '							 СПИСОК ПРОДУКТІВ ПО ТОРГОВИХ ВІДДІЛАХ: '
--DECLARE cursorSubtype CURSOR LOCAL FOR
--    SELECT Name, ID_subtypes
--    FROM Subtypes
--  --  ORDER BY ID_groupProduct

--OPEN cursorSubtype
--FETCH NEXT FROM cursorSubtype
--INTO @NAME_SUBTYPE, @ID
--WHILE @@FETCH_STATUS=0
--BEGIN
--    PRINT ' '
--	PRINT ' '
--	PRINT ' '
--    SELECT @message='Група ******					'+ @NAME_SUBTYPE
--    PRINT @message
--	PRINT '__________________________________________________________________________________________________________'
--    SELECT @message='Назва продукту					Виробник					Ціна					Штрихкод'
--    PRINT @message
--	PRINT '__________________________________________________________________________________________________________'
--    DECLARE cursorProduct CURSOR FOR
--        SELECT prd.Name, prd.Firm, res.Price, res.BarCode
--        FROM Reserve res, Products prd
--        WHERE prd.ID_subtypes = @ID
--		AND prd.ID_product = res.ID_product

--    OPEN cursorProduct
--    FETCH NEXT FROM cursorProduct
--      INTO @NAME_PRODUCT, @FIRM, @PRICES, @BARCODE
--    IF @@FETCH_STATUS<>0
--        PRINT ' Немає продуктів'
--    WHILE @@FETCH_STATUS=0
--    BEGIN
--        SELECT @message= CONVERT(VARCHAR(80),@NAME_PRODUCT,103)+'	'+ CONVERT(VARCHAR(50),@FIRM,103)+'	'+ CONVERT(VARCHAR(10),@PRICES,103)+'	'+ CONVERT(VARCHAR(50),@BARCODE,103)
--        PRINT @message
--        FETCH NEXT FROM cursorProduct
--        INTO @NAME_PRODUCT, @FIRM, @PRICES, @BARCODE
--    END
--    CLOSE cursorProduct
--    DEALLOCATE cursorProduct  

--    FETCH NEXT FROM cursorSubtype
--    INTO @NAME_SUBTYPE, @ID
--END


--Транзакція оновлення інформації про товар на складі 
--DECLARE
--@tempID_reserve INT,
--@tempID_store INT = 1,
--@tempID_product INT = 10104,
--@tempID_sal_res_inv INT = 90003,
--@tempExpirationDate DATE = '2017-11-28',
--@tempQuantity INT = 14,
--@tempPrice FLOAT = 13.14,
--@tempBarCode VARCHAR(13) = 5994332466735,
--@temProductSize FLOAT = 290
----------------------TRASACTION------------------------------------
--BEGIN TRY
--	BEGIN TRAN
--	SET @tempID_reserve = ISNULL((SELECT Reserve.ID_reserve FROM Reserve WHERE Reserve.ID_product = @tempID_Product), 0)
--	IF @tempID_reserve = 0
--	BEGIN
--		INSERT INTO Reserve(ID_reserve, ID_store, ID_product, ID_sal_res_inv, ExpirationDate, Quantity,  Price, BarCode, ProductSize)
--			VALUES (0 , @tempID_store, @tempID_product, @tempID_sal_res_inv, @tempExpirationDate, @tempQuantity, @tempPrice, @tempBarCode, @temProductSize)
--	END
--	ELSE
--	BEGIN
--		UPDATE Reserve
--		SET Reserve.ExpirationDate = @tempExpirationDate, Reserve.Quantity = @tempQuantity, Reserve.Price = @tempPrice, Reserve.BarCode = @tempBarCode, Reserve.ProductSize = @temProductSize
--		WHERE Reserve.ID_reserve = @tempID_reserve
--	END
--	COMMIT TRAN
--END TRY
--BEGIN CATCH
--	ROLLBACK TRAN
--END CATCH;
--GO


--------------------------------------Транзакція при купівлі товарів 
------------------------------------DECLARE 
------------------------------------@tempChequeId INT = 114, 
------------------------------------@tempCosId INT = 0, 
------------------------------------@tempWorkerId INT = 35121, 
------------------------------------@tempSaleId INT = 1304, 
------------------------------------@tempReserveId INT = 11006,
------------------------------------@tempQOrders INT = 1, 
------------------------------------@tempNameGS VARCHAR(50) = 'ТзОВ ТВК "Львівхолод" Магазин "Рукавичка"', 
------------------------------------@tempAddressGS VARCHAR(80) = 'м.Львів, вул.Городоцька, 76', 
------------------------------------@tempPriceOrd FLOAT = 754.21, 
------------------------------------@DateOrder DATE = '2017-05-29', 
-----------------------------------------------------ID DEP--------— 
-------------------------------------------------------CLIENT INFO —------------------------------— 
------------------------------------@cosSurname VARCHAR(50) = 'Андрущакевич', 
------------------------------------@cosName VARCHAR(50) = 'Оксана', 
------------------------------------@cosNumberCard VARCHAR(16) = '2500007546787', 
------------------------------------@DateOfBirth_customer DATE = '1990-05-29' 
--------------------------------------------------------BUY ITEMS----------------------------------— 
------------------------------------DECLARE @ItemsTable TABLE (_Price money, WgID INT) 

------------------------------------INSERT INTO @ItemsTable (_Price, WgID) VALUES 
------------------------------------(1.000,2002),(10,3003),(15.21,4004) 
--------------------------------------------------------TRASACTION----------------------------------— 
------------------------------------BEGIN TRY 
------------------------------------   BEGIN TRAN 
------------------------------------      SET @tempCosId = ISNULL((SELECT Customers.ID_customers FROM Customers WHERE Surname =     
------------------------------------    @cosSurname AND Name=@cosName AND NumberCard = @cosNumberCard AND    
------------------------------------     DateOfBirth = @DateOfBirth_customer),0) 
------------------------------------IF @tempCosId = 0 
------------------------------------BEGIN 
------------------------------------   INSERT INTO Customers(Surname, Name, NumberCard,DateOfBirth) 
------------------------------------      VALUES (@cosSurname, @cosName, @cosNumberCard, @DateOfBirth_customer) 
------------------------------------    SET @tempCosId = @@IDENTITY 
------------------------------------END 
------------------------------------INSERT INTO Cheque(ID_sale, ID_customers, ID_order,ID_reserve, Amount, OrderData) 
------------------------------------   VALUES (@tempSaleId, @tempCosId, @tempChequeId,  @tempReserveId,  @tempQOrders, @DateOrder) 
------------------------------------     SET @tempChequeId = @@IDENTITY 
------------------------------------INSERT INTO Orders(ID_sale,ID_reserve, ID_workers,TotalSum) 
------------------------------------    SELECT  @tempSaleId, @tempReserveId, @tempWorkerId, @tempPriceOrd
------------------------------------FROM @ItemsTable 
------------------------------------INNER JOIN Reserve 
------------------------------------ON Reserve.ID_product = WgID 

------------------------------------UPDATE Orders SET Orders.ID_order = (SELECT SUM(Orders.TotalSum) FROM Orders WHERE 
------------------------------------Orders.ID_order = @tempChequeId) 
------------------------------------WHERE Orders.ID_order = @tempChequeId 
------------------------------------   COMMIT TRAN 
------------------------------------END TRY 
------------------------------------BEGIN CATCH 
------------------------------------   ROLLBACK TRAN 
------------------------------------END CATCH; 
------------------------------------GO


--Видалення запису в таблиці за відомим полем
--CREATE PROCEDURE proc_deleteWorkers AS
--SELECT
--ERROR_NUMBER()AS ErrorNumber,
--ERROR_SEVERITY()AS ErrorSeverity,
--ERROR_STATE()AS ErrorState,
--	ERROR_LINE()AS ErrorLine,
--		ERROR_PROCEDURE()AS ErrorProcedure,
--			ERROR_MESSAGE()AS ErrorMessage;
--		SET XACT_ABORT ON;
--		BEGIN TRY
--			BEGIN TRANSACTION;
--			DELETE FROM Workers	          
--			WHERE Surname = 'Заліско'
--			COMMIT TRANSACTION;
--			END TRY BEGIN CATCH
--				EXECUTE proc_deleteWorkers;
--					IF (XACT_STATE())=-1     
--			BEGIN PRINT'Транзація нефіксована. Відкат'
--			ROLLBACK TRANSACTION; END;
--			IF (XACT_STATE())= 1     BEGIN
--				PRINT'Транзакція фіксована. COMMIT'
--COMMIT TRANSACTION;
--END;
--END CATCH;


--Вставка нового запису в таблицю
--CREATE PROCEDURE proc_InsertWorkers AS
--SELECT
--ERROR_NUMBER()AS ErrorNumber,
--ERROR_SEVERITY()AS ErrorSeverity,
--ERROR_STATE()AS ErrorState,
--	ERROR_LINE()AS ErrorLine,
--		ERROR_PROCEDURE()AS ErrorProcedure,
--			ERROR_MESSAGE()AS ErrorMessage;

--		SET XACT_ABORT ON;
--		BEGIN TRY
--			BEGIN TRANSACTION;
--			INSERT INTO Workers   
--             (Surname, Name, MiddleName, DateOfBirth)
--	VALUES('Урбанська','Надія', 'Ярославівна', '1980-09-20')

--				COMMIT TRANSACTION;
--				END TRY
--				BEGIN CATCH
--				EXECUTE proc_InsertWorkers;
--					IF (XACT_STATE())=-1     
--			BEGIN PRINT'Транзація нефіксована. Відкат'
--			ROLLBACK TRANSACTION;END;
--			IF (XACT_STATE())= 1     BEGIN
--				PRINT'Транзакціяфіксована. COMMIT'
--COMMIT TRANSACTION;
--END;
--END CATCH;


--------------------------------Вставка нового продукту
------------------------------CREATE PROCEDURE InsertNewProducts(
------------------------------				  @NameSubtypes VARCHAR(35),
------------------------------                  @Name VARCHAR(80),
------------------------------				  @Firm VARCHAR(50),
------------------------------				  @BarCode VARCHAR(13),
------------------------------				  @Price MONEY,
------------------------------				  @Quantity INT,
------------------------------				  @ExpirationDate DATE,				  		  
------------------------------				  @ProductSize FLOAT)
------------------------------AS
------------------------------DECLARE 
------------------------------@MaxIDproducts int,
------------------------------@MaxIDreserve int,
------------------------------@IDSubtypes int

------------------------------BEGIN TRANSACTION
------------------------------SET @MaxIDproducts = (SELECT MAX(ID_product) + 1 FROM Products) 
------------------------------SET @IDSubtypes = (SELECT MAX(ID_subtypes) + 1 FROM Subtypes) 
------------------------------INSERT INTO Products VALUES 
------------------------------(
------------------------------	@MaxIDproducts, 
------------------------------	@IDSubtypes,
------------------------------	@Name,
------------------------------	@Firm
------------------------------)
------------------------------SET @MaxIDreserve = (SELECT MAX(ID_reserve) + 1 FROM Reserve)
------------------------------INSERT INTO Reserve VALUES 
------------------------------(
------------------------------	@MaxIDreserve, 
------------------------------	1,
------------------------------	@MaxIDproducts,
------------------------------	@ExpirationDate,
------------------------------	@Quantity,
------------------------------	@Price,
------------------------------	@BarCode,
------------------------------	@ProductSize
------------------------------)
------------------------------IF ((SELECT COUNT(ID_subtypes) FROM Subtypes WHERE ID_subtypes = @IDSubtypes)> 0)
------------------------------BEGIN
------------------------------PRINT 'Transaction successful.'
------------------------------COMMIT TRANSACTION
------------------------------END
------------------------------ELSE
------------------------------BEGIN
------------------------------PRINT 'Error'
------------------------------ROLLBACK TRANSACTION
------------------------------END


------------------------------DECLARE @return_value INT
------------------------------EXEC @return_value = dbo.InsertNewProducts
------------------------------	 @ID_groupProduct = 254,
------------------------------	 @BarCode = 987689890643,
------------------------------	 @Name = 'Лосось',
------------------------------	 @Firm = 'Аляска',
------------------------------	 @Price = 165.59,                                 
------------------------------	 @DeliveryDate = '2016-12-16',
------------------------------	 @ExpirationDate = '2017-01-10',
------------------------------	 @Quantity = 22,
------------------------------	 @Weight = 250
------------------------------SELECT 'Return Value' = @return_value
                            
--Оптимізація виконання запитів
--CREATE UNIQUE INDEX Searsh_customer_NumberCard ON Customers(NumberCard)
--CREATE UNIQUE INDEX Searsh_workers_Surname ON Workers(Surname)
--CREATE UNIQUE INDEX Searsh_products_Name ON Products(Name)
--CREATE UNIQUE INDEX Searsh_store_Name ON Store(Name)
--CREATE UNIQUE INDEX Searsh_reserve_ExpirationData ON Reserve(ExpirationDate)
--CREATE UNIQUE INDEX Searsh_reserve_BarCode ON Reserve(BarCode)
--CREATE UNIQUE INDEX Searsh_subtypes_Name ON Subtypes(Name)

--------------CREATE UNIQUE INDEX NCLIX_Products_Idproduct ON Products(ID_product)
--------------SELECT *
--------------FROM Products WITH (INDEX(NCLIX_Products_Idproduct))
--------------WHERE ID_product > 10104
--------------ORDER BY ID_product 


--CREATE UNIQUE INDEX NCLIX_Reserve_BarCode ON Reserve(BarCode)