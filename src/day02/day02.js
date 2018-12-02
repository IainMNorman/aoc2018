import { P5Base } from '../p5base/p5base';

export class Day02 extends P5Base {
  constructor() {
    super('day02-container');
    this.answer1 = 0;
    this.answer2 = '';
    this.input = [];
    this.count = 0;
    this.twiceCount = 0;
    this.thriceCount = 0;
    this.part1Done = false;
    this.part2Done = false;
  }

  setup(p) {
    let self = this;
    p.textFont('Helvetica');
    p.loadStrings('https://aocproxy.azurewebsites.net/2018/day/2/input', (file) => {
      self.input = file;
      p.createCanvas(600, 200);
      p.background(21, 6, 37);
      p.fill(255, 215, 0);
      p.text('Checksum twice count', 0, 10);
      p.text('Checksum thrice count', 0, 85);
    });
  }

  draw(p) {
    if (this.input.length > 0) {
      if (!this.part1Done) {
        if (this.count < this.input.length) {
          if (this.hasRepeatedLetterCount(this.input[this.count], 2)) {
            this.twiceCount++;
          }
          if (this.hasRepeatedLetterCount(this.input[this.count], 3)) {
            this.thriceCount++;
          }

          p.rect(0, 15, this.twiceCount * 2, 50);
          p.rect(0, 90, this.thriceCount * 2, 50);
          this.answer1 = this.twiceCount * this.thriceCount;
          this.count++;
        } else {
          this.part1Done = true;
          this.count = 0;
        }
      }
    }

    if (this.part1Done && !this.part2Done) {
      let parcelA = this.input[this.count];

      for (let i = 0; i < this.input.length; i++) {
        let parcelB = this.input[i];
        let commonLetters = this.getCommonLettersWhenOnlyOneDifferent(parcelA, parcelB);
        p.textFont('courier');
        p.textSize(25);
        p.fill(21, 6, 37);
        p.noStroke();
        p.rect(0, 160, 600, 40);
        p.fill(255, 215, 0);
        p.text(parcelA, 0, 180);

        if (commonLetters) {
          this.part2Done = true;
          this.answer2 = commonLetters;
        }
      }
      this.count++;
    }

    if (this.part1Done && this.part2Done) {
      p.noLoop();
    }
  }

  getCommonLettersWhenOnlyOneDifferent(parcelId1, parcelId2) {
    let commonCount = 0;
    let uncommonIndex = 0;
    for (let i = 0; i < parcelId1.length; i++) {
      if (parcelId1[i] === parcelId2[i]) {
        commonCount++;
      } else {
        uncommonIndex = i;
      }
    }
    if (commonCount === parcelId1.length - 1) {
      let ar = parcelId1.split('');
      ar.splice(uncommonIndex, 1);
      return ar.join('');
    }
    return false;
  }

  hasRepeatedLetterCount(parcelId, count) {
    let dict = {};
    for (let i = 0; i < parcelId.length; i++) {
      dict[parcelId[i]] ? dict[parcelId[i]]++ : dict[parcelId[i]] = 1;
    }
    for (const key in dict) {
      if (dict[key] === count) {
        return true;
      }
    }
    return false;
  }
}
