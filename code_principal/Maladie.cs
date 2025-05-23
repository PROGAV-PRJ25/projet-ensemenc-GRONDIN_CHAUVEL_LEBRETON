public class Maladie : Obstacle
{
    public Maladie(string nom, int duree)
        : base(nom, "maladie", "contamine une plante en bonne santé", duree, affecteTerrain: false)
    {
    }

    public override void Agir()
    {
        // Créer une liste de plantes en bonne santé
        List<Plante> plantesSaines = new List<Plante>();

        foreach (Plante plante in Univers.PlantesCultivees)
        {
            if (plante.Sante == Plante.EtatSante.EnBonneSante)
            {
                plantesSaines.Add(plante);
            }
        }

        // S'il y a au moins une plante saine, on en contamine une au hasard
        if (plantesSaines.Count > 0)
        {
            int index = rnd.Next(plantesSaines.Count);
            Plante planteChoisie = plantesSaines[index];
            planteChoisie.Contaminer(Nom);
        }
        else
        {
            Console.WriteLine("Aucune plante saine à contaminer.");
        }
    }
}