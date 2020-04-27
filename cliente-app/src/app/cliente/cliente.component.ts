import { Component, OnInit } from '@angular/core';
import { ClienteApiService } from 'src/service/cliente-api.service';
import { Cliente } from 'src/model/cliente';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})

export class ClienteComponent implements OnInit {

  displayedColumns: string[] = [ 'nome', 'endereco', 'bairro', 'cep', 'cidade', 'estado', 'email', 'id'];
  dataSource: Cliente[];
  
  constructor(private _api: ClienteApiService) { }

  ngOnInit() {
    this._api.getClientes()
      .subscribe(res => {
        this.dataSource = res;
        console.log(this.dataSource);
       // this.isLoadingResults = false;
      }, err => {
        console.log(err);
      //  this.isLoadingResults = false;
      });
  }
}
