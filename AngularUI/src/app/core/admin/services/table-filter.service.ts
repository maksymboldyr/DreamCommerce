import { Injectable } from '@angular/core';
import { Filter } from '../interfaces/filter';
import { TableLazyLoadEvent } from 'primeng/table';
import { MultiSelectChangeEvent } from 'primeng/multiselect';

@Injectable({
  providedIn: 'root'
})
export class TableFilterService {
  filters: Filter[] = [];
  page: number = 1;
  pageSize: number = 10;
  sortField: string | string[] = '';
  sortOrder: number|undefined;

  constructor() {

  }

  get filtersString() {
    //remove filters with empty array as value
    this.filters = this.filters.filter(filter => {
      return !(Array.isArray(filter.value) && filter.value.length === 0);
    });
    return this.filters.map(filter => {
      return `${filter.field} ${filter.operator} ${filter.value}`;
    }).join(' and ');
  }

  emptyFilters() {
    this.filters = [];
  }

  addFilter(filter: Filter) {
    this.filters.push(filter);
  }

  removeFilter(filter: Filter) {
    this.filters = this.filters.filter(f => f !== filter);
  }

  applyFilters(event: TableLazyLoadEvent) {
    this.emptyFilters();
    for (let key in event.filters) {
      let eventFilterField = key;
      let eventFilter = event.filters[key];

      if (eventFilter) {
        if (Array.isArray(eventFilter)) {
          eventFilter = eventFilter[0];
        }
        if (eventFilter.value) {
          let filterValue = eventFilter.value;
          let filterOperator = eventFilter.matchMode || 'contains';

          this.addFilter({
            field: eventFilterField,
            value: filterValue,
            operator: filterOperator
          });
        }
      }
    }
  }

  applyMultiselectFilter(event: MultiSelectChangeEvent, field: string, tableEvent: TableLazyLoadEvent) {
    this.removeFilter({ field, value: '', operator: '' });
    if (event.value.length > 0) {
      this.addFilter({
        field,
        value: event.value,
        operator: 'in'
      });
    }
    this.mapMultiSelectToTableEvent(event, tableEvent, field);
  }

  applyPaginationAndSorting(event: TableLazyLoadEvent) {
    this.page = (event.first === 0 || event.first == undefined) ? 1 : event.first / (event.rows == undefined ? 1 : event.rows) + 1;
    this.pageSize = event.rows == undefined ? 10 : event.rows;
    this.sortField = event.sortField || this.sortField;
    this.sortOrder = event.sortOrder || 1;
  }

  mapMultiSelectToTableEvent(event: MultiSelectChangeEvent, tableEvent: TableLazyLoadEvent, field: string) {
    if (!tableEvent.filters) {
      tableEvent.filters = {};
    }
    tableEvent.filters[field] = { value: event.value, matchMode: 'in' };
  }
}