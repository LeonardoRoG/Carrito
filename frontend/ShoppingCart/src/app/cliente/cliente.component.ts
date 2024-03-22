import { Component } from '@angular/core';
import { Cliente } from './interface/cliente.interface';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.css'
})
export class ClienteComponent {
  clientes: Cliente[] = [
    {
      nombre: 'Juan',
      apellido: 'Sosa',
      id: 1,
      nivel: 8
    },
    {
      nombre: 'Sofia',
      apellido: 'Anriquez',
      id: 2,
      nivel: 6
    }
  ];

  
}
