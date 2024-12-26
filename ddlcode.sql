CREATE DATABASE bob;
USE bob;  


CREATE TABLE books (  
    id INT IDENTITY(1,1) NOT NULL,  
    title VARCHAR(100) NOT NULL UNIQUE,  
    number_of_additions INT NOT NULL DEFAULT 0 CHECK (number_of_additions >= 0),  
    booked INT NOT NULL DEFAULT 0 CHECK (booked >= 0),  
    sold INT NOT NULL DEFAULT 0 CHECK (sold >= 0),  
    PRIMARY KEY (id)  
);  

CREATE TABLE authors (  
    id INT IDENTITY(1,1) NOT NULL,  
    name VARCHAR(100) NOT NULL,  
    PRIMARY KEY (id)  
);  

CREATE TABLE authored (  
    book_id INT,   
    author_id INT,  
    year INT,  
	PRIMARY KEY(book_id , author_id),
    FOREIGN KEY (book_id) REFERENCES books(id),  
    FOREIGN KEY (author_id) REFERENCES authors(id)  
);  

CREATE TABLE translators (  
    id INT IDENTITY(1,1) NOT NULL,  
    name VARCHAR(100) NOT NULL,  
    PRIMARY KEY (id)  
);  

CREATE TABLE translated (  
    book_id INT,   
    translator_id INT,  
    year INT, 
	_language VARCHAR(50),
	PRIMARY KEY(book_id , translator_id),
    FOREIGN KEY (book_id) REFERENCES books(id),  
    FOREIGN KEY (translator_id) REFERENCES translators(id)  
);  

CREATE TABLE members(
	id  INT IDENTITY(1,1) ,
	ssn VARCHAR(16) UNIQUE NOT NULL , 
	name VARCHAR(100) NOT NULL,
	birth_date DATE NOT NULL,
	user_name VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL ,
	address VARCHAR (100) NOT NULL,
	state VARCHAR (6) CHECK(state IN ('ADMIN' , 'USER')),
	PRIMARY KEY(id)
);


CREATE TABLE booked(
	member_id INT, 
	book_id INT , 
	date DATE NOT NULL,
	PRIMARY KEY(book_id,member_id),
	FOREIGN KEY(book_id) REFERENCES books(id),
	FOREIGN KEY(member_id) REFERENCES members(id),
);

CREATE TABLE sold(
	member_id INT, 
	book_id INT , 
	date DATE NOT NULL,
	PRIMARY KEY(book_id,member_id),
	FOREIGN KEY(book_id) REFERENCES books(id),
	FOREIGN KEY(member_id) REFERENCES members(id),
);


 
INSERT INTO books (title , number_of_additions)
VALUES ('alicee' , 10);  
INSERT INTO books (title , number_of_additions)
VALUES ('bob' , 10);
INSERT INTO books (title , number_of_additions)
VALUES ('alix' , 10);
INSERT INTO books (title , number_of_additions)
VALUES ('aliceds' , 10);
INSERT INTO booked (member_id , book_id , date)
VALUES (19 , 1 , '2026-12-14');
INSERT INTO sold (member_id , book_id , date)
VALUES (19 , 1 , '2026-12-14');
INSERT INTO authors ( name)  
VALUES ( 'wageeh');  
INSERT INTO authors ( name)  
VALUES ('MOHSEN');  
INSERT INTO members (ssn , name , birth_date , user_name , password , address , state) 
VALUES ('111121113211111' , 'Ahmed Wageeh' , '2004-04-18' , 'with_wageeh' , '123456', '80 portsaid street' , 'USER');
DELETE FROM booked WHERE book_id = 1;
EXEC sp_help members;

INSERT INTO authored (book_id, author_id, year)  
VALUES (1, 1, 2023);  
DELETE FROM members WHERE id = 16;
INSERT INTO authored (book_id, author_id, year)  
VALUES (1, 2, 2023);
INSERT INTO translators (id, name)  
VALUES (1, 'abdo'); 
INSERT INTO translated (book_id, translator_id, year ,_language)  
VALUES (1, 1, 2021 , 'ENGLISH');