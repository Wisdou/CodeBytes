import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';
import { ProblemService } from 'src/app/services/problem.service';
import { Problem, ProblemByIdDTO } from '../../services/problem.service';
import { of, switchMap } from 'rxjs';
import { SolutionService } from 'src/app/services/solution.service';
import { HttpClient } from '@angular/common/http';
import { SolutionCode } from '../../components/code-editor/code-editor.component';
interface SolutionRequest{
  code: string,
  language: string,
  problemId: number;
}

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss'],
})
export class ProblemComponent implements OnInit {
  @Input() problemId: number = -1;
  currentProblem!: Problem;
  currentSolution!: SolutionCode;

  constructor(
    private problemService: ProblemService,
    private route: ActivatedRoute,
    private cdRef: ChangeDetectorRef,
    public solutionService: SolutionService,
    private httpClient: HttpClient
  ) {
    this.currentSolution = {
      code: '',
      language: 'C#',
    };
  }

  ngOnInit(): void {
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

  onSolutionChanged(event: SolutionCode){
    this.currentSolution = event;
  }

  onSubmitClicked(){
    this.solutionService.startConnection();
    this.solutionService.solutionListener('Wisdou' + Math.random() * 100);
    const request: SolutionRequest = {
      problemId: this.problemId,
      code: this.currentSolution.code,
      language: this.currentSolution.language
    };
    this.httpClient.post('https://localhost:5001/api/solution', request).subscribe((res) => console.log(res));
  }
}
