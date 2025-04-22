public abstract class BonneFee
{
    public string Nom { get; set; }
    public string Type { get; set; } //"animal", "créature", "soleil", etc.
    public string Cible { get; set; } //"plante", "terrain", etc.
    public string Effet { get; set; }
    public int DureeTours { get; set; }

    public BonneFee(string nom, string type, string cible, string effet,  int dureeTours) // constructeur
    {
        Nom = nom;
        Type = type;
        Cible = cible;
        Effet = effet;
        DureeTours = dureeTours;
    }

    public override string ToString() // méthode pour afficher textuellement les obstacles et tout les informations qui les concernent
    {
        return $"{Nom} ({Type}) - Cible : {Cible}, Effet : {Effet}, Gravité : {Gravite*100}%" +
        $"Temporaire : {(EstTemporaire ? "Oui, " + DureeTours + "tours(s)" : "Non")}";
    }

}