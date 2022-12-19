import { Component, OnInit } from '@angular/core';
import { BackendService } from '../backend.service';
import { SignalrService } from '../signalr.service';

@Component({
  selector: 'app-card-reader',
  templateUrl: './card-reader.component.html',
  styleUrls: ['./card-reader.component.css']
})
export class CardReaderComponent implements OnInit {

  display : string = "";

  constructor(private backend : BackendService, private signalr : SignalrService) { }
  
  ngOnInit(): void {
    this.signalr.addListener("cardReaderDisplay", data => this.display = data);
  }

  selectCard(cardId : string) {
    this.backend.post("cardreader", cardId);
  }

  cancel() {
    this.backend.cancel("cardreader");
  }

}
