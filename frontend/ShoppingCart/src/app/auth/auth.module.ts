import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthRoutingRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { MaterialModule } from '../shared/material/material.module';
import { MatTabsModule } from '@angular/material/tabs';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AuthComponent
  ],
  imports: [
    MaterialModule,
    CommonModule,
    AuthRoutingRoutingModule,
    ReactiveFormsModule
  ]
})
export class AuthModule { }
