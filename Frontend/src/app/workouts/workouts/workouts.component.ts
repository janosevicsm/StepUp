import {AfterViewInit, Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import {WorkoutDto} from '../../shared/model';
import {WorkoutsService} from '../workouts.service';
import {AuthService} from '../../auth/auth.service';
import {DatePipe, NgForOf, NgStyle} from '@angular/common';

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
    MatButtonModule,
    NgForOf,
    DatePipe,
    NgStyle
  ],
  templateUrl: './workouts.component.html',
  styleUrl: './workouts.component.css'
})
export class WorkoutsComponent implements OnInit {

  workouts: WorkoutDto[] = [];

  constructor(private workoutsService: WorkoutsService, private authService: AuthService) {}

  ngOnInit() {
    this.fetchWorkouts();
  }

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

  private readonly _currentYear = new Date().getFullYear();
  readonly maxDate = new Date();

  addWorkout() {
    if (this.workoutForm.valid) {
      const formValue = this.workoutForm.value;

      const workoutTypeMap: { [key: string]: number } = {
        'cardio': 0,
        'weight-lifting': 1,
        'flexibility': 2
      };

      const date: Date = new Date(formValue.date as string);
      const [hours, minutes] = (formValue.time as string).split(':').map(Number);

      date.setHours(hours);
      date.setMinutes(minutes);
      date.setSeconds(0);
      date.setMilliseconds(0);

      const workoutDto: WorkoutDto = {
        id: 0,
        userId: this.authService.getUserId(),
        workoutType: workoutTypeMap[formValue.type as string],
        duration: Number(formValue.duration!),
        calories: Number(formValue.calories!),
        intensity: formValue.intensity!,
        fatigue: formValue.fatigue!,
        notes: formValue.note || null,
        dateTime: date
      };


      this.workoutsService.addWorkout(workoutDto).subscribe({
        next: (response) => {
          const insertIndex = this.workouts.findIndex(w => new Date(w.dateTime) < new Date(response.dateTime));

          if (insertIndex === -1) {
            this.workouts.push(response);
          } else {
            this.workouts.splice(insertIndex, 0, response);
          }

          this.workoutForm.reset();

        },
        error: error => {
          console.log(error);
        }
      });
    }
  }

  fetchWorkouts() {
    this.workoutsService.getWorkoutsByUserId(this.authService.getUserId()).subscribe({
      next: (response) => {
        this.workouts = response;
      },
      error: error => {
        console.log(error);
      }
    })
  }

  getWorkoutTypeLabel(type: number): string {
    switch (type) {
      case 0: return 'Cardio';
      case 1: return 'Weightlifting';
      case 2: return 'Flexibility';
      default: return 'Unknown';
    }
  }

  getWorkoutColor(type: number): string {
    switch (type) {
      case 0: return '#EE612A';
      case 1: return '#FDBA32';
      case 2: return '#1EA2DD';
      default: return '#F5841A';
    }
  }

}
