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
('Bold and Brash', 'It is art', 'https://i.kym-cdn.com/entries/icons/original/000/016/289/Screen_Shot_2019-04-16_at_3.42.28_PM.png', '631b5b5fa7f0b66bb817725a');

SELECT * FROM pieces p
JOIN accounts a ON a.id = p.creatorId;