import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private hubConnection? : HubConnection;

  public startConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7029/hub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('connection started'))
      .catch(err => console.log('Error starting connection: ' + err));
  }

  public addListener(key : string, callback : (data : string) => void) {
    if (this.hubConnection) {
      this.hubConnection.on(key, data => {
        console.log('received data for ' + key);
        callback(data);
      });
    }
  }
}
