import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { TagService } from '../../services/tag.service';
import { Router } from '@angular/router';
import { TableFilterService } from '../../services/table-filter.service';
import { TagDto } from '../../interfaces/tag-dto';
import { ToolbarModule } from 'primeng/toolbar';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';
import { SubcategoryService } from '../../services/subcategory.service';
import { SubcategoryDto } from '../../interfaces/subcategory-dto';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectChangeEvent, MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-tags',
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
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss']
})
export class TagsComponent {
  tagService: TagService;
  subcategoryService: SubcategoryService;
  router: Router;
  tableFilter: TableFilterService;
  loading: boolean = true;

  tags: TagDto[] = [];
  subcategories: SubcategoryDto[] = [];
  subcategoryNames: string[] = [];
  totalRecords: number = 100;

  tagNameField: string = '';
  subcategoryDropdownSelect: SubcategoryDto | undefined;

  tagFormVisible: boolean = false;

  lastEvent: TableLazyLoadEvent = {};
  subcategoryNamesToFilter: string[] = [];

  constructor(tagService: TagService, subcategoryService: SubcategoryService, router: Router, tableFilter: TableFilterService) {
    this.tagService = tagService;
    this.subcategoryService = subcategoryService;
    this.router = router;
    this.tableFilter = tableFilter;
  }

  ngOnInit() {
    this.getSubcategories();
  }

  loadData(event: TableLazyLoadEvent) {
    if (event.filters) {
      this.tableFilter.applyFilters(event);
    }

    this.tableFilter.applyPaginationAndSorting(event);

    this.getTags();

    this.loading = false;
    this.lastEvent = event;
  }

  getTags() {
    this.loading = true;
    this.tagService.getFiltered(
      this.tableFilter.filtersString,
      this.tableFilter.page,
      this.tableFilter.pageSize,
      this.tableFilter.sortField,
      this.tableFilter.sortOrder)
      .subscribe((response: { totalCount: number, data: TagDto[] }) => {
        this.tags = response.data;
        this.totalRecords = response.totalCount;
        this.loading = false;
      });
  }

  // TODO filter subcategories by category
  getSubcategories() {
    this.subcategoryService.getAll().subscribe((subcategories: SubcategoryDto[]) => {
      this.subcategories = subcategories;
      this.subcategoryNames = subcategories.map(subcategory => subcategory.name);
    });
  }

  addTag() {
    const tag: TagDto = {
      name: this.tagNameField,
      subcategoryId: this.subcategoryDropdownSelect?.id || '',
    };

    return this.tagService.create(tag).subscribe(() => {
      this.getTags();
      this.toggleFormDialog();
    });
  }

  editTag(tag: TagDto) {
    this.tagNameField = tag.name;
    this.subcategoryDropdownSelect = this.subcategories.find(subcategory => subcategory.id === tag.subcategoryId);
    this.toggleFormDialog();
  }

  deleteTag(tag: TagDto) {
    if (!tag.id) return;

    this.loading = true;
    this.tagService.delete(tag.id).subscribe({
      next: () => {
        this.getTags();
      },
      error: (error) => {
        console.error('Error deleting tag', error);
        this.loading = false;
      }
    });
  }

  toggleFormDialog() {
    this.tagFormVisible = !this.tagFormVisible;
  }
}