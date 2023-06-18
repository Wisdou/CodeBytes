import { Component } from '@angular/core';
import * as _ from 'lodash';
import { Observable, of, switchMap, tap } from 'rxjs';
import { ProblemFilter, ProblemsDTO, ProblemService } from 'src/app/services/problem.service';

@Component({
  selector: 'app-problems',
  templateUrl: './problems.component.html',
  styleUrls: ['./problems.component.scss']
})
export class ProblemsComponent {
  problemFunction: (
    filter: ProblemFilter,
    initFunc: () => void
  ) => Observable<ProblemsDTO>;

  chartFunction: (
    initFunc?: () => void
  ) => Observable<ProblemsDTO>;

  constructor(private problemService: ProblemService) {
    this.problemFunction = (filter: ProblemFilter, initFunc: () => void) => {
      const problems$ = this.problemService
        .getProblemsWithFilter(filter);
      if (_.isFunction(initFunc)) {
        return of(undefined).pipe(
          tap(() => initFunc()),
          switchMap(() => problems$)
        );
      }
      return of(undefined).pipe(
        switchMap(() => problems$)
      );
    };

    this.chartFunction = (initFunc?: () => void) => {
      const problems$ = this.problemService.getProblems();
      if (_.isFunction(initFunc)) {
        return of(undefined).pipe(
          tap(() => initFunc()),
          switchMap(() => problems$)
        );
      }
      return of(undefined).pipe(
        switchMap(() => problems$)
      );
    };
  }
}
