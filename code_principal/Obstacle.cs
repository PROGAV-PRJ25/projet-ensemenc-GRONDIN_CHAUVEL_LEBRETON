public abstract class Obstacle
{
    public string Nom { get; set; }
    public string Type { get; set; } //"animal", "intempérie", "maladie", etc.
    public string Cible { get; set; } //"plante", "terrain", "général", etc.
    public string Effet { get; set; }
    public float Gravite { get; set; } //0 à 1
    public bool EstTemporaire { get; set; }
    public int DureeTours { get; set; }

    public Obstacle(string nom, string type, string cible, string effet, float gravite, bool estTemporaire, int dureeTours) // constructeur
    {
        Nom = nom;
        Type = type;
        Cible = cible;
        Effet = effet;
        Gravite = gravite;
        EstTemporaire = estTemporaire;
        DureeTours = dureeTours;
    }

    public override string ToString() // méthode pour afficher textuellement les obstacles et tout les informations qui les concernent
    {
        return $"{Nom} ({Type}) - Cible : {Cible}, Effet : {Effet}, Gravité : {Gravite*100}%" +
        $"Temporaire : {(EstTemporaire ? "Oui, " + DureeTours + "tours(s)" : "Non")}";
    }

}