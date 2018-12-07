import {
  P5Base
} from '../p5base/p5base';

export class Day05 extends P5Base {
  constructor() {
    super('day05-container');
    this.answer1 = 0;
    this.answer2 = 0;
    this.input = [];
  }

  setup(p) {
    this.stop();

    this.frameRate = 5;
    p.createCanvas(600, 600, p.WEBGL);
    p.background(21, 6, 37);
    p.fill(255, 215, 0);
    p.stroke(255, 215, 0);
    

    let self = this;
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/5/input', (file) => {
      self.input = file[0];
      this.play();
    });
  }

  draw(p) {
    p.background(21, 6, 37);
    p.orbitControl();
    for (let i = 0; i < 10000; i++) {
      let x = i % 200;
      let y = Math.floor(i / 200);
      p.push();
      p.translate((x * 5) - 200, (y * 5) - 200);
      p.sphere(1);
      p.pop();
    }
  }
}
