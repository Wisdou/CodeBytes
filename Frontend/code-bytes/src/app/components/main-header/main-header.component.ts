import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-main-header',
  templateUrl: './main-header.component.html',
  styleUrls: ['./main-header.component.scss']
})
export class MainHeaderComponent {
  @Input() avatar: string = 'https://avatars.githubusercontent.com/u/11832552?v=4';
  logo: string = 'https://ng-web-apis.github.io/dist/assets/images/web-api.svg';
  currentTheme: boolean = false;
}
