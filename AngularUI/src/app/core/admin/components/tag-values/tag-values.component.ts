import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { TagValueService } from '../../services/tag-value.service';
import { Router } from '@angular/router';
import { TableFilterService } from '../../services/table-filter.service';
import { TagValueDto } from '../../interfaces/tag-value-dto';
import { ToolbarModule } from 'primeng/toolbar';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';
import { TagService } from '../../services/tag.service';
import { TagDto } from '../../interfaces/tag-dto';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectChangeEvent, MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-tag-values',
  standalone: true,
  providers: [TableFilterService],
  imports: [
    CommonModule,
    TableModule,
    InputTextModule,
    DialogModule,
    ButtonModule,
    ToolbarModule,
    FormsModule,
    FieldsetModule,
    ReactiveFormsModule,
    DropdownModule,
    MultiSelectModule,
  ],
  templateUrl: './tag-values.component.html',
  styleUrls: ['./tag-values.component.scss']
})
export class TagValuesComponent {
  tagValueService: TagValueService;
  tagService: TagService;
  router: Router;
  tableFilter: TableFilterService;
  loading: boolean = true;

  tagValues: TagValueDto[] = [];
  tags: TagDto[] = [];
  tagNames: string[] = [];
  totalRecords: number = 100;

  tagValueField: string = '';
  tagDropdownSelect: TagDto | undefined;

  tagValueFormVisible: boolean = false;

  lastEvent: TableLazyLoadEvent = {};
  tagNamesToFilter: string[] = [];

  constructor(tagValueService: TagValueService, tagService: TagService, router: Router, tableFilter: TableFilterService) {
    this.tagValueService = tagValueService;
    this.tagService = tagService;
    this.router = router;
    this.tableFilter = tableFilter;
  }

  ngOnInit() {
    this.getTags();
  }

  loadData(event: TableLazyLoadEvent) {
    if (event.filters) {
      this.tableFilter.applyFilters(event);
    }

    this.tableFilter.applyPaginationAndSorting(event);

    this.getTagValues();

    this.loading = false;
    this.lastEvent = event;
  }

  getTagValues() {
    this.loading = true;
    this.tagValueService.getFiltered(
      this.tableFilter.filtersString,
      this.tableFilter.page,
      this.tableFilter.pageSize,
      this.tableFilter.sortField,
      this.tableFilter.sortOrder)
      .subscribe((response: { totalCount: number, data: TagValueDto[] }) => {
        this.tagValues = response.data;
        this.totalRecords = response.totalCount;
        this.loading = false;
      });
  }

  getTags() {
    this.tagService.getAll().subscribe((tags: TagDto[]) => {
      this.tags = tags;
      this.tagNames = tags.map(tag => tag.name);
    });
  }

  addTagValue() {
    const tagValue: TagValueDto = {
      value: this.tagValueField,
      tagId: this.tagDropdownSelect?.id || '',
    };

    return this.tagValueService.create(tagValue).subscribe(() => {
      this.getTagValues();
      this.toggleFormDialog();
    });
  }

  editTagValue(tagValue: TagValueDto) {
    this.tagValueField = tagValue.value;
    this.tagDropdownSelect = this.tags.find(tag => tag.id === tagValue.tagId);
    this.toggleFormDialog();
  }

  deleteTagValue(tagValue: TagValueDto) {
    if (!tagValue.id) return;

    this.loading = true;
    this.tagValueService.delete(tagValue.id).subscribe({
      next: () => {
        this.getTagValues();
      },
      error: (error) => {
        console.error('Error deleting tag value', error);
        this.loading = false;
      }
    });
  }

  toggleFormDialog() {
    this.tagValueFormVisible = !this.tagValueFormVisible;
  }
}