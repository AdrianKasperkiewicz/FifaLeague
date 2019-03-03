import { NgModule } from '@angular/core';
import { AccordionLinkDirective, AccordionAnchorDirective, AccordionDirective } from './directives/accordion';
import { MenuItems } from './models/menu-items/menu-items';



@NgModule({
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective
  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective
   ],
  providers: [ MenuItems ]
})
export class SharedModule { }
