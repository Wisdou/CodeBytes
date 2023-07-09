import { AfterViewInit, Component, OnInit } from '@angular/core';
import { first } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { SolutionService } from 'src/app/services/solution.service';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

declare var monaco: any;

@Component({
  selector: 'app-code-editor',
  templateUrl: './code-editor.component.html',
  styleUrls: ['./code-editor.component.scss'],
})
export class CodeEditorComponent implements OnInit {
  editorOptions = {theme: 'vs-dark', language: 'javascript'};
  code: string= 'function x() {\nconsole.log("Hello world!");\n}';
  chosenLanguage: string = "C#";

  items: readonly string[] = [
    "C#",
    "Python",
    "Go",
    "F#",
    "C++"
  ];

  problemForm: FormControl = new FormControl(this.items[0]);
  
  constructor(public solutionService: SolutionService, private httpClient: HttpClient){}

  ngOnInit(): void {
    this.solutionService.startConnection();
    this.solutionService.solutionListener('Wisdou' + Math.random() * 100);
    this.httpClient.get('https://localhost:5001/api/solution').subscribe((res) => console.log(res));
  }
}