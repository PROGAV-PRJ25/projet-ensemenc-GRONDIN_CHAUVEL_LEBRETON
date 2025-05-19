// Interface pour les modes de jeu
public interface IModeJeu
{
    void Executer(Jeu jeu);
    void AfficherMenu(Jeu jeu);
    void TraiterChoixUtilisateur(Jeu jeu, int choix);
}
public class Jeu
{
    private Terrain terrainActuel;
    private List<Plante> plantesPossedees = new List<Plante>();
    private List<Obstacle> obstaclesActifs = new List<Obstacle>();
    private List<BonneFee> bonnesFeeActives = new List<BonneFee>();
    private bool jeuEnCours = true;
    private int tour = 0;
    private const int ActionsParTour = 3;
    private int actionsRestantes = ActionsParTour;
    private Random random = new Random();
    private int agePlantes = 0;

    // Dictionnaire des modes de jeu disponibles
    private Dictionary<string, IModeJeu> modesDeJeu = new Dictionary<string, IModeJeu>();
    private IModeJeu modeActuel;

    // Propriétés pour permettre l'accès aux données depuis les modes
    public Terrain TerrainActuel => terrainActuel;
    public List<Plante> PlantesPossedees => plantesPossedees;
    public List<Obstacle> ObstaclesActifs => obstaclesActifs;
    public List<BonneFee> BonnesFeeActives => bonnesFeeActives;
    public bool JeuEnCours { get => jeuEnCours; set => jeuEnCours = value; }
    public int Tour => tour;
    public int ActionsRestantes { get => actionsRestantes; set => actionsRestantes = value; }
    public Random Random => random;
    public int AgePlantes => agePlantes;

    public Jeu()
    {
        // Initialisation des modes de jeu
        modesDeJeu.Add("Classique", new ModeClassique());
        modesDeJeu.Add("Urgence", new ModeUrgence());
        modeActuel = modesDeJeu["Classique"];
    }

    public void Demarrer()
    {
        Console.WriteLine("========================");
        Console.WriteLine("Bienvenue dans le simulateur de potager");
        Console.WriteLine("========================");

        ChoisirTerrain();
        InitialiserSemences();

        ExecuterBoucleJeu();
    }

    private void ChoisirTerrain()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("Choisissez le type de terrain pour votre potager :");
        Console.WriteLine("=================================\n");

        Console.WriteLine("1. Terrain Sableux");
        Console.WriteLine("   Description: Sol drainant et chaud, idéal pour les plantes méditerranéennes.");
        Console.WriteLine("   Avantages: Bonne croissance pour les plantes qui aiment la chaleur et le sol sec.");
        Console.WriteLine("   Inconvénients: Retient peu l'eau et les nutriments.\n");

        Console.WriteLine("2. Terrain Argileux");
        Console.WriteLine("   Description: Sol riche en nutriments mais drainant mal.");
        Console.WriteLine("   Avantages: Riche et fertile, idéal pour les légumes-racines.");
        Console.WriteLine("   Inconvénients: Peut être lourd et compact quand il est mouillé.\n");

        Console.WriteLine("3. Terrain Limoneux");
        Console.WriteLine("   Description: Sol équilibré et fertile, le meilleur pour un potager traditionnel.");
        Console.WriteLine("   Avantages: S'adapte à la plupart des plantes cultivées.");
        Console.WriteLine("   Inconvénients: Peut nécessiter un entretien régulier.\n");

        Console.WriteLine("4. Terrain Forestier");
        Console.WriteLine("   Description: Sol ombragé et riche en matière organique.");
        Console.WriteLine("   Avantages: Excellent pour les plantes d'ombre et les baies sauvages.");
        Console.WriteLine("   Inconvénients: Peu de lumière et compétition avec les racines d'arbres.\n");

        Console.Write("Votre choix (1-4): ");
        int choixTerrain = LireChoixUtilisateur(1, 4);

        switch (choixTerrain)
        {
            case 1:
                terrainActuel = new TerrainSableux();
                break;
            case 2:
                terrainActuel = new TerrainArgileux();
                break;
            case 3:
                terrainActuel = new TerrainLimoneux();
                break;
            case 4:
                terrainActuel = new TerrainForestier();
                break;
        }

