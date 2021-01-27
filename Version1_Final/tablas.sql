DROP DATABASE IF EXISTS T1_BBDDFIREBOYandWATERGIRL;

CREATE DATABASE T1_BBDDFIREBOYandWATERGIRL;



USE T1_BBDDFIREBOYandWATERGIRL;



CREATE TABLE JUGADOR (

	ID INT NOT NULL,

	USERNAME VARCHAR(20),

	PASSWD VARCHAR(15),

	PRIMARY KEY (ID)

)ENGINE=InnoDB;



CREATE TABLE PARTIDA (

	ID INT NOT NULL,

	NUM_JUGADORES INT,

	PRIMARY KEY (ID)

)ENGINE=InnoDB;





CREATE TABLE PARTICIPACION (

	ID_J INT NOT NULL,

	ID_P INT NOT NULL,

	PUNTUACION INT,

	POSICION INT,

	FOREIGN KEY (ID_J) REFERENCES JUGADOR(ID),

	FOREIGN KEY (ID_P) REFERENCES PARTIDA(ID)

)ENGINE=InnoDB;



INSERT INTO JUGADOR VALUES (1,'Omar','12345678');

INSERT INTO JUGADOR VALUES (2,'Ivan','12345677');

INSERT INTO JUGADOR VALUES (3,'Edgar','12345676');



INSERT INTO PARTIDA VALUES (1, 3);

INSERT INTO PARTIDA VALUES (2, 3);

INSERT INTO PARTIDA VALUES (3, 3);

INSERT INTO PARTIDA VALUES (4, 3);





INSERT INTO PARTICIPACION VALUES (1,2,90,5);

INSERT INTO PARTICIPACION VALUES (2,2,10,3);

INSERT INTO PARTICIPACION VALUES (3,2,40,2);

INSERT INTO PARTICIPACION VALUES (1,1,40,7);

INSERT INTO PARTICIPACION VALUES (2,1,90,1);

INSERT INTO PARTICIPACION VALUES (3,1,0,3);

INSERT INTO PARTICIPACION VALUES (1,3,200,3);