import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'fixdate'
})
export class FixdatePipe implements PipeTransform {

  transform(value: any, ...args: any[]): string {
    return value.split("T")[0];
  }
}
