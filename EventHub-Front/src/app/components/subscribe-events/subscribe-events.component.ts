import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-subscribe-events',
  templateUrl: './subscribe-events.component.html',
  styleUrls: ['./subscribe-events.component.css']
})
export class SubscribeEventsComponent implements OnInit {

  public userId: BigInteger;
  public events: any;
  pageOfEvents: Array<any>;

  constructor(private eventService: EventService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.userId = JSON.parse(localStorage.getItem('user')).id;
    this.eventService.getUserSubscribedEvents(this.userId).subscribe(
      (res: any) => {
        console.log(res);
        this.events = res;
      },
      err => {
        if(err.status == 400) {
          console.log("Error 400");
          this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações dos eventos!');
        }
        else {
          console.log("err");
          this.toastr.error('Tente novamente mais tarde.','Erro ao preencher informações dos eventos!');
        }
      }
    );
  }

}
