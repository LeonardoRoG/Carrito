import { Component, inject } from '@angular/core';
import { Producto } from '../interface/productos.interface';
import { ProductosComponent } from '../productos.component';
import { CommonModule } from '@angular/common';
import { ProductosService } from '../../productos.service';

@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrl: './agregar-producto.component.css',
})
export class AgregarProductoComponent {

/*   productosList: Producto[] = [];
  productosService: ProductosService = inject(ProductosService);

  constructor(){
    this.productosList = this.productosService.obtenerProductos();
  } */


}
