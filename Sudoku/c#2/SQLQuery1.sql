select g.Id as "Grille",l.Id as "Ligne", c.Id as "Case", c.Contenu as "value" from Grille as g
Join Ligne as l on l.GrilleId=g.Id
join [dbo].[Case] as c on c.LigneId=l.Id