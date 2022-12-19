import { Component, OnInit } from '@angular/core';
import { SignalrService } from '../signalr.service';

@Component({
  selector: 'app-printer',
  templateUrl: './printer.component.html',
  styleUrls: ['./printer.component.css']
})
export class PrinterComponent implements OnInit {

  printed : string = "";

  constructor(private signalr : SignalrService) { }

  ngOnInit(): void {
    this.signalr.addListener("print", data => this.printed = data);
  }

}
