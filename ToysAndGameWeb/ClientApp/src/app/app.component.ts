
import { Component, OnInit } from '@angular/core';
import { ProductsGNL } from "./ProductsGNL";
import { ProductsService} from "./products.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Toys And Games';
  public productGNL: ProductsGNL;
  public listProductGNL: ProductsGNL[];
  public addValue: boolean = false;
  public updateValue: boolean = false;
  public rValidation: boolean = false;
  public vName: boolean = false;
  public vPrice: boolean = false;
  public vCompany: boolean = false;

  constructor(private productServices: ProductsService) {

  }


  public async ngOnInit() {
    this.productGNL = new ProductsGNL();
    let r = await this.productServices.getAll();
    this.listProductGNL = r;
    console.log(this.listProductGNL);
  }

  public async DeleteProduct(id: number) {
    console.log("Ingresando delete");
    let Result = await this.productServices.deleteProduct(id);
    console.log("result:");
    console.log(Result);
    return Result;

  }

  AddNew() {
    this.addValue = true;
    this.updateValue = false;
  }

  public async AddProduct() {
    console.log(this.productGNL);
    this.validations();
    if (this.rValidation)
      return "";
    let Result = await this.productServices.postProduct(this.productGNL);
    console.log("result:");
    console.log(Result);
    return Result;
  }
  validations() {
    this.rValidation = false;
    this.vName = false;
    this.vPrice = false;
    this.vCompany = false;
    if (this.productGNL.name == "" || this.productGNL.name == null) {
      this.vName = true;
      this.rValidation = true;
    }
      if (this.productGNL.descriptionToy == "" || this.productGNL.descriptionToy == null) {
      this.productGNL.descriptionToy = " ";
    }
    if (this.productGNL.ageRestriction == 0 || this.productGNL.ageRestriction == null ) {
      this.productGNL.ageRestriction = 1;
    }
    if (this.productGNL.price <1 || this.productGNL.ageRestriction == null || this.productGNL.ageRestriction >1000) {
      this.vPrice = true;
      this.rValidation = true;
    }
    if (this.productGNL.company == 0 || this.productGNL.company == null) {
      this.vCompany = true;
      this.rValidation = true;
    }
  }

  UpdateProduct(product: ProductsGNL) {
    console.log("Ingresando a put");
    console.log(product);
    this.productGNL = product;
    this.updateValue = true;
    this.addValue = false;

  }
 public async UpdateProductSend() {
    console.log("Enviar al servicio PUT");
    console.log(this.productGNL);
    let Result = await this.productServices.PutProduct(this.productGNL);
    console.log("result:");
    console.log(Result);
    return Result;

  }


}
