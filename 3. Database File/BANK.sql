CREATE database dbBANK
use dbBANK

CREATE TABLE tblAdmin
(
	username VARCHAR(30) PRIMARY KEY,
	name VARCHAR(30),
	password NVARCHAR (max) NOT NULL,
	secret_question NVARCHAR (max) NOT NULL,
	secret_answer NVARCHAR (max) NOT NULL,
	usertype NVARCHAR(max) DEFAULT 'Teller',
	isactive NVARChAR(MAX) default 'ACTIVE',
	isRemember bit default 'false'
)

--insert administrator
INSERT INTO tblAdmin(username,name,password,secret_question,secret_answer,userType,isactive,isRemember)
VALUES('admin','Admin','ISMvKXpXpadDiUoOSoAfww==','','','Admin','ACTIVE','')

CREATE TABLE tblClient
(
	CAccountID VARCHAR(30) PRIMARY KEY,
	fname NVARCHAR(max) NOT NULL,
	lname NVARCHAR(max) NOT NULL,
	CurrentBalance DECIMAL(16,2) DEFAULT 100.00,
	isActive NVARChAR(MAX) default 'ACTIVE'
)
select * from tblClient

CREATE TABLE tblTransactions
(
	TransacID VARCHAR(30) PRIMARY KEY,
	CAccountID VARCHAR(30) FOREIGN KEY REFERENCES tblClient(CAccountID),
	username VARCHAR(30) FOREIGN KEY REFERENCES tblAdmin(username),
	date DATETIME NOT NULL,
	transacStatus VARCHAR(20) NOT NULL,
	amount DECIMAL(16,2) DEFAULT 0.00,
	balance DECIMAL(16,2) NOT NULL	
)

-------------STORED PROCEDURES-----------------------------
--INSERT/add Admin
CREATE PROC sp_INSERT_admin
@username VARCHAR(30),
@name VARCHAR(30),
@password NVARCHAR (max),
@secret_question NVARCHAR (max),
@secret_answer NVARCHAR (max)
AS INSERT INTO tblAdmin(username,name,password,secret_question,secret_answer)
VALUES(@username,@name,@password,@secret_question,@secret_answer)

--INSERT/add Client
CREATE PROC sp_insert_client
@CAccountID VARCHAR(30),
@fname NVARCHAR (max),
@lname NVARCHAR (max)
AS INSERT INTO tblClient(CAccountID,fname,lname)
VALUES(@CAccountID,@fname,@lname)

--select client by CAccountID
CREATE PROC sp_view_client
@CAccountID VARCHAR(30)
AS SELECT * FROM tblClient WHERE CAccountID = @CAccountID

--retrieve	
CREATE PROC sp_retrieve_user
@username VARCHAR(30),
@secret_question NVARCHAR (max),
@secret_answer NVARCHAR(max)
AS SELECT * FROM tblAdmin WHERE username = @username AND secret_question = @secret_question AND secret_answer = @secret_answer

--verify username and password
CREATE PROC sp_verifyusernamepass
@username VARCHAR(30),
@password NVARCHAR(max)
AS SELECT * FROM tblAdmin WHERE username=@username and password=@password

--verify username
CREATE PROC sp_verifyusername
@username VARCHAR(30)
AS SELECT * FROM tblAdmin WHERE username=@username 

--verify password
CREATE PROC sp_verifypassword
@password VARCHAR(30)
AS SELECT * FROM tblAdmin WHERE password=@password 

--get CleintID count
CREATE PROC sp_GetClientIDCount
AS SELECT count(*) AS Count FROM tblClient

--get TransacID count
CREATE PROC sp_GetTransacIDCount
AS SELECT count(*) AS Count1 FROM tblTransactions

--Add Client deposit
CREATE PROC sp_client_deposit
@TransacID VARCHAR(30),
@CAccountID VARCHAR(30),
@username VARCHAR(30),
@amount DECIMAL(16,2),
@CurrentBalance DECIMAL(16,2),
@date DATETIME
AS
UPDATE tblClient
SET CurrentBalance = @CurrentBalance
WHERE CAccountID = @CAccountID

