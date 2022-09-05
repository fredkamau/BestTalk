import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account/account.component';
import { LayoutComponent } from './layout/layout.component';
import { NewAccountComponent } from './new-account/new-account.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'layout' },
  { path: 'new-account', component: NewAccountComponent },
  { path: 'layout', component: LayoutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
