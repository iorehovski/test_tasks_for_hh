CREATE TABLE Products (
    ProductId SERIAL PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL
);

CREATE TABLE Categories (
    CategoryId SERIAL PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE ProductCategory (
    ProductId INTEGER,
    CategoryId INTEGER,
    PRIMARY KEY (ProductId, CategoryId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

INSERT INTO Products
VALUES 
(1,'1prod'),
(2,'2prod'),
(3,'3prod');

INSERT INTO Categories
VALUES 
(1,'1cat'),
(2,'2cat');

INSERT INTO ProductCategory
VALUES 
(1,1),
(1,2),
(2,1),
(2,2);


1 версия:
SELECT  p.ProductName, c.CategoryName
FROM ProductCategory as pc
LEFT JOIN Products p on p.ProductId = pc.ProductId
LEFT JOIN Categories c on c.CategoryId = pc.CategoryId
UNION
SELECT  p.ProductName, NULL
FROM Products as p
LEFT JOIN  ProductCategory pc on p.ProductId = pc.ProductId
WHERE pc.CategoryId IS NULL

2 версия(оптимизированная):
SELECT p.ProductName,c.CategoryName
FROM Products p
LEFT JOIN ProductCategory pc ON p.ProductId = pc.ProductId
LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId;
