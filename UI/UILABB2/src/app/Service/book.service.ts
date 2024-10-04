import { HttpClient } from "@angular/common/http";
import { Books } from "../Models/books";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiResponse } from '../Models/api-response-model';

@Injectable({
providedIn: 'root'
})
export class BooksService {
baseUrl = 'https://localhost:7280/api/books';
singleBookUrl = 'https://localhost:7280/api/book';

constructor(private https: HttpClient) {}

getAllBooks(): Observable<ApiResponse<Books>> {
    return this.https.get<ApiResponse<Books>>(this.baseUrl);
}

updateBook(book: Books): Observable<Books> {
    return this.https.put<Books>(this.singleBookUrl, book);
}

addBook(book: Books): Observable<Books> {
    book.id = 0;
    return this.https.post<Books>(this.singleBookUrl, book);
}

deleteBook(id: number): Observable<Books> {
    return this.https.delete<Books>(`${this.singleBookUrl}/${id}`);
}

getBookDetails(id: number): Observable<Books> {
    return this.https.get<Books>(`${this.singleBookUrl}/${id}`);
}
}