public class ModeJeu
{
    public abstract void LancerTour(); // Tour différent pour chaque mode 

    public static ModeJeu CreerModeAleatoire()
    {
        Random rng = new Random();
        int choix = rng.Next(0,2);

        if (choix==0)
        {
            Console.WriteLine("Mode classique");
            return new ModeClassique();
        }
        else
        {
            Console.WriteLine("Mode urgence");
            return new ModeUrgence();
        }
    }
}