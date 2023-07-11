// import du module FileSystem (permet de manipuler les fichiers locaux)
const fs = require('fs');

class CpuCollection
{
    constructor()
    {
        // Chargement du JSON (e frontend, on utilisait fetch pour charger un fichier distant)
        // ici, on charge un fichier local
        let rawdata = fs.readFileSync('cpuz.json');

        // Conversion du JSON en objet JS et stockage de l'objet dans this.data
        this.data = JSON.parse(rawdata);
    }

    /**
     * 
     * @param {Number} _id 
     * @returns {Object} found CPU or empty object if not found
     */
    findCpuById(_id)
    {
        let cpu = {};
        this.data.forEach(c => {
            if(c.id==_id){
                cpu=c;
            }
        });
        return cpu;
    }
    checkValue(value,type){
        if(typeof(value)==type){
            return true;
        }
        return false;
    }
    addCpu(_newCpu)
    {
        // implémenter ici l'ajout d'un CPU dans la collection 'this.data' puis retourner le nouveau CPU ajouté
        // Pensez à générer un nouvel identifiant pour le nouveau CPU
        if(
            this.checkValue(_newCpu.brand,"string") &&
            this.checkValue(_newCpu.family,"string") &&
            this.checkValue(_newCpu.model,"string") &&
            this.checkValue(_newCpu.ghz,"number") &&
            this.checkValue(_newCpu.price,"number"))
        {
            let maxId = Math.max.apply(Math, this.data.map(function(x){return x.id}));
            _newCpu.id=maxId+1;
            this.data.push(_newCpu);
        }
        return _newCpu;
    }
}


module.exports = CpuCollection