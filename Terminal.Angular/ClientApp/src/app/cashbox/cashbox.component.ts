import { Component, OnInit } from '@angular/core';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-cashbox',
  templateUrl: './cashbox.component.html',
  styleUrls: ['./cashbox.component.css']
})
export class CashboxComponent {

  constructor(private backend : BackendService) { }

  private pressButton(button: string) {
    this.backend.post("cashbox", button);
  }

  pressNewSale() {
    this.pressButton("StartNewSale");
  }

  pressFinishSale() {
    this.pressButton("FinishSale");
  }

  pressPayWithCash() {
    this.pressButton("PayWithCash");
  }

  pressPayWithCard() {
    this.pressButton("PayWithCard");
  }

  pressDisableExpressMode() {
    this.pressButton("DisableExpressMode");
  }

}
