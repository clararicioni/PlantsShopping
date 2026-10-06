import { Component, EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreatePlant, Plant } from '../../services/plant.service';

@Component({
  selector: 'app-modal-gerenciar-planta',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './modal-gerenciar-planta.html',
  styleUrl: './modal-gerenciar-planta.css'
})
export class ModalGerenciarPlanta implements OnChanges {

  @Input() planta: Plant | null = null;

  @Output() fechar = new EventEmitter<void>();
  @Output() salvar = new EventEmitter<CreatePlant | Plant>();

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

  get modoEdicao(): boolean {
    return this.planta !== null;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['planta']) {
      this.preencherFormulario();
    }
  }

  preencherFormulario(): void {
    if (!this.planta) {
      this.limparFormulario();
      return;
    }

    this.nome = this.planta.name;
    this.descricao = this.planta.description ?? '';
    this.categoria = this.planta.categoryName ?? '';
    this.imagemUrl = this.planta.imageUrl ?? '';
    this.preco = this.planta.price;

    this.tipo = this.planta.price === 0
      ? 'doacao'
      : 'venda';

    this.imagemValida = true;
  }

  limparFormulario(): void {
    this.nome = '';
    this.descricao = '';
    this.categoria = '';
    this.imagemUrl = '';
    this.imagemValida = true;
    this.tipo = 'venda';
    this.preco = null;
  }

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

    const dados = {
      name: this.nome.trim(),
      description: this.descricao.trim(),
      categoryName: this.categoria,
      imageUrl: this.imagemUrl.trim(),
      price: this.tipo === 'doacao' ? 0 : Number(this.preco)
    };

    if (this.planta) {
      this.salvar.emit({
        ...dados,
        id: this.planta.id
      });

      return;
    }

    this.salvar.emit(dados);
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
