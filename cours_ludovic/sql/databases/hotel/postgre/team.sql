CREATE TABLE team(
   Id_team SERIAL,
   "name" VARCHAR(50)  NOT NULL,
   creation_date DATE,
   PRIMARY KEY(Id_team)
);

CREATE TABLE human_centiped(
   Id_human_centiped SERIAL,
   first_name VARCHAR(50)  NOT NULL,
   lastname VARCHAR(50)  NOT NULL,
   PRIMARY KEY(Id_human_centiped)
);

CREATE TABLE arbitrer(
   Id_human_centiped INTEGER,
   PRIMARY KEY(Id_human_centiped),
   FOREIGN KEY(Id_human_centiped) REFERENCES human_centiped(Id_human_centiped)
);

CREATE TABLE player(
   Id_human_centiped INTEGER,
   date_of_birth DATE NOT NULL,
   Id_team INTEGER,
   PRIMARY KEY(Id_human_centiped),
   FOREIGN KEY(Id_human_centiped) REFERENCES human_centiped(Id_human_centiped),
   FOREIGN KEY(Id_team) REFERENCES team(Id_team)
);

CREATE TABLE match(
   Id_match SERIAL,
   "date" DATE,
   begin_time TIME,
   result SMALLINT,
   Id_human_centiped INTEGER NOT NULL,
   PRIMARY KEY(Id_match),
   FOREIGN KEY(Id_human_centiped) REFERENCES arbitrer(Id_human_centiped)
);

CREATE TABLE playing(
   Id_team INTEGER,
   Id_match INTEGER,
   PRIMARY KEY(Id_team, Id_match),
   FOREIGN KEY(Id_team) REFERENCES team(Id_team),
   FOREIGN KEY(Id_match) REFERENCES _match(Id_match)
);
