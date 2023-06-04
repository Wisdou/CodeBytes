import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

export interface ProblemTag{
  tag: string;
}
export interface Problem {
  title: string;
  description: string;
  // status: 'easy' | 'medium' | 'hard';
  tags: ProblemTag[];
}

@Injectable({
  providedIn: 'root',
})
export class ProblemService {
  private problemsUrl: string = 'https://localhost:5001/api/problems/';
  constructor(private httpClient: HttpClient) {}

  getProblems() {
    return this.httpClient.get<Problem[]>(this.problemsUrl);
  }

  getProblem(id: number) {
    let problemUrl = `{this.getProblems}/{id}`;
    return this.httpClient.get<Problem>(problemUrl);
  }
}
