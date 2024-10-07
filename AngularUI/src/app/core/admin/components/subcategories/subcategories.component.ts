import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { SubcategoryService } from '../../services/subcategory.service';
import { Router } from '@angular/router';
import { TableFilterService } from '../../services/table-filter.service';
import { SubcategoryDto } from '../../interfaces/subcategory-dto';
import { ToolbarModule } from 'primeng/toolbar';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';
import { CategoryService } from '../../services/category.service';
import { CategoryDto } from '../../interfaces/category-dto';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectChangeEvent, MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-subcategories',
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
  templateUrl: './subcategories.component.html',
  styleUrl: './subcategories.component.scss'
})
export class SubcategoriesComponent {
  subcategoryService: SubcategoryService;
  categoryService: CategoryService;
  router: Router;
  tableFilter: TableFilterService;
  loading: boolean = true;

  subcategories: SubcategoryDto[] = [];
  categories: CategoryDto[] = [];
  categoryNames: string[] = [];
  totalRecords: number = 100;

  subcategoryNameField: string = '';
  categoryDropdownSelect: CategoryDto | undefined;

  subcategoryFormVisible: boolean = false;

  lastEvent: TableLazyLoadEvent = {};
  categoryNamesToFilter: string[] = [];

  constructor(subcategoryService: SubcategoryService, categoryService: CategoryService, router: Router, tableFilter: TableFilterService) {
    this.subcategoryService = subcategoryService;
    this.categoryService = categoryService;
    this.router = router;
    this.tableFilter = tableFilter;
  }

  ngOnInit() {
    this.getCategories();
  }

  loadData(event: TableLazyLoadEvent) {
    if (event.filters) {
      this.tableFilter.applyFilters(event);
    }

    this.tableFilter.applyPaginationAndSorting(event);

    this.getSubcategories();

    this.loading = false;
    this.lastEvent = event;
  }

  getSubcategories() {
    this.loading = true;
    this.subcategoryService.getFiltered(
      this.tableFilter.filtersString,
      this.tableFilter.page,
      this.tableFilter.pageSize,
      this.tableFilter.sortField,
      this.tableFilter.sortOrder)
      .subscribe((response: { totalCount: number, data: SubcategoryDto[] }) => {
        this.subcategories = response.data;
        this.totalRecords = response.totalCount;
        this.loading = false;
      });
  }

  getCategories() {
    this.categoryService.getAll().subscribe((categories: CategoryDto[]) => {
      this.categories = categories;
      this.categoryNames = categories.map(category => category.name);
    });
  }

  addSubcategory() {
    const subcategory: SubcategoryDto = {
      name: this.subcategoryNameField,
      categoryId: this.categoryDropdownSelect?.id,
    };

    return this.subcategoryService.create(subcategory).subscribe(() => {
      this.getSubcategories();
      this.toggleFormDialog();
    });
  }

  editSubcategory(subcategory: SubcategoryDto) {
    this.subcategoryNameField = subcategory.name;
    this.categoryDropdownSelect = this.categories.find(category => category.id === subcategory.categoryId);
    this.toggleFormDialog();
  }

  deleteSubcategory(subcategory: SubcategoryDto) {
    // Implement delete logic here
  }

  toggleFormDialog() {
    this.subcategoryFormVisible = !this.subcategoryFormVisible;
  }
}