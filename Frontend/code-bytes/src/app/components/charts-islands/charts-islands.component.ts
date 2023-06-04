import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-charts-islands',
  templateUrl: './charts-islands.component.html',
  styleUrls: ['./charts-islands.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChartsIslandsComponent {
  private readonly labels = ['Food', 'Cafe', 'Open Source', 'Taxi', 'other'];
  readonly value = [13769, 12367, 10172, 3018, 2592];
  readonly total = [...this.value].reduce((acc, x) => acc + x, 0);

  index = NaN;

  get sum(): number {
      return Number.isNaN(this.index) ? this.total : this.value[this.index];
  }

  get label(): string {
      return Number.isNaN(this.index) ? 'Total' : this.labels[this.index];
  }
}
