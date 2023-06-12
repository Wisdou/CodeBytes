import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { ProblemService, Problem, ProblemFilter, ProblemsDTO } from './services/problem.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
  problemFunction: (filter: ProblemFilter) => Observable<ProblemsDTO>;
  constructor(private problemService: ProblemService){
    this.problemFunction = (filter: ProblemFilter) => this.problemService.getProblemsWithFilter(filter);
  }
}
