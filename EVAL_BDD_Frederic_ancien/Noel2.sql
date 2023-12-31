DROP DATABASE IF EXISTS Noel;
CREATE DATABASE IF NOT EXISTS Noel;
USE Noel;

--
--  ENFANT
--

CREATE TABLE ENFANT(
   Id_ENFANT INT AUTO_INCREMENT,
   nom_enfant VARCHAR(25)  NOT NULL,
   prenom_enfant VARCHAR(25) ,
   adresse_enfant VARCHAR(255)  NOT NULL,
   sexe_enfant BOOLEAN,
   sagesse_enfant DECIMAL(15,2)  ,
   PRIMARY KEY(Id_ENFANT)
);
ALTER TABLE ENFANT ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  LUTIN
--

CREATE TABLE LUTIN(
   Id_Lutin INT AUTO_INCREMENT,
   nom_lutin VARCHAR(25) ,
   prenom_lutin VARCHAR(25) ,
   PRIMARY KEY(Id_Lutin)
);
ALTER TABLE LUTIN ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  TRAINEAU
--

CREATE TABLE TRAINEAU(
   Id_TRAINEAU INT AUTO_INCREMENT,
   date_mise_en_service DATE,
   taille_traineau DECIMAL(15,2)  ,
   date_revision DATE,
   PRIMARY KEY(Id_TRAINEAU)
);
ALTER TABLE TRAINEAU ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  RENNE
--

CREATE TABLE RENNE(
   nom_renne VARCHAR(50) ,
   sexe_renne BOOLEAN,
   date_de_naissance DATE,
   Id_TRAINEAU INT,
   PRIMARY KEY(nom_renne),
   FOREIGN KEY(Id_TRAINEAU) REFERENCES TRAINEAU(Id_TRAINEAU)
);
ALTER TABLE RENNE ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  TOURNEE
--

CREATE TABLE TOURNEE(
   Id_TOURNEE INT AUTO_INCREMENT,
   date_depart DATE,
   Id_Lutin INT,
   Id_TRAINEAU INT,
   PRIMARY KEY(Id_TOURNEE),
   FOREIGN KEY(Id_Lutin) REFERENCES LUTIN(Id_Lutin),
   FOREIGN KEY(Id_TRAINEAU) REFERENCES TRAINEAU(Id_TRAINEAU)
);
ALTER TABLE TOURNEE ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  CADEAU
--

CREATE TABLE CADEAU(
   Id_CADEAU INT AUTO_INCREMENT,
   designation_cadeau VARCHAR(50)  NOT NULL,
   Id_TRAINEAU INT,
   PRIMARY KEY(Id_CADEAU),
   FOREIGN KEY(Id_TRAINEAU) REFERENCES TRAINEAU(Id_TRAINEAU)
);
ALTER TABLE CADEAU ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  VOEUX
--

CREATE TABLE VOEUX(
   Id_Voeu INT AUTO_INCREMENT,
   est_exaucé VARCHAR(50) ,
   Id_CADEAU INT NOT NULL,
   Id_ENFANT INT,
   PRIMARY KEY(Id_Voeu),
   FOREIGN KEY(Id_CADEAU) REFERENCES CADEAU(Id_CADEAU),
   FOREIGN KEY(Id_ENFANT) REFERENCES ENFANT(Id_ENFANT)
);
ALTER TABLE VOEUX ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Gérer
--

CREATE TABLE Gérer(
   Id_Lutin INT,
   Id_TRAINEAU INT,
   date_prise_en_compte VARCHAR(50) ,
   PRIMARY KEY(Id_Lutin, Id_TRAINEAU),
   FOREIGN KEY(Id_Lutin) REFERENCES LUTIN(Id_Lutin),
   FOREIGN KEY(Id_TRAINEAU) REFERENCES TRAINEAU(Id_TRAINEAU)
);
ALTER TABLE Gérer ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;
