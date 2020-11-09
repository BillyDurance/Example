import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './faq.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
