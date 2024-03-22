import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productos-detalles',
  templateUrl: './productos-detalles.component.html',
  styleUrl: './productos-detalles.component.css'
})
export class ProductosDetallesComponent implements OnInit {
  
  private activatedRoute = inject(ActivatedRoute);
  
  productoId = 0;
  title = 'Detalles'
  
  
  ngOnInit(): void {
    this.activatedRoute.paramMap
      .subscribe(params => {
        this.productoId = parseInt(params.get('id')!)
        console.log('Id de ruta: ', this.productoId)
      })
  }

}