        Console.WriteLine($"\nVous avez choisi un terrain {terrainActuel.TypeSol}.");
        Console.WriteLine(terrainActuel.Nom);

        Console.WriteLine("\nAppuyez sur une touche pour commencer à cultiver !");
        Console.ReadKey();
        Console.Clear();
    }

    private void InitialiserSemences()
    {
        // Ajouter les semences de base au joueur
        plantesPossedees.Add(new Carottes());
        plantesPossedees.Add(new Tomates());
        plantesPossedees.Add(new Salades());
        plantesPossedees.Add(new Rose());
        plantesPossedees.Add(new Fraise());
        plantesPossedees.Add(new Tournesol());

        Console.WriteLine("Vous commencez avec les semences suivantes :");
        for (int i = 0; i < plantesPossedees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {plantesPossedees[i].Nom}");
        }
    }

    private void ExecuterBoucleJeu()
    {
        while (jeuEnCours)
        {
            tour++;
            actionsRestantes = ActionsParTour;
            agePlantes++;

            // Déterminer si un événement d'urgence se produit
            if (random.Next(100) < 20 && tour > 2) // 20% de chance après le 2ème tour
            {
                modeActuel = modesDeJeu["Urgence"];
            }
            else
            {
                modeActuel = modesDeJeu["Classique"];
            }

            // Exécuter le mode de jeu actuel
            modeActuel.Executer(this);

            // Vérifier fin de jeu
            if (tour >= 50) // Limite de tours ou autre condition
            {
                Console.WriteLine("Fin de la partie ! Votre potager a vécu 50 semaines.");
                jeuEnCours = false;
            }
        }

        AfficherBilanFinal();
    }

    public string DeterminerSaison()
    {
        int saisonIndex = (tour % 4);
        switch (saisonIndex)
        {
            case 0: return "Printemps";
            case 1: return "Été";
            case 2: return "Automne";
            case 3: return "Hiver";
            default: return "Printemps";
        }
    }

    public void MettreAJourPlantes()
    {
        List<Plante> plantesARetirer = new List<Plante>();

        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Votre potager est vide. Plantez des semences !");
            return;
        }

        Console.WriteLine("\nÉtat des plantes :");
        foreach (Plante plante in terrainActuel.PlantesCultivees)
        {
            plante.MettreAJourCroissance();
            plante.VerifierFinDeVie(agePlantes);
            plante.AfficherEvolutionPlantes();
            plante.AfficherJauge();

            if (plante.Sante == Plante.EtatSante.Morte)
            {
                plantesARetirer.Add(plante);
            }
        }

        // Retirer les plantes mortes
        foreach (Plante planteMorte in plantesARetirer)
        {
            terrainActuel.PlantesCultivees.Remove(planteMorte);
            Console.WriteLine($"{planteMorte.Nom} a été retirée du potager.");
        }
    }

    public void MettreAJourObstacles()
    {
        List<Obstacle> obstaclesARetirer = new List<Obstacle>();

        foreach (Obstacle obstacle in obstaclesActifs)
        {
            obstacle.DureeTours--;
            if (obstacle.DureeTours <= 0)
            {
                obstaclesARetirer.Add(obstacle);
            }
            else
            {
                obstacle.Action();
            }
        }

        foreach (Obstacle obstacle in obstaclesARetirer)
        {
            obstaclesActifs.Remove(obstacle);
            Console.WriteLine($"{obstacle.Nom} a disparu du potager.");
        }

        // Possibilité d'ajouter un nouvel obstacle aléatoirement
        if (random.Next(100) < 15 && terrainActuel.PlantesCultivees.Count > 0) // 15% de chance
        {
            AjouterObstacleAleatoire();
        }
    }

    public void MettreAJourBonnesFees()
    {
        List<BonneFee> feesARetirer = new List<BonneFee>();

        foreach (BonneFee fee in bonnesFeeActives)
        {
            fee.DureeTours--;
            if (fee.DureeTours <= 0)
            {
                feesARetirer.Add(fee);
            }
        }

        foreach (BonneFee fee in feesARetirer)
        {
            bonnesFeeActives.Remove(fee);
            Console.WriteLine($"{fee.Nom} a quitté votre potager.");
        }

        // Possibilité d'ajouter une nouvelle bonne fée aléatoirement
        if (random.Next(100) < 10) // 10% de chance
        {
            AjouterBonneFeeAleatoire();
        }
    }

    private void AjouterObstacleAleatoire()
    {
        Obstacle nouvelObstacle = null;
        int typeObstacle = random.Next(3);

        switch (typeObstacle)
        {
            case 0:
                nouvelObstacle = new Taupe();
                break;
            case 1:
                nouvelObstacle = new Corbeau();
                break;
            case 2:
                nouvelObstacle = new Dragon();
                break;
        }

        if (nouvelObstacle != null)
        {
            nouvelObstacle.DefinirUnivers(terrainActuel);
            obstaclesActifs.Add(nouvelObstacle);
            Console.WriteLine($"\n!! ALERTE !! {nouvelObstacle.Nom} est apparu dans votre potager !");
            nouvelObstacle.Action();
        }
    }

    private void AjouterBonneFeeAleatoire()
    {
        BonneFee nouvelleFee = new Brebis();
        bonnesFeeActives.Add(nouvelleFee);
        Console.WriteLine($"\n✨ {nouvelleFee.Nom} est apparue pour aider votre potager ! ✨");
        Console.WriteLine($"Effet: {nouvelleFee.Effet} {nouvelleFee.Cible}");
    }

    public void PlanteSemence()
    {
        if (plantesPossedees.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de semences disponibles !");
            return;
        }

        Console.WriteLine("Quelle semence souhaitez-vous planter ?");
        for (int i = 0; i < plantesPossedees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {plantesPossedees[i].Nom} (Type: {plantesPossedees[i].Type})");
        }
        Console.WriteLine($"{plantesPossedees.Count + 1}. Annuler");

        int choix = LireChoixUtilisateur(1, plantesPossedees.Count + 1);

        if (choix <= plantesPossedees.Count)
        {
            Plante aPlanter = plantesPossedees[choix - 1];
            terrainActuel.AjouterPlante(aPlanter);
            plantesPossedees.RemoveAt(choix - 1);
            actionsRestantes--;
        }
        else
        {
            Console.WriteLine("Plantation annulée.");
        }
    }

    public void ArroserPlante()
    {
        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de plantes à arroser !");
            return;
        }

        Console.WriteLine("Quelle plante souhaitez-vous arroser ?");
        for (int i = 0; i < terrainActuel.PlantesCultivees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {terrainActuel.PlantesCultivees[i].Nom}");
        }
        Console.WriteLine($"{terrainActuel.PlantesCultivees.Count + 1}. Annuler");

        int choix = LireChoixUtilisateur(1, terrainActuel.PlantesCultivees.Count + 1);

        if (choix <= terrainActuel.PlantesCultivees.Count)
        {
            terrainActuel.PlantesCultivees[choix - 1].ArroserPlantes();
            actionsRestantes--;
        }
        else
        {
            Console.WriteLine("Arrosage annulé.");
        }
    }

    public void Desherber()
    {
        Console.WriteLine("Vous désherbez le terrain...");
        // Supprimer les mauvaises herbes s'il y en a
        int nbMauvaisesHerbesEnlevees = 0;
        List<Plante> plantesARetirer = new List<Plante>();

        foreach (Plante plante in terrainActuel.PlantesCultivees)
        {
            if (plante is MauvaiseHerbe)
            {
                plantesARetirer.Add(plante);
                nbMauvaisesHerbesEnlevees++;
            }
        }

        foreach (Plante mauvaise in plantesARetirer)
        {
            terrainActuel.PlantesCultivees.Remove(mauvaise);
        }

        if (nbMauvaisesHerbesEnlevees > 0)
        {
            Console.WriteLine($"Vous avez enlevé {nbMauvaisesHerbesEnlevees} mauvaise(s) herbe(s).");
        }
        else
        {
            Console.WriteLine("Il n'y avait pas de mauvaises herbes à enlever.");
        }

        actionsRestantes--;
    }

    public void FertiliserPlante()
    {
        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de plantes à fertiliser !");
            return;
        }

        Console.WriteLine("Quelle plante souhaitez-vous fertiliser ?");
        for (int i = 0; i < terrainActuel.PlantesCultivees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {terrainActuel.PlantesCultivees[i].Nom}");
        }
        Console.WriteLine($"{terrainActuel.PlantesCultivees.Count + 1}. Annuler");

        int choix = LireChoixUtilisateur(1, terrainActuel.PlantesCultivees.Count + 1);

        if (choix <= terrainActuel.PlantesCultivees.Count)
        {
            terrainActuel.PlantesCultivees[choix - 1].Fertiliser();
            actionsRestantes--;
        }
        else
        {
            Console.WriteLine("Fertilisation annulée.");
        }
    }

    public void TaillerPlante()
    {
        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de plantes à tailler !");
            return;
        }

        Console.WriteLine("Quelle plante souhaitez-vous tailler ?");
        for (int i = 0; i < terrainActuel.PlantesCultivees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {terrainActuel.PlantesCultivees[i].Nom}");
        }
        Console.WriteLine($"{terrainActuel.PlantesCultivees.Count + 1}. Annuler");

        int choix = LireChoixUtilisateur(1, terrainActuel.PlantesCultivees.Count + 1);

        if (choix <= terrainActuel.PlantesCultivees.Count)
        {
            terrainActuel.PlantesCultivees[choix - 1].Tailler();
            actionsRestantes--;
        }
        else
        {
            Console.WriteLine("Taillage annulé.");
        }
    }

    public void ExposerPlante()
    {
        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de plantes à exposer au soleil !");
            return;
        }

        Console.WriteLine("Quelle plante souhaitez-vous exposer au soleil ?");
        for (int i = 0; i < terrainActuel.PlantesCultivees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {terrainActuel.PlantesCultivees[i].Nom}");
        }
        Console.WriteLine($"{terrainActuel.PlantesCultivees.Count + 1}. Annuler");

        int choix = LireChoixUtilisateur(1, terrainActuel.PlantesCultivees.Count + 1);

        if (choix <= terrainActuel.PlantesCultivees.Count)
        {
            terrainActuel.PlantesCultivees[choix - 1].ExposerAuSoleil();
            actionsRestantes--;
        }
        else
        {
            Console.WriteLine("Exposition annulée.");
        }
    }

    public void RecolterPlante()
    {
        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Vous n'avez pas de plantes à récolter !");
            return;
        }

        Console.WriteLine("Quelle plante souhaitez-vous récolter ?");
        for (int i = 0; i < terrainActuel.PlantesCultivees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {terrainActuel.PlantesCultivees[i].Nom} (Croissance: {terrainActuel.PlantesCultivees[i].Croissance})");
        }
        Console.WriteLine($"{terrainActuel.PlantesCultivees.Count + 1}. Annuler");

        int choix = LireChoixUtilisateur(1, terrainActuel.PlantesCultivees.Count + 1);

        if (choix <= terrainActuel.PlantesCultivees.Count)
        {
            Plante aRecolter = terrainActuel.PlantesCultivees[choix - 1];
            aRecolter.Recolter();

            if (aRecolter.Sante == Plante.EtatSante.Morte)
            {
                terrainActuel.PlantesCultivees.Remove(aRecolter);

                // Ajouter des nouvelles semences en fonction du type récolté
                if (aRecolter is Legume || aRecolter is Fruit)
                {
                    // 50% de chance d'obtenir une nouvelle semence du même type
                    if (random.Next(100) < 50)
                    {
                        plantesPossedees.Add(aRecolter);
                        Console.WriteLine($"Vous avez obtenu une nouvelle semence de {aRecolter.Nom} !");
                    }
                }
            }

            actionsRestantes--;
        }
        else
        {
            Console.WriteLine("Récolte annulée.");
        }
    }

    public void AfficherInfosDetaillees()
    {
        Console.WriteLine("\n======= INFORMATIONS DÉTAILLÉES =======");
        Console.WriteLine(terrainActuel.ToString());

        Console.WriteLine("\nPLANTES CULTIVÉES :");
        if (terrainActuel.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Aucune plante dans le potager.");
        }
        else
        {
            foreach (Plante plante in terrainActuel.PlantesCultivees)
            {
                Console.WriteLine(plante.ToString());
                plante.AfficherJauge();
            }
        }

        Console.WriteLine("\nOBSTACLES ACTIFS :");
        if (obstaclesActifs.Count == 0)
        {
            Console.WriteLine("Aucun obstacle actif.");
        }
        else
        {
            foreach (Obstacle obstacle in obstaclesActifs)
            {
                Console.WriteLine(obstacle.ToString());
            }
        }

        Console.WriteLine("\nBONNES FÉES ACTIVES :");
        if (bonnesFeeActives.Count == 0)
        {
            Console.WriteLine("Aucune bonne fée active.");
        }
        else
        {
            foreach (BonneFee fee in bonnesFeeActives)
            {
                Console.WriteLine(fee.ToString());
            }
        }

        Console.WriteLine("\nSEMENCES DISPONIBLES :");
        if (plantesPossedees.Count == 0)
        {
            Console.WriteLine("Aucune semence disponible.");
        }
        else
        {
            foreach (Plante semence in plantesPossedees)
            {
                Console.WriteLine(semence.Nom);
            }
        }

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }

    public void ReparerTerrain()
    {
        // Réinitialiser les cases endommagées par les obstacles
        for (int i = 0; i < terrainActuel.Lignes; i++)
        {
            for (int j = 0; j < terrainActuel.Colonnes; j++)
            {
                // 6 = pas de géant, 7 = tas de terre (taupe)
                if (terrainActuel.TerrainVisuel[i, j] == 6 || terrainActuel.TerrainVisuel[i, j] == 7)
                {
                    terrainActuel.TerrainVisuel[i, j] = 0; // Remise à 0 (sol normal)
                }
            }
        }
        Console.WriteLine("Le terrain a été réparé !");
        actionsRestantes--;
    }

    public int LireChoixUtilisateur(int min, int max)
    {
        int choix;
        bool choixValide = false;
        
        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out choix) && choix >= min && choix <= max)
            {
                choixValide = true;
            }
            else
            {
                Console.Write($"Veuillez entrer un nombre entre {min} et {max}: ");
            }
        } while (!choixValide);
        
        return choix;
    }

    public bool ConfirmerAction(string message)
    {
        Console.Write(message);
        string reponse = Console.ReadLine().ToUpper();
        return reponse == "O" || reponse == "OUI" || reponse == "Y" || reponse == "YES";
    }

    private void AfficherBilanFinal()
    {
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("           BILAN FINAL               ");
        Console.WriteLine("======================================");
        
        Console.WriteLine($"Durée de votre aventure: {tour} tours");
        Console.WriteLine($"Type de terrain utilisé: {terrainActuel.TypeSol}");
        
        Console.WriteLine("\nStatistiques de votre potager :");
        Console.WriteLine($"Nombre de plantes encore vivantes: {terrainActuel.PlantesCultivees.Count}");
        
        int nbPlantesMatures = 0;
        int nbPlantesMalades = 0;
        
        foreach (Plante plante in terrainActuel.PlantesCultivees)
        {
            if (plante.Croissance >= 80)
            {
                nbPlantesMatures++;
            }
            
            if (plante.Sante == Plante.EtatSante.Malade)
            {
                nbPlantesMalades++;
            }
        }
        
        Console.WriteLine($"Plantes arrivées à maturité: {nbPlantesMatures}");
        Console.WriteLine($"Plantes malades: {nbPlantesMalades}");
        
        // Calcul du score global
        int score = nbPlantesMatures * 100 - nbPlantesMalades * 50;
        
        if (terrainActuel.EstProtege)
        {
            score += 200; // Bonus pour avoir mis en place une protection
        }
        
        Console.WriteLine($"\nVotre score final: {score} points");
        
        // Message personnalisé selon le score
        if (score >= 500)
        {
            Console.WriteLine("\nFélicitations ! Vous êtes un jardinier d'exception !");
        }
        else if (score >= 300)
        {
            Console.WriteLine("\nBravo ! Votre potager est un succès !");
        }
        else if (score >= 100)
        {
            Console.WriteLine("\nBon travail ! Votre potager s'est bien développé.");
        }
        else
        {
            Console.WriteLine("\nVous avez fait de votre mieux. La prochaine fois sera meilleure !");
        }
        
        Console.WriteLine("\nMerci d'avoir joué à notre simulateur de potager !");
        Console.WriteLine("Appuyez sur une touche pour quitter...");
        Console.ReadKey();
    }
}