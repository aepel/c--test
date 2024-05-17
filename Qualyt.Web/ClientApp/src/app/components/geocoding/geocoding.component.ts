import { Component, OnInit, EventEmitter, Output, ViewChild, OnChanges, Input } from '@angular/core';
import { GooglePlaceDirective } from 'ngx-google-places-autocomplete';
import { Address } from 'ngx-google-places-autocomplete/objects/address';

@Component({
  selector: 'app-geocoding',
  templateUrl: './geocoding.component.html',
  styleUrls: ['./geocoding.component.scss']
})
export class GeocodingComponent implements OnInit{
  @Input() cssClass:string
  @Output() AddressChange: EventEmitter<Address> = new EventEmitter<Address>();
  constructor() {
    
  }

  ngOnInit() {
    
  }

  @ViewChild("placesRef") placesRef: GooglePlaceDirective;

  public handleAddressChange(address: Address) {
    
    this.AddressChange.emit(address);
  }
 
  
}
