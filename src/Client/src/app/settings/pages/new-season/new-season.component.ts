import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { SeasonService } from '../../../shared/services/season.service';
import { CdkDragDrop} from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-new-season',
  templateUrl: './new-season.component.html',
  styleUrls: ['./new-season.component.css']
})
export class NewSeasonComponent {
  isLinear = true;
  seasonFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private seasonService: SeasonService) { }

  ngOnInit() {
    this.seasonFormGroup = this.formBuilder.group({
      startdate: ['', Validators.required],
      divisions: this.formBuilder.array([])
    });
  }

  addNewDivision() {
    this.formArray.push(
      this.formBuilder.group({
        name: ['', Validators.required],
        hierarchy: this.formArray.controls.length + 1,
        numberOfDegraded: [''],
        numberOfPromoted: ['']
      }));
  }

  onSubmit() {
    this.seasonService
      .create(this.seasonFormGroup.value)
      .subscribe(x => console.log('created: ' + x));
  }

  get formArray(): FormArray {
    return this.seasonFormGroup.get('divisions') as FormArray;
  }

  drop(event: CdkDragDrop<FormArray[]>) {
    const dir = event.currentIndex > event.previousIndex ? 1 : -1;

    const from = event.previousIndex;
    const to = event.currentIndex;

    const temp = this.formArray.at(from);
    for (let i = from; i * dir < to * dir; i = i + dir) {
      const current = this.formArray.at(i + dir);
      this.formArray.setControl(i, current);
    }
    this.formArray.setControl(to, temp);
    this.reorderHierarchy();
  }

  private reorderHierarchy() {
    for (var i = 0; i < this.formArray.controls.length; i++) {
      this.formArray.controls[i].controls['hierarchy'].value = i + 1;
    }
  }
}
