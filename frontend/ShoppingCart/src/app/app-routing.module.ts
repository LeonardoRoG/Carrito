import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';
import { HomePageComponent } from './productos/home-page/home-page.component';
import { authGuard } from './auth/guard/auth.guard';
import { isNotAuthenticatedGuard } from './auth/guard/is-not-authenticated.guard';
import { redireccionGuard } from './auth/guard/redireccion.guard';

const routes: Routes = [
  {
    path: 'productos',
    canActivate: [authGuard],
    data: { roles: ['administrador','vendedor']},
    loadChildren: () => import('./productos/productos.module')
    .then(m => m.ProductosModule) //Carga diferida (lazy loading)
  },
  {
    path: 'cliente',
    canActivate: [authGuard],
    data: { roles: ['administrador','vendedor']},
    component: ClienteComponent
  },
  {
    path: 'auth',
    canActivate: [isNotAuthenticatedGuard],
    loadChildren: () => import('./auth/auth.module')
    .then(m => m.AuthModule)
  },
  {
    path: '',
    canActivate: [redireccionGuard],
    component: HomePageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
