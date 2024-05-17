import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nullable'
})
export class NullablePipe implements PipeTransform {

  transform(value: any): any {
    return ((value != "" && value) || value===0 ) ? value : "No aplica";
  }

}
