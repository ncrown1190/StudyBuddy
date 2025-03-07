import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { QuestionListComponent } from "./question-list/question-list.component";

@Component({
  selector: 'app-root',
  imports: [QuestionListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'study-buddy-ui';
}
