import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EventService } from 'src/app/services/event.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css']
})
export class EventEditComponent implements OnInit {

  publicPlaces: any;
  eventId: any;

  eventInfo = {
    eventName: '',
    eventDescription: '',
    startDate: '',
    endDate: '',
    ticketsLimit: ''
  };

  adressInfo = {
    adressId: '',
    publicPlaceId: '',
    placeName: '',
    city: '',
    uf: '',
    cep: '',
    neighborhood: '',
    adressComplement: '',
    adressNumber: ''
  };

  constructor(private eventService: EventService, private router: Router, private toastr: ToastrService,  private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.eventService.getAllPublicPlaces().subscribe(
      (res: any) => {
        this.publicPlaces = res
      }
    );

    this.fillForm();
    if(this.eventId != JSON.parse(localStorage.getItem('user')).id) {
      this.router.navigateByUrl("/eventhub/home");
    }
  }

  fillForm() {
    this.activatedRoute.queryParams.subscribe(params => {
      if(params.id != null) {
        this.eventId = params.id;
        this.eventService.getEventById(params.id).subscribe(
          (res: any) => {
            this.fillFormVariables(res);
            this.eventService.buildEventEditForm(this.eventInfo, this.adressInfo);
          },
          err => {
            if(err.status == 400) {
              console.log("Error 400");
              this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações do evento!').onHidden.subscribe(() => {
                this.router.navigateByUrl("/eventhub/home");
              });
            }
            else {
              console.log("err");
              this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações do evento!').onHidden.subscribe(() => {
                this.router.navigateByUrl("/eventhub/home");
              });
            }
          }
        );
      }
      else {
        this.router.navigateByUrl("/eventhub/home");
      }
    });
  }

  fillFormVariables(data: any) {
    this.eventInfo = {
      eventName: data.eventName,
      eventDescription: data.eventDescription,
      startDate: data.startDate,
      endDate: data.endDate,
      ticketsLimit: data.ticketsLimit
    };

    this.adressInfo = {
      adressId: data.adressId,
      publicPlaceId: data.publicPlaceId,
      placeName: data.placeName,
      city: data.city,
      uf: data.uf,
      cep: data.cep,
      neighborhood: data.neighborhood,
      adressComplement: data.adressComplement,
      adressNumber: data.adressNumber
    };
  }

  onSubmit() {
    console.log(this.eventService.editEventForm);
    this.eventService.editEvent(JSON.parse(localStorage.getItem('user')).id,
    this.eventId,
    +this.adressInfo.adressId,
    JSON.parse(localStorage.getItem('user')).twitterLogin,
    JSON.parse(localStorage.getItem('user')).googleLogin).subscribe(
      (res: any) => {
        this.router.navigateByUrl("/eventhub/evento?id=" + this.eventId);
      },
      err => {
        if(err.status == 400) {
          console.log("Error 400");
          this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações do evento!').onHidden.subscribe(() => {
            this.router.navigateByUrl("/eventhub/home");
          });
        }
        else {
          console.log("err");
          this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações do evento!').onHidden.subscribe(() => {
            this.router.navigateByUrl("/eventhub/home");
          });
        }
      } 
    );
  }


}
