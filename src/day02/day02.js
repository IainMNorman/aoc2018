import P5 from "p5";

export class Day02 {
  answer1 = 0;
  answer2 = 0;

  attached() {
    this.initP5();
  }

  initP5() {
    this.p5 = new P5(this.sketch, "day02-container");
    this.p5.parent = this;
  }

  sketch(p) {
    let count = 0;
    let parcels = [];
    let rx = 1.25;
    let ry = 0.9;
    let rz = 0;

    p.setup = () => {
      p.loadStrings("https://aocproxy.azurewebsites.net/2015/day/2/input", (file) => {
        parcels = file;
        p.createCanvas(600, 600, p.WEBGL);
        p.background(21, 6, 37);
      });
    };

    p.draw = () => {
      if (parcels.length !== 0 && count !== parcels.length - 1) {
        let area = +(p.parent.calculateParcelArea(parcels[count]));
        p.parent.answer1 += area;
        p.fill(255, 215, 0)
        p.background(21, 6, 37);
        var dims = parcels[count].split("x");
        p.rotateY(rx += 0.005);
        p.rotateX(ry += 0.006);
        p.rotateZ(rz += 0.007);
        p.box(dims[0] * 10, dims[1] * 10, dims[2] * 10);
        if (count == parcels.length - 1) {
          p.noLoop();
        }

        count++;
      }
    };
  }

  calculateParcelArea(parcel) {
    let dims = parcel.split("x");
    let sides = [];
    sides.push(dims[0] * dims[1]);
    sides.push(dims[0] * dims[2]);
    sides.push(dims[1] * dims[2]);
    let smallest = Math.min(...sides);
    return smallest + sides[0] * 2 + sides[1] * 2 + sides[2] * 2;
  }
}
