import { PLATFORM } from "aurelia-framework";
  
export class App {
  configureRouter(config, router) {
    config.map([
      { route: [''],   name: 'home',    moduleId: PLATFORM.moduleName('home/home') },
      { route: ['day01'],   name: 'day01',    moduleId: PLATFORM.moduleName('day01/day01') },
      { route: ['day02'],   name: 'day02',    moduleId: PLATFORM.moduleName('day02/day02') }
    ]);

    this.router = router;
  }
}
