import { Component, OnInit, Inject } from '@angular/core';
import { flatMap, startWith } from 'rxjs/operators';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { ITeam } from '../../../../shared/models/team.viewmodel';
import { TeamService } from '../../../../shared/services/team.service';
import { DivisionService } from '../../../../shared/services/division.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IDivision } from '../../../../shared/models/division.viewmodel';

@Component({
  selector: 'app-add-team-to-division-dialog',
  templateUrl: './add-team-to-division-dialog.component.html',
  styleUrls: ['./add-team-to-division-dialog.component.css']
})
export class AddTeamToDivisionDialogComponent implements OnInit {
  teamForm: FormGroup;
  filteredOptions: Observable<ITeam[]>;
  division: IDivision;
  constructor(
    private formbBuilder: FormBuilder,
    private teamService: TeamService,
    private divisionService: DivisionService,
    public dialogRef: MatDialogRef<AddTeamToDivisionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any) {
    this.division = data.division;
  }

  ngOnInit() {
    this.teamForm = this.formbBuilder.group({
      seasonId: '',
      divisionId: '',
      teamId: ''
    });

    this.filteredOptions = this.teamForm.controls['teamId'].valueChanges
      .pipe(
        startWith(''),
        flatMap(x => this.teamService.filterByName(x))
      );
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.teamForm.valid) {
      this.teamForm.patchValue({ seasonId: this.division.seasonId });
      this.teamForm.patchValue({ divisionId: this.division.id });

      this.divisionService.addTeamToDivision(this.teamForm.value)
        .subscribe(this.dialogRef.close(true));
    }
  }
}
