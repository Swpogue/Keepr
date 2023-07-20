CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
    ) default charset utf8 COMMENT '';

ALTER TABLE accounts ADD COLUMN coverImg VARCHAR(500) DEFAULT "";

CREATE TABLE
    IF NOT EXISTS keeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(255) NOT NULL,
        views INT DEFAULT "0",
        creatorId VARCHAR(255) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';
    ALTER TABLE keeps ADD COLUMN kept int DEFAULT "0";

CREATE TABLE
    IF NOT EXISTS vaults(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(50) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(500) NOT NULL,
        isPrivate BOOLEAN NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        creatorId VARCHAR(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        UNIQUE(creatorId, vaultId, keepId)
    ) default charset utf8 COMMENT '';

    SELECT
    keeps.*,
    COUNT(vaultKeeps.id) AS kept
    FROM keeps
    LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keepId
    GROUP BY (keeps.id);