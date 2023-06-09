import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, of, debounceTime, tap, switchMap } from 'rxjs';
import {
  ProblemService,
  Problem,
  ProblemFilter,
  ProblemsDTO,
} from './services/problem.service';
import * as _ from 'lodash';
import { SideNavToggle } from './components/sidenav/sidenav.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
  isSideNavCollapsed: boolean = false;
  screenWidth: number = 0;

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

  onToggleSideNav(event: SideNavToggle){
    this.screenWidth = event.screenWidth;
    this.isSideNavCollapsed = event.collapsed;
  }
}
