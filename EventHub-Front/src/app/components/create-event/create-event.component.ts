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
        console.log("Sucesso!");
        this.router.navigateByUrl('eventhub/event/' + res.Id);
      },
      err => {
        if(err.status == 400) {
          console.log("Error 400");
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar criar evento!');
        }
        else {
          console.log(err);
          this.toastr.error('Tente novamente mais tarde.','Erro ao tentar criar evento!');
        }
      }
    );
  }
}
