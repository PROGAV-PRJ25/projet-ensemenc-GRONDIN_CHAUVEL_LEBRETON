public class Corbeau : Obstacle
{
    public Corbeau () : base ("Corbeau", "animal", "Fruit", "Picore les fruits", 0.6f, 1)
    {}

     public override void Action()
    {
        if (Univers != null && Univers.PlantesCultivees != null)
        {
            foreach (Plante plante in Univers.PlantesCultivees)
        {
            if (plante != null && plante.Type == Plante.TypePlante.Fruit)
            {
                Console.Write(" 🐦‍⬛ ");
            }
        }
        }
    }
}