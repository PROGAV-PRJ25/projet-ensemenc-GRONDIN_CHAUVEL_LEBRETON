using System.Security.Cryptography.X509Certificates;
public class PasDeGeant : Obstacle
{
    public PasDeGeant () : base ("Pas de géant", "destructeur",  "Ecrase toutes les plantations", 1)
    {}

    public override void Action()
    {
        
        Random random = new Random ();
        int PositionX = random.Next (0,Univers.Lignes-1);
        int PositionY = random.Next (0,Univers.Colonnes-1);
        Univers.T[PositionX,PositionY] = 6;
        Univers.T [PositionX+1,PositionY] = 6;
        Univers.T[PositionX,PositionY+1] = 6;
        Univers.T [PositionX-1,PositionY] = 6;
        Univers.T [PositionX,PositionY-1] = 6;
        Univers.T[PositionX+1,PositionY+1] = 6;
        Univers.T [PositionX-1,PositionY-1] = 6;
        Univers.T [PositionX+1,PositionY-1] = 6;
        Univers.T [PositionX-1,PositionY+1] = 6;
    }
}