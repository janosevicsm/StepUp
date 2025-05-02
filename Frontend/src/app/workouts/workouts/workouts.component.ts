import {AfterViewInit, Component} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-workouts',
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSliderModule,
    MatButtonModule
  ],
  templateUrl: './workouts.component.html',
  styleUrl: './workouts.component.css'
})
export class WorkoutsComponent {

  constructor() {}

  workoutForm = new FormGroup({
    type: new FormControl('', Validators.required),
    date: new FormControl('', Validators.required),
    time: new FormControl('', Validators.required),
    duration: new FormControl('', [Validators.required, Validators.min(1)]),
    calories: new FormControl('', [Validators.required, Validators.min(1)]),
    intensity: new FormControl(5),
    fatigue: new FormControl(5),
    note: new FormControl('')
  });

  submitWorkout() {
    if (this.workoutForm.valid) {
      console.log(this.workoutForm.value);
      // Submit to backend here
    }
  }
}
