import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';
import { ProblemService } from 'src/app/services/problem.service';
import { Problem, ProblemByIdDTO } from '../../services/problem.service';
import { of, switchMap } from 'rxjs';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss'],
})
export class ProblemComponent implements OnInit {
  @Input() problemId: number = 0;
  currentProblem!: Problem;
  constructor(
    private problemService: ProblemService,
    private router: Router,
    private route: ActivatedRoute,
    private cdRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    console.log('Initialised');
    const titlePromise = this.route.params.pipe(switchMap(params => {
      if (!_.isNil(params)) {
        this.problemId = parseInt(params['id']);
        return this.problemService
          .getProblem(this.problemId);
      }
      else{
        return of(undefined);
      }
    }));
    titlePromise.subscribe((problem: Problem | undefined) => {
      if (!_.isNil(problem)) {
        this.currentProblem = problem;
      } else {
        this.currentProblem = {
          id: -1,
          title: 'Not assigned',
          description: 'None',
          tags: [],
          difficulty: 'Unknown',
        };
      }
      this.cdRef.markForCheck();
    });
  }
}
