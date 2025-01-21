import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TagValuesComponent } from './tag-values.component';

describe('TagValuesComponent', () => {
  let component: TagValuesComponent;
  let fixture: ComponentFixture<TagValuesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TagValuesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TagValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
