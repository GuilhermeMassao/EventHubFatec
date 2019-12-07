import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {

  publicPlaces: any;

  constructor(private eventService: EventService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.eventService.eventForm.reset();
    this.eventService.getAllPublicPlaces().subscribe(
      (res: any) => {
        this.publicPlaces = res
      }
    );
  }

  onSubmit() {
    this.eventService.createEvent(JSON.parse(localStorage.getItem('user')).id,
                                  JSON.parse(localStorage.getItem('user')).twitterLogin,
                                  JSON.parse(localStorage.getItem('user')).googleLogin).subscribe(
      (res: any) => {
        if(JSON.parse(localStorage.getItem('user')).googleLogin == true){
          this.toastr.toastrConfig.timeOut = 10000;
          this.toastr.success('Por favor entre na sua conta do Google Agenda e deixe sua nova agenda pública para que as pessoas possam se inscrever no seu novo evento.','Evento criado com sucesso!');
        }
        this.router.navigateByUrl('eventhub/event/' + res.Id);
      },
      err => {
        if(err.status == 400) {
          console.log("Error 400");
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar criar evento!');
        }
        else {
          console.log("err");
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar criar evento!');
        }
      }
    );
  }
}
