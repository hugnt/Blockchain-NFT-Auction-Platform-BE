USE NFTAuctionPlatform
GO
CREATE TABLE tAccount(
	id INT PRIMARY KEY IDENTITY(1, 1),
	wallet_address VARCHAR(250) UNIQUE,
	name NVARCHAR(100),
	email NVARCHAR(50),
	address NVARCHAR(500),
	description NVARCHAR(3000),
	avatar NVARCHAR(100),
	cover NVARCHAR(100),
	followers INT,
	following INT,
	facebook NVARCHAR(100),
	youtube NVARCHAR(100),
	twitter NVARCHAR(100),
	telegram NVARCHAR(100),
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)
GO

CREATE TABLE tNFT(
	id INT PRIMARY KEY IDENTITY(1, 1),
	policyId VARCHAR(250) UNIQUE,
	name NVARCHAR(500),
	likes INT,
	status INT,
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)

GO

CREATE TABLE tNFTCategory(
	id INT PRIMARY KEY IDENTITY(1, 1),
	name NVARCHAR(100),
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)

GO
-- many-many rela bw NFT & cate
CREATE TABLE tNFT_NFTCategory(
	id INT PRIMARY KEY IDENTITY(1, 1),
	nftId INT FOREIGN KEY REFERENCES tNFT(id) ON DELETE CASCADE ON UPDATE CASCADE,
	nftCategoryId INT FOREIGN KEY REFERENCES tNFTCategory(id) ON DELETE CASCADE ON UPDATE CASCADE,
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)
-- many-many rela bw NFT & Account
CREATE TABLE tAccount_NFT(
	id INT PRIMARY KEY IDENTITY(1, 1),
	accountId INT FOREIGN KEY REFERENCES tAccount(id) ON DELETE CASCADE ON UPDATE CASCADE,
	nftId INT FOREIGN KEY REFERENCES tNFT(id) ON DELETE CASCADE ON UPDATE CASCADE,
	likes INT,
	Votes INT,
	isAuthor BIT,
	wasAuthor BIT,
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)

CREATE TABLE tFounder(
	id INT PRIMARY KEY IDENTITY(1, 1),
	fullName NVARCHAR(100),
	role NVARCHAR(100),
	company NVARCHAR(300),
	avatar NVARCHAR(100),
	facebook NVARCHAR(100),
	youtube NVARCHAR(100),
	twitter NVARCHAR(100),
	telegram NVARCHAR(100),
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)

CREATE TABLE tBlog(
	id INT PRIMARY KEY IDENTITY(1, 1),
	title NVARCHAR(100),
	content NVARCHAR(4000),
	description NVARCHAR(1000),
	image NVARCHAR(100),
	video NVARCHAR(100),
	createdAt DATETIME,
	updatedAt DATETIME,
	isActive BIT
)





