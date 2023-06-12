import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-burger-button',
  templateUrl: './burger-button.component.html',
  styleUrls: ['./burger-button.component.scss']
})
export class BurgerButtonComponent {
  @Output() isOpen = new EventEmitter<Boolean>();
  isOpenFlag: boolean = false;

  toggle(){
    this.isOpenFlag = !this.isOpenFlag;
  }
}
