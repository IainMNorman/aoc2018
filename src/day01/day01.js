import P5 from "p5";

export class Day01 {
  attached() {
    this.initP5();
  }

  initP5() {
    this.p5 = new P5(this.sketch, "day01-container");
    this.p5.parent = this;
  }

  sketch(p) {
    let speed = 30;
    let count = 0;    
    let drift = 0;
    let repeat = false;
    let input = "";
    let length = 0;
    let pastFreqs = new Set([0]);
    let partOne = false;

    p.setup = () => {
      p.loadStrings("https://aocproxy.azurewebsites.net/2018/day/1/input", (file) => {
        file.pop();
        input = file;
        length = input.length;
        speed = length;
        p.createCanvas(p.map(length, 0, length, 0, 1200), 600);
        p.background(21, 6, 37);
        p.stroke(255, 215, 0);
        p.line(0, p.height / 2, p.width, p.height / 2);
        p.parent.totalShifts = 0;
      });
    };

    p.draw = () => {
      if (input.length !== 0 && count !== length) {
        for (let i = 0; i < speed; i++) {
          p.parent.count = count;
          let move = parseInt(input[count]);
          drift += move;
          if (pastFreqs.has(drift) && !repeat) {
            p.parent.repeat = drift;
            repeat = true;
            p.noLoop();
          } else {
            pastFreqs.add(drift);
          }
          p.point(p.map(count, 0, length, 0, p.width), p.map(drift, 80000, -80000, 0, p.height));
          count++;
          p.parent.totalShifts++;
          if (count == length) {
            if (!partOne) {
              p.parent.finalFreq = drift;
              partOne = true;
            }
            count = 0;
          }
        }
      }
    };
  }
}
