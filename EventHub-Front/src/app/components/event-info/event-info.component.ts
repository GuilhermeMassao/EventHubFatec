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

  private eventId: any;
  private eventInfo: any;
  private adressInfo: any;
  private ownerEvent: boolean;
  private userId: number;

  constructor(
    private eventService: EventService,
    private router: Router,
    private toastr: ToastrService,
    private activatedRoute: ActivatedRoute
  ) {
    this.userId = JSON.parse(localStorage.getItem('user')).id;
   }

  fillEvent() {
    this.activatedRoute.queryParams.subscribe(params => {
      if (params.id != null) {
        this.eventId = params.id;
        this.eventService.getEventById(params.id).subscribe(
          (res: any) => {
            this.fillInfoEvent(res);
            this.ownerEvent = this.eventInfo.userOwnerId === this.userId;
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
  fillInfoEvent(data: any) {
    this.eventInfo = {
      eventId: data.eventId,
      eventName: data.eventName,
      eventDescription: data.eventDescription,
      startDate: new Date(data.startDate).toUTCString(),
      endDate: new Date(data.endDate).toUTCString(),
      ticketsLimit: data.ticketsLimit,
      userOwnerId: data.userOwnerId
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
    this.eventService.inactiveEvent(this.eventId, this.adressInfo.adressId).subscribe(
      (res: any) => {
        this.fillInfoEvent(res);     
        this.router.navigateByUrl("/eventhub/home");    
      },
      err => {
        if(err.status == 400) {
          console.log("Error 400");
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar excluir o evento!');
        }
        else {
          console.log("err");
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar excluir o evento!');
        }
    });
  }

  ngOnInit() {
    this.fillEvent();

  }

  private subscriberOnEvent(): void {
    const subscription = {
      userId: this.userId,
      eventId: this.eventInfo.eventId
    };
    this.eventService.subscriberOnEvent(subscription)
    .subscribe(
      (result) => {
      },
      (error) => {
        this.toastr.error('Tente novamente mais tarde.', 'Erro ao se increver no evento!');
      }
    );
  }

  private userAlreadyRegistered(): boolean {
    let alreadyRegistered: boolean;
    this.eventService.getAllEventsByUser(this.userId)
    .subscribe(
      (result) => {

      }
    );
  }

  return true;
}
