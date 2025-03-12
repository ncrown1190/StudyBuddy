import { Component, OnInit } from '@angular/core';
import { QuestionAnswer } from '../models/question-answer';
import { ApiService } from '../api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Favorite } from '../models/favorite.model';
import { FavoriteQAInterface } from '../models/favorite.model';
import { QuestionAnswerInterface } from '../models/favorite.model';
@Component({
  selector: 'app-question-list',
  imports: [CommonModule,FormsModule],
  templateUrl: './question-list.component.html',
  styleUrl: './question-list.component.css'
})
export class QuestionListComponent implements OnInit {
  QaList: QuestionAnswerInterface[] = []; // List of questions
  favorites: FavoriteQAInterface[] = []; // List of favorite objects
  userId: string = ''; // User ID for API requests

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.userId = this.apiService.getUserId(); // Assume getUserId() returns the logged-in user's ID
    this.loadQuestions();
    this.loadFavorites();
  }

  // Fetch all questions
  loadQuestions() {
    this.apiService.getQuestionsAnswers().subscribe(
      (questions) => (this.QaList = questions)
    );
  }

  // Fetch favorites from the backend
  loadFavorites() {
    this.apiService.getFavorites().subscribe(
      (favorites) => (this.favorites = favorites)
    );
  }

  // Check if a question is a favorite
  isFavorite(questionId: number): boolean {
    return this.favorites.some(fav => fav.questionId === questionId);
  }

  // Toggle favorite (add or remove)
  toggleFavorite(question: QuestionAnswerInterface) {
    const favorite = this.favorites.find(fav => fav.questionId === question.id);
    
    if (favorite) {
      this.removeFromFavorites(favorite.favoriteId);
    } else {
      this.addToFavorites(question);
    }
  }

  // Add a question to favorites
  addToFavorites(question: QuestionAnswerInterface) {
    const newFavorite: Favorite = {
      userId: this.userId,
      questionId: question.id
    };

    this.apiService.addFavorite(newFavorite).subscribe((createdFavorite) => {
      this.favorites.push(createdFavorite);
    });
  }

  // Remove a question from favorites
  removeFromFavorites(favoriteId: number) {
    this.apiService.deleteFavorite(favoriteId).subscribe(() => {
      this.favorites = this.favorites.filter(fav => fav.favoriteId !== favoriteId);
    });
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
