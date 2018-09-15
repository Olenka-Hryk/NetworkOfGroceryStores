CREATE TABLE Cheque
(
	ID_cheque            INT NOT NULL ,
	ID_order             INT NOT NULL ,
	ID_reserve           INT NOT NULL ,
	ID_customers         INT NOT NULL ,
	ID_sale              INT NOT NULL ,
	Amount               INT NULL ,
	OrderData            DATE NULL 
);



CREATE UNIQUE INDEX XPKCheck ON Cheque
(ID_cheque   ASC);



ALTER TABLE Cheque
	ADD  PRIMARY KEY (ID_cheque);



CREATE  INDEX XIF2Check ON Cheque
(ID_reserve   ASC);



CREATE  INDEX XIF3Check ON Cheque
(ID_order   ASC);



CREATE  INDEX XIF4Check ON Cheque
(ID_customers   ASC);



CREATE  INDEX XIF5Check ON Cheque
(ID_sale   ASC);



CREATE TABLE Customers
(
	ID_customers         INT NOT NULL ,
	Surname              VARCHAR(50) NULL ,
	Name                 VARCHAR(50) NULL ,
	MiddleName           VARCHAR(50) NULL ,
	DateOfBirth          DATE NULL ,
	PhoneNumder          VARCHAR(20) NULL ,
	NumberCard           VARCHAR(16) NULL ,
	Discount             INT NULL 
);



CREATE UNIQUE INDEX XPKCustomers ON Customers
(ID_customers   ASC);



ALTER TABLE Customers
	ADD  PRIMARY KEY (ID_customers);



CREATE TABLE Invoice_Products
(
	ID_invoice_products  int NOT NULL ,
	ID_invoice           int NOT NULL ,
	ID_product           int NOT NULL ,
	Quantity             int NULL 
);



CREATE UNIQUE INDEX XPKInvoice_Product ON Invoice_Products
(ID_invoice_products   ASC);



ALTER TABLE Invoice_Products
	ADD  PRIMARY KEY (ID_invoice_products);



CREATE  INDEX XIF1Invoice_Product ON Invoice_Products
(ID_product   ASC);



CREATE  INDEX XIF2Invoice_Product ON Invoice_Products
(ID_invoice   ASC);



CREATE TABLE InvoiceForGoods
(
	ID_invoice           INT NOT NULL ,
	ID_provisor          INT NOT NULL ,
	ID_workers           INT NOT NULL ,
	OrderDate            DATE NULL 
);



CREATE UNIQUE INDEX XPKInvoiceForGoods ON InvoiceForGoods
(ID_invoice   ASC);



ALTER TABLE InvoiceForGoods
	ADD  PRIMARY KEY (ID_invoice);



CREATE  INDEX XIF1InvoiceForGoods ON InvoiceForGoods
(ID_provisor   ASC);



CREATE  INDEX XIF2InvoiceForGoods ON InvoiceForGoods
(ID_workers   ASC);



CREATE TABLE Orders
(
	ID_order             INT NOT NULL ,
	ID_workers           INT NOT NULL ,
	ID_sale              INT NOT NULL ,
	ID_reserve           INT NOT NULL ,
	TotalSum             FLOAT NULL 
);



CREATE UNIQUE INDEX XPKOrders ON Orders
(ID_order   ASC);



ALTER TABLE Orders
	ADD  PRIMARY KEY (ID_order);



CREATE  INDEX XIF4Orders ON Orders
(ID_sale   ASC);



CREATE  INDEX XIF6Orders ON Orders
(ID_workers   ASC);



CREATE  INDEX XIF7Orders ON Orders
(ID_reserve   ASC);



CREATE TABLE Products
(
	ID_product           INT NOT NULL ,
	ID_subtypes          INT NOT NULL ,
	Name                 VARCHAR(80) NULL ,
	Firm                 VARCHAR(50) NULL 
);



CREATE UNIQUE INDEX XPKProducts ON Products
(ID_product   ASC);



ALTER TABLE Products
	ADD  PRIMARY KEY (ID_product);



CREATE  INDEX XIF2Products ON Products
(ID_subtypes   ASC);



CREATE TABLE Provisor
(
	ID_provisor          int NOT NULL ,
	LegalAddress         VARCHAR(50) NULL ,
	CompanyName          VARCHAR(50) NULL ,
	PhoneNumber          VARCHAR(50) NULL ,
	CheckingAccount      VARCHAR(50) NULL 
);



CREATE UNIQUE INDEX XPKProvisor ON Provisor
(ID_provisor   ASC);



ALTER TABLE Provisor
	ADD  PRIMARY KEY (ID_provisor);



CREATE TABLE Reserve
(
	ID_reserve           INT NOT NULL ,
	ID_store             INT NOT NULL ,
	ID_product           INT NOT NULL ,
	ID_sal_res_inv       int NOT NULL ,
	ExpirationDate       DATE NULL ,
	Quantity             INT NULL ,
	Price                FLOAT NULL ,
	BarCode              VARCHAR(13) NULL ,
	ProductSize          FLOAT NULL 
);



CREATE UNIQUE INDEX XPKReserve ON Reserve
(ID_reserve   ASC);



ALTER TABLE Reserve
	ADD  PRIMARY KEY (ID_reserve);



CREATE  INDEX XIF1Reserve ON Reserve
(ID_store   ASC);



CREATE  INDEX XIF2Reserve ON Reserve
(ID_product   ASC);



CREATE  INDEX XIF3Reserve ON Reserve
(ID_sal_res_inv   ASC);



CREATE TABLE Sale
(
	ID_sale              INT NOT NULL ,
	ID_products          INT NOT NULL ,
	Percents              INT NULL ,
	Name_sale            VARCHAR(50) NULL ,
	DateOfStart          DATE NULL ,
	DateOfFinish         DATE NULL 
);



CREATE UNIQUE INDEX XPKSale ON Sale
(ID_sale   ASC);



ALTER TABLE Sale
	ADD  PRIMARY KEY (ID_sale);



CREATE TABLE Sales_Reserve_Invoice
(
	ID_sal_res_inv       int NOT NULL ,
	ID_invoice_products  int NOT NULL ,
	Quantity             int NULL ,
	PriceUnit            FLOAT NULL ,
	ID_SalersInvoice     int NOT NULL 
);



CREATE UNIQUE INDEX XPKSales_Reserve_Invoice ON Sales_Reserve_Invoice
(ID_sal_res_inv   ASC);



ALTER TABLE Sales_Reserve_Invoice
	ADD  PRIMARY KEY (ID_sal_res_inv);



CREATE  INDEX XIF2Sales_Reserve_Invoice ON Sales_Reserve_Invoice
(ID_invoice_products   ASC);



CREATE  INDEX XIF3Sales_Reserve_Invoice ON Sales_Reserve_Invoice
(ID_SalersInvoice   ASC);



CREATE TABLE SalesInvoice
(
	ID_SalersInvoice     int NOT NULL ,
	ID_invoice           int NOT NULL ,
	ID_workers           int NOT NULL ,
	DeliveryDate         DATE NULL 
);



CREATE UNIQUE INDEX XPKSalesInvoice ON SalesInvoice
(ID_SalersInvoice   ASC);



ALTER TABLE SalesInvoice
	ADD  PRIMARY KEY (ID_SalersInvoice);



CREATE  INDEX XIF1SalesInvoice ON SalesInvoice
(ID_workers   ASC);



CREATE  INDEX XIF2SalesInvoice ON SalesInvoice
(ID_invoice   ASC);



CREATE TABLE Store
(
	ID_store             INT NOT NULL ,
	Address              VARCHAR(80) NULL ,
	IfStore              INT NULL 
);



CREATE UNIQUE INDEX XPKStore ON Store
(ID_store   ASC);



ALTER TABLE Store
	ADD  PRIMARY KEY (ID_store);



CREATE TABLE Subtypes
(
	ID_subtypes          INT NOT NULL ,
	Name                 VARCHAR(35) NULL 
);



CREATE UNIQUE INDEX XPKSubtypes ON Subtypes
(ID_subtypes   ASC);



ALTER TABLE Subtypes
	ADD  PRIMARY KEY (ID_subtypes);



CREATE TABLE Timetable
(
	ID_timetable         INT NOT NULL ,
	ID_workers           INT NOT NULL ,
	ID_store             INT NOT NULL ,
	WorkDate             DATE NULL ,
	Salary               FLOAT NULL 
);



CREATE UNIQUE INDEX XPKTimetable ON Timetable
(ID_timetable   ASC);



ALTER TABLE Timetable
	ADD  PRIMARY KEY (ID_timetable);



CREATE  INDEX XIF1Timetable ON Timetable
(ID_workers   ASC);



CREATE  INDEX XIF2Timetable ON Timetable
(ID_store   ASC);



CREATE TABLE Workers
(
	ID_workers           INT NOT NULL ,
	Surname              VARCHAR(50) NULL ,
	Name                 VARCHAR(50) NULL ,
	MiddleName           VARCHAR(50) NULL ,
	DateOfBirth          DATE NULL 
);



CREATE UNIQUE INDEX XPKWorkers ON Workers
(ID_workers   ASC);



ALTER TABLE Workers
	ADD  PRIMARY KEY (ID_workers);



--ALTER TABLE Cheque
--	ADD (FOREIGN KEY (ID_reserve) REFERENCES Reserve (ID_reserve));



--ALTER TABLE Cheque
--	ADD (FOREIGN KEY (ID_order) REFERENCES Orders (ID_order));



--ALTER TABLE Cheque
--	ADD (FOREIGN KEY (ID_customers) REFERENCES Customers (ID_customers));



--ALTER TABLE Cheque
--	ADD (FOREIGN KEY (ID_sale) REFERENCES Sale (ID_sale));



--ALTER TABLE Invoice_Products
--	ADD (FOREIGN KEY (ID_product) REFERENCES Products (ID_product));



--ALTER TABLE Invoice_Products
--	ADD (FOREIGN KEY (ID_invoice) REFERENCES InvoiceForGoods (ID_invoice));



--ALTER TABLE InvoiceForGoods
--	ADD (FOREIGN KEY (ID_provisor) REFERENCES Provisor (ID_provisor));



--ALTER TABLE InvoiceForGoods
--	ADD (FOREIGN KEY (ID_workers) REFERENCES Workers (ID_workers));



--ALTER TABLE Orders
--	ADD (FOREIGN KEY (ID_sale) REFERENCES Sale (ID_sale));



--ALTER TABLE Orders
--	ADD (FOREIGN KEY (ID_workers) REFERENCES Workers (ID_workers));



--ALTER TABLE Orders
--	ADD (FOREIGN KEY (ID_reserve) REFERENCES Reserve (ID_reserve));



--ALTER TABLE Products
--	ADD (FOREIGN KEY (ID_subtypes) REFERENCES Subtypes (ID_subtypes));



--ALTER TABLE Reserve
--	ADD (FOREIGN KEY (ID_store) REFERENCES Store (ID_store));



--ALTER TABLE Reserve
--	ADD (FOREIGN KEY (ID_product) REFERENCES Products (ID_product));



--ALTER TABLE Reserve
--	ADD (FOREIGN KEY (ID_sal_res_inv) REFERENCES Sales_Reserve_Invoice (ID_sal_res_inv));



--ALTER TABLE Sales_Reserve_Invoice
--	ADD (FOREIGN KEY (ID_invoice_products) REFERENCES Invoice_Products (ID_invoice_products));



--ALTER TABLE Sales_Reserve_Invoice
--	ADD (FOREIGN KEY (ID_SalersInvoice) REFERENCES SalesInvoice (ID_SalersInvoice));



--ALTER TABLE SalesInvoice
--	ADD (FOREIGN KEY (ID_workers) REFERENCES Workers (ID_workers));



--ALTER TABLE SalesInvoice
--	ADD (FOREIGN KEY (ID_invoice) REFERENCES InvoiceForGoods (ID_invoice));



--ALTER TABLE Timetable
--	ADD (FOREIGN KEY (ID_workers) REFERENCES Workers (ID_workers));



--ALTER TABLE Timetable
--	ADD (FOREIGN KEY (ID_store) REFERENCES Store (ID_store));
