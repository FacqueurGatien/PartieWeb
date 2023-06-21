class Db{
    static async fetchData(lien) 
    {
        let reponse = await fetch(lien);
        let json = await reponse.json();
        return json;
    }
}
export {Db}