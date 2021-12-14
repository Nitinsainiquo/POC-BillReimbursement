import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'addsign'
})
export class AddsignPipe implements PipeTransform {

  transform(value: any, ...args: any[]): string {
    return "Rs." + " " + value;
  }

}
