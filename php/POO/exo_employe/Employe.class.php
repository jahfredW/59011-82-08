<?php

class Employe
{

    /*****************Attributs***************** */
    private $_nom;
    private $_prenom;
    private $_date_embauche;
    private $_fonction;
    private $_salaire;
    private $_service;

    /*****************Accesseurs***************** */
    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }

    public function getDate_embauche()
    {
        return $this->_date_embauche;
    }

    public function setDate_embauche(string $date_embauche)
    {
        $this->_date_embauche = $date_embauche;
    }

    public function getFonction()
    {
        return $this->_fonction;
    }

    public function setFonction($fonction)
    {
        $this->_fonction = $fonction;
    }

    public function getSalaire()
    {
        return $this->_salaire;
    }

    public function setSalaire($salaire)
    {
        $this->_salaire = $salaire;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = $service;
    }
    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value)
        {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable([$this, $methode])) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        return "";
    }

    // méthode de calcul d' ancienneté
    public function anciennete(){
        $today = new \DateTime();
        $date_embauche = new \DateTime($this->getDate_embauche());
        if($today > $date_embauche){
            $interval = $today->diff($date_embauche);
            return (int) $interval->days;;
        }
        return "date Invalide";
    }

    // méthode de calcul de la prime 
    public function calculPrime()
    {
        // salaire annuel : 5 pourcent du brut 
        $salaire_annuel = $this->getSalaire();
        $pourcentage_prime = $salaire_annuel * 0.05;

        // ancienneté : 2 pourcent du brut pour chaque année 
        $nbre_annees = floor($this->anciennete() / 365);
        $pourcentage_anciennete = $salaire_annuel * 0.02;
        
        $prime_totale = $pourcentage_prime + $nbre_annees * $pourcentage_anciennete;

        var_dump($prime_totale);
        return $prime_totale;

    }

    // méthode de versement de la prime 
    public function versement()
    {
        // date du jour 
        $today = new \DateTime();
        $currentYear = $today->format('Y');
        // date du 30/11 : 
        $date_de_versement = new \DateTime("30-11-$currentYear");

        // différence entre le nombre de jour : 
        $diff = $date_de_versement->diff($today); 
        if($diff == 0)
        {
            return true;
        }
        return false;
    }




}
// private $_nom;
// private $_prenom;
// private $_date_embauche;
// private $_fonction;
// private $_salaire;
// private $_service;
["nom" => "gruwe", "prenom" => "fred", "date_embauche" => "10-01-2022", "fonction" => "dev", "salaire" => 10000, "service" => "dev"];
$employe = new Employe(["nom" => "gruwe", "prenom" => "fred", "date_embauche" => "10-01-2022", "fonction" => "dev", "salaire" => 10, "service" => "dev"]);
$employe->calculPrime();

