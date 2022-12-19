import { Component, OnInit } from '@angular/core';
import { SignalrService } from '../signalr.service';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css']
})
export class DisplayComponent implements OnInit {

  display : string = "";

  constructor(private signalr : SignalrService) { }

  ngOnInit(): void {
    this.signalr.addListener("display", data => this.display = data);
  }

}
