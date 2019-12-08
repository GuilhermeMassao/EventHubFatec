import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EventService } from 'src/app/services/event.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent  implements  OnInit {

  public userId: BigInteger;
  public events: any;
  pageOfEvents: Array<any>;

  constructor(private eventService: EventService, private router: Router, private toastr: ToastrService) { }


  ngOnInit() {
    this.userId = JSON.parse(localStorage.getItem('user')).id;
    this.eventService.getAllActiveEvents().subscribe(
      (res: any) => {
        console.log(res);
        this.events = res;
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
    
  redirectEvent(id){
    this.router.navigateByUrl("/eventhub/evento?id=" + id);
  }

  onChangePage(pageOfEvents: Array<any>) {
    this.pageOfEvents = pageOfEvents;
}

}
