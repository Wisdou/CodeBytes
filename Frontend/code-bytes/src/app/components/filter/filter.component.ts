import { Component, Output, OnInit, EventEmitter } from '@angular/core';
import {AbstractControl, FormControl, FormGroup} from '@angular/forms';

export interface FilterParams{
  startsWith: string;
  difficulties: string[];
}

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  @Output() filterParamsChange = new EventEmitter<FilterParams>();

  difficulties: readonly string[] = [
    'Easy',
    'Medium',
    'Hard'
  ];

  ngOnInit(): void {
    this.filterForm.valueChanges.subscribe((form) => {
      const newFilterParams = {
        startsWith: form.startsWith || '',
        difficulties: form.difficulty ?? [],
      }
      this.filterParamsChange.emit(newFilterParams);
    })
  }

  filterForm = new FormGroup({
    startsWith: new FormControl<string>(''),
    difficulty: new FormControl<string[]>([]),
  });
}
