using System.Security.Cryptography.X509Certificates;

public class PasDeGeant : Obstacle
{
    public PasDeGeant () : base ("Pas de géant", "destructeur", "Tout", "Ecrase les plantations", 0.9f, 1)
    {}

    public override void Action()
    {
        int positionX = rnd.Next (1,Univers.Lignes-1);
        int positionY = rnd.Next (1,Univers.Colonnes-1);
        
        // Vérifications pour éviter les IndexOutOfRangeException
        if (positionX >= 0 && positionX < Univers.Lignes && 
            positionY >= 0 && positionY < Univers.Colonnes)
        {
            // On marque les cases du pas de géant
            Univers.TerrainVisuel[positionX, positionY] = 6;

            // On vérifie la validité de chaque position avant de la modifier
            TryModifyTerrain(positionX + 1, positionY);
            TryModifyTerrain(positionX, positionY + 1);
            TryModifyTerrain(positionX - 1, positionY);
            TryModifyTerrain(positionX, positionY - 1);
            TryModifyTerrain(positionX + 1, positionY + 1);
            TryModifyTerrain(positionX - 1, positionY - 1);
            TryModifyTerrain(positionX + 1, positionY - 1);
            TryModifyTerrain(positionX - 1, positionY + 1);
        }
    }

    // Méthode auxiliaire pour vérifier et modifier le terrain si la position est valide
    private void TryModifyTerrain(int x, int y)
    {
        if (x >= 0 && x < Univers.Lignes && y >= 0 && y < Univers.Colonnes)
        {
            Univers.TerrainVisuel[x, y] = 6;
        }
    }
}