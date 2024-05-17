import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationsComponent } from './notifications/notifications.component';
import { RouterModule } from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule
  ],
  declarations: [NotificationsComponent],
  exports: [NotificationsComponent]
})
export class NotificationsModule { }
