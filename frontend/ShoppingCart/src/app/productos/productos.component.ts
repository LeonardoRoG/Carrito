import { Component, inject } from '@angular/core';
import { Producto } from './interface/productos.interface';
import { ProductosService } from '../productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css',
})
export class ProductosComponent {

  title: string = 'Productos'

  productosList: Producto[] = [];
  productosService: ProductosService = inject(ProductosService);

  constructor(){
    this.productosList = this.productosService.obtenerProductos();
  }

}
