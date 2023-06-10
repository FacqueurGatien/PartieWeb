using System;

namespace SudokuGrille
{
    public class Grille
    {
        public List<Rangee> Rangees { get; set; }
        public List<Colonne> Colonnes { get; set; }
        public List<Block> Blocks { get; set; }
        public List<List<Case>> GrilleDepart { get; set; }
        public EnumEtatGrille EtatGrille { get; set; }

        public bool PurgeRecomencer { get; set; }
        public bool ItterationRecomencer { get; set; }

        public Grille(List<List<Case>> _grille, EnumEtatGrille etatGrille = EnumEtatGrille.Incomplette)
        {
            GrilleDepart = _grille;
            Rangees = new List<Rangee>();
            Colonnes = new List<Colonne>();
            Blocks = new List<Block>();
            GenererRangees();
            GenererColonne();
            GenererBlocks();
            EtatGrille = etatGrille;

            PurgeRecomencer = false;
            ItterationRecomencer = false;
        }
        public Grille()
        {
            List<List<Case>> grille = new List<List<Case>>();
            for (int r = 0; r < 9; r++)
            {
                grille.Add(new List<Case>());
                for (int c = 0; c < 9; c++)
                {
                    grille[r].Add(new Case(0));
                }
            }
            GrilleDepart = grille;
            Rangees = new List<Rangee>();
            Colonnes = new List<Colonne>();
            Blocks = new List<Block>();
            GenererRangees();
            GenererColonne();
            GenererBlocks();
            EtatGrille = EnumEtatGrille.Vierge;
        }

        public void GenererRangees()
        {
            for (int r = 0; r < 9; r++)
            {
                Case[] rangee = new Case[9];
                for (int c = 0; c < 9; c++)

                {
                    rangee[c] = GrilleDepart[r][c];
                    rangee[c].NumRangee = r;
                }

                Rangees.Add(new Rangee(rangee));
            }
        }
        public void GenererColonne()
        {
            for (int i = 0; i < 9; i++)
            {
                Case[] colonne = new Case[9];
                for (int r = i; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (i == r)
                        {
                            colonne[c] = GrilleDepart[c][r];
                            colonne[c].NumColonne = r;
                        }

                    }
                }
                Colonnes.Add(new Colonne(colonne));
            }
        }
        public void GenererBlocks()
        {
            int compteur = 0;
            int compteurBlock = 0;
            Case[] block = new Case[9];
            for (int rb = 0; rb < 9; rb += 3)
            {
                for (int cb = 0; cb < 9; cb += 3)
                {
                    compteur = 0;
                    for (int r = rb; r < 9; r++)
                    {
                        for (int c = cb; c < 9; c++)
                        {
                            if ((rb == r || rb + 1 == r || rb + 2 == r) && (cb == c || cb + 1 == c || cb + 2 == c))
                            {
                                block[compteur] = GrilleDepart[r][c];
                                block[compteur].NumBlock = compteurBlock;
                                compteur++;
                            }
                            if (compteur == 9)
                            {
                                Blocks.Add(new Block(block));
                                c = 9;
                                r = 9;
                                block = new Case[9];
                            }
                        }
                    }
                    compteurBlock++;
                }
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (Rangee r in Rangees)
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