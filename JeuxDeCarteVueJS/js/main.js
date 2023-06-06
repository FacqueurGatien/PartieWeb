import {carte } from "./carte.js";
import {cartes} from "./cartes.js";

var lien= "https://arfp.github.io/tp/web/frontend/cardgame/cardgame.json";

const app = {
    data() {
      return {
        titre: 'JeuxDeCarte',
        cartes:null
      }
    },
    async mounted(){
      /**@var {Cartes} cartes**/ 
      this.cartes = new cartes(lien);
      await this.cartes.fetchJson();
    }
  }
  Vue.createApp(app).mount('#app')