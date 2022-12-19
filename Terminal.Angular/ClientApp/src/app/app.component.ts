import { Component, OnInit } from '@angular/core';
import { SignalrService } from './signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  constructor(private signalr : SignalrService) {}

  title = 'app';

  ngOnInit(): void {
    this.signalr.startConnection();
  }

}
