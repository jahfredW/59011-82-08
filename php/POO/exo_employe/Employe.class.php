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
    static $employe_liste;
    private $agence;
    private array $enfants;

    #region  /*****************Accesseurs***************** */ 
    public function getEnfants()
    {
        return $this->enfants;
    }

    public function setEnfants(Array $enfants)
    {
        $this->enfants = $enfants;
    }

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

    public function getAgence()
    {
        return $this->agence;
    }

    public function setAgence(Agence $agence)
    {
        $this->agence = $agence;
    }

    #endregion
    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        // ajout de l'employé créé à la liste statique 
        self::$employe_liste[] = $this;
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

    public static function compareToNom(Employe $a, Employe $b) : bool {
        return $a->getNom() < $b->getNom();
    }

    public static function compareToPrenom(Employe $a, Employe $b) : bool {
        return strcmp($a->getPrenom(), $b->getPrenom());
    }

    public static function compareToService(Employe $a, Employe $b) : bool {
        return strcmp($a->getService(), $b->getService());
    }

    public static function calculCout() : float {
        // salaire + prime 
        $salaire_total = 0;
        foreach(self::$employe_liste as $employe){
            $cout_pour_un_employe = $employe->getSalaire() + $employe->calculPrime();
            $salaire_total += $cout_pour_un_employe;
        }
        return $salaire_total;
    }
    
    // affiche et formate les datas
    public static function display($elt_to_display) : void
    {
        if(is_array($elt_to_display)){
            foreach($elt_to_display as $elt){
               if(is_object($elt)){
                foreach($elt as $sous_elt){
                    echo $sous_elt . " " . PHP_EOL;
                }
                echo PHP_EOL;
               } else {
                echo $elt . PHP_EOL;
               }
            }
        } else {
            echo $elt_to_display . PHP_EOL;
        }
    }

    public function displayResto()
    {
        echo $this->getAgence()->getResto() ? "il peut manger au resto" : "prévoir son repas" . PHP_EOL;
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
        
        // calcul de la prime totale 
        $prime_totale = $pourcentage_prime + $nbre_annees * $pourcentage_anciennete;

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
   
        if($diff->days == 0)
        {
            return true;
        }
        return false;
    }

    // méthode qui permet de déterminer si l'employé peut bénéficier de chêques vacances.
    public function canHaveHolidaysCheques() : bool
    {
        return $this->anciennete() > 365;
    }

    // méthode qui permet de déterminer si l'employé peut bénéficier des chêques Noel
    public function canHaveNoelCheques() : bool 
    {
        // déterminer le nomber d'enfants 
        return count($this->getEnfants()) > 0;
    }

    // affiche si les employés peuvent 
    public function displayNoelCheques(): void
    {
        echo $this->canHaveNoelCheques() ? "Oui" : "non";
    }


    // function de calcul des cheques de Noel 
    public function calculNoelCheque() : array
    {   
        $tabCheques = ["20" => 0, "30" => 0, "50" => 0];
      
        if($this->canHaveNoelCheques()){
            foreach($this->getEnfants() as $enfant){
                if($enfant->getAge() < 11)
                {
                    $tabCheques["20"] += 1;
                }

                else if($enfant->getAge() < 16){
                    $tabCheques["30"] += 1;
                }
                else 
                {
                    $tabCheques["50"] += 1;
                }
            }
        }

        return $tabCheques;
    }
    
    public function displayChequesNoel(array $chequeArray) : void
    {
        $total = 0;
        foreach($chequeArray as $key => $value)
        {
            if($value != 0){
                echo "cheque de " . $key . " euros, nombre : " . $value . PHP_EOL;
                $total += $value * (int)$key;
            }                
        }

        echo "Total " . $total;
    }

}



