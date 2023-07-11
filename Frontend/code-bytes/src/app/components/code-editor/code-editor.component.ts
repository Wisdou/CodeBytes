import { AfterViewInit, Component, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { first } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { SolutionService } from 'src/app/services/solution.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Problem } from '../../services/problem.service';

declare var monaco: any;

export interface SolutionCode{
  code: string,
  language: string,
}

@Component({
  selector: 'app-code-editor',
  templateUrl: './code-editor.component.html',
  styleUrls: ['./code-editor.component.scss'],
})
export class CodeEditorComponent implements OnInit {
  @Output() currentCode = new EventEmitter<SolutionCode>();
  @Output() submitButtonClicked = new EventEmitter<void>();

  readonly avatarUrl = `https://img.icons8.com/?size=512&id=59862&format=png`;

  Possible_Languages: readonly string[] = [
    "C#",
    "Python",
    "Go",
    "F#",
    "C++"
  ];

  editorOptions = {theme: 'vs-dark', language: 'javascript'};
  
  problemForm!: FormGroup;

  constructor(private fb: FormBuilder){}

  ngOnInit(): void {
    this.problemForm = this.fb.group(
      {
        code: new FormControl('function x() {\nconsole.log("Hello world!");\n}'),
        language: new FormControl(this.Possible_Languages[0]),
      }
    );
    this.problemForm.valueChanges.subscribe(form => {
      const userCode = {
        language: form.language,
        code: form.code,
      };
      this.currentCode.emit(userCode);
    });
  }

  onClick(): void{
    this.submitButtonClicked.emit();
  }
}