import {Component, OnInit} from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepicker, MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {FormControl, FormsModule, ReactiveFormsModule} from '@angular/forms';
import _moment from 'moment';
import {default as _rollupMoment, Moment} from 'moment';
import {provideMomentDateAdapter} from '@angular/material-moment-adapter';
import {BaseChartDirective} from 'ng2-charts';
import {
  BarController,
  BarElement,
  CategoryScale,
  Chart,
  ChartOptions,
  Legend,
  LinearScale,
  Title,
  Tooltip
} from 'chart.js';
import {WorkoutsService} from '../../workouts/workouts.service';
import {AuthService} from '../../auth/auth.service';

Chart.register(
  BarController,
  BarElement,
  CategoryScale,
  LinearScale,
  Tooltip,
  Legend,
  Title
);

const moment = _rollupMoment || _moment;

export const MY_FORMATS = {
  parse: {
    dateInput: 'MM/YYYY',
  },
  display: {
    dateInput: 'MM/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-progress',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    FormsModule,
    ReactiveFormsModule,
    BaseChartDirective,
  ],
  providers: [
    provideMomentDateAdapter(MY_FORMATS),
  ],
  templateUrl: './progress.component.html',
  styleUrl: './progress.component.css'
})
export class ProgressComponent implements OnInit {

  constructor(private workoutsService: WorkoutsService, private authService: AuthService) {
  }

  readonly date = new FormControl(moment());
  readonly maxDate = new Date();
  progressTitle: string = '';

  durationChartData: any;
  countChartData: any;
  intensityChartData: any;
  fatigueChartData: any;

  chartOptions: ChartOptions = {
    responsive: true,
    plugins: {
      legend: { display: false }
    }
  };

  ngOnInit() {
    this.fetchProgressData();
  }

  fetchProgressData() {
    const selectedDate = this.date.value;
    if (selectedDate) {
      const year = selectedDate.year();
      const month = selectedDate.month() + 1;

      this.progressTitle = `Progress for ${selectedDate.format('MMMM YYYY')}`;

      this.workoutsService.getProgress(this.authService.getUserId(), year, month).subscribe({
        next: (data) => {
          const labels = data.map(d => `Week ${d.week}`);

          this.durationChartData = {
            labels,
            datasets: [{ data: data.map(d => d.totalDuration), label: 'Duration (min)', backgroundColor: '#1EA2DD' }]
          };

          this.countChartData = {
            labels,
            datasets: [{ data: data.map(d => d.workoutCount), label: 'Workouts', backgroundColor: '#388e3c' }]
          };

          this.intensityChartData = {
            labels,
            datasets: [{ data: data.map(d => d.averageIntensity), label: 'Intensity', backgroundColor: '#F5841A' }]
          };

          this.fatigueChartData = {
            labels,
            datasets: [{ data: data.map(d => d.averageFatigue), label: 'Fatigue', backgroundColor: '#d32f2f' }]
          };
        },
        error: error => {
          console.log(error);
        }
      })
    }
  }

  setMonthAndYear(normalizedMonthAndYear: Moment, datepicker: MatDatepicker<Moment>) {
    const ctrlValue = this.date.value ?? moment();
    ctrlValue.month(normalizedMonthAndYear.month());
    ctrlValue.year(normalizedMonthAndYear.year());
    this.date.setValue(ctrlValue);
    datepicker.close();
    this.fetchProgressData();
  }
}
