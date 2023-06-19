using System;

namespace SudokuGrille
{
    public class Grille
    {
        public List<Ligne> Rangees { get; set; }
        public List<Ligne> Colonnes { get; set; }
        public List<Ligne> Blocks { get; set; }
        public EnumEtatGrille EtatGrille { get; set; }

        public bool PurgeRecomencer { get; set; }
        public bool ItterationRecomencer { get; set; }
        public string resolutionMessage { get; set; }

        public Grille(List<Ligne> _grille, EnumEtatGrille etatGrille = EnumEtatGrille.Incomplette)
        {
            Rangees = new List<Ligne>();
            Colonnes = new List<Ligne>();
            Blocks = new List<Ligne>();
            GenererRangees(_grille);
            GenererColonne();
            GenererBlocks();
            EtatGrille = etatGrille;

            PurgeRecomencer = false;
            ItterationRecomencer = false;
        }
        public Grille()
        {
            List<Ligne> grille = new List<Ligne>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new Ligne());
                for (int c = 0; c < 9; c++)
                {
                    grille[r].Cases.Add(new Case());
                }
            }
            Rangees = new List<Ligne>();
            Colonnes = new List<Ligne>();
            Blocks = new List<Ligne>();
            GenererRangees(grille);
            GenererColonne();
            GenererBlocks();
            EtatGrille = EnumEtatGrille.Vierge;
        }

        public void GenererRangees(List<Ligne> _grille)
        {
            for (int r = 0; r < 9; r++)
            {
                int numPosition = 0;
                Ligne rangee = new Ligne();
                for (int c = 0; c < 9; c++)
                {
                    rangee.Cases[c] = new Case(_grille[r].Cases[c]);
                    rangee.Cases[c].NumRangee = r;
                    rangee.Cases[c].NumPositionRangee = numPosition;
                    numPosition++;
                }

                Rangees.Add(new Ligne(rangee.Cases));
            }
        }
        public void GenererColonne()
        {

            for (int c = 0; c < 9; c++)
            {
                Ligne colonne = new Ligne();
                for (int r = 0; r < 9; r++)
                {
                    Rangees[r].Cases[c].NumColonne = c;
                    colonne.Cases[r] = Rangees[r].Cases[c];
                }
                Colonnes.Add(new Ligne(colonne.Cases));
            }

        }
        public void GenererBlocks()
        {
            int compteurBlock = -1;
            for (int rb = 0; rb < 3; rb++)
            {
                for (int cb = 0; cb < 3; cb++)
                {
                    Ligne block = new Ligne();
                    int compteur = 0;
                    compteurBlock++;
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            block.Cases[compteur] = Rangees[rb * 3 + r].Cases[cb * 3 + c];
                            block.Cases[compteur].NumBlock = compteurBlock;
                            compteur++;
                        }
                    }
                    compteur = 0;
                    Blocks.Add(new Ligne(block.Cases));

                }
            }
        }
        public int CompterItterationTotal()
        {
            int total = 0;
            foreach (Ligne r in Rangees)
            {
                total += r.CompterItterationLigne();
            }
            return total;
        }
        public Dictionary<int, int> RecupererItteration()
        {
            Dictionary<int, int> itteration = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
                { 9, 0 }
            };
            foreach (Ligne r in Rangees)
            {
                r.CompterItteration();
                for (int i = 1; i < 10; i++)
                {
                    itteration[i] += r.Itteration[i];
                }
            }
            return itteration;
        }
        public override string ToString()
        {
            string result = "";
            foreach (Ligne r in Rangees)
            {
                result += "\n________________________________________________________________________________________________________________\n";
                foreach (Case c in r.Cases)
                {
                    result += "(";
                    string temp = "";
                    foreach (int n in c.Contenu)
                    {
                        temp += n;
                    }
                    result += string.Format("{0,-9})|", temp);
                }
            }
            result += "\n________________________________________________________________________________________________________________";
            return result;
        }
    }
}