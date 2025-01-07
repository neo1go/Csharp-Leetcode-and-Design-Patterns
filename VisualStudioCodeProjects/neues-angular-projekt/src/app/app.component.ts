import { Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';//Hier müssen die Komponenten importiert werden
import { FooterComponent } from './footer/footer.component';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet,HeaderComponent,FooterComponent], //Hier müssen die Komponenten importiert werden
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
   standalone:true,
})
export class AppComponent {
  title = 'neues-angular-projekt';
}
