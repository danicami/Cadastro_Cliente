import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ClienteApiService } from 'src/service/cliente-api.service';

@Component({
  selector: 'app-cliente-editar',
  templateUrl: './cliente-editar.component.html',
  styleUrls: ['./cliente-editar.component.scss']
})
export class ClienteEditarComponent implements OnInit {
  id: number = 0;
  clienteForm: FormGroup;
  nome: String = '';
  endereco: String = '';
  bairro: String = '';
  cep: String;
  cidade: String = '';
  estado: String = '';
  email:String = '';
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ClienteApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.getCliente(this.route.snapshot.params['id']);
    this.clienteForm = this.formBuilder.group({
   'nome' : [null, Validators.required],
   'endereco' : [null, Validators.required],
   'bairro' : [null, Validators.required],
   'cep' : [null, Validators.required],
   'cidade' : [null, Validators.required],
   'estado' : [null, Validators.required],
   'email' : [null, Validators.required],
  });
  }

  getCliente(id) {
    this.api.getCliente(id).subscribe(data => {
      this.id = data.id;
      this.clienteForm.setValue({
        nome: data.nome,
        endereco: data.endereco,
        bairro: data.bairro,
        cep: data.cep,
        cidade: data.cidade,
        estado: data.estado,
        email: data.email,
      });
    });
  }
  
  updateCliente(form: NgForm) {
    this.isLoadingResults = true;
    this.api.updateCliente(this.id, form)
      .subscribe(res => {
          this.isLoadingResults = false;
          this.router.navigate(['/cliente-detalhe/' + this.id]);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        }
      );
  }

}
