import { Component, OnInit } from '@angular/core';
import { Book } from './model/books.model';
import { BooksService } from './product-list.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  livros!: Book[]; // Corrigido para definir o tipo como Book[]

  constructor(private booksService: BooksService) {
    // Injeção de dependência do serviço BooksService no construtor
  }

  ngOnInit(): void {
    this.booksService.getBooks().subscribe((data: Book[]) => {
      this.livros = data;
      console.log(this.livros);
    });
  }
}
