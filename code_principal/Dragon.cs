public class Dragon : Obstacle
{
    public Dragon () : base ("Ptit dragon", "animal", "Fleur", "Brûle les fleurs", 0.7f, 1)
    {}

    public override void Action()
    {
        foreach (Plante plante in Univers.PlantesCultivees)
        {
            if (plante != null && plante.Type == Plante.TypePlante.Fleur)
            {
                Console.Write(" 🔥 ");
            }
        }
    }
}