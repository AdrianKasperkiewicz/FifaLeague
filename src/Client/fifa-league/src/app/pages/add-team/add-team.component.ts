import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TeamService } from 'src/app/shared/services/team.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css']
})

export class AddTeamComponent implements OnInit {
  teamForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private teamsService: TeamService) { }

  ngOnInit() {
    this.teamForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required]
    });

  }

  get f() { return this.teamForm.controls; }


  onSubmit() {
    if (this.teamForm.invalid) {
      console.log("invalid")
      return;
    }
    console.log('ok')
    this.teamsService.add(this.teamForm.value).subscribe(x => console.log(x));
  }
}
