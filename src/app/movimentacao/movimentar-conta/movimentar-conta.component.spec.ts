import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimentarContaComponent } from './movimentar-conta.component';

describe('MovimentarContaComponent', () => {
  let component: MovimentarContaComponent;
  let fixture: ComponentFixture<MovimentarContaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MovimentarContaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MovimentarContaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
