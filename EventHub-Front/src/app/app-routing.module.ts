import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { AppOverlayComponent } from './components/app-overlay/app-overlay.component';
import {ChangePasswordComponent} from './components/change-password/change-password.component'
import { CreateEventComponent } from './components/create-event/create-event.component';
import { EventInfoComponent } from './components/event-info/event-info.component';
import { EventEditComponent } from './components/event-edit/event-edit.component';
import { SubscribeEventsComponent } from './components/subscribe-events/subscribe-events.component';
import { OwnerEventComponent } from './components/owner-event/owner-event.component';

const routes: Routes = [
  { path: '', redirectTo: '/eventhub/home', pathMatch:'full'},
  { path: 'cadastro', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'eventhub', component: AppOverlayComponent, canActivate:[AuthGuard],
    children: [
      { path: 'home', component: HomeComponent, canActivate:[AuthGuard]},
      { path: 'user/profile', component: UserInfoComponent, canActivate:[AuthGuard] },
      { path: 'user/editar-senha', component: ChangePasswordComponent, canActivate:[AuthGuard] },
      { path: 'criar-evento', component: CreateEventComponent, canActivate:[AuthGuard]},
      { path: 'evento', component: EventInfoComponent, canActivate:[AuthGuard]},
      { path: 'editar-evento', component: EventEditComponent, canActivate:[AuthGuard]},
      { path: 'eventos-inscritos', component: SubscribeEventsComponent, canActivate:[AuthGuard]},
      { path: 'eventos-criados', component: OwnerEventComponent, canActivate:[AuthGuard]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponents = [RegisterComponent,
                                  LoginComponent,
                                  HomeComponent,
                                  UserInfoComponent,
                                  AppOverlayComponent,
                                  CreateEventComponent,
                                  ChangePasswordComponent,
                                  EventInfoComponent,
                                  EventEditComponent,
                                  SubscribeEventsComponent]
