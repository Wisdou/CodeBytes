import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { delay, map } from 'rxjs';

export interface ProblemsDTO{
  total: number,
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
  difficulty: string;
  tags: ProblemTag[];
}

export interface ProblemPaging{
  size: number;
  page: number;
}

export class ProblemFilter{
  constructor(public paging: ProblemPaging, public startsWith: string){}

  static getDefault(): ProblemFilter {
    return {
      startsWith: "",
      paging: {
        size: 10,
        page: 0,
      }
    };
  };
}

@Injectable({
  providedIn: 'root',
})
export class ProblemService {
  private problemsUrl: string = 'https://localhost:5001/api/problems/';
  constructor(private httpClient: HttpClient) {}

  getProblems() {
    return this.httpClient.get<ProblemsDTO>(this.problemsUrl);
  }

  getProblemsWithFilter(filter: ProblemFilter) {
    return this.httpClient.post<ProblemsDTO>(this.problemsUrl, filter);
  }

  getProblem(id: number) {
    let problemUrl = `{this.getProblems}/{id}`;
    return this.httpClient.get<ProblemByIdDTO>(problemUrl).pipe(map((x) => x.problem));
  }
}
