import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { QuestionAnswer } from '../models/question-answer';

@Component({
  selector: 'app-favorites-list',
  imports: [CommonModule,FormsModule],
  templateUrl: './favorites-list.component.html',
  styleUrl: './favorites-list.component.css'
})
export class FavoritesListComponent  {
    
  favoritesList: QuestionAnswer[]=[];
  userId = '11111' //Place holder

  constructor(private apiService: ApiService){}
    
}
