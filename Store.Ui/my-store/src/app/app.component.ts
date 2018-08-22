import { Component } from '@angular/core';
import { ProductDto, ProductServiceProxy } from '../shared/service-proxies/service-proxies';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  products: ProductDto[];
  /**
   *
   */
  constructor(private productServiceProxy: ProductServiceProxy) {
    this.productServiceProxy.getActive(50, 0).subscribe(data => {
      this.products = data;
    });
  }
}
