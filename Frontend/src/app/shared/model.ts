export interface LoginDto {
  email: string;
  password: string;
}

export interface RegisterDto {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}

export interface TokenDto {
  token: string;
}

export interface UserDto {
  id: number;
  email: string;
  password: string | null;
  firstName: string;
  lastName: string;
  workouts: WorkoutDto[]
}

export interface WorkoutDto {
  id: number;
  userId: number;
  workoutType: WorkoutType;
  duration: number;
  calories: number;
  intensity: number;
  fatigue: number;
  notes: string | null;
  dateTime: Date;
}

export interface ProgressDto {
  week: number;
  totalDuration: number;
  workoutCount: number;
  averageIntensity: number;
  averageFatigue: number;
}

export enum WorkoutType {

}
