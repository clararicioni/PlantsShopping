import { Component, OnInit } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule } from '@angular/forms';

import localePt from '@angular/common/locales/pt';

import { PlantService, Plant } from '../../services/plant.service';

registerLocaleData(localePt, 'pt-BR');

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './home.html',
  styleUrls: ['./home.css'],
})
export class Home implements OnInit {

  plants: Plant[] = [];
  plantasFiltradas: Plant[] = [];

  filtroPreco = 'todos';
  ordemNome = 'az';

  constructor(private plantService: PlantService) { }

  ngOnInit(): void {
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
}
