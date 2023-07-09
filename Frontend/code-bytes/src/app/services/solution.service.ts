import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { TUI_CACHE_BUSTING_PAYLOAD } from '@taiga-ui/core';

@Injectable({
  providedIn: 'root'
})
export class SolutionService {
  private readonly serverUrl: string = 'https://localhost:5001';
  private readonly hubName: string = 'solutions';

  private hubConnection!: signalR.HubConnection;

  public startConnection(){
    const hubUrl = `${this.serverUrl}/${this.hubName}`;
    this.hubConnection = new signalR.HubConnectionBuilder().withUrl(hubUrl).build();
    this.hubConnection.start().then(() => console.log('Connection started')).catch(err => console.log(err));
  }

  public solutionListener(user: string){
    this.hubConnection.on("GetSolution", (data) => {
      console.log(data);
    });
  }

  constructor() { }
}
