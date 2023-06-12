import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { TuiLabelModule } from '@taiga-ui/core';
import { distinct, Observable, of } from 'rxjs';
import { ProblemFilter, ProblemsDTO } from 'src/app/services/problem.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-charts-islands',
  templateUrl: './charts-islands.component.html',
  styleUrls: ['./charts-islands.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChartsIslandsComponent implements OnInit {
  @Input() dataSource: (initFunc?: () => void) => Observable<ProblemsDTO> =
    () => of({ total: 0, problems: [] });

  labels: string[] = [];
  value: number[] = [];

  constructor(private cdRef: ChangeDetectorRef) {}

  get total(): number {
    return [...this.value].reduce((acc, x) => acc + x, 0);
  }

  index = NaN;

  get sum(): number {
    return Number.isNaN(this.index) ? this.total : this.value[this.index];
  }

  get label(): string {
    return Number.isNaN(this.index) ? 'Total' : this.labels[this.index];
  }

  ngOnInit(): void {
    this.dataSource().subscribe((problems) => {
      const data = problems.problems;
      const problemGroups = _.groupBy(data, (val) => val.difficulty);
      this.labels = _.keys(problemGroups);
      this.value = this.labels.map((val) => problemGroups[val].length);
      this.cdRef.markForCheck();
    });
  }
}
