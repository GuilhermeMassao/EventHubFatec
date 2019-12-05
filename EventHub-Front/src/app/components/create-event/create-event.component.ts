import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {

  public customPatterns = { '0': { pattern: new RegExp('\[0-9\]')} };

  publicPlaces: any;

  constructor(private eventService: EventService) { }

  ngOnInit() {
    this.eventService.eventForm.reset();
    this.eventService.getAllPublicPlaces().subscribe(
      (res: any) => {
        this.publicPlaces = res
      }
    );
  }

  onSubmit() {
    this.eventService.createEvent(JSON.parse(localStorage.getItem('user')).id).subscribe(
      (res: any) => {
        console.log("Sucesso!");
      },
      err => {
        if(err.status == 400)
        console.log("Error 400");
        else
          console.log(err);
      }
    );
  }
}
