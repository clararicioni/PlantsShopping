import { Component, OnInit } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule } from '@angular/forms';
import localePt from '@angular/common/locales/pt';
import Swal from 'sweetalert2';
import { ToastrService } from 'ngx-toastr';

import {
  PlantService,
  Plant,
  CreatePlant
} from '../../services/plant.service';

import { ModalGerenciarPlanta } from '../../shared/modal-gerenciar-planta/modal-gerenciar-planta';

registerLocaleData(localePt, 'pt-BR');

@Component({
  selector: 'app-plantas',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ModalGerenciarPlanta
  ],
  templateUrl: './plantas.html',
  styleUrl: './plantas.css',
})
export class Plantas implements OnInit {

  plants: Plant[] = [];
  plantasFiltradas: Plant[] = [];
  plantaEmEdicao: Plant | null = null;

  filtroPreco = 'todos';
  ordemNome = 'az';

  mostrarModal = false;
  salvandoPlanta = false;

  constructor(
    private plantService: PlantService,
    private toastr: ToastrService
  ) { }

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
    this.plantaEmEdicao = null;
    this.mostrarModal = true;
  }

  fecharModalInserir(): void {
    this.mostrarModal = false;
    this.plantaEmEdicao = null;
  }

  salvarPlanta(planta: CreatePlant | Plant): void {
    if (this.salvandoPlanta) {
      return;
    }

    this.salvandoPlanta = true;

    const editando = 'id' in planta;

    const requisicao = editando
      ? this.plantService.atualizarPlanta(planta)
      : this.plantService.criarPlanta(planta);

    requisicao.subscribe({
      next: () => {
        this.salvandoPlanta = false;
        this.fecharModalInserir();
        this.carregarPlantas();

        if (editando) {
          this.toastr.success(
            'A planta foi atualizada com sucesso.',
            'Planta atualizada'
          );
        } else {
          this.toastr.success(
            'A planta foi cadastrada com sucesso.',
            'Planta cadastrada'
          );
        }
      },
      error: (error) => {
        this.salvandoPlanta = false;

        console.log('Status:', error.status);
        console.log('Erro da API:', error.error);
        console.log('Erros de validação:', error.error?.errors);

        this.toastr.error(
          'Não foi possível salvar a planta.',
          'Erro'
        );
      }
    });
  }

  editarPlanta(planta: Plant): void {
    this.plantaEmEdicao = planta;
    this.mostrarModal = true;
  }

  excluirPlanta(planta: Plant): void {
    Swal.fire({
      title: 'Excluir planta?',
      text: `A planta "${planta.name}" será excluída.`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir',
      cancelButtonText: 'Cancelar',
      reverseButtons: true
    }).then((resultado) => {

      if (!resultado.isConfirmed) {
        return;
      }

      this.plantService.excluirPlanta(planta.id).subscribe({
        next: () => {
          this.toastr.success(
            'A planta foi excluída com sucesso.',
            'Planta excluída'
          );

          this.carregarPlantas();
        },
        error: (error) => {
          console.log('Status:', error.status);
          console.log('Erro da API:', error.error);

          this.toastr.error(
            'Não foi possível excluir a planta.',
            'Erro'
          );
        }
      });
    });
  }
}
