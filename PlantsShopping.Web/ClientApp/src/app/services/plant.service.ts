import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Plant {
  id: number;
  name: string;
  description?: string;
  imageUrl?: string;
  price: number;
}

export interface CreatePlant {
  name: string;
  description: string;
  categoryName: string;
  imageUrl: string;
  price: number;
}

@Injectable({
  providedIn: 'root'
})
export class PlantService {
  private apiUrl = '/api/v1/Plant';

  constructor(private http: HttpClient) { }

  getPlants(): Observable<Plant[]> {
    return this.http.get<Plant[]>(this.apiUrl);
  }

  criarPlanta(planta: CreatePlant): Observable<Plant> {
    return this.http.post<Plant>(this.apiUrl, planta);
  }
}
