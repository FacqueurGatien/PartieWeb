# ecf-webfront-cpuz
 
Vous devez créer une application web listant des microprocesseurs d’une usine de production. Les informations proviennent d’une API fictive et sont rendues disponibles dans le fichier JSON [www/cpuz.json](www/cpuz.json).

Pour chaque microprocesseur, vous devez afficher :

- L'identifiant
- La marque 
- La famille
- Le numéro de modèle
- La fréquence nominale
- Le prix
- Le nom complet

Le nom complet correspond à la Marque +  la Famille + le Numéro de modèle.

Exemple :

```json
{
        "id": 101,
        "brand": "AMD",
        "family": "Ryzen 3",
        "model": "3200G",
        "ghz": 3.6,
        "price": 99
}
```

Pour le microprocesseur ci-dessus, le nom complet sera **`AMD Ryzen 3 3200G`**

---

## Interface Utilisateur 

Vous disposez d'un `Kit de démarrage` dans le répertoire `www` de ce dépôt.

Réalisez une interface utilisateur accessible en utilisant uniquement les couleurs référencées dans le fichier `www/css/main-cpuz.css`. 

Le titre et l'image doivent être alignés horizontalement (le titre à gauche, l'image à droite).

Le champ de recherche doit être accessible.

La recherche se fait sur le *nom complet* du microprocesseur.

Le tableau HTML doit être centré et agréable à consulter.

Il est possible de trier les microprocesseurs selon leur prix.

Le nombre de microprocesseurs actuellement affichés est toujours disponible dans le pied de page.

--- 

