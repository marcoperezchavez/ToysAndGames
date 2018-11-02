import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductsGNL } from "./ProductsGNL";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private productsGNL: ProductsGNL;
  productosList: any;

  private productURL: string = 'https://localhost:44343/api/Products';

  constructor(private httpClient: HttpClient) { }

  public async getAll(): Promise<any> {
    let response = await this.httpClient.get(this.productURL).toPromise();
    return response;

  }

  public async deleteProduct(id: number) {
    let response = this.httpClient.delete(this.productURL + '/' + id).toPromise();
    console.log(response);
    return response;
  }

  public async postProduct(product: ProductsGNL): Promise<ProductsGNL> {
    console.log("Dentro service POST");
    console.log(product);
    let response = await this.httpClient.post<ProductsGNL>(this.productURL, product).toPromise();
    return response;
  }

  public async PutProduct(product: ProductsGNL): Promise<ProductsGNL> {
    console.log("Dentro service Put");
    console.log(product);
    let response = await this.httpClient.put<ProductsGNL>(this.productURL +"/"+ product.id, product).toPromise();
    return response;
  }
}

