import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/modals/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;
  data : any;
  constructor() { }

  ngOnInit(): void {

  this.data = JSON.stringify(this.product.atttributes[0]);
  console.log(this.data);
  }
}
