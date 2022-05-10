import { Pipe, PipeTransform } from '@angular/core';
import { Md5 } from 'ts-md5';

@Pipe({
  name: 'textConverter'
})
export class TextConverterPipe implements PipeTransform {
  morseCode: Map<string, string> = new Map<string, string>([
    ["A", ".-"],
    ["B", "-..."],
    ["C", "-.-."],
    ["D", "-.."],
    ["E", "."],
    ["F", "..-."],
    ["G", "--."],
    ["H", "...."],
    ["I", ".."],
    ["J", ".---"],
    ["K", "-.-"],
    ["L", ".-.."],
    ["M", "--"],
    ["N", "-."],
    ["O", "---"],
    ["P", ".--."],
    ["Q", "--.-"],
    ["R", ".-."],
    ["S", "..."],
    ["T", "-"],
    ["U", "..-"],
    ["W", ".--"],
    ["X", "-..-"],
    ["Y", "-.--"],
    ["Z", "--.."]
  ])


  transform(value: string, args: string): unknown {
    if (args == "morse") {
      let newString = "";
      for (let i = 0; i < value.length; i++) {
        const letter = value[i].toUpperCase();
        newString += this.morseCode.get(letter);
      }
      return newString;
    }
    //For md5 hash, for now it is just gonna hash if morse is not chosen
    else {
      return Md5.hashStr(value);
    }
  }

}
