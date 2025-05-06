import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ProgressDto, WorkoutDto} from '../shared/model';
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

  getProgress(userId: number, year: number, month: number): Observable<ProgressDto[]> {
    const params = new HttpParams()
      .set('year', year.toString())
      .set('month', month.toString());

    return this.http.get<ProgressDto[]>(environment.apiHost + 'workout/progress/' + userId, { params });
  }
}
