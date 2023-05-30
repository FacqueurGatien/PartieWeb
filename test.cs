public enum EnumSaison
{
    printemps,
    ete,
    automne,
    hivert
}
public class Vue
{
    public int point{ get; set;}
    public int po{get;set;}
    public int malus{get;set;}
    public List<object> objectifs{get;set;}
    public EnumSaison saison{get;set;}
    public List<object> cartes{get;set;}
    public object[,] matrice{get;set;} 

    public Vue(int _point,int _po, int _malus, List<object> _objectifs, EnumSaison _saison, List<object> _cartes, object[,] _matrice)
    {
        point = _point;
        po = _po;
        malus = _malus;
        objectifs = _objectifs;
        saison = _saison;
        cartes = _cartes;
        matrice = _matrice;
    }
}