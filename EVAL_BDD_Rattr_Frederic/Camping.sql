DROP DATABASE IF EXISTS Camping;
CREATE DATABASE IF NOT EXISTS Camping;
USE Camping;

--
--  Type_emplacement
--

CREATE TABLE Type_emplacement(
   Id_Type_emplacement INT AUTO_INCREMENT,
   intitulé VARCHAR(50) ,
   PRIMARY KEY(Id_Type_emplacement)
);
ALTER TABLE Type_emplacement ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Client
--

CREATE TABLE Client(
   Id_Client INT AUTO_INCREMENT,
   nom VARCHAR(25) ,
   prénom VARCHAR(25) ,
   adresse VARCHAR(255) ,
   telephone VARCHAR(50) ,
   courriel VARCHAR(50) ,
   PRIMARY KEY(Id_Client)
);
ALTER TABLE Client ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Options
--

CREATE TABLE Options(
   Id_Options INT AUTO_INCREMENT,
   intitulé VARCHAR(25) ,
   PRIMARY KEY(Id_Options)
);
ALTER TABLE Options ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Zone
--

CREATE TABLE Zone(
   Id_Zone INT AUTO_INCREMENT,
   intitulé VARCHAR(25) ,
   PRIMARY KEY(Id_Zone)
);
ALTER TABLE Zone ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Activité
--

CREATE TABLE Activité(
   Id_Activité INT AUTO_INCREMENT,
   intitulé VARCHAR(50) ,
   prix BOOLEAN,
   PRIMARY KEY(Id_Activité)
);
ALTER TABLE Activité ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Type_reservation
--

CREATE TABLE Type_reservation(
   Id_Type_reservation INT AUTO_INCREMENT,
   intitulé VARCHAR(25) ,
   PRIMARY KEY(Id_Type_reservation)
);
ALTER TABLE Type_reservation ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Type_acompte
--

CREATE TABLE Type_acompte(
   Id_Type_acompte INT AUTO_INCREMENT,
   intitulé VARCHAR(50) ,
   PRIMARY KEY(Id_Type_acompte)
);
ALTER TABLE Type_acompte ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Emplacement
--

CREATE TABLE Emplacement(
   Id_Emplacement INT AUTO_INCREMENT,
   numéro INT NOT NULL,
   situation BOOLEAN,
   electricite BOOLEAN,
   parking BOOLEAN,
   prix INT,
   Id_Zone INT NOT NULL,
   Id_Type_emplacement INT NOT NULL,
   PRIMARY KEY(Id_Emplacement)
);
ALTER TABLE Emplacement ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Acompte
--

CREATE TABLE Acompte(
   Id_Acompte INT AUTO_INCREMENT,
   date_reception_acompte VARCHAR(50) ,
   montant DECIMAL(15,2)  ,
   Id_Type_acompte INT NOT NULL,
   PRIMARY KEY(Id_Acompte)
);
ALTER TABLE Acompte ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Reservation
--

CREATE TABLE Reservation(
   Id_Reservation INT,
   Id_Emplacement INT,
   Id_Client INT,
   Id_Acompte INT,
   Id_Type_reservation INT,
   Id_Options INT,
   date_debut DATE,
   date_fin DATE,
   est_confirmee BOOLEAN,
   prix_points INT,
   prix_total_ttc DECIMAL(15,2)  ,
   prix_total_ht DECIMAL(15,2) ,
   est_payée BOOLEAN ,
   PRIMARY KEY(Id_Reservation)
);
ALTER TABLE Reservation ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Loisir
--

CREATE TABLE Loisir(
   Id_Loisir INT,
   Id_Client INT,
   Id_Zone INT,
   Id_Activité INT,
   paiement BOOLEAN  ,
   PRIMARY KEY(Id_Loisir)
);
ALTER TABLE Loisir ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;


ALTER TABLE Emplacement
ADD CONSTRAINT FK_EMPLACEMENT_ZONE FOREIGN KEY(Id_Zone) REFERENCES Zone(Id_Zone),
ADD CONSTRAINT FK_EMPLACEMENT_TYPE FOREIGN KEY(Id_Type_emplacement) REFERENCES Type_emplacement(Id_Type_emplacement);

ALTER TABLE Acompte
ADD CONSTRAINT FK_Acompte_Type FOREIGN KEY(Id_Type_acompte) REFERENCES Type_acompte(Id_Type_acompte);

ALTER TABLE Reservation
ADD CONSTRAINT FK_Reservation_emplacement FOREIGN KEY(Id_Emplacement) REFERENCES Emplacement(Id_Emplacement),
ADD CONSTRAINT FK_Reservation_client FOREIGN KEY(Id_Client) REFERENCES Client(Id_Client),
ADD CONSTRAINT FK_Reservation_Acompte FOREIGN KEY(Id_Acompte) REFERENCES Acompte(Id_Acompte),
ADD CONSTRAINT FK_Reservation_type FOREIGN KEY(Id_Type_reservation) REFERENCES Type_reservation(Id_Type_reservation),
ADD CONSTRAINT FK_Reservation_options FOREIGN KEY(Id_Options) REFERENCES Options(Id_Options);

ALTER TABLE Loisir
ADD CONSTRAINT FK_Loisir_client FOREIGN KEY(Id_Client) REFERENCES Client(Id_Client),
ADD CONSTRAINT FK_Loisir_zone FOREIGN KEY(Id_Zone) REFERENCES Zone(Id_Zone),
ADD CONSTRAINT  FK_Loisir_activite FOREIGN KEY(Id_Activité) REFERENCES Activité(Id_Activité);