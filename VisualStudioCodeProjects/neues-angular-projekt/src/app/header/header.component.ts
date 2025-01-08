import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  title = 'neues-angular-projekt';
description: string ='Dies ist eine einfache Angular-Komponente'

changeTitle(newTitle:string){
  this.title=newTitle;
}
}
