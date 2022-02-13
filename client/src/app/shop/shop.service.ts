import { ShopParams } from './../shared/models/shopParams';
import { IType } from './../shared/models/product-type';
import { IBrand } from './../shared/models/brand';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:7117/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    if(shopParams.brandId !== 0){
      params.append('brandId', shopParams.brandId.toString());
    }
    if(shopParams.typeId !== 0) {
      params.append('typeId', shopParams.typeId.toString());
    }
    if(shopParams.search) {
      params.append('search', shopParams.search);
    }
    params.append('sort', shopParams.sort);
    params.append('pageIndex', shopParams.pageNumber.toString());
    params.append('pageSize', shopParams.pageSize.toString());
    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params}).pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'types');
  }

}

