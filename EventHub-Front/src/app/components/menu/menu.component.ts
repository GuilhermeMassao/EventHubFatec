import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  userName = JSON.parse(localStorage.getItem('user')).userName;

  constructor(private router: Router) { }

  onLogout() {
    localStorage.removeItem('user');
    this.router.navigate(['/login']);
  }

}
