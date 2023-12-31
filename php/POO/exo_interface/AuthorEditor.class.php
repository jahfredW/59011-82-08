<?php 

class AuthorEditor extends User implements IAuthor, IEditor
{

    /*****************Attributs***************** */
    private $_authorPrivilegesArray;
    private $_editorPrivilegesArray;

    /*****************Accesseurs***************** */

    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
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

    /**
     * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
     *
     * @param [type] $obj
     * @return bool
     */
    public function equalsTo($obj)
    {
        return true;
    }
    /**
     * Compare 2 objets
     * Renvoi 1 si le 1er est >
     *        0 si ils sont égaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareTo($obj1, $obj2)
    {
        return 0;
    }

    public function setEditorPrivileges(array $editorPrivilegesArray)
    {
        $this->_editorPrivilegesArray = $editorPrivilegesArray;
    }

    public function getEditorPrivileges()
    {
        return $this->_editorPrivilegesArray;
    }

    public function getAuthorPrivileges()
    {
        return $this->_authorPrivilegesArray;
    }

    public function setAuthorPrivileges(array $authorPrivilegesArray)
    {
        $this->_authorPrivilegesArray = $authorPrivilegesArray;
    }

    public function __toString()
    {
        return $this->getUsername() . " has the following privileges : " . implode(" , ", $this->getAuthorPrivileges());
    }
}