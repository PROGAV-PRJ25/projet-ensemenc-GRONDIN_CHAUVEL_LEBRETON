public override void InitialiserT()
{
    base.InitialiserT();
    Random random = new Random();
    int nbArbres = random.Next(Lignes * Colonnes / 20, Lignes * Colonnes / 10);

    for (int i = 0; i < nbArbres; i++)
    {
        int x = random.Next(0, Lignes);
        int y = random.Next(0, Colonnes);
        if (T[x, y] == 0)
        {
            T[x, y] = 9; 
        }
    }
}
