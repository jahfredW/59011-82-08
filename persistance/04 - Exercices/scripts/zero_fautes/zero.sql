CREATE TABLE CategorieFaute(
   Id_CategorieFaute INT AUTO_INCREMENT,
   nom VARCHAR(25)  NOT NULL,
   description TEXT,
   Id_CategorieFaute_1 INT NOT NULL,
   PRIMARY KEY(Id_CategorieFaute),
   FOREIGN KEY(Id_CategorieFaute_1) REFERENCES CategorieFaute(Id_CategorieFaute)
);

CREATE TABLE Modele(
   Id_Modele INT AUTO_INCREMENT,
   code INT NOT NULL,
   nom_modele VARCHAR(50)  NOT NULL,
   date_miseEnPlace DATE,
   PRIMARY KEY(Id_Modele),
   UNIQUE(code)
);

CREATE TABLE Produit(
   id_produit INT,
   numero_de_serie INT NOT NULL,
   numero_de_produit INT NOT NULL,
   production_année DATE NOT NULL,
   Id_Modele INT NOT NULL,
   PRIMARY KEY(id_produit),
   FOREIGN KEY(Id_Modele) REFERENCES Modele(Id_Modele)
);

CREATE TABLE Fautes(
   Id_Fautes INT AUTO_INCREMENT,
   Titre VARCHAR(25)  NOT NULL,
   commentaire TEXT,
   Id_CategorieFaute INT NOT NULL,
   PRIMARY KEY(Id_Fautes),
   FOREIGN KEY(Id_CategorieFaute) REFERENCES CategorieFaute(Id_CategorieFaute)
);

CREATE TABLE Concerner(
   Id_Fautes INT,
   id_produit INT,
   date_detection DATE,
   date_reparation DATE,
   PRIMARY KEY(Id_Fautes, id_produit),
   FOREIGN KEY(Id_Fautes) REFERENCES Fautes(Id_Fautes),
   FOREIGN KEY(id_produit) REFERENCES Produit(id_produit)
);
