import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Books } from '../Models/books';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal',
  standalone: true,
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css'],
  imports: [FormsModule, CommonModule]
})
export class ModalComponent {
  @Input() book!: Books;
  @Input() modalType!: 'edit' | 'details' | 'add' | null;
  @Output() closeModal = new EventEmitter<void>();
  @Output() updateBook = new EventEmitter<Books>(); 
  @Output() addBook = new EventEmitter<Books>();

  onClose() {
    this.closeModal.emit();
  }

  onUpdate() {
    this.updateBook.emit(this.book);
  }

  onAdd() {
    this.addBook.emit(this.book);
  }
}








