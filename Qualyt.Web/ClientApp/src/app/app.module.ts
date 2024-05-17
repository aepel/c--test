import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AvatarModule } from 'ng2-avatar';
import { AdminComponent } from './layout/admin/admin.component';
import { AuthComponent } from './layout/auth/auth.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {SharedModule} from './shared/shared.module';
import {MenuItems} from './shared/menu-items/menu-items';
import {BreadcrumbsComponent} from './layout/admin/breadcrumbs/breadcrumbs.component';
import { BasicLoginModule } from './components/auth/login/basic-login/basic-login.module';
import { AuthModule } from './components/auth/auth.module';
import { GooglePlaceModule } from "ngx-google-places-autocomplete";
import { GeocodingComponent } from './components/geocoding/geocoding.component';
import { MatFormFieldModule } from '@angular/material';
import { AuthGuard } from './auth/auth.guard';
import { ToastaModule } from 'ngx-toasta';
import { TermsAndConditionsModule } from './components/terms-and-conditions/terms-and-conditions.module';
import { NgxPermissionsModule } from 'ngx-permissions';
import { NotificationsService } from './services/notifications.service';
import { NotificationsModule } from './components/notifications/notifications.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ResetPaswwordComponent } from './components/auth/login/reset-paswword/reset-paswword.component';
import { ResetPasswordModel } from './models/reset-password.model';
import { ResetPaswwordModule } from './components/auth/login/reset-paswword/reset-paswword.module';




@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    AuthComponent,
    BreadcrumbsComponent
  ],
  imports: [
    NgxPermissionsModule.forRoot(),
    BrowserModule,
    ToastaModule.forRoot(),
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule,
    BasicLoginModule,
    AuthModule,
    TermsAndConditionsModule,
    AvatarModule.forRoot(),
    NotificationsModule,
    FormsModule,
    ReactiveFormsModule,
    ResetPaswwordModule
  ],
  providers: [
    MenuItems, AuthGuard,
    {
      provide: 'BASE_URL', useFactory: getBaseUrl
    },
    NotificationsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }



export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
