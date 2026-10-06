import { Component, OnInit } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule } from '@angular/forms';
import localePt from '@angular/common/locales/pt';

import {
  PlantService,
  Plant,
  CreatePlant
} from '../../services/plant.service';

import { ModalInserirPlanta } from '../../shared/modal-inserir-planta/modal-inserir-planta';

registerLocaleData(localePt, 'pt-BR');

@Component({
  selector: 'app-plantas',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ModalInserirPlanta
  ],
  templateUrl: './plantas.html',
  styleUrl: './plantas.css',
})
export class Plantas implements OnInit {

  plants: Plant[] = [];
  plantasFiltradas: Plant[] = [];

  filtroPreco = 'todos';
  ordemNome = 'az';

  mostrarModal = false;
  salvandoPlanta = false;

  constructor(private plantService: PlantService) { }

  ngOnInit(): void {
    this.carregarPlantas();
  }

  carregarPlantas(): void {
    this.plantService.getPlants().subscribe({
      next: (plants) => {
        this.plants = plants;
        this.filtrarPlantas();
      },
      error: (error) => {
        console.error('Erro ao carregar plantas:', error);
      }
    });
  }

  filtrarPlantas(): void {
    const resultado = [...this.plants];

    resultado.sort((a, b) => {

      if (this.filtroPreco === 'menor') {
        const diferencaPreco = a.price - b.price;

        if (diferencaPreco !== 0) {
          return diferencaPreco;
        }
      }

      if (this.filtroPreco === 'maior') {
        const diferencaPreco = b.price - a.price;

        if (diferencaPreco !== 0) {
          return diferencaPreco;
        }
      }

      const diferencaNome = a.name.localeCompare(
        b.name,
        'pt-BR',
        {
          sensitivity: 'base'
        }
      );

      if (this.ordemNome === 'za') {
        return -diferencaNome;
      }

      return diferencaNome;
    });

    this.plantasFiltradas = resultado;
  }

  abrirModalInserir(): void {
    this.mostrarModal = true;
  }

  fecharModalInserir(): void {
    this.mostrarModal = false;
  }

  criarPlanta(planta: CreatePlant): void {
    if (this.salvandoPlanta) {
      return;
    }

    this.salvandoPlanta = true;

    console.log('Objeto enviado:', planta);

    this.plantService.criarPlanta(planta).subscribe({
      next: () => {
        this.salvandoPlanta = false;
        this.mostrarModal = false;
        this.carregarPlantas();
      },
      error: (error) => {
        this.salvandoPlanta = false;

        console.log('Status:', error.status);
        console.log('Erro da API:', error.error);
        console.log('Erros de validação:', error.error?.errors);
      }
    });
  }

  editarPlanta(planta: Plant): void {
    console.log('Editar planta:', planta);
  }

  excluirPlanta(planta: Plant): void {
    console.log('Excluir planta:', planta);
  }
}
