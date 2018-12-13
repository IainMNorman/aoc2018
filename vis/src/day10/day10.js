import {
  P5Base
} from '../p5base/p5base';

export class Day10 extends P5Base {
  constructor() {
    super('day10-container');
    this.answer1 = 0;
    this.answer2 = 0;
    this.input = [];
    this.points = [];
    this.left = 0;
    this.top = 0;
    this.right = 0;
    this.bottom = 0;
    this.frameNumber = 1;
    this.divider = 200;
    this.ticksPerFrame = 10;
  }

  setup(p) {
    this.stop();

    this.frameRate = 30;
    p.frameRate(10);
    p.createCanvas(600, 600);
    p.background(21, 6, 37);
    p.fill(255, 215, 0);
    p.stroke(255, 215, 0);

    let self = this;
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/10/input', (file) => {
      file.pop();
      self.input = file;

      for (let i = 0; i < self.input.length; i++) {
        let x = parseInt(self.input[i].substr(10, 6), 10);
        let y = parseInt(self.input[i].substr(18, 6), 10);
        let dx = parseInt(self.input[i].substr(36, 2), 10);
        let dy = parseInt(self.input[i].substr(40, 2), 10);

        self.left = x < self.left ? x : self.left;
        self.top = y < self.top ? y : self.top;
        self.right = x > self.right ? x : self.right;
        self.bottom = y > self.bottom ? x : self.bottom;

        let newPoint = {
          position: p.createVector(x, y),
          velocity: p.createVector(dx, dy)
        };

        self.points.push(newPoint);
      }

      for (let j = 0; j < 10640; j++) {
        for (const point of self.points) {
          point.position.add(point.velocity);
          p.point(p.map(point.position.x, self.left / self.divider, self.right / self.divider, 0, 600), p.map(point.position.y, self.top / self.divider, self.bottom / self.divider, 0, 600));
        }
        self.frameNumber++;
      }

      self.play();
    });
  }

  draw(p) {
    p.frameRate(this.frameRate);

    for (let j = 0; j < 1; j++) {
      p.background(21, 6, 37);
      for (const point of this.points) {
        point.position.add(point.velocity);
        p.point(p.map(point.position.x, this.left / this.divider, this.right / this.divider, 0, 600), p.map(point.position.y, this.top / this.divider, this.bottom / this.divider, 0, 600));
      }
      this.frameNumber++;
    }

    if (this.frameNumber === 10645) p.noLoop();
  }


  faster() {
    this.p5.noLoop();
    this.p5.redraw();
  }

  slower() {
    this.frameRate--;
  }
}
