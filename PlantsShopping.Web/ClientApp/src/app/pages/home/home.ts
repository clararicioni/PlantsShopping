import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { PlantService, Plant } from '../../services/plant.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrls: ['./home.css'],
})
export class Home {
  plants$: Observable<Plant[]>;

  constructor(private plantService: PlantService) {
    this.plants$ = this.plantService.getPlants();
  }

}
