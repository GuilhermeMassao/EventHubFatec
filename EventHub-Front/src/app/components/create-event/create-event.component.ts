import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {

  constructor(private eventService: EventService) { }

  ngOnInit() {
    this.eventService.eventForm.reset();
  }

  onSubmit() {
    console.log(this.eventService.eventForm.value);
  }
}
