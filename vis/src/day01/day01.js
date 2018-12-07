import { P5Base } from '../p5base/p5base';

export class Day01 extends P5Base {
  constructor() {
    super('day01-container');
    this.speed = 30;
    this.count = 0;
    this.drift = 0;
    this.repeat = false;
    this.input = '';
    this.length = 0;
    this.pastFreqs = new Set([0]);
    this.partOne = false;
  }

  setup(p) {
    let self = this;
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/1/input', (file) => {
      file.pop();
      self.input = file;
      self.length = this.input.length;
      self.speed = self.length;
      p.createCanvas(p.map(self.length, 0, self.length, 0, 1200), 600);
      p.stroke(255, 215, 0);
      p.line(0, p.height / 2, p.width, p.height / 2);
      self.totalShifts = 0;
    });
  }

  draw(p) {
    if (this.input.length > 0 && this.count < this.length) {
      for (let i = 0; i < this.speed; i++) {
        let move = parseInt(this.input[this.count], 10);
        this.drift += move;
        if (this.pastFreqs.has(this.drift) && !repeat) {
          this.answer2 = this.drift;
          this.repeat = true;
          p.noLoop();
        } else {
          this.pastFreqs.add(this.drift);
        }
        p.point(p.map(this.count, 0, this.length, 0, p.width), p.map(this.drift, 80000, -80000, 0, p.height));
        this.count++;
        this.totalShifts++;
        if (this.count === this.length) {
          if (!this.partOne) {
            this.answer1 = this.drift;
            this.partOne = true;
          }
          this.count = 0;
        }
      }
    }
  }
}
