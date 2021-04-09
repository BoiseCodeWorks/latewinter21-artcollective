USE artcollective;

-- DROP TABLE artists;

-- CREATE TABLE artists(
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) DEFAULT 'This is a description',
--   age INT NOT NULL,

--   PRIMARY KEY (id)
-- );

-- ALTER TABLE artists
-- ADD bio VARCHAR(255) DEFAULT 'Some default val';

-- TRUNCATE TABLE artists
-- to clear out the data and then you can make with correct columns


-- ALTER TABLE artists
-- DROP COLUMN bio;


-- CREATE TABLE paintings
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   year INT NOT NULL,
--   artistId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (artistId)
--     REFERENCES artists (id)
--     ON DELETE CASCADE
-- )


-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE admissions
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   date VARCHAR(255) NOT NULL,
--   buyerId VARCHAR(255),

--   PRIMARY KEY (id),

--   FOREIGN KEY (buyerId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );


-- DROP TABLE admissions;
-- DROP TABLE profiles;