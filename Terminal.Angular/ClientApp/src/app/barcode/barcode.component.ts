import { Component, OnInit } from '@angular/core';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-barcode',
  templateUrl: './barcode.component.html',
  styleUrls: ['./barcode.component.css']
})
export class BarcodeComponent implements OnInit {

  barcode : string = "";

  constructor(private backend : BackendService) { }

  ngOnInit(): void {
  }

  sendBarcode(barcode : string) {
    this.backend.post("barcode", barcode);
  }

  sendCustomBarcode() {
    this.sendBarcode(this.barcode);
    this.barcode = "";
  }

}
