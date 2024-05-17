import { Component, OnInit, Input, ViewChild, OnChanges } from '@angular/core';
import { Field, OptionsField, Option } from '../../../models/field.model';
import { FieldType, EnumValDesc } from '../../../models/enums.model';
import { MatTableDataSource, MatSort } from '@angular/material';

@Component({
  selector: 'app-fields-manager',
  templateUrl: './fields-manager.component.html',
  styleUrls: ['./fields-manager.component.scss']
})
export class FieldsManagerComponent implements OnInit, OnChanges {
  options: string;
  @Input() campos: Field[];
  TiposCampo;
  FieldType = FieldType;
  campoNuevo: Field;
  nextId: number = 0;
  posiblesParents: Field[] = [];
  dataSource: MatTableDataSource<Field>;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns = ['nombre', 'parentId', 'tipo', 'minimo', 'maximo', 'obligatorio', 'orden', 'acciones'];

  constructor() {
  }

  ngOnChanges() {
    this.campos = this.campos ? this.campos : [];
    if (this.campos.length > 0) {
      for (let campo of this.campos) {
        this.nextId = this.nextId < campo.id ? campo.id : this.nextId;
      }
    }
    this.setearParents();
    this.dataSource = new MatTableDataSource(this.campos);
  }

  ngOnInit(): void {
    this.TiposCampo = EnumValDesc(FieldType);
    this.campoNuevo = new Field();
  }

  setearParents() {
    if (this.campos.length > 0) {
      for (let campo of this.campos) {
        if (campo.type == FieldType.checkbox && !this.posiblesParents.some(x => x.id == campo.id))
          this.posiblesParents.push(campo);
        if (campo.parentId)
          campo.parentName = this.campos.find(x => x.id == campo.parentId) ? this.campos.find(x => x.id == campo.parentId).name:undefined;
      }
    }
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  onSubmit() {
    this.campoNuevo.id = ++this.nextId;
    if (this.campoNuevo.type == FieldType.simpleSelect) {
      var campo = this.campoNuevo as OptionsField;
      var opts = this.options.split(",");
      campo.options = [];
      for (let o of opts) {
        campo.options.push(new Option(o));
      }
      this.campos.push(campo);
    }
    else
      this.campos.push(this.campoNuevo);
    this.campoNuevo = new Field();
    this.options='';
    this.setearParents();
    this.dataSource = new MatTableDataSource(this.campos);
  }

  subirCampo(id: number) {
    let index = this.campos.findIndex(x => x.id == id);
    let campoAux = this.campos[index - 1];
    this.campos[index - 1] = this.campos[index];
    this.campos[index] = campoAux;
    this.dataSource = new MatTableDataSource(this.campos);
  }

  bajarCampo(id: number) {
    let index = this.campos.findIndex(x => x.id == id);
    let campoAux = this.campos[index + 1];
    this.campos[index + 1] = this.campos[index];
    this.campos[index] = campoAux;
    this.dataSource = new MatTableDataSource(this.campos);
  }

  removeRow(i: number) {
    var ans = confirm("¿Está seguro que desea borrar a este campo? Tenga en cuenta que los campos hijo también serán eliminados!");
    if (ans) {
      for (let campo of this.campos) {
        if (campo.parentId == i)
          this.removeRow(campo.id);
      }
      let indexParents = this.posiblesParents.findIndex(x => x.id == i);
      if (indexParents != -1)
        this.posiblesParents.splice(indexParents, 1);
      let index = this.campos.findIndex(x => x.id == i);
      this.campos.splice(index, 1);
      this.dataSource = new MatTableDataSource(this.campos);
    }
  }
}
