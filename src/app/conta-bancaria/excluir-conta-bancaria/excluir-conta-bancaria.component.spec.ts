import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirContaBancariaComponent } from './excluir-conta-bancaria.component';

describe('ExcluirContaBancariaComponent', () => {
  let component: ExcluirContaBancariaComponent;
  let fixture: ComponentFixture<ExcluirContaBancariaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExcluirContaBancariaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExcluirContaBancariaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
