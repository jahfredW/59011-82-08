1 - SELECT * from villes_france v where CHAR_LENGTH(v.ville_nom) >= 40;

2 - SELECT * from departements d where SUBSTRING(d.departement_code, 1, 2) = "97";

3 - 
SELECT
    *
FROM
    departements d
WHERE
    d.departement_regionId =(
    SELECT
        r.region_id
    FROM
        regions r
    WHERE
        r.region_nom = "Hauts-de-France"
);

4 - select v.ville_id, v.ville_departement from villes_france v
order by ville_population_2012 DESC

5 - 
SELECT
    d.departement_nom,
    d.departement_code,
    COUNT(v.ville_id) AS "nombre_villes"
FROM
    villes_france v
INNER JOIN departements d ON
    v.ville_departement = d.departement_code
GROUP BY
    v.ville_departement

6 - 

SELECT d.departement_nom, d.departement_code, sum(v.ville_surface) AS superficie FROM villes_france v INNER JOIN departements d ON v.ville_departement = d.departement_code GROUP BY d.departement_code ORDER BY superficie DESC;

7 - 

SELECT
    COUNT(v.ville_id)
FROM
    villes_france v
WHERE
    SUBSTRING(v.ville_nom, 1, 5) = "Saint";

8 - 

SELECT
    v.ville_id,
    COUNT(v.ville_nom) AS nombre_occurence
FROM
    villes_france v
GROUP BY
    v.ville_nom
HAVING
    nombre_occurence >= 2
ORDER BY
    nombre_occurence
DESC

9 - 

SELECT
    v.ville_id,
    v.ville_nom,
    V.ville_surface
FROM
    villes_france v
WHERE
    v.ville_surface >=(
    SELECT
        AVG(v.ville_surface)
    FROM
        villes_france v
);

10 - 
SELECT
    v.ville_departement AS "numero_departement",
    SUM(v.ville_population_2012) AS somme_population_2012
FROM
    villes_france v
GROUP BY
    v.ville_departement
HAVING
    somme_population_2012 >= 1500000

11 - 

UPDATE
    villes_france v
SET
    v.ville_nom =(
REPLACE
    (v.ville_nom, "-", " ")
)
WHERE
    LEFT(v.ville_nom, 6) = "SAINT-";

12 - 

SELECT
    v.ville_id,
    v.ville_nom,
    v.ville_surface
FROM
    villes_france v
ORDER BY
    v.ville_surface ASC
LIMIT 50;

13 - 


alter table regions  
add COLUMN region_nbDepartement INT 

14 - 

-- - Recupération du nombre de ville par départements : 

select count(d.departement_id) from departements d 
group by d.departement_regionId 
having d.departement = $param

begin

udpate regions r SET 
r.region_nbDepartement =

end

-- Puis on udpate en passant le param 

-- PLUS LE TEMPS, JE ME SUIS TROMPE SUR LA TABLE. 




15 - 

CREATE View three_tables as
SELECT v.ville_id, v.ville_nom, d.departement_id, d.departement_nom, r.region_id, r.region_nom
FROM villes_france v
INNER JOIN departements d  ON v.ville_departement = d.departement_code
INNER JOIN regions r  ON r.region_id = d.departement_regionId;
