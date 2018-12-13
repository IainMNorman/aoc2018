import { PLATFORM } from 'aurelia-framework';

export class App {
  configureRouter(config, router) {
    config.map([
      { route: [''],   name: 'home',    moduleId: PLATFORM.moduleName('home/home') },
      { route: ['day01'],   name: 'day01',    moduleId: PLATFORM.moduleName('day01/day01') },
      { route: ['day02'],   name: 'day02',    moduleId: PLATFORM.moduleName('day02/day02') },
      { route: ['day03'],   name: 'day03',    moduleId: PLATFORM.moduleName('day03/day03') },
      { route: ['day04'],   name: 'day04',    moduleId: PLATFORM.moduleName('day04/day04') },
      { route: ['day05'],   name: 'day05',    moduleId: PLATFORM.moduleName('day05/day05') },
      { route: ['day10'],   name: 'day10',    moduleId: PLATFORM.moduleName('day10/day10') }
    ]);

    this.router = router;
  }
}
