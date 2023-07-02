class db{
    static async RecupererTableau(lien) 
    {
        let reponse = await fetch(lien);
        let json = await reponse.json();
        return json;
    }
}
export {db}