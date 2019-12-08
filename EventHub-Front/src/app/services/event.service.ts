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
      EventStartTime: ['', Validators.required],
      EventEndDate: ['', Validators.required],
      EventEndTime: ['', Validators.required]
    }, { validator: [this.validateDates, this.validPastDate] }),
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

  editEventForm = this.fb.group({
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
      StartDate: this.formatDate(this.eventForm.value.EventDates.EventStartDate, this.eventForm.value.EventDates.EventStartTime),
      EndDate: this.formatDate(this.eventForm.value.EventDates.EventEndDate,this.eventForm.value.EventDates.EventEndTime),
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

  editEvent(userId: number, eventId: number, adressId: number, twitterLogin: boolean, googleLogin: boolean) {
    var body = {
      UserOwnerId: userId,
      EventName: this.editEventForm.value.EventName,
      StartDate: this.editEventForm.value.EventDates.EventStartDate,
      EndDate: this.editEventForm.value.EventDates.EventEndDate,
      EventDescription: this.getFormNullableValue(this.editEventForm.value.EventDescription),
      EventShortDescription: this.createShortDescription(this.editEventForm.value.EventDescription),
      TicketsLimit: +this.editEventForm.value.EventTicket,
      Adress: {
        Id: adressId,
        PublicPlaceId: this.editEventForm.value.EventAdressPublicPlace,
        PlaceName: this.editEventForm.value.EventAdressPlaceName,
        City: this.editEventForm.value.EventAdressCity,
        UF: this.formatUF(this.editEventForm.value.EventAdressUF),
        CEP: this.editEventForm.value.EventAdressCEP,
        Neighborhood: this.editEventForm.value.EventAdressNeighborhood,
        AdressComplement: this.getFormNullableValue(this.editEventForm.value.EventAdressComplement),
        AdressNumber: this.editEventForm.value.EventAdressNumber
      },
      TwitterLogin: twitterLogin,
      GoogleLogin: googleLogin
    };
    return this.http.put(this.BaseURI + '/api/event/' + eventId, body);
  }

  inactiveEvent(eventId: any, adressId: any) {
    var body = {
      AdressId: adressId
    }

    return this.http.put(this.BaseURI + '/api/event/inactive/' + eventId, body);
  }

  buildEventEditForm(eventInfo: any, adressInfo: any) {
    this.editEventForm = this.fb.group({
      EventName: [eventInfo.eventName, Validators.required],
      EventDescription: [eventInfo.eventDescription],
      EventDates: this.fb.group({
        EventStartDate: [eventInfo.startDate, Validators.required],
        EventEndDate: [eventInfo.endDate, Validators.required],
      }, { validator: this.validateDates }),
      EventTicket: [eventInfo.ticketsLimit, Validators.required],
      EventAdressPublicPlace: [adressInfo.publicPlaceId, Validators.required],
      EventAdressPlaceName: [adressInfo.placeName, Validators.required],
      EventAdressCity: [adressInfo.city, Validators.required],
      EventAdressUF: [adressInfo.uf, Validators.required],
      EventAdressCEP: [adressInfo.cep, Validators.required],
      EventAdressNeighborhood: [adressInfo.neighborhood, Validators.required],
      EventAdressComplement: [adressInfo.adressComplement],
      EventAdressNumber: [adressInfo.adressNumber, Validators.required]
    });
  }

  public getEventById(id: number) {
    return this.http.get(this.BaseURI + '/api/event/' + id);
  }

  public getEventsByUserId(id) {
    return this.http.get(this.BaseURI + '/api/event/user/' + id);
  }

  public getAllActiveEvents() {
    return this.http.get(this.BaseURI + '/api/event/active/');
  }

  public getAllPublicPlaces() {
    return this.http.get(this.BaseURI + '/public-places');
  }

  public  getAllEventsButUser(id:BigInteger, tableParameters:any){
    debugger;
    var body = {
      UserId: id,
      Draw: tableParameters.draw,
      Length: tableParameters.length,
      Order: tableParameters.order[0].dir,
      Search: tableParameters.search.value,
      Start: tableParameters.start
    }
    return this.http.post(this.BaseURI + '/api/events', body);
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
    let startDate = fb.get("EventStartDate");
    let startTime = fb.get("EventStartTime");
    let endDate = fb.get("EventEndDate");
    let endTime = fb.get("EventEndTime");

    if(startDate != null && startTime != null && endDate != null && endTime != null) {
      if (startDate.errors == null || 'invalidDate' in startDate.errors) {
        if(startDate.value == endDate.value) {
          if(+startTime.value > +endTime.value) {
            startDate.setErrors({ invalidDate: true });
          } else {
            startDate.setErrors(null);
          }
        } else {
          if (fb.get('EventStartDate').value > fb.get('EventEndDate').value) {
            startDate.setErrors({ invalidDate: true });
          }
          else {
            startDate.setErrors(null);
          }
        }
      }
    }
  }

  private validPastDate(fb: FormGroup) {
    let startDate = fb.get("EventStartDate");
    let endDate = fb.get("EventEndDate");
    if(startDate != null) {
      if (startDate.errors == null || 'pastDate' in startDate.errors) {
        var startFieldDate = new Date(startDate.value);
        startFieldDate.setDate(startFieldDate.getDate() + 1);
        if (new Date(startFieldDate) < new Date()) {
          startDate.setErrors({ pastDate: true });
        }
        else {
          startDate.setErrors(null);
        }
      }
    }

    if(endDate != null) {
      if (endDate.errors == null || 'pastDate' in endDate.errors) {
        var endFieldDate = new Date(endDate.value);
        endFieldDate.setDate(endFieldDate.getDate() + 1);
        if (new Date(endFieldDate) < new Date()) {
          endDate.setErrors({ pastEndDate: true });
        }
        else {
          endDate.setErrors(null);
        }
      }
    }
  }

  formatDate(date, time) {
    if(time.length == 2) {
      return (date + "T0"+ time.substring(0,1) + ":0" + time.substring(1,2) + ":00.000Z");
    }
    return (date + "T"+ time.substring(0,2) + ":" + time.substring(2,4) + ":00.000Z");
  }

  private formatUF(uf: string) {
    return uf.toUpperCase();
  }

}
