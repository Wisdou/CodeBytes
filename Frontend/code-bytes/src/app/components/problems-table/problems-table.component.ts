import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Problem, ProblemService, ProblemFilter, ProblemsDTO } from '../../services/problem.service';
import { tuiTablePaginationOptionsProvider } from '@taiga-ui/addon-table';
import { BehaviorSubject, debounce, debounceTime, of, tap, Observable, Subscriber, Subscription, Subject } from 'rxjs';

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
export class ProblemsTableComponent implements OnInit, OnDestroy {
  @Input() dataSource: (filter: ProblemFilter, initFunc: () => void) => Observable<ProblemsDTO> = () => of({total: 0, problems: [] });

  readonly columns: string[] = ['title', 'description', 'difficulty', 'tags'];
  readonly sizeOptions = [10, 50, 100];
  private size: number = this.sizeOptions[0];
  private _startsWith: string = '';
  totalCount: number = 0;
  page: number = 0;
  loading: boolean = false;
  updateProblems$: Subject<ProblemFilter>;
  problemSubscription: Subscription;

  set startsWith(val: string) {
    this.page = 0;
    this._startsWith = val;
    this.updateProblems$.next(this.filter);
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

  constructor(private cdRef: ChangeDetectorRef) {
    this.page = 0;
    this._startsWith = '';
    let paging = {
      size: this.size,
      page: this.page,
    };
    let filter: ProblemFilter = new ProblemFilter(paging, this._startsWith);
    this.updateProblems$ = new Subject<ProblemFilter>().pipe(debounceTime(300)) as Subject<ProblemFilter>;
    this.problemSubscription = this.updateProblems$.subscribe(filter => {
      this.loading = true;
      this.cdRef.markForCheck();
      this.updateProblems(this.filter);
    });
  }

  ngOnDestroy(): void {
    this.problemSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.updateProblems$.next(this.filter);
  }

  updateProblems(filter: ProblemFilter){
    this.dataSource(filter, () => {}).subscribe((problemsPage) => {
      this.totalCount = problemsPage.total;
      this.problems = problemsPage.problems;
      this.loading = false;
      this.cdRef.markForCheck();
    });
  }

  onPageChange(page: number) {
    this.page = page;
    this.updateProblems$.next(this.filter);
  }

  onSizeChange(size: number) {
    this.size = size;
    this.updateProblems$.next(this.filter);
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
    return this.statusByDifficulty.get(difficulty) || 'color-22';
  }
}
