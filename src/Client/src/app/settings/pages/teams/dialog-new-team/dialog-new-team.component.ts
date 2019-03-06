import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { TeamService } from '../../../../shared/services/team.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-dialog-new-team',
  templateUrl: './dialog-new-team.component.html',
  styleUrls: ['./dialog-new-team.component.css']
})
export class DialogNewTeamComponent implements OnInit {
  ngOnInit(): void {
    this.teamFormGroup = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: '',
      email: ['', [Validators.email, Validators.required]]
    })
  }
  teamFormGroup: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<DialogNewTeamComponent>,
    private teamService: TeamService,
    private formBuilder: FormBuilder
  ) { }


  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.teamFormGroup.valid) {
      this.teamService
        .add(this.teamFormGroup.value)
        .subscribe(resp => this.dialogRef.close(true));
    }
  }
}
