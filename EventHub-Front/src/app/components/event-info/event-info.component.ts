import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EventService } from 'src/app/services/event.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-event-info',
  templateUrl: './event-info.component.html',
  styleUrls: ['./event-info.component.css']
})
export class EventInfoComponent implements OnInit {

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

  fillEvent() {
    this.activatedRoute.queryParams.subscribe(params => {
      if(params.id != null) {
        this.eventId = params.id;
        this.eventService.getEventById(params.id).subscribe(
          (res: any) => {
            this.fillInfoEvent(res);          },
          err => {
            if(err.status == 400) {
              console.log("Error 400");
              this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações do evento!').onHidden.subscribe(() => {
                // this.router.navigateByUrl("/eventhub/home");
              });
            }
            else {
              console.log("err");
              this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações do evento!').onHidden.subscribe(() => {
                // this.router.navigateByUrl("/eventhub/home");
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
  fillInfoEvent(data: any) {
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

  toEditEvent() {
    this.router.navigateByUrl("/eventhub/editar-evento?id=" + this.eventId);
  }

  toDeleteEvent() {

  }

  ngOnInit() {
    this.fillEvent();
  }

}
