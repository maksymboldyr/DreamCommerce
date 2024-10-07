import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogueProductComponent } from './catalogue-product.component';

describe('CatalogueProductComponent', () => {
  let component: CatalogueProductComponent;
  let fixture: ComponentFixture<CatalogueProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CatalogueProductComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatalogueProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
