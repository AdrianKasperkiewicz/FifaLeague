import { FormControl } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CustomValidators {
  static GUID(formControl: FormControl) {
    const GUID_REGEXP = new RegExp('^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$');

    if (!GUID_REGEXP.test(formControl.value)) {
      return {
        GUID: true
      };
    }

    return null;
  }
}
