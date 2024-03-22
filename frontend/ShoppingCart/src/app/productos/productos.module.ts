import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductosComponent } from './productos.component';
import { ProductosDetallesComponent } from './productos-detalles/productos-detalles.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RouterModule } from '@angular/router';
import { routes } from './productos-routing';
import { MatButton } from '@angular/material/button';
import { AgregarProductoComponent } from './agregar-producto/agregar-producto.component';



@NgModule({
  declarations: [
    ProductosComponent,
    ProductosDetallesComponent,
    HomePageComponent,
    AgregarProductoComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatButton
  ],
  exports: [
    ProductosComponent,
    ProductosDetallesComponent
  ]
})
export class ProductosModule { }