INSERT INTO tblTransactions(TransacID,CAccountID,username,transacStatus,amount,balance,date)
VALUES(@TransacID,@CAccountID,@username,'Deposit',@amount,@CurrentBalance,@date)

--add client view
CREATE PROC sp_client_view
@TransacID VARCHAR(30),
@CAccountID VARCHAR(30),
@username VARCHAR(30),
@CurrentBalance DECIMAL(16,2),
@date DATETIME
AS INSERT INTO tblTransactions(TransacID,CAccountID,username,transacStatus,balance,date)
VALUES(@TransacID,@CAccountID,@username,'Check Balance',@CurrentBalance,@date)

--view transactions
CREATE PROC sp_view_transactions
AS SELECT TransacID,
		  CAccountID,
		  date AS Date,
		  username,
		  amount AS Amount,
		  balance AS Balance,
		  transacStatus
FROM tblTransactions

--view Usertype "Teller"
CREATE PROC sp_view_teller
AS SELECT name AS AdminName,
		  username AS Username,
		  isactive as Isactive
FROM tblAdmin where username != 'administrator'

--view remembered user
CREATE PROC sp_view_remember
AS SELECT * FROM tblAdmin WHERE isRemember = 'TRUE'

--UPDATE remember user
CREATE PROC sp_UPDATE_remember
@username VARCHAR(30),
@isRemember bit
AS
UPDATE tblAdmin
SET isRemember = 'false'

UPDATE tblAdmin
SET isRemember = @isRemember
WHERE username = @username

--Update isactive user
Create proc sp_Update_isactive
@username Varchar(30),
@isActive NVARChAR(MAX)
as
update tblAdmin
set isactive = @isActive
where username = @username

--Update not isactive user
create proc sp_Update_isNotActive
@username Varchar(30),
@isActive NVARChAR(MAX)
as
update tblAdmin
set isactive = @isActive
where username = @username

--change password
CREATE PROC sp_changepass
@username VARCHAR(30),
@oldpassword NVARCHAR(max),
@newpassword NVARCHAR(max)
AS
UPDATE tblAdmin
SET password = @newpassword
WHERE username = @username AND password = @oldpassword



--Add Client withdraw
CREATE PROC sp_client_withdraw
@TransacID VARCHAR(30),
@CAccountID VARCHAR(30),
@username VARCHAR(30),
@amount DECIMAL(16,2),
@CurrentBalance DECIMAL(16,2),
@date DATETIME
AS
UPDATE tblClient
SET CurrentBalance = @CurrentBalance
WHERE CAccountID = @CAccountID

INSERT INTO tblTransactions(TransacID,CAccountID,username,transacStatus,amount,balance,date)
VALUES(@TransacID,@CAccountID,@username,'Withdraw',@amount,@CurrentBalance,@date)

--start FROM the beginning
CREATE PROC sp_restart_db
AS
DROP table tblTransactions
TRUNCATE TABLE tblAdmin
TRUNCATE TABLE tblClient


CREATE TABLE tblTransactions
(
	TransacID VARCHAR(30) PRIMARY KEY,
	CAccountID VARCHAR(30) FOREIGN KEY REFERENCES tblClient(CAccountID),
	username VARCHAR(30) FOREIGN KEY REFERENCES tblAdmin(username),
	date DATETIME NOT NULL,
	transacStatus VARCHAR(20) NOT NULL,
	amount DECIMAL(16,2) DEFAULT 0.00,
	balance DECIMAL(16,2) NOT NULL	
)

--Search Admin
create proc sp_searchA
@key varchar(100)
as
select * from tblAdmin
where name like @key + '%'
or username like @key 

--View AccountID
create proc sp_ViewAccountID
as select CAccountID from tblClient

--view all Tables
SELECT * FROM tblTransactions
SELECT * FROM tblClient
SELECT * FROM tblAdmin

--delete all tables
delete from tblTransactions
delete from tblAdmin
delete from tblClient