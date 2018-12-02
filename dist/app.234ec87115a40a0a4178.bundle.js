!function(t){function n(n){for(var r,a,u=n[0],s=n[1],c=n[2],h=0,f=[];h<u.length;h++)a=u[h],o[a]&&f.push(o[a][0]),o[a]=0;for(r in s)Object.prototype.hasOwnProperty.call(s,r)&&(t[r]=s[r]);for(p&&p(n);f.length;)f.shift()();return i.push.apply(i,c||[]),e()}function e(){for(var t,n=0;n<i.length;n++){for(var e=i[n],r=!0,u=1;u<e.length;u++){var s=e[u];0!==o[s]&&(r=!1)}r&&(i.splice(n--,1),t=a(a.s=e[0]))}return t}var r={},o={0:0},i=[];function a(n){if(r[n])return r[n].exports;var e=r[n]={i:n,l:!1,exports:{}};return t[n].call(e.exports,e,e.exports,a),e.l=!0,e.exports}a.m=t,a.c=r,a.d=function(t,n,e){a.o(t,n)||Object.defineProperty(t,n,{enumerable:!0,get:e})},a.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},a.t=function(t,n){if(1&n&&(t=a(t)),8&n)return t;if(4&n&&"object"==typeof t&&t&&t.__esModule)return t;var e=Object.create(null);if(a.r(e),Object.defineProperty(e,"default",{enumerable:!0,value:t}),2&n&&"string"!=typeof t)for(var r in t)a.d(e,r,function(n){return t[n]}.bind(null,r));return e},a.n=function(t){var n=t&&t.__esModule?function(){return t.default}:function(){return t};return a.d(n,"a",n),n},a.o=function(t,n){return Object.prototype.hasOwnProperty.call(t,n)},a.p="/";var u=window.webpackJsonp=window.webpackJsonp||[],s=u.push.bind(u);u.push=n,u=u.slice();for(var c=0;c<u.length;c++)n(u[c]);var p=s;i.push([137,5,3,4,2,1]),e()}({137:function(t,n,e){e(138),e(309),t.exports=e(312)},app:function(t,n,e){"use strict";e.r(n),e.d(n,"App",function(){return r});e("aurelia-framework");var r=function(){function t(){}return t.prototype.configureRouter=function(t,n){t.map([{route:[""],name:"home",moduleId:"home/home"},{route:["day01"],name:"day01",moduleId:"day01/day01"},{route:["day02"],name:"day02",moduleId:"day02/day02"}]),this.router=n},t}()},"app.html":function(t,n,e){t.exports='<template>\n  <require from="./app.scss"></require>\n  <nav><span class="glow">AOC 2018 - Iain M Norman</span> <a href="#">[Home]</a></nav>\n  <router-view></router-view>\n</template>\n'},"app.scss":function(t,n,e){(t.exports=e(308)(!1)).push([t.i,"body {\n  font-family: Cousine, 'Courier New', Courier, monospace;\n  background: #150625;\n  color: gold;\n  padding: 20px;\n  font-size: 18px; }\n\na {\n  color: goldenrod; }\n  a:hover {\n    color: gold;\n    text-decoration: none; }\n\nnav {\n  margin-bottom: 20px;\n  display: block; }\n\n.glow {\n  text-shadow: 0 0 5px #e0cc99; }\n\n.canvas-cont {\n  height: 600px; }\n",""])},"day01/day01":function(t,n,e){"use strict";e.r(n),e.d(n,"Day01",function(){return i});var r=e(77),o=e.n(r),i=function(){function t(){}var n=t.prototype;return n.attached=function(){this.initP5()},n.initP5=function(){this.p5=new o.a(this.sketch,"day01-container"),this.p5.parent=this},n.sketch=function(t){var n=30,e=0,r=0,o=!1,i="",a=0,u=new Set([0]),s=!1;t.setup=function(){t.loadStrings("https://aocproxy.azurewebsites.net/2018/day/1/input",function(e){e.pop(),a=(i=e).length,n=a,t.createCanvas(t.map(a,0,a,0,1200),600),t.background(21,6,37),t.stroke(255,215,0),t.line(0,t.height/2,t.width,t.height/2),t.parent.totalShifts=0})},t.draw=function(){if(0!==i.length&&e!==a)for(var c=0;c<n;c++){t.parent.count=e;var p=parseInt(i[e]);r+=p,u.has(r)&&!o?(t.parent.repeat=r,o=!0,t.noLoop()):u.add(r),t.point(t.map(e,0,a,0,t.width),t.map(r,8e4,-8e4,0,t.height)),e++,t.parent.totalShifts++,e==a&&(s||(t.parent.finalFreq=r,s=!0),e=0)}}},t}()},"day01/day01.html":function(t,n){t.exports='<template>\n  <p>--- Day 1: Chronal Calibration ---</p>\n  <div id="day01-container" class="canvas-cont"></div>\n  <p>Shifts: ${totalShifts}</p>\n  <p>First repeat: ${repeat}</p>\n  <p>Final frequency: ${finalFreq}</p>\n</template>\n'},"day02/day02":function(t,n,e){"use strict";e.r(n);var r=e(77),o=e.n(r),i=function(){function t(t){this.container=t}var n=t.prototype;return n.attached=function(){this.init()},n.init=function(){var t=this;new o.a(function(n){n.setup=function(){t.setup(n)},n.draw=function(){t.draw(n)}},this.container,!0)},t}();e.d(n,"Day02",function(){return a});var a=function(t){var n,e;function r(){var n;return(n=t.call(this,"day02-container")||this).answer1=0,n.answer2="",n.input=[],n.count=0,n.twiceCount=0,n.thriceCount=0,n.part1Done=!1,n.part2Done=!1,n}e=t,(n=r).prototype=Object.create(e.prototype),n.prototype.constructor=n,n.__proto__=e;var o=r.prototype;return o.setup=function(t){var n=this;t.textFont("Helvetica"),t.loadStrings("https://aocproxy.azurewebsites.net/2018/day/2/input",function(e){n.input=e,t.createCanvas(600,200),t.background(21,6,37),t.fill(255,215,0),t.text("Checksum twice count",0,10),t.text("Checksum thrice count",0,85)})},o.draw=function(t){if(this.input.length>0&&(this.part1Done||(this.count<this.input.length?(this.hasRepeatedLetterCount(this.input[this.count],2)&&this.twiceCount++,this.hasRepeatedLetterCount(this.input[this.count],3)&&this.thriceCount++,t.rect(0,15,2*this.twiceCount,50),t.rect(0,90,2*this.thriceCount,50),this.answer1=this.twiceCount*this.thriceCount,this.count++):(this.part1Done=!0,this.count=0))),this.part1Done&&!this.part2Done){for(var n=this.input[this.count],e=0;e<this.input.length;e++){var r=this.input[e],o=this.getCommonLettersWhenOnlyOneDifferent(n,r);t.textFont("courier"),t.textSize(25),t.fill(21,6,37),t.noStroke(),t.rect(0,160,600,40),t.fill(255,215,0),t.text(n,0,180),o&&(this.part2Done=!0,this.answer2=o)}this.count++}this.part1Done&&this.part2Done&&t.noLoop()},o.part2=function(t,n){for(var e=0;e<t.length;e++)for(var r=0;r<t.length;r++){var o=this.getCommonLettersWhenOnlyOneDifferent(t[e],t[r]);if(0!=o)return o}},o.getCommonLettersWhenOnlyOneDifferent=function(t,n){for(var e=0,r=0,o=0;o<t.length;o++)t[o]===n[o]?e++:r=o;if(e===t.length-1){var i=t.split("");return i.splice(r,1),i.join("")}return!1},o.hasRepeatedLetterCount=function(t,n){for(var e={},r=0;r<t.length;r++)e[t[r]]?e[t[r]]++:e[t[r]]=1;for(var o in e)if(e[o]==n)return!0;return!1},r}(i)},"day02/day02.html":function(t,n){t.exports='<template>\n  <p>--- Day 2: Inventory Management System ---</p>\n  <div id="day02-container"></div>\n  <p>Box list checksum: ${answer1}</p>\n  <p>Common letters: ${answer2}</p>\n</template>\n'},"home/home":function(t,n,e){"use strict";e.r(n),e.d(n,"Home",function(){return r});var r=function(){this.message="Hello world"}},"home/home.html":function(t,n){t.exports='<template>\n  <p><a href="#day01">--- Day 1: Chronal Calibration ---</a></p>\n  <p><a href="#day02">--- Day 2: Inventory Management System ---</a></p>\n</template>\n'},main:function(t,n,e){"use strict";e(139);var r={debug:!1,testing:!1},o=(e(0),e(13)),i=e.n(o);function a(t){return t.use.standardConfiguration().feature("resources/index"),t.use.developmentLogging(r.debug?"debug":"warn"),r.testing&&t.use.plugin("aurelia-testing"),t.start().then(function(){return t.setRoot("app")})}e.d(n,"configure",function(){return a}),i.a.config({warnings:{wForgottenReturn:!1}})},"resources/index":function(t,n,e){"use strict";function r(t){}e.r(n),e.d(n,"configure",function(){return r})}});
//# sourceMappingURL=app.234ec87115a40a0a4178.bundle.map