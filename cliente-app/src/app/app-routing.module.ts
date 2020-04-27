import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';
import { ClienteDetalheComponent } from './cliente-detalhe/cliente-detalhe.component';
import { ClienteNovoComponent } from './cliente-novo/cliente-novo.component';
import { ClienteEditarComponent } from './cliente-editar/cliente-editar.component';

const routes: Routes = [
  {
    path: 'cliente',
    component: ClienteComponent,
    data: { title: 'Lista de Cliente' }
  },
  {
    path: 'cliente-detalhe/:id',
    component: ClienteDetalheComponent,
    data: { title: 'Detalhe do Cliente' }
  },
  {
    path: 'cliente-novo',
    component: ClienteNovoComponent,
    data: { title: 'Adicionar Cliente' }
  },
  {
    path: 'cliente-editar/:id',
    component: ClienteEditarComponent,
    data: { title: 'Editar o Cliente' }
  },
  { path: '',
    redirectTo: '/clientes',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
