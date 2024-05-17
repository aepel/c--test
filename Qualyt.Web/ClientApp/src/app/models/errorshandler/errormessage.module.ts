import { NgModule } from "@angular/core";

import { CommonModule } from "@angular/common";
import { MatFormFieldModule, MatExpansionModule, MatGridListModule, MatListModule, MatTableModule, MatPaginatorModule } from "@angular/material";
import {ErrorMessageComponent} from "src/app/models/errorshandler/error-message.component";
@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        ErrorMessageComponent,
    ],
    exports: [
        ErrorMessageComponent
    ]
})
export class ErrorMessageModule { }
