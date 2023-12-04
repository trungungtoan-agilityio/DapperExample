CREATE DATABASE [product-dapper-db]
GO

USE [product-dapper-db];
GO

CREATE TABLE product (
     Id          INT          NOT NULL IDENTITY,
     Name        varchar(max) NOT NULL,
     Barcode     varchar(max) NOT NULL,
     Description varchar(max) NOT NULL,
     Rate        INT          NOT NULL,
     AddedOn     DATE         NOT NULL,
     ModifiedOn  DATE         NULL,
     PRIMARY KEY (Id)
);
GO