import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {WorkoutDto} from '../shared/model';
import {environment} from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class WorkoutsService {

  constructor(private http: HttpClient) { }

  getWorkoutsByUserId(userId: number): Observable<WorkoutDto[]> {
    return this.http.get<WorkoutDto[]>(environment.apiHost + 'workout/' + userId);
  }

  addWorkout(workoutDto: WorkoutDto): Observable<WorkoutDto> {
    return this.http.post<WorkoutDto>(environment.apiHost + 'workout/add', workoutDto)
  }
}
