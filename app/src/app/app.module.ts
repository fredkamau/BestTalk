import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { AccountTypeComponent } from './account-type/account-type.component';
import { HttpClientModule } from '@angular/common/http';
import { NewAccountComponent } from './new-account/new-account.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AccountTypesService } from './account-type/account-types.service';
import { HeaderComponent } from './header/header.component';
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    AccountTypeComponent,
    NewAccountComponent,
    HeaderComponent,
    LayoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [AccountTypesService],
  bootstrap: [AppComponent],
})
export class AppModule {}
