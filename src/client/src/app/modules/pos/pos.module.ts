import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PosRoutingModule } from './pos-routing.module';
import { BaseComponent } from './base/base.component';
import { MaterialModule } from 'src/app/core/material/material.module';


@NgModule({
  declarations: [
    BaseComponent
  ],
  imports: [
    CommonModule,
    PosRoutingModule,
    MaterialModule
  ]
})
export class PosModule { }
