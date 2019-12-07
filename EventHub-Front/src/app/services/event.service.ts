import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
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
    EventDescription: [''],
    EventDates: this.fb.group({
      EventStartDate: ['', Validators.required],
      EventEndDate: ['', Validators.required],
    }, { validator: this.validateDates }),
    EventTicket: ['', Validators.required],
    EventAdressPublicPlace: ['', Validators.required],
    EventAdressPlaceName: ['', Validators.required],
    EventAdressCity: ['', Validators.required],
    EventAdressUF: ['', Validators.required],
    EventAdressCEP: ['', Validators.required],
    EventAdressNeighborhood: ['', Validators.required],
    EventAdressComplement: [''],
    EventAdressNumber: ['', Validators.required]
  });

  EditeventForm = this.fb.group({
    EventName: ['', Validators.required],
    EventDescription: [''],
    EventDates: this.fb.group({
      EventStartDate: ['', Validators.required],
      EventEndDate: ['', Validators.required],
    }, { validator: this.validateDates }),
    EventTicket: ['', Validators.required],
    EventAdressPublicPlace: ['', Validators.required],
    EventAdressPlaceName: ['', Validators.required],
    EventAdressCity: ['', Validators.required],
    EventAdressUF: ['', Validators.required],
    EventAdressCEP: ['', Validators.required],
    EventAdressNeighborhood: ['', Validators.required],
    EventAdressComplement: [''],
    EventAdressNumber: ['', Validators.required]
  });

  createEvent(userId: number, twitterLogin: boolean, googleLogin: boolean) {
    var body = {
      UserOwnerId: userId,
      EventName: this.eventForm.value.EventName,
      StartDate: this.eventForm.value.EventDates.EventStartDate,
      EndDate: this.eventForm.value.EventDates.EventEndDate,
      EventDescription: this.getFormNullableValue(this.eventForm.value.EventDescription),
      EventShortDescription: this.createShortDescription(this.eventForm.value.EventDescription),
      TicketsLimit: +this.eventForm.value.EventTicket,
      Adress: {
        PublicPlaceId: this.eventForm.value.EventAdressPublicPlace,
        PlaceName: this.eventForm.value.EventAdressPlaceName,
        City: this.eventForm.value.EventAdressCity,
        UF: this.formatUF(this.eventForm.value.EventAdressUF),
        CEP: this.eventForm.value.EventAdressCEP,
        Neighborhood: this.eventForm.value.EventAdressNeighborhood,
        AdressComplement: this.getFormNullableValue(this.eventForm.value.EventAdressComplement),
        AdressNumber: this.eventForm.value.EventAdressNumber
      },
      TwitterLogin: twitterLogin,
      GoogleLogin: googleLogin
    };
    console.log(body);
    return this.http.post(this.BaseURI + '/api/event', body);
  }

  public getEventById(id: number) {
    return this.http.get(this.BaseURI + '/public-places');
  }

  public getAllPublicPlaces() {
    return this.http.get(this.BaseURI + '/public-places');
  }

  private getFormNullableValue(formValue: any) {
    if(formValue == null) {
      return '';
    }
    return formValue;
  }

  private createShortDescription(formValue: any) {
    if(formValue == null || formValue == '') {
      return '';
    }

    if(String(formValue).length >= 150) {
      return String(formValue).substring(0, 140) + '...';
    }
    
    return formValue;
  }

  private validateDates(fb: FormGroup) {
    let startDatefield = fb.get('EventStartDate')
    if (startDatefield.errors == null || 'invalidDate' in startDatefield.errors) {
      if (fb.get('EventStartDate').value > fb.get('EventEndDate').value) {
        startDatefield.setErrors({ invalidDate: true });
      }
      else {
        startDatefield.setErrors(null);
      }
    }
  }

  private formatUF(uf: string) {
    return uf.toUpperCase();
  }

}

/*
{
  "UserOwnerId": 1,
  "EventName": "Event Name",
  "StartDate": "2019-12-04T14:00",
  "EndDate": "2019-12-04T14:00",
  "EventDescription": "Event Description",
  "EventShortDescription": "Event Short Description",
  "TicketsLimit": 1;
  "Adress": {
    "PublicPlace": {
      "PlaceName": "Place Name"
    },
    "City": "City",
    "UF": "SP",
    "CEP": "214214",
    "Neighborhood": "Neighborhood",
    "AdressComplement": "Adress Complement",
    "AdressNumber": 12345
  }
}
*/
