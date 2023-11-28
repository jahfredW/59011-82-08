DROP DATABASE IF EXISTS drone_session;
CREATE DATABASE IF NOT EXISTS drone_session;
USE drone_session;

CREATE TABLE Type_Drone(
   Id_Type_Drone INT AUTO_INCREMENT,
   intitule VARCHAR(50) ,
   PRIMARY KEY(Id_Type_Drone)
);
ALTER TABLE Type ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

CREATE TABLE Pilote(
   Id_Pilote INT AUTO_INCREMENT,
   nom VARCHAR(50) ,
   prenom VARCHAR(50) ,
   PRIMARY KEY(Id_Pilote)
);
ALTER TABLE Pilote ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

CREATE TABLE Drone(
   Id_Drone INT AUTO_INCREMENT,
   nom VARCHAR(50) ,
   prix DECIMAL(15,2)  ,
   Id_Type INT NOT NULL,
   PRIMARY KEY(Id_Drone),
   FOREIGN KEY(Id_Type) REFERENCES Type(Id_Type)
);
ALTER TABLE Drone ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

CREATE TABLE Session(
   Id_Drone INT,
   Id_Pilote INT,
   Id_session INT NOT NULL,
   Date_session DATE,
   PRIMARY KEY(Id_Drone, Id_Pilote),
   UNIQUE(Id_session),
   FOREIGN KEY(Id_Drone) REFERENCES Drone(Id_Drone),
   FOREIGN KEY(Id_Pilote) REFERENCES Pilote(Id_Pilote)
);
ALTER TABLE Session ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

ALTER TABLE Session
ADD CONSTRAINT FK_SESSION_PILOTE FOREIGN KEY(Id_Pilote) REFERENCES Pilote(Id_Pilote),
ADD CONSTRAINT FK_SESSION_DRONE FOREIGN KEY(Id_Drone) REFERENCES Drone(Id_Drone);

ALTER TABLE Drone
ADD CONSTRAINT FK_DRONE_TYPE FOREIGN KEY(Id_Type_Drone) REFERENCES Type(Id_Type_Drone);




