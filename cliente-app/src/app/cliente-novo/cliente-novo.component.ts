import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ClienteApiService } from 'src/service/cliente-api.service';

@Component({
  selector: 'app-cliente-novo',
  templateUrl: './cliente-novo.component.html',
  styleUrls: ['./cliente-novo.component.scss']
})
export class ClienteNovoComponent implements OnInit {

  clienteForm: FormGroup;
  isLoadingResults = false;

  constructor(private router: Router, private api: ClienteApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.clienteForm = this.formBuilder.group({
      'nome': [null, Validators.required],
      'endereco': [null, [Validators.required, Validators.minLength(4)]],
      'bairro': [null, Validators.required],
      'cep': [null, Validators.required],
      'cidade': [null, Validators.required],
      'estado': [null, Validators.required],
      'email': [null, Validators.required],
    });
  }

  addCliente(form: NgForm) {
    this.isLoadingResults = true;
    this.api.addCliente(form)
      .subscribe(res => {
          const id = res['id'];
          this.isLoadingResults = false;
          this.router.navigate(['/cliente-detalhe', id]);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        });
      }
}
