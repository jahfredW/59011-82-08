<?php 

class Formulaire 
{
    static $inputArray = [];

    private int $id;
    private string $action;
    private string $method;

    public function __construct($id)
    {
        $this->id = $id;
    }

    /**
     * Construit les inputs et les stockes dans l'input Array. 
     *
     * @param integer $inputNumber
     * @param string $inputType
     * @return void
     */
    public function inputHtmlBuilder(int $inputNumber, string $name, string $type)
    {
        $input = "";
        $input = "<input type=" . $type . "name=" .  $name;
        self::$inputArray[] = $input;
    }

    public function formHtmlBuilder()
    {
        $form = "";
        $form .= "<form action=" . $this->action . " method=" . $this->method;
    }
}

