class ZipCode{
    constructor(_zipCode){
        this.zipCode=_zipCode;
        this.zipDetail=[];
    }

    ZipDetail(){
        for(let d of this.zipCode){
            this.zipDetail.push(d);
        }
        return this.zipDetail;
    }
}
export {ZipCode}