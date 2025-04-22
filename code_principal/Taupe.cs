public class Taupe : Obstacle
{
    public Taupe () : base ("Taupe", "animal", "Tout", "Fait des tas de terre et déracine les plantations", 0.5f, 1)
    {}

    public override void Action()
    {
        for (int i = 0; i<5; i++)
        {
            Random random = new Random ();
            int PositionX = random.Next (0,Univers.Lignes-1);
            int PositionY = random.Next (0,Univers.Colonnes-1);
            Univers.TerrainVisuel [PositionX,PositionY] = 7;
            i++;
        }
        
    }
}