import {Cereals} from "./Cereals.js";
import {GenerationHeader} from "./GenerationBody/GenerationHeader.js"
import {GenerationMain} from "./GenerationBody/GenerationMain.js"

let cereals = new Cereals();
await cereals.GetCereals();

let header = new GenerationHeader(cereals);
header.Generer();





