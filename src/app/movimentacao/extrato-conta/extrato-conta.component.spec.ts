import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtratoContaComponent } from './extrato-conta.component';

describe('ExtratoContaComponent', () => {
  let component: ExtratoContaComponent;
  let fixture: ComponentFixture<ExtratoContaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExtratoContaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExtratoContaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
