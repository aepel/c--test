import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
//import { AuthenticationService } from "app/services/authentication.service";

@Injectable()
export class RoutesAvailable {
    private readonly ROUTESAVAILABLE = [
        { "route": "home", "permittedRoles": ["ADMIN", "MEDICO", "LABORATORIO", "APM"] },
        { "route": "redirectTerminos", "permittedRoles": ["ADMIN", "MEDICO", "LABORATORIO", "APM"] },

        { "route": "fetch-medicos", "permittedRoles": ["ADMIN", "APM"] },
        { "route": "medico-get", "permittedRoles": ["ADMIN"] },

        { "route": "fetch-apms", "permittedRoles": ["ADMIN"] },
        { "route": "apm-get", "permittedRoles": ["ADMIN"] },

        { "route": "fetch-pacientes", "permittedRoles": ["ADMIN", "MEDICO"] },
        { "route": 'paciente-get', "permittedRoles": ["ADMIN", "MEDICO"]  },

        { "route": "fetch-tratamientos", "permittedRoles": ["ADMIN", "MEDICO", "LABORATORIO", "APM"] },
        { "route": 'tratamiento-get', "permittedRoles": ["ADMIN", "MEDICO"] },
        { "route": 'details-tratamiento', "permittedRoles": ["ADMIN", "MEDICO","LABORATORIO","APM"] },
        { "route": "fetch-visitas", "permittedRoles": ["ADMIN", "MEDICO", "LABORATORIO", "APM"] },
        { "route": 'visita-get', "permittedRoles": ["ADMIN", "MEDICO"] },
        { "route": "details-visita", "permittedRoles": ["ADMIN", "MEDICO","APM","LABORATORIO"] },
        { "route": "isLaboratorio", "permittedRoles": ["LABORATORIO"] },

        

        { "route": "fetch-patologias", "permittedRoles": ["ADMIN"] },
        { "route": "patologia-get", "permittedRoles": ["ADMIN"] },
        { "route": "fetch-laboratorios", "permittedRoles": ["ADMIN"] },
        { "route": "laboratorio-get", "permittedRoles": ["ADMIN"] },
        { "route": "fetch-farmacos", "permittedRoles": ["ADMIN"] },
        { "route": "farmaco-get", "permittedRoles": ["ADMIN"] },
        { "route": "fetch-users", "permittedRoles": ["ADMIN"] },
        { "route": "users-get", "permittedRoles": ["ADMIN"] },
        { "route": "fetch-terminosycondiciones", "permittedRoles": ["ADMIN"] },
        { "route": "terminosycondiciones-get", "permittedRoles": ["ADMIN"] },
        { "route": "verdatospaciente", "permittedRoles": ["ADMIN", "MEDICO"] },
        { "route": "verAccionesTratamiento", "permittedRoles": ["ADMIN", "MEDICO"] },

        { "route": "verEstadisticasGlobales", "permittedRoles": ["ADMIN", "LABORATORIO"] },
        { "route": "verEstadisticasAPM", "permittedRoles": ["ADMIN","APM"] },
        { "route": "desactivarMedicos", "permittedRoles": ["ADMIN","APM"] },
        { "route": "desactivarVisitadores", "permittedRoles": ["ADMIN"] },

        { "route": "farmacosprevios", "permittedRoles": ["ADMIN"] },
        { "route": "motivosdefinalizacionprevios", "permittedRoles": ["ADMIN"] },

        { "route": "fetch-changePassword", "permittedRoles": ["ADMIN", "MEDICO", "APM", "LABORATORIO"]  },
        { "route": "descargarExcel", "permittedRoles": ["ADMIN"]  },
        { "route": "registro-paciente", "permittedRoles": ["ADMIN","MEDICO"]  },
        { "route": "alertas", "permittedRoles": ["MEDICO","APM"] },
        { "route": "ver-alertas", "permittedRoles": ["MEDICO"] },
        { "route": "verMedicoAlertas", "permittedRoles": ["APM"] },
        
        
          
];
  private userRoles: Set<string>;
    // do your remember the step 1 ? it is used here
  //  constructor(private currentUserService: AuthenticationService) {
  //}
  // returns a boolean observable
//    public checkAuthorization(path: any): boolean {
//        // we are loading the roles only once
        

//        if (!this.userRoles && this.currentUserService.getCurrentUser()) {
//          this.userRoles = new Set(this.currentUserService.getCurrentUser().roles);
//        }
//        let resultado = this.doCheckAuthorization(path);
//        return resultado;
      
//  }

//    public isInRole(role: string): boolean {
//        try {
//            return this.userRoles.has(role);

//        } catch (ex) {
//            return false;
//        }

//    }
//    private doCheckAuthorization(path: string): boolean {
        
//    if (path.length) {
//        const entry = this.findEntry(path);
//        if (entry && entry.permittedRoles
//            && this.userRoles && this.userRoles.size) {
//          let permitidos = entry.permittedRoles;
//          return permitidos
//        .some(permittedRole => this.userRoles.has(permittedRole));
//      }
//      return false;
//    }
//    return false;
//  }
///**
// * Recursively find workflow-map entry based on the path strings
// */
//private findEntry(keys: string, index = 0) {

//    let idx = this.ROUTESAVAILABLE.find(item => {
//        return item.route == keys
//    })
//    return idx;
    
    
//  }

}
