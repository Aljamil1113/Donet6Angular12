import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'SkiNet';
  products!: IProduct[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:7023/api/products?pageSize=50').subscribe({
      next: (response: any) => {
        this.products = response.data;
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
} 