import { Component, OnInit } from '@angular/core';
import { IBrand } from '../models/brand';
import { IProduct } from '../models/product';
import { IType } from '../models/type';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  products!: IProduct[];
  brands!: IBrand[];
  types!: IType[];
  brandIdSelected = 0;
  typeIdSelected = 0;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe({
      next: (response => {
         this.products = response.data
      }),
      error: (err) => {
        console.log(err);
      }
    })
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: (response => {
         this.brands = [{id: 0, name: 'All'}, ...response];
      }),
      error: (err) => {
        console.log(err);
      }
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: (response => {
         this.types = [{id: 0, name: 'All'}, ...response];
      }),
      error: (err) => {
        console.log(err);
      }
    })
  }

  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

}
