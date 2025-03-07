import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { QuestionListComponent } from "./question-list/question-list.component";

@Component({
  selector: 'app-root',
  imports: [QuestionListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'study-buddy-ui';

  
  ngOnInit(): void {
    let userId = localStorage.getItem('userId');
    if (!userId){
      userId = this.generateUserId();
      localStorage.setItem('userId',userId)
    }
  }
  
  generateUserId(): string {
    return 'user-' + Math.random().toString(36).substring(2,9);
  }

}
