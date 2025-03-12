import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { QuestionAnswer } from './models/question-answer';
import { Favorite, FavoriteQAInterface, QuestionAnswerInterface } from './models/favorite.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7274/api';
  constructor(private http: HttpClient) { }

  private userId: string = '123456789';

  getUserId(): string {
    return this.userId;
  }
  
  getQuestionsAnswers(): Observable<QuestionAnswerInterface[]> {
    return this.http.get<QuestionAnswerInterface[]>(`${this.baseUrl}/Qas`);
  }
  getQuestionById(id: number){
    this.http.get(`${this.baseUrl}/Qas/${id}`)
  }
  addQuestionAnswer(question: string){
    return this.http.post(`${this.baseUrl}/Qas`,question)
  }
  editQuestionAnswer(id: number, question: QuestionAnswer){
    return this.http.put(`${this.baseUrl}/Qas/${id}`,question)
  }
  deleteQuestionAnswer(id: number){
    return this.http.delete(`${this.baseUrl}/Qas/${id}`)
  }

  //Favorites
  addFavorite(favorite: Favorite): Observable<FavoriteQAInterface> {
    return this.http.post<FavoriteQAInterface>(`${this.baseUrl}/UserFavorites`, favorite);
  }
  getFavorites(): Observable<FavoriteQAInterface[]> {
    return this.http.get<FavoriteQAInterface[]>(`${this.baseUrl}/UserFavorites`);
  }
  deleteFavorite(favoriteId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/UserFavorites/${favoriteId}`);
  }
}
