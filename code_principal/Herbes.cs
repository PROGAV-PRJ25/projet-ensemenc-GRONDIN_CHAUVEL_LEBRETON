public abstract class Herbe: Plante 
{
    public Herbe(string nom, string saisonPref, TypePlante type, string typeSolNecessaire,
                float humiditeNecessaire, float temperatureNecessaire, int luminositeNecessaire,
                int espaceNecessaire, int esperanceDeVie, float croissance = 0)
        : base(nom, saisonPref, type, typeSolNecessaire, humiditeNecessaire, temperatureNecessaire,
               luminositeNecessaire, espaceNecessaire, esperanceDeVie, croissance) {}
}