import { Component, Input } from '@angular/core';
import { errorMessage } from 'src/app/models/errormessages.model';

@Component({
    selector: 'app-error-message',
    templateUrl: './error-message.component.html',
})
export class ErrorMessageComponent {
    @Input() errorMessages: errorMessage[];
    public isVisible: boolean = false;

    constructor() {
    }

    pushearErrores(erroresBruto: any, errors: errorMessage[]) {
        console.log(erroresBruto);
        if (erroresBruto.hasOwnProperty('_body')) {
            let erroreschico = erroresBruto._body;
            erroresBruto = JSON.parse(erroreschico).errors;
        } else if (erroresBruto.hasOwnProperty('error')) {
            try {
                erroresBruto = JSON.parse(erroresBruto.error).errors;
            } catch (ex) {
                erroresBruto = erroresBruto.error.errors;

            }
        }
        
        console.log(erroresBruto);
        for (let err in erroresBruto) {
            errors.push(new errorMessage(erroresBruto[JSON.parse(err)].field, erroresBruto[JSON.parse(err)].message));

        }
    }
}