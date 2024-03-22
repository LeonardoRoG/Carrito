import { Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { ProductosComponent } from './productos.component';
import { ProductosDetallesComponent } from './productos-detalles/productos-detalles.component';
import { AgregarProductoComponent } from './agregar-producto/agregar-producto.component';

export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
    children: [
      {
        path: 'index',
        component: ProductosComponent
      },
      {
        path: 'detalle/:id',
        component: ProductosDetallesComponent
      },
      {
        path: 'agregar',
        component: AgregarProductoComponent
      }
    ]
  }
];
