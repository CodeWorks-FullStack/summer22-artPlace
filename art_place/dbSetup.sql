CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

-- NOTE This wont work unless there is not child data for this account, thanks FOREIGN key constraints.
DELETE FROM accounts WHERE id = '631b5b5fa7f0b66bb817725a';


-- STUB PIECES
CREATE TABLE IF NOT EXISTS pieces(
  id INT AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  description VARCHAR(500) COMMENT 'The artists interpretation of the piece.',
  imgUrl VARCHAR(255),
  forSale BOOLEAN NOT NULL DEFAULT false,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

DROP TABLE pieces;

INSERT INTO pieces
(title, description, imgUrl, creatorId)
VALUES
('Cat in window', 'brrrrreow', 'https://wallpapercave.com/wp/wp7817776.jpg', '631b5b5fa7f0b66bb817725a');

SELECT * FROM pieces p
JOIN accounts a ON a.id = p.creatorId;


-- STUB COLLECTIONS
CREATE TABLE IF NOT EXISTS collections (
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  location VARCHAR(255),
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

INSERT INTO collections
(name, location, creatorId)
VALUES
('Just Cats', 'Jerms house', '631b5b5fa7f0b66bb817725a');

-- STUB COLLECTIONPIECES
CREATE TABLE IF NOT EXISTS collectionpieces(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  pieceId INT NOT NULL,
  collectionId INT NOT NULL,

  FOREIGN KEY (pieceId) REFERENCES pieces (id),
  FOREIGN KEY (collectionId) REFERENCES collections (id)
) default charset utf8 COMMENT '';

INSERT INTO collectionpieces
(pieceId, collectionId)
VALUES
(4,2);

-- join both tables together
SELECT 
cp.id AS collectionPieceId,
p.*,
c.*
FROM collectionpieces cp
JOIN pieces p ON cp.pieceId = p.id
JOIN collections c ON cp.collectionId = c.id;

-- join tables and get the pieces artist out
SELECT 
cp.id AS collectionPieceId,
p.title, p.imgUrl,
c.name,
a.name AS artist
FROM collectionpieces cp
JOIN pieces p ON cp.pieceId = p.id
JOIN collections c ON cp.collectionId = c.id
JOIN accounts a ON p.creatorId = a.id;

-- GET PIECES BY COLLECTION ID
SELECT
cp.*,
p.*,
a.*
FROM collectionpieces cp
JOIN pieces p ON cp.pieceId = p.id
JOIN accounts a ON p.creatorId = a.id
WHERE cp.collectionId = 2;