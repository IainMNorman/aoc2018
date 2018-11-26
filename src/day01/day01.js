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
    let currentFloor = 0;
    let basement = false;
    let input = "";
    let length = 0;

    p.setup = () => {
      p.loadStrings("https://aocproxy.azurewebsites.net/2015/day/1/input", (file) => {
        input = file[0];
        length = input.length;
        p.createCanvas(p.map(length, 0, length, 0, 600), 600);
        p.background(21, 6, 37);
        p.stroke(255, 215, 0);
        p.line(0, p.height / 2, p.width, p.height / 2);
      });
    };

    p.draw = () => {
      if (input.length !== 0) {
        for (let i = 0; i < speed; i++) {
          let move = input[count] === "(" ? 1 : -1;
          currentFloor += move;
          if (currentFloor === -1 && !basement) {
            p.parent.basement = count;
            basement = true;
          }
          if (count == length - 1) {
            p.parent.lastFloor = currentFloor;
          }
          p.point(p.map(count, 0, length, 0, p.width), p.map(currentFloor, 1000, -1000, 0, p.height));
          count++;
        }    
      }
    };
  }
}
