import { P5Base } from '../p5base/p5base';

export class Day02 extends P5Base {
  constructor() {
    super('day03-container');
    this.answer1;
    this.answer2;
    this.input = [];
    this.count = 0;
  }

  setup(p) {
    let self = this;
    p.textFont('Helvetica');
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/3/input', (file) => {
      self.input = file;
      p.createCanvas(600, 200);
      p.background(21, 6, 37);
      p.fill(255, 215, 0);
    });
  }

  draw(p) {
    if (this.input.length > 0) {
      //null
    }
  }
}
