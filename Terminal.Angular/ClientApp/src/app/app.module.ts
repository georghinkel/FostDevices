import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BarcodeComponent } from './barcode/barcode.component';
import { DisplayComponent } from './display/display.component';
import { CardReaderComponent } from './card-reader/card-reader.component';
import { PrinterComponent } from './printer/printer.component';
import { CashboxComponent } from './cashbox/cashbox.component';

@NgModule({
  declarations: [
    AppComponent,
    BarcodeComponent,
    DisplayComponent,
    CardReaderComponent,
    PrinterComponent,
    CashboxComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
