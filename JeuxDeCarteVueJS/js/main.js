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
    },
    computed: {
      clesCarte(){
        return this.cartes.getFirst().getKeys();
      },
      forColspan(){
        return this.cartes.getFirst().getKeys().length;
      }
    }
  }
  Vue.createApp(app).mount('#app')

