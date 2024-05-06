import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarContaBancariaComponent } from './criar-conta-bancaria.component';

describe('CriarContaBancariaComponent', () => {
  let component: CriarContaBancariaComponent;
  let fixture: ComponentFixture<CriarContaBancariaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CriarContaBancariaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CriarContaBancariaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
