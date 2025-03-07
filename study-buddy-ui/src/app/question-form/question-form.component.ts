import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../api.service';
import { QuestionAnswer } from '../models/question-answer';
@Component({
  selector: 'app-question-form',
  imports: [CommonModule,FormsModule],
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})
export class QuestionFormComponent {
question: QuestionAnswer = {id: 0, question: '', answer: ''};

constructor(private apiService: ApiService){}

submitQuestion(): void {
  if(this.question.id){
    this.apiService.editQuestionAnswer(this.question.id,this.question).subscribe();
  }
  else{
    this.apiService.addQuestionAnswer(this.question).subscribe();
  }
}


}
