import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { TableFilterService } from '../../services/table-filter.service';
import { ProductDto } from '../../interfaces/product-dto';
import { ToolbarModule } from 'primeng/toolbar';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';
import { CategoryService } from '../../services/category.service';
import { CategoryDto } from '../../interfaces/category-dto';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectChangeEvent, MultiSelectModule } from 'primeng/multiselect';
import { SubcategoryDto } from '../../interfaces/subcategory-dto';
import { SubcategoryService } from '../../services/subcategory.service';
import { environment } from '../../../../../environments/environment.development';
import { FileUploadEvent, FileUploadHandlerEvent, FileUploadModule } from 'primeng/fileupload';
import { ProductImageUploadDto } from '../../interfaces/product-image-upload-dto';

@Component({
  selector: 'app-products',
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
    FileUploadModule,
  ],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  productService: ProductService;
  categoryService: CategoryService;
  subcategoryService: SubcategoryService;
  router: Router;
  tableFilter: TableFilterService;
  loading: boolean = true;
  apiUrl: string = environment.apiUrl;
  

  products: ProductDto[] = [];
  categories: CategoryDto[] = [];
  categoryNames: string[] = [];
  subcategories: SubcategoryDto[] = [];
  filteredSubcategories: SubcategoryDto[] = [];

  totalRecords: number = 100;

  productNameField: string = '';
  productDescriptionField: string = '';
  productPriceField: number = 0;
  productStockField: number = 0;
  productDiscountField: number = 0;
  productImageUrlField: string = '';
  categoryDropdownSelect: CategoryDto | undefined;
  subcategoryDropdownSelect: SubcategoryDto | undefined;

  productFormVisible: boolean = false;
  isFormEditing: boolean = false;

  lastEvent: TableLazyLoadEvent = {};
  categoryNamesToFilter: string[] = [];

  imageUploadVisible: boolean = false;
  imageProduct: ProductDto | undefined;

  constructor(productService: ProductService, categoryService: CategoryService, subcategoryService: SubcategoryService, router: Router, tableFilter: TableFilterService) {
    this.productService = productService;
    this.categoryService = categoryService;
    this.subcategoryService = subcategoryService;
    this.router = router;
    this.tableFilter = tableFilter;
  }

  ngOnInit() {
    this.getCategories();
    this.getSubcategories();
  }

  loadData(event: TableLazyLoadEvent) {
    if (event.filters) {
      this.tableFilter.applyFilters(event);
    }

    this.tableFilter.applyPaginationAndSorting(event);

    this.getProducts();

    this.loading = false;
    this.lastEvent = event;
  }

  getProducts() {
    this.loading = true;
    this.productService.getFiltered(
      this.tableFilter.filtersString,
      this.tableFilter.page,
      this.tableFilter.pageSize,
      this.tableFilter.sortField,
      this.tableFilter.sortOrder)
      .subscribe((response: { totalCount: number, data: ProductDto[] }) => {
        this.products = response.data;
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

  getSubcategories() {
    this.subcategoryService.getAll().subscribe((subcategories: SubcategoryDto[]) => {
      this.subcategories = subcategories;
    });
  }

  addProduct() {
    if (!this.categoryDropdownSelect?.id) {
      return;
    }

    if (!this.subcategoryDropdownSelect?.id) {
      return;
    }

    const product: ProductDto = {
      name: this.productNameField,
      description: this.productDescriptionField,
      price: this.productPriceField,
      stock: this.productStockField,
      discount: this.productDiscountField,
      imageUrl: this.productImageUrlField,
      categoryId: this.categoryDropdownSelect?.id,
      subcategoryId: this.subcategoryDropdownSelect?.id,
    };

    return this.productService.create(product).subscribe(() => {
      this.getProducts();
      this.toggleFormDialog();
    });
  }

  editProduct(product: ProductDto) {
    this.productNameField = product.name;
    this.productDescriptionField = product.description;
    this.productPriceField = product.price;
    this.productStockField = product.stock;
    this.productDiscountField = product.discount;
    this.productImageUrlField = product.imageUrl || '';
    this.categoryDropdownSelect = this.categories.find(category => category.id === product.categoryId);
    this.subcategoryDropdownSelect = this.subcategories.find(subcategory => subcategory.id === product.subcategoryId);
    this.isFormEditing = true;
    this.toggleFormDialog();
  }

  updateSubcategoryDropdown(event: MultiSelectChangeEvent) {  
    this.filteredSubcategories = this.subcategories.filter(subcategory => subcategory.categoryId === this.categoryDropdownSelect?.id);   
  }

  deleteProduct(product: ProductDto) {
    if (!product.id) {
      return;
    }
    this.productService.delete(product.id).subscribe(() => {
      this.getProducts();
    });
  }

  toggleFormDialog() {
    this.productFormVisible = !this.productFormVisible;
    if (this.isFormEditing) {
      this.isFormEditing = false;
    }
  }

  getImage(product: ProductDto) {
    return 'https://localhost:2048/' + product.imageUrl;
  }

  uploadImage(product: ProductDto) {
    this.imageProduct = product;
    this.toggleImageUploadDialog();
  }

  onUpload($event: FileUploadHandlerEvent) {
    const file = $event.files[0];

    if (!file || !this.imageProduct?.id) {
      return;
    }
    const imageUploadDto : ProductImageUploadDto = {
      productId: this.imageProduct.id,
      image: file,
    };

    

    this.productService.uploadImage(imageUploadDto).subscribe((imageUrl: string) => {
      this.toggleImageUploadDialog();
    });

  }

  toggleImageUploadDialog() {
    this.imageUploadVisible = !this.imageUploadVisible;
  }
}