import P5 from "p5";

export class Aup5 {
  constructor(container){
    this.container = container;
  }

  attached() {
    this.init();
  }

  init() {
    var self = this;
    new P5((p) => {
      p.setup = () => {
        self.setup(p);
      }  
      p.draw = () => {
        self.draw(p);
      }
    }, this.container, true);
  }
}
