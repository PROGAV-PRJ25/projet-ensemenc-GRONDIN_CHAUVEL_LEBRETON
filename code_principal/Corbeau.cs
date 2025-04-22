public class Corbeau : Obstacle
{
    public Corbeau () : base ("Corbeau", "animal", "Fruit", "Picore les fruits", 0.6f, 1)
    {}

     public override void Action()
    {
        foreach (Plante plante in Univers.PlantesCultivees)
        {
            if (plante.TypePlante == Type.Fruit)
            {
                Console.Write(" 🐦‍⬛ ");
            }
        }
    }
}