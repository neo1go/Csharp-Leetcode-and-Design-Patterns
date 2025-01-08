import { Component} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';//Hier müssen die Komponenten importiert werden
import { FooterComponent } from './footer/footer.component';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet,HeaderComponent,FooterComponent,CommonModule], //Hier müssen die Komponenten importiert werden
    templateUrl: './app.component.html',                     //Eigene Komponenten werden mit:   ng generate component Name   :erstellt
    styleUrls: ['./app.component.css'],
   standalone:true,
})
export class AppComponent {
variable1:string='';
isVisible: boolean =false;

 showVariable(newVariable:string){
 this.variable1=newVariable;
 }

 toggleVisibility(){
 this.isVisible = !this.isVisible;  //Toggle mit 2 Zuständen

 }
}
