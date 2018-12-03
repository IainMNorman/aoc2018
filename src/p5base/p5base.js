import P5 from 'p5';

export class P5Base {
  constructor(container) {
    this.container = container;
    this.drawing = true;
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
        if (this.drawing) {
          self.draw(p);
        }
      };
    }, this.container, true);
    this.p5 = p5;
  }

  stop() {
    this.drawing = false;
  }
}
