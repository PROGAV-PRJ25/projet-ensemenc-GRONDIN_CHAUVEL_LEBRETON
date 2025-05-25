public class PoussiereDeFee : BonneFee
{
    private Terrain terrain;
    private static Random ok = new Random();

    public PoussiereDeFee(Terrain terrain)
        : base("Poussière de Fée", "Fait passer toutes les jeunes pousses en état final sur 6 lignes d'un terrain", 1)
    {
        this.terrain = terrain;
    }

    public override void AiderPotager()
    {
        int nbLignes = terrain.Lignes;
        int nbColonnes = terrain.Colonnes;

        int lignesAAgir = Math.Min(6, nbLignes);

        // Choisir un indice de départ aléatoire pour 6 lignes consécutives
        int startIndex = ok.Next(0, nbLignes - lignesAAgir + 1);

        // Parcourir toutes les plantes cultivées
        foreach (var plante in terrain.PlantesCultivees)
        {
            // Si la plante est sur une des lignes ciblées et qu'elle n'est pas morte
            if (plante.PositionX >= startIndex
                && plante.PositionX < startIndex + lignesAAgir
                && plante.Sante != Plante.EtatSante.Morte)
            {
                plante.AtteindreEtatFinal();
                Console.WriteLine($"{plante} a atteint son état final grâce à la {Nom} ✨");
            }
        }
    }


}