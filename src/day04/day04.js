import { P5Base } from '../p5base/p5base';
import { DateTime } from 'luxon';

export class Day04 extends P5Base {
  constructor() {
    super('day04-container');
    this.answer1 = 0;
    this.answer2 = 0;
    this.input = [];
    this.count = 0;
    this.dt = DateTime.utc(1518, 2, 11);
    this.currentState = 'unknown';
    this.currentGuard = 'unknown';
    this.guardX = 300;
  }

  setup(p) {
    this.stop();

    this.frameRate = 6;
    p.angleMode(p.DEGREES);
    p.createCanvas(600, 300);
    p.background(21, 6, 37);
    p.fill(255, 215, 0);
    p.stroke(255, 215, 0);

    p.textFont('Helvetica');

    this.lab = p.loadImage('/day04/lab.png');
    this.elfAwake = p.loadImage('/day04/elfawake.png');
    this.elfAwakeR = p.loadImage('/day04/elfawaker.png');
    this.elfAsleep = p.loadImage('/day04/elfasleep.png');

    let self = this;
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/4/input', (file) => {
      file.pop();
      self.input = file;
      this.play();
    });
  }

  draw(p) {
    p.frameRate(this.frameRate);
    p.background(21, 6, 37);
    p.image(this.lab, 0, 0);

    this.drawClock(p);
    let self = this;
    let line = this.input.filter(x => {
      return x.substring(1, 17) === self.dt.toFormat('yyyy-MM-dd HH:mm');
    })[0];
    if (line) {
      let sag = this.getInputStateAndGuard(line);
      this.currentState = sag.state;
      if (this.currentState === 'shift') {
        this.currentGuard = sag.guard;
      }
    }
    if (this.currentState === 'shift' || this.currentState === 'awake') {
      if (this.dt.minute % 2 === 0) {
        p.image(this.elfAwake, this.guardX, 140);
      } else {
        p.image(this.elfAwakeR, this.guardX, 140);
      }
      p.constrain(this.guardX += p.random(-30, 30), 100, 500);
    } else if (this.currentState === 'asleep') {
      p.image(this.elfAsleep, this.guardX, 140);
    }

    this.date = this.dt.toFormat('yyyy-MM-dd');
    this.dt = this.dt.plus({ minutes: 1 });
    if (this.dt.hour === 1) {
      this.dt = DateTime.utc(this.dt.year, this.dt.month, this.dt.day, 23, 40);
      this.currentGuard = 'unknown';
      this.currentState = 'unknown';
    }
  }

  drawClock(p) {
    let x = 60;
    let y = 60;
    p.rect(0, 0, 599, 299);
    p.noFill();
    p.ellipse(x, y, 60);
    this.lineAngle(p, x, y, ((Math.PI / -30) * this.dt.minute) + (Math.PI / 2), 25);
    this.lineAngle(p, x, y, ((Math.PI / -30) * (this.dt.hour + (this.dt.minute / 60)) * 5) + (Math.PI / 2), 20);
  }

  lineAngle(p, x, y, angle, length) {
    p.line(x, y, x + Math.cos(angle) * length, y - Math.sin(angle) * length);
  }

  getInputStateAndGuard(line) {
    if (line.includes('shift')) {
      let guard = line.match(/\d+/g)[5];
      return { state: 'shift', guard: guard };
    } else if (line.includes('wakes')) {
      return { state: 'awake' };
    } else if (line.includes('sleep')) {
      return { state: 'asleep' };
    }
  }
}
