import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContasClientesComponent } from './contas-clientes.component';

describe('ContasClientesComponent', () => {
  let component: ContasClientesComponent;
  let fixture: ComponentFixture<ContasClientesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContasClientesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContasClientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
