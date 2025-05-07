public class Taupe : Obstacle
{
    public Taupe () : base ("Taupe", "animal", "Tout", "Fait des tas de terre et déracine les plantations", 0.5f, 1)
    {}

    public override void Action()
    {
        int nbTrous = 5; 

        for (int i = 0; i<nbTrous; i++)
        {
            int positionX = rnd.Next (0,Univers.Lignes-1);
            int positionY = rnd.Next (0,Univers.Colonnes-1);
            // Vérification pour éviter les index out of range
            if (positionX >= 0 && positionX < Univers.Lignes && 
                positionY >= 0 && positionY < Univers.Colonnes)
            {
                Univers.TerrainVisuel[positionX, positionY] = 7; // 7 représente un tas de terre
            }
        }
        
    }
}