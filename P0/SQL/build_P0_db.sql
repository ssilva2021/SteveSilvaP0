CREATE TABLE Users (
    UserID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserName varchar(40) NOT NULL,
    UserPassword varchar(255)
);

CREATE TABLE Customers (
    CustomerID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    PrefferedStore int,
    FOREIGN KEY (PrefferedStore) REFERENCES Stores(StoreID)
); 

    -- Single quotes is important
INSERT INTO Customers (LastName, FirstName, Age) VALUES ('Silva', 'Steve', 55);
INSERT INTO Customers (LastName, FirstName, Age) VALUES ('Moore', 'Markoore', 40);
INSERT INTO Customers (LastName, FirstName, Age) VALUES ('Kuhner', 'Jeff', 50);
INSERT INTO Customers (LastName, FirstName, Age) VALUES ('Carr', 'Howie', 65);

CREATE TABLE Orders (
    OrderID int IDENTITY(1,1) NOT NULL,
    OrderNumber int NOT NULL,
    CustomerID int,
    StoreID int,
    OrderDate datetime not null default(current_timestamp),
    PRIMARY KEY (OrderID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID)
); 

CREATE TABLE Products (
    ProductID int IDENTITY(1,1) NOT NULL,
    ProductName varchar(64) NOT NULL,
    ProductDesc varchar(255),
    ProductPrice money NOT NULL default(0),
    PRIMARY KEY (ProductID)
); 
INSERT INTO Products (ProductName, ProductDesc, ProductPrice) VALUES ('Desk', 'computer desk', 165.00);
INSERT INTO Products (ProductName, ProductDesc, ProductPrice) VALUES ('Lamp', 'Desk Lamp', 55.00);
INSERT INTO Products (ProductName, ProductDesc, ProductPrice) VALUES ('Stapler', 'Red Stapler', 16.00);
INSERT INTO Products (ProductName, ProductDesc, ProductPrice) VALUES ('Printer', 'PC Load Letter', 65.00);
INSERT INTO Products (ProductName, ProductDesc, ProductPrice) VALUES ('Shredder', 'Paper Shredder', 45.00);


CREATE TABLE OrdersItems (
    OrderItemID int IDENTITY(1,1) NOT NULL,
    OrderID int NOT NULL,
    ProductID int NOT NULL,
    Price money NOT NULL,
    Quantity int NOT NULL,
    PRIMARY KEY (OrderItemID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
); 


CREATE TABLE Stores (
    StoreID int IDENTITY(1,1) NOT NULL,
    StoreName varchar(64),
    StoreAddr1 varchar(64),
    StoreAddr2 varchar(64),
    StoreCity varchar(64),
    StoreState varchar(2),
    StoreZip varchar(12),
    PRIMARY KEY (StoreID)
); 

CREATE TABLE StoreInventory (
    StoreInventoryID int IDENTITY(1,1) NOT NULL,
    StoreID int NOT NULL,
    ProductID int NOT NULL,
    Quantity int NOT NULL default(0),
    PRIMARY KEY (StoreInventoryID),
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
); 
