import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './sharedcomponents/paging-header/paging-header.component';
import { PagerComponent } from './sharedcomponents/pager/pager.component';


@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  exports: [PaginationModule,PagingHeaderComponent, PagerComponent]
})
export class SharedModule { }
