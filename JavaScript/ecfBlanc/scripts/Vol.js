class Vol{
    constructor(vol){
        Object.assign(this,vol);
        this.duree=this.calcDuree();
    }
    getValues(){
        return Object.values(this);
    }
    calcDuree(){
        let date1 = new Date(this.start_time);
        let date2 = new Date(this.arrival_time);

        let diffTime = Math.abs(date2 - date1);
        let diffHours = Math.floor(diffTime / (1000 * 60 * 60 ))%24; 
        let diffMinute = Math.floor(diffTime / (1000 * 60  ))%60; 
        let diffSeconde = Math.floor(diffTime / (1000  ))%60; 

        let date = diffHours+":"+diffMinute+":"+diffSeconde
        return date;
    }
}
export {Vol}