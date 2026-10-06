import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreatePlant } from '../../services/plant.service';

@Component({
  selector: 'app-modal-inserir-planta',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './modal-inserir-planta.html',
  styleUrl: './modal-inserir-planta.css'
})
export class ModalInserirPlanta {

  @Output() fechar = new EventEmitter<void>();
  @Output() salvar = new EventEmitter<CreatePlant>();

  nome = '';
  descricao = '';
  categoria = '';
  imagemUrl = '';
  imagemValida = true;
  tipo = 'venda';
  preco: number | null = null;

  categorias = [
    'CACTOS/SUCULENTAS',
    'FLORES/ORNAMENTAIS',
    'FOLHAGENS',
    'ARVORES/ARBUSTOS',
    'FRUTIFERAS',
    'HORTAS/ERVAS',
    'OUTRAS'
  ];

  salvarPlanta(): void {
    if (
      !this.nome.trim() ||
      !this.descricao.trim() ||
      !this.categoria ||
      !this.imagemUrl.trim() ||
      !this.imagemValida
    ) {
      return;
    }

    if (this.tipo === 'venda' && (!this.preco || this.preco <= 0)) {
      return;
    }

    const planta: CreatePlant = {
      name: this.nome.trim(),
      description: this.descricao.trim(),
      categoryName: this.categoria,
      imageUrl: this.imagemUrl.trim(),
      price: this.tipo === 'doacao' ? 0 : Number(this.preco)
    };

    this.salvar.emit(planta);
  }

  fecharModal(): void {
    this.fechar.emit();
  }

  alterarTipo(): void {
    if (this.tipo === 'doacao') {
      this.preco = 0;
    } else {
      this.preco = null;
    }
  }
}
