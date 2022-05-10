import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'textReplacer'
})
export class TextReplacerPipe implements PipeTransform {

  transform(value: string, args?: any): string {
    let newString = value;
    newString = newString.replace("stupid","bad").replace("dumb", "wierd");

    return newString;
  }

}
