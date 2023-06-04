import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { Problem } from '../../services/problem.service';
import { tuiTablePaginationOptionsProvider } from '@taiga-ui/addon-table';

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
  readonly columns: string[] = ['title', 'description', 'status', 'tags'];
  readonly sizeOptions = [10, 50, 100];
  private page: number = 0;
  private size: number = this.sizeOptions[0];
  
  startsWith: string = '';

  @Input() problems: Problem[] = [];

  constructor() {}

  get total() {
    return this.problems.length;
  }

  get shownProblems() {
    return this.problems.slice(
      this.size * this.page,
      this.size * (this.page + 1)
    );
  }

  onPageChange(page: number) {
    this.page = page;
  }

  onSizeChange(size: number) {
    this.size = size;
  }
}
