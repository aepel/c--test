import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nestedProperty'
})
export class NestedPropertyPipe implements PipeTransform {

  transform(value: any, arg1: string): any {
    var arr = arg1.split(".");
    while (arr.length && (value = value[arr.shift()])) {};
    return value ? value.toString():"";
  }

}
