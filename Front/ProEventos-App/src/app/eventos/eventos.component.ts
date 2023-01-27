import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {

  public eventos: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {

    this.http.get('http://localhost:5093/api/Evento').subscribe(
      response =>
      this.eventos = response,
      error => console.log(error)

    );

    // this.eventos =  [
    //   {
    //     tema: '.Net',
    //     local: 'Rio de Janeiro'
    //   },
    //   {
    //     tema: 'Angular',
    //     local: 'São Paulo'
    //   },
    //   {
    //     tema: 'Angular 11',
    //     local: 'São Paulo'
    //   }

    //   ]
  }
}
