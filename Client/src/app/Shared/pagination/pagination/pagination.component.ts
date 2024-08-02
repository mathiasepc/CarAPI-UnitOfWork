// Importerer Input for at modtage værdier fra parent component
// Importerer Output for at sende hændelser til parent component
// Importerer EventEmitter for at sende hændelser
// Importerer OnChanges for at håndtere ændringer i input-egenskaber
import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';

@Component({
    selector: 'pagination', // Bemærk 'app-pagination' som selector
    templateUrl: './pagination.component.html', // Korrekt brug af templateUrl
    styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnChanges {
   // Input: Totalt antal elementer
  @Input('total-items') totalItems: number = 10;
  // Input: Antal elementer per side
  @Input('page-size') pageSize: number = 5;    
  // Output: Udsender den nye side, når den ændres
  @Output('page-changed') pageChanged = new EventEmitter<number>(); 
  // Array til at holde side-numre
  pages: number[] = []; 
  // Aktuel side
  currentPage: number = 1;

  ngOnChanges() {
      // Nulstil til første side ved ændringer i input
      this.currentPage = 1; 
      
      // Beregn antal sider udfra totalItems og pageSize
      console.log("totalItems: ", this.totalItems);
      console.log("pageSize: ", this.pageSize);
      const pagesCount = Math.ceil(this.totalItems / this.pageSize); 
      console.log("pageCount: ", pagesCount);
      this.pages = [];
      for (let i = 1; i <= pagesCount; i++) {
          // Tilføj hvert side-nummer til array
          this.pages.push(i); 
      }
  }

  changePage(page: number) {
      this.currentPage = page; 
      
      // send den nye side
      this.pageChanged.emit(page); 
  }

  previous() {
      // Kontroller om det ikke er den første side
      if (this.currentPage > 1) { 
          this.currentPage--;

          // send den nye side
          this.pageChanged.emit(this.currentPage);
      }
  }

  next() {
      // Kontroller om det ikke er den sidste side
      if (this.currentPage < this.pages.length) { 
          this.currentPage++; 

          // send den nye side til parent component.
          this.pageChanged.emit(this.currentPage);
      }
  }
}
