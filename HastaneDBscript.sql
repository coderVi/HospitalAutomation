USE MASTER
CREATE DATABASE HastaneOtomasyonDB
GO 
USE HastaneOtomasyonDB
GO
CREATE TABLE tbl_user
(ID INT IDENTITY(10,3) PRIMARY KEY, kAdi NVARCHAR(10), sifre NVARCHAR(10))

INSERT INTO tbl_user(kAdi,sifre) VALUES ('admin','admin1234')

CREATE TABLE tbl_bolumler
(
    BolumID INT IDENTITY(1,1) PRIMARY KEY, 
    BolumAdi NVARCHAR(20)
)
CREATE TABLE tbl_hastalar
(
tc INT PRIMARY KEY NOT NULL,
adSoyad NVARCHAR(50),
Dtarih DATE,
dYeri NVARCHAR(50),
cinsiyet CHAR(5),
Adres NVARCHAR(500),
telefon NVARCHAR(11),
guvence NVARCHAR(20)
)

CREATE TABLE tbl_doktorlar
(
tc INT PRIMARY KEY NOT NULL,
adSoyad NVARCHAR(50),
Dtarih DATE,
dYeri NVARCHAR(50),
cinsiyet CHAR(5),
Adres NVARCHAR(500),
telefon NVARCHAR(11),
bolum INT FOREIGN KEY REFERENCES tbl_bolumler(BolumID)
)

CREATE TABLE tbl_randevu
(
IslemNo INT IDENTITY(1,1) PRIMARY KEY,
HastaTc INT FOREIGN KEY REFERENCES tbl_hastalar(tc),
HastaAdi nvarchar(50),
DoktorTc INT FOREIGN KEY REFERENCES tbl_doktorlar(tc),
Bolum INT FOREIGN KEY REFERENCES tbl_bolumler(BolumID),
Tarih DATE
)



