import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { NgModel } from '@angular/forms';
import { $ } from 'protractor';
import { angularClassDecoratorKeys } from 'node_modules/codelyzer/util/utils';
import { EventService } from 'src/app/services/event.service';
import { json } from '@angular-devkit/core';
import { DataTableDirective } from 'node_modules/angular-datatables';
import { Subject } from 'rxjs';
import { map, subscribeOn } from 'rxjs/operators';
import { HttpClient, HttpResponse } from '@angular/common/http';
class Person {
  id: number;
  firstName: string;
  lastName: string;
}

class DataTablesResponse {
  data: any[];
  draw: number;
  recordsFiltered: number;
  recordsTotal: number;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent  implements  OnInit {

  constructor(private service: EventService, private router: Router, private toastr: ToastrService, private http: HttpClient) { }
  public dtOptions: DataTables.Settings = {};
  public userId: BigInteger
  public datatableData : any  
  dtElement: DataTableDirective;
  dtTrigger: Subject<any> = new Subject();
  ngOnInit(): void {
    debugger;
    const that = this;
    this.userId = JSON.parse(localStorage.getItem('user')).id;
    //  this.service.getAllEventsButUser(this.userId).subscribe((res:any)=>{
    //     this.datatableData = res; 
    //       });  
    
    
    var lang = {
      "decimal":        "",
      "emptyTable":     "Nenhum dado foi encontrado",
      "info":           "Mostrando _START_ até _END_ de _TOTAL_ eventos",
      "infoEmpty":      "Mostrando 0 até 0 de 0 eventos",
      "infoFiltered":   "(Filtrando de _MAX_ eventos totais)",
      "infoPostFix":    "",
      "thousands":      ",",
      "lengthMenu":     "mostrando _MENU_ eventos",
      "loadingRecords": "Carregando...",
      "processing":     "Processando...",
      "search":         "Pesquisar:",
      "zeroRecords":    "Nenhum evento encontrado",
      "paginate": {
          "first":      "Primeiro",
          "last":       "Ultimo",
          "next":       "Proximo",
          "previous":   "Anterior"
      },
      "aria": {
          "sortAscending":  ": Ativar ordenação de coluna crescente",
          "sortDescending": ": Ativar ordenação de coluna decrescente"
      }
  }
  // .http
  // .post<DataTablesResponse>(
  //   'https://angular-datatables-demo-server.herokuapp.com/',
  //   dataTablesParameters, {}
  // )
    this.dtOptions = {
      language :lang,
      pagingType: 'full_numbers',
      responsive: true,
      serverSide: true,
      processing: true,
      // ajax: (dataTablesParameters: any, callback) => {
      //   that.http.post<any>(this.service.BaseURI + '/api/events',createObject(dataTablesParameters)).subscribe(resp => {
      //       that.datatableData = resp.data;

      //       callback({
      //         recordsTotal: resp.recordsTotal,
      //         recordsFiltered:resp.recordsFiltered,
      //         data: []
      //       });
      //     });
      // },
      ajax: (dataTablesParameters: any, callback) => {
       this.service.getAllEventsButUser(this.userId,dataTablesParameters).subscribe((resp:any ) => {
         debugger;
            this.datatableData = resp.data;
            callback({
              recordsTotal: resp.recordsTotal,
              recordsFiltered:resp.recordsFiltered,
              data: []
            });
          });
      },
      columns: [ { data: 'eventName' }, { data: 'eventDescription' }]
    };
  }
  redirectEvent(id:BigInteger){
    alert(id);
  }

  ngAfterViewInit(): void {
    this.dtElement.dtInstance.then((dtInstance: any) => {
      console.info("foobar");
      dtInstance.columns.adjust()
         .responsive.recalc();
    });
  }
}
