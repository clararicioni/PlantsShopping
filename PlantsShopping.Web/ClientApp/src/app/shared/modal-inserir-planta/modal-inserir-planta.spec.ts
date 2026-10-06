import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalInserirPlanta } from './modal-inserir-planta';

describe('ModalInserirPlanta', () => {
  let component: ModalInserirPlanta;
  let fixture: ComponentFixture<ModalInserirPlanta>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalInserirPlanta]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalInserirPlanta);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
