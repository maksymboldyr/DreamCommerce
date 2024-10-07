import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { CategoryService } from '../../services/category.service';
import { Router } from '@angular/router';
import { TableFilterService } from '../../services/table-filter.service';
import { CategoryDto } from '../../interfaces/category-dto';
import { ToolbarModule } from 'primeng/toolbar';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';

@Component({
  selector: 'app-categories',
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
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss'
})
export class CategoriesComponent {
  categoryService: CategoryService;
  router: Router;
  tableFilter: TableFilterService;
  loading: boolean = true;

  categories: CategoryDto[] = [];
  totalRecords: number = 100;

  categoryFormVisible: boolean = false;

  addCategoryForm: FormGroup = new FormGroup({
    name: new FormControl(''),
  });

  constructor(categoryService: CategoryService, router: Router, tableFilter: TableFilterService) {
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

    this.getCategories();
  }

  getCategories() {
    this.loading = true;
    this.categoryService.getFiltered(
      this.tableFilter.filtersString,
      this.tableFilter.page,
      this.tableFilter.pageSize,
      this.tableFilter.sortField,
      this.tableFilter.sortOrder)
      .subscribe((response: { totalCount: number, data: CategoryDto[] }) => {
        this.categories = response.data;
        this.totalRecords = response.totalCount;
        this.loading = false;
      });
  }

  addCategory() {
    const category: CategoryDto = {
      name: this.name?.value,
    };

    return this.categoryService.create(category).subscribe(() => {
      this.getCategories();
      this.toggleAddDialog();
    });
  }

  editCategory(category: CategoryDto) {
    // Implement edit logic here
  }

  deleteCategory(category: CategoryDto) {
    if (category.id) {
      this.categoryService.delete(category.id).subscribe((res) => {
        this.getCategories();
      });
    }
  }

  toggleAddDialog() {
    this.categoryFormVisible = !this.categoryFormVisible;
  }

  get name() {
    return this.addCategoryForm.get('name');
  }
}