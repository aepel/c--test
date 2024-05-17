import {Injectable} from '@angular/core';

export interface BadgeItem {
  type: string;
  value: string;
}

export interface ChildrenItems {
  state: string;
  target?: boolean;
  name: string;
  type?: string;
  children?: ChildrenItems[];
}

export interface MainMenuItems {
  state: string;
  short_label?: string;
  main_state?: string;
  target?: boolean;
  name: string;
  type: string;
  icon: string;
  badge?: BadgeItem[];
  children?: ChildrenItems[];
  permittedRoles: string[];
}

export interface Menu {
  label: string;
  main: MainMenuItems[];
}

const MENUITEMS = [
  {
    label: 'Estadísticas',
    main: [
      {
        state: 'dashboard',
        name: 'Dashboard',
        type: 'link',
        icon: 'fa fa-tachometer',
        permittedRoles: ['ADMIN','OPERADOR','LABORATORIO']
      }
    ]
  },
  {
    label: 'Operaciones',
    main: [
      {
        state: 'treatments',
        name: 'Tratamientos',
        type: 'link',
        icon: 'fa fa-heartbeat',
        permittedRoles: ['ADMIN', 'OPERADOR','LABORATORIO']
      }
    ]
  },
  {
    label: 'Parámetros',
    main: [
      {
        state: 'pathologies',
        name: 'Patologías',
        type: 'link',
        icon: 'fa fa-wheelchair',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'patients',
        name: 'Pacientes',
        type: 'link',
        icon: 'fa fa-users',
        permittedRoles: ['ADMIN', 'OPERADOR']
      },
      {
        state: 'plans',
        name: 'Programas',
        type: 'link',
        icon: 'fa fa-heart',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'nurses',
        name: 'Enfermeras/os',
        type: 'link',
        icon: 'fa fa-stethoscope',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'sales-contacts',
        name: 'Representantes',
        type: 'link',
        icon: 'fa fa-suitcase',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'doctors',
        name: 'Médicas/os',
        type: 'link',
        icon: 'fa fa-user-md',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'users',
        name: 'Usuarias/os',
        type: 'link',
        icon: 'fa fa-user',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'laboratories',
        name: 'Laboratorios',
        type: 'link',
        icon: 'fa fa-industry',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'products',
        name: 'Productos',
        type: 'link',
        icon: 'fa fa-flask',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'health-insurances',
        name: 'Seguros médicos',
        type: 'link',
        icon: 'fa fa-shield',
        permittedRoles: ['ADMIN']
      },
      {
        state: 'terms-and-conditions',
        name: 'Términos y condiciones',
        type: 'link',
        icon: 'fa fa-file-text-o',
        permittedRoles: ['ADMIN']
      }
    ]
  }
];

@Injectable()
export class MenuItems {
  getAll(): Menu[] {
    return MENUITEMS;
  }
}
