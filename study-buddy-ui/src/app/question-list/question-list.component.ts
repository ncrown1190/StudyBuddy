import { Component, OnInit } from '@angular/core';
import { QuestionAnswer } from '../models/question-answer';
import { ApiService } from '../api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-question-list',
  imports: [CommonModule,FormsModule],
  templateUrl: './question-list.component.html',
  styleUrl: './question-list.component.css'
})
export class QuestionListComponent implements OnInit {
  QaList: QuestionAnswer[]=[];

  constructor(private apiService: ApiService){}
 
  ngOnInit(): void {
    this.apiService.getQuestionsAnswers().subscribe(
      data => {
        this.QaList = data as any[];
      }
    );
  }


  // What does this do?
  ShowQuestions(): QuestionAnswer[] {
    this.apiService.getQuestionsAnswers()
    .subscribe(
      response => {
      console.log(response)
      this.QaList = response as any[]
    })
    return this.QaList
  }

}
