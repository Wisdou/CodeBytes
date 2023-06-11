import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input } from '@angular/core';
import { Problem, ProblemService, ProblemFilter, ProblemsDTO } from '../../services/problem.service';
import { tuiTablePaginationOptionsProvider } from '@taiga-ui/addon-table';
import { BehaviorSubject, debounce, debounceTime, of, tap } from 'rxjs';

@Component({
  selector: 'app-problems-table',
  templateUrl: './problems-table.component.html',
  styleUrls: ['./problems-table.component.scss'],
  providers: [
    tuiTablePaginationOptionsProvider({
      showPages: false,
    }),
  ],
})
export class ProblemsTableComponent {
  readonly columns: string[] = ['title', 'description', 'difficulty', 'tags'];
  readonly sizeOptions = [10, 50, 100];
  page: number = 0;
  private size: number = this.sizeOptions[0];
  private _startsWith: string = '';
  totalCount: number = 0;
  loading: boolean = false;
  currentFilter$: BehaviorSubject<ProblemFilter>;

  set startsWith(val: string) {
    this.page = 0;
    this._startsWith = val;
    this.currentFilter$.next(this.filter);
  }

  problems: Problem[] = [];

  get filter(): ProblemFilter{
    let paging = {
      size: this.size,
      page: this.page,
    };
    let filter: ProblemFilter = new ProblemFilter(paging, this._startsWith);
    return filter; 
  }

  constructor(private problemService: ProblemService, private cdRef: ChangeDetectorRef) {
    this.page = 0;
    this._startsWith = '';
    let paging = {
      size: this.size,
      page: this.page,
    };
    let filter: ProblemFilter = new ProblemFilter(paging, this._startsWith);
    this.currentFilter$ = new BehaviorSubject<ProblemFilter>(filter).pipe(debounceTime(200)) as BehaviorSubject<ProblemFilter>;
    this.currentFilter$.subscribe(filter => this.updateProblems(filter));
  }

  updateProblems(filter: ProblemFilter){
    this.problemService.getProblemsWithFilter(filter).pipe(tap(val => {
      console.log(1);
      this.totalCount = val.total;
      this.problems = val.problems;
      this.loading = false;
      this.cdRef.markForCheck();
    })).subscribe(() => undefined);
  }

  onPageChange(page: number) {
    this.page = page;
    this.currentFilter$.next(this.filter);
  }

  onSizeChange(size: number) {
    this.size = size;
    this.currentFilter$.next(this.filter);
  }

  readonly statusByDifficulty: Map<string, string> = new Map<string, string>(
    [
      ['Easy', 'color-3'],
      ['Medium', 'color-7'],
      ['Hard', 'color-5'],
      ['Unknown', 'color-21']
    ]
  );

  difficultyColor(difficulty: string): string{
    console.log(this.statusByDifficulty);
    return this.statusByDifficulty.get(difficulty) || 'color-22';
  }
}
