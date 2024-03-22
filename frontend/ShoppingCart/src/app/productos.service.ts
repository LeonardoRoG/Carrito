import { Injectable, inject } from '@angular/core';
import { Producto } from './productos/interface/productos.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth/auth.service';
import { enviroment } from './enviroments/enviroment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly url = enviroment.apiUrl;

  constructor(){}

  getProductos(): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });

    return this.http.get<any>(`${this.url}/producto`, {headers});
  }

  title: string = 'Sección productos'

  protected productos: Producto[] = [
    {
      id: 1,
      nombre: 'Oreos',
      precio: 1200,
      categoria: 'Galletitas',
      stock: 45
    },
    {
      id: 2,
      nombre: 'Spaghetti',
      precio: 900,
      categoria: 'Fideos',
      stock: 70
    },
    {
      id: 3,
      nombre: 'Pan común',
      precio: 1800,
      categoria: 'Panificados',
      stock: 120
    },
    {
      id: 4,
      nombre: 'Arroz Don Mario',
      precio: 1200,
      categoria: 'Arroz',
      stock: 200
    },
  ];

  obtenerProductos(): Producto[]{
    return this.productos;
  }

  obtenerProductoPorId(id: number): Producto | undefined{
    return this.productos.find((producto) => producto.id === id);
  } 

}
