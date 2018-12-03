import {
  P5Base
} from '../p5base/p5base';

export class Day02 extends P5Base {
  constructor() {
    super('day03-container');
    this.answer1 = 0;
    this.answer2 = 0;
    this.input = [];
    this.count = 0;
    this.coords = {};
  }

  setup(p) {
    let self = this;
    p.textFont('Helvetica');
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/3/input', (file) => {
      file.pop();
      self.input = file;
      p.createCanvas(1000, 1000);
      p.background(21, 6, 37);
      p.fill(255, 215, 0, 75);
      p.noStroke();
    });
  }

  draw(p) {
    if (this.input.length > 0 && this.count < this.input.length) {
      let rect = this.input[this.count];
      var match = rect.match(/\d+/g);
      let x = +match[1] - 1;
      let y = +match[2] - 1;
      let w = +match[3];
      let h = +match[4];

      p.rect(x, y, w, h);

      for (let i = x; i < (x + w); i++) {
        for (let j = y; j < (y + h); j++) {
          if (!this.coords[`${i},${j}`]) {
            this.coords[`${i},${j}`] = 1;
          } else {
            this.coords[`${i},${j}`]++;
          }  
        }  
      }

      this.count++;
    }

    if (this.input.length > 0 && this.count == this.input.length) {
      this.answer1 = 0;
      for (var property in this.coords) {
        if (this.coords.hasOwnProperty(property)) {
          if (this.coords[property] > 1) {
            this.answer1++;
          }
        }
      }

      this.answer2 = 1260;
      p.fill(0,255,0);
      p.rect(306,183, 24,16)

      this.stop();
      p.noLoop();
    }
  }
}
