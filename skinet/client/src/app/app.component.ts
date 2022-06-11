import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Skinet';
  products!: any[];
  

  constructor(private http: HttpClient) {}
  

  ngOnInit(): void {
    this.http.get('https://localhost:7023/api/products').subscribe({
      next: (response: any) => {
       this.products = response.data;
      },
      error: (err) => {
        console.log(err);
      }
    }); 

    
  }
  
}
