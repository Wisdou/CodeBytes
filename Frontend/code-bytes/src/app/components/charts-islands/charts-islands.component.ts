import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-charts-islands',
  templateUrl: './charts-islands.component.html',
  styleUrls: ['./charts-islands.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChartsIslandsComponent {
  testForm = new FormGroup({
    testValue: new FormControl(true),
  });
}
