import P5 from 'p5';

export class P5Base {
  constructor(container) {
    this.container = container;
  }

  attached() {
    this.init();
  }

  init() {
    let self = this;
    let p5 = new P5((p) => {
      p.setup = () => {
        self.setup(p);
      };
      p.draw = () => {
        self.draw(p);
      };
    }, this.container, true);
    this.p5 = p5;
  }
}
