public abstract class Obstacle 
{
    public string Nom { get; set; }
    public string Type { get; set; } // "animal", "intempérie", "maladie", etc.
    public string Cible { get; set; } // "plante", "terrain", "général", etc.
    public string Effet { get; set; }
    public float Gravite { get; set; } // 0 à 1
    public int DureeTours { get; set; }
    public Terrain Univers { get; set; }
    private static Random random = new Random(); // pour le déplacement aléatoire

    public Obstacle(string nom, string type, string cible, string effet, float gravite, int dureeTours) // constructeur
    {
        Nom = nom;
        Type = type;
        Cible = cible;
        Effet = effet;
        Gravite = gravite;
        DureeTours = dureeTours;
    }
   
    public abstract void Action() ;
    public override string ToString() // méthode pour afficher textuellement les obstacles et tout les informations qui les concernent
    {
        return $"{Nom} ({Type}) - Cible : {Cible}, Effet : {Effet}, Gravité : {Gravite*100}%" +
        $"Durée : { DureeTours} tours(s)";
    }

}