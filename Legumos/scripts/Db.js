class Db{
    static async getDb(link){
        let response = await fetch(link);
        return await response.json();
    }
}
export {Db};