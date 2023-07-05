import { formatCurrency } from '@angular/common';
import { Component, Output, OnInit, EventEmitter } from '@angular/core';
import {AbstractControl, FormControl, FormGroup} from '@angular/forms';
import * as _ from 'lodash';

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

  filterTags: string[] = [];

  ngOnInit(): void {
    this.filterForm.valueChanges.subscribe((form) => {
      const newFilterParams = {
        startsWith: form.startsWith || '',
        difficulties: form.difficulty ?? [],
      }
      this.filterParamsChange.emit(newFilterParams);
      const newFilterTags = [];
      if (!_.isEmpty(form.startsWith)){
        newFilterTags.push('Starts with: ' + form.startsWith);
      }
      if (!_.isEmpty(form.difficulty) && !_.isNil(form.difficulty)){
        newFilterTags.push(...form.difficulty);
      }
      this.filterTags = newFilterTags;
    })
  }

  filterForm = new FormGroup({
    startsWith: new FormControl<string>(''),
    difficulty: new FormControl<string[]>([]),
  });
}
