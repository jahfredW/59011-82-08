<?php 


/**
 * Classe formualaire, permet de construire un formualaire html. 
 */
class Formulaire 
{
    static $inputArray = [];

    private int $id;
    private string $action = "";
    private string $method = "get";
    private string $form = "";

    public function __construct($id, $action = "", $method = "get" )
    {
        $this->id = $id;
        $this->action = $action;
        $this->method = $method;
        $this->form = "";
    }

    /**
     * Construit les inputs et les stockes dans l'input Array. 
     *
     * @param integer $inputNumber
     * @param string $inputType
     * @return void
     */
    public function inputHtmlBuilder(string $name, string $type)
    {
        $input = "";
        // pour les champos de type text et password, on ajoute le label. 
        if($type ===  "text" || $type === "password"){
            $input  .= "<label for=\"" . $name . "\"> Entrez votre $name </label>";
        }
        $input .= "<input type=\"$type\" name=\"$name\"" . PHP_EOL;
        self::$inputArray[] = $input;
    }

    /**
     * création du formualaire
     *
     * @param [type] $buttonValue
     * @return string : le formulaire en chaine de caractère 
     */
    public function formHtmlBuilder(string $buttonValue) : string
    { 
        $this->form .= "<form action=\"$this->action\" method=\"$this->method\" id=\"$this->id\">" . PHP_EOL;
        for ($i = 1; $i <= count(self::$inputArray); $i++) 
        {
            $input = self::$inputArray[$i - 1];
            $id = $i + 1 ;
            $input .= "id=\"$id\" " . "/>" . PHP_EOL;
            $this->form .= $input;
        }
        $button = $this->buttonBuilder($buttonValue);

        $this->form .= $button;

        $this->form .= "</form>";

        return $this->form;
    }

    /**
     * Permet de créer un bouton 
     *
     * @param [type] $value
     * @return void
     */
    public function buttonBuilder($value)
    {
        $button = "";
        $button .= "<input type='submit' value = \"$value\" . />" . PHP_EOL; 

        return $button;
    }

    /**
     * Display du formualaire 
     *
     * @return string
     */
    public function __toString()
    {
        return $this->form . PHP_EOL;
    }


}


