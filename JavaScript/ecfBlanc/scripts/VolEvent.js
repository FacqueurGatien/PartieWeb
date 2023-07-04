class VolEvent{
    static volCollection; 
    static sortDirection = true;

    static columnSortEvent(e){
        this.volCollection.columnSortEvent(e);
    }
}
export {VolEvent}