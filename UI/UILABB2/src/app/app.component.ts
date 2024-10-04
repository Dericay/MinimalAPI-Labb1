import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Books } from './Models/books';
import { BooksService } from './Service/book.service';
import { ApiResponse } from '../app/Models/api-response-model';
import { ModalComponent } from './modal/modal.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule, ModalComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Book Manager';
  books: Books[] = [];
  book: Books = this.resetBook();
  isLoading = false;
  errorMessage: string | null = null;
  isManageBooks: boolean = false;
  isModalOpen: boolean = false;
  modalType: 'edit' | 'details' | 'add' | null = null;

  constructor(private booksService: BooksService) {}

  ngOnInit(): void {
    this.getAllBooks();
  }

  getAllBooks() {
    this.isLoading = true;
    this.booksService.getAllBooks().subscribe({
      next: (response: ApiResponse<Books>) => {
        if (response && Array.isArray(response.result)) {
          this.books = response.result;
        } else {
          console.error('Unexpected response structure:', response);
          this.errorMessage = 'Failed to load books. Unexpected response format.';
          this.books = [];
        }
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching books:', error);
        this.errorMessage = 'Failed to load books. Please try again later.';
        this.books = [];
        this.isLoading = false;
      }
    });
  }

  toggleManageBooks() {
    this.isManageBooks = !this.isManageBooks;
    if (this.isManageBooks) {
      this.getAllBooks();
    } else {
      this.resetBook();
    }
  }

  openModal(book: Books, type: 'edit' | 'details') {
    this.book = { ...book };
    this.modalType = type;
    this.isModalOpen = true;
  }
  openAddBookModal() {
    this.book = this.resetBook();
    this.modalType = 'add';
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
    this.resetBook();
    this.modalType = null;
  }

  updateBook(book: Books) {
    this.booksService.updateBook(book).subscribe({
      next: () => {
        this.getAllBooks();
        this.closeModal();
      },
      error: (error) => {
        console.error('Error updating book:', error);
        this.errorMessage = 'Failed to update book. Please try again.';
      }
    });
  }
  onDelete(bookId: number) {
    this.booksService.deleteBook(bookId).subscribe({
      next: () => {
        this.getAllBooks();
      },
      error: (error) => {
        console.error('Error deleting book:', error);
        this.errorMessage = 'Failed to delete book. Please try again.';
      }
    });
  }

  addBook(book: Books) {
    this.booksService.addBook(book).subscribe({
      next: () => {
        this.getAllBooks();
        this.closeModal(); // Close modal after adding
      },
      error: (error) => {
        console.error('Error adding book:', error);
        this.errorMessage = 'Failed to add book. Please try again.';
      }
    });
  }

  resetBook(): Books {
    return {
      id: 0,
      bookTitle: '',
      author: '',
      genre: '',
      description: '',
      isAvailable: false
    };
  }
}












