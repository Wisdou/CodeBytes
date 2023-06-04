import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

export interface ProblemsDTO{
  problems: Problem[];
}

export interface ProblemByIdDTO{
  problem: Problem;
}

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
    return this.httpClient.get<ProblemsDTO>(this.problemsUrl).pipe(map((x) => x.problems));
  }

  getProblemsWithTitle(text: string) {
    let problemUrl = `{this.getProblems}?title={text}`;
    return this.httpClient.get<ProblemsDTO>(problemUrl).pipe(map((x) => x.problems));
  }

  getProblem(id: number) {
    let problemUrl = `{this.getProblems}/{id}`;
    return this.httpClient.get<ProblemByIdDTO>(problemUrl).pipe(map((x) => x.problem));
  }
}
