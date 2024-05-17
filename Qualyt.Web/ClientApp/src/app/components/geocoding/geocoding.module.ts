import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeocodingComponent } from './geocoding.component';
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule, MatInputModule } from '@angular/material';

@NgModule({
  imports: [
    MatFormFieldModule,
    MatInputModule,
    CommonModule,
    GooglePlaceModule,
    FormsModule,
  ],
  declarations: [GeocodingComponent],
  exports: [GeocodingComponent],

})
export class GeocodingModule { }



