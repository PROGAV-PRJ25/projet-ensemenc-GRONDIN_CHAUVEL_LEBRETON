public class ModeUrgence : IModeJeu
{
    public void Executer(Jeu jeu)
    {
        Console.Clear();
        Console.WriteLine("\n!!! ALERTE !!! MODE URGENCE ACTIVÉ !!! ALERTE !!!");
        Console.WriteLine("La webcam a détecté un problème dans votre potager !");

        // Générer un événement d'urgence aléatoire
        Obstacle urgence = null;
        int typeUrgence = jeu.Random.Next(3);
        switch (typeUrgence)
        {
            case 0:
                urgence = new Taupe();
                Console.WriteLine("Une taupe est en train de ravager votre potager !");
                break;
            case 1:
                urgence = new PasDeGeant();
                Console.WriteLine("Un géant piétine votre potager !");
                break;
            case 2:
                urgence = new Corbeau();
                Console.WriteLine("Des corbeaux attaquent vos fruits !");
                break;
        }

        if (urgence != null)
        {
            urgence.DefinirUnivers(jeu.TerrainActuel);
            urgence.Action();

            // Afficher le terrain avec les dégâts
            jeu.TerrainActuel.AfficherT(jeu.TerrainActuel.TerrainVisuel);

            AfficherMenu(jeu);
            int choix = jeu.LireChoixUtilisateur(1, 5);
            TraiterChoixUtilisateur(jeu, choix);
        }

        Console.WriteLine("\nL'urgence est terminée. Retour au mode classique.");
        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    public void AfficherMenu(Jeu jeu)
    {
        // Proposer des actions d'urgence
        Console.WriteLine("\nQue souhaitez-vous faire ? (Actions d'urgence)");
        Console.WriteLine("1. Faire du bruit pour effrayer l'intrus");
        Console.WriteLine("2. Déployer une protection temporaire");
        Console.WriteLine("3. Réparer les dégâts");
        Console.WriteLine("4. Acheter un épouvantail (protection permanente)");
        Console.WriteLine("5. Ne rien faire");
        Console.Write("Votre choix: ");
    }

    public void TraiterChoixUtilisateur(Jeu jeu, int choix)
    {
        switch (choix)
        {
            case 1:
                Console.WriteLine("Vous faites du bruit et effrayez temporairement l'intrus !");
                // Réduire l'impact de l'urgence
                break;
            case 2:
                Console.WriteLine("Vous déployez une bâche de protection !");
                // Protéger une partie des plantes
                break;
            case 3:
                Console.WriteLine("Vous réparez les dégâts causés par l'intrus !");
                // Restaurer certaines parties du terrain
                jeu.ReparerTerrain();
                break;
            case 4:
                Console.WriteLine("Vous installez un épouvantail pour éloigner les intrus !");
                jeu.TerrainActuel.EstProtege = true;
                break;
            case 5:
                Console.WriteLine("Vous laissez la nature suivre son cours...");
                break;
        }
    }
}