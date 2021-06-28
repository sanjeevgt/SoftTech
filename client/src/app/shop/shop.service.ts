import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, delay } from 'rxjs/operators';
import { IPagination } from '../modals/pagination';
import { IProduct } from '../modals/product';
import { IPType } from '../modals/productType';
import { ShopParams } from '../modals/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/'
  constructor(private http : HttpClient) { }
  shopParams: ShopParams
  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.catId !== 0) {
      params = params.append('catId', shopParams.catId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getCategories() {
    return this.http.get<IPType[]>(this.baseUrl + 'products/ProductCat');
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }
}
