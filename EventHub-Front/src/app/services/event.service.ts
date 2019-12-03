import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:61096';
  readonly BaseFrontURI = "http://localhost:4200";

  eventForm = this.fb.group({
    EventName: ['', Validators.required],
    EventStartDate: ['', Validators.required],
    EventEndDate: ['', Validators.required],
    EventTicket: ['', Validators.required],
    EventAdressPublicPlace: ['', Validators.required],
    EventAdressCity: ['', Validators.required],
    EventAdressUF: ['', Validators.required],
    EventAdressCEP: ['', Validators.required],
    EventAdressNeighborhood: ['', Validators.required],
    EventAdresNumber: ['', Validators.required]
  });

  createEvent() {
    var body = {
      UserName: this.eventForm.value.UserName
    };
    return this.http.post(this.BaseURI + '/api/user', body);
  }
}
