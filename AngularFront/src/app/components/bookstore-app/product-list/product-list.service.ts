import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Book } from "./model/books.model";
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class BooksService {

  private url = 'http://localhost:5028/Product';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url)
      .pipe(
        catchError((error) => {
          console.error('Error fetching books:', error);
          return throwError('Something went wrong while fetching books.');
        })
      );
  }
}
