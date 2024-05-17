import { Component, OnInit, Input, ViewChild, Output, EventEmitter, ElementRef, AfterViewInit } from '@angular/core';
import { QueryParameters } from '../../../models/query-parameters.model';
import { DatatableColumn, DatatableAction, DatatableColor, KeyValue } from '../../../models/datatable-column.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { AlertService } from '../../../services/alert.service';
import { Observable } from 'rxjs';
import { DatatableResponse } from 'src/app/models/datatable-response.model';

@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss']
})
export class DatatableComponent implements OnInit, AfterViewInit {

  @Input() service: any; //Servicio de la entidad a listar
  @Input() columns: DatatableColumn[]; //Columnas a mostrar
  @Input() actions: DatatableAction[]; //Acciones a permitir
  @Input() colors: DatatableColor[]; //Colores de fila según condiciones. Solo la primer condición se aplicará
  @Input() actionsRoute: string; //Nombre de la ruta del abm a listar
  @Input() editProperty: string; //Propiedad de la entidad listada (bool) que permita saber si es editable o no
  @Input() deleteProperty: string; //Propiedad de la entidad listada (bool) que permita saber si es eliminable o no
  @Input() delete: boolean; //Permitir eliminación de entidades
  @Input() edit: boolean; //Permitir edición de entidades
  @Input() inheritParamsOnCreate: boolean; //Enviar parametros de la url a página de create
  @Input() paramsOnListService: KeyValue[]; //Enviar parametros de la url a página de create
  @Input() notCreate: boolean;
  @Input() backButtonRoute: string; 
  @Output() deleted: EventEmitter<number> = new EventEmitter(); //Evento de eliminación







  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[];
  dataSource: MatTableDataSource<any>;
  queryParameters: QueryParameters = new QueryParameters();
  @ViewChild(MatSort) sort: MatSort;
  self: any;
  @ViewChild('input') text: ElementRef;

  constructor(public router: Router, public alertService: AlertService) {

  }

  remove(id: number) {
    this.deleted.emit(id);
  }

  ngOnInit() {
    
    this.queryParameters.pageNumber = 1;
    this.queryParameters.pageSize = 10;
    this.setupPaginator();
    this.displayedColumns = this.columns.map(x => x.name);
    this.displayedColumns.push("actions");
    this.self = this;
    this.applyFilter("").subscribe(
      x => {
        let list = this.completeList(x.list, x.totalCount, this.queryParameters.pageSize * (this.queryParameters.pageNumber - 1));
        this.dataSource = new MatTableDataSource(list);
        this.setupSort();
        this.paginator.length = list.length;
        this.dataSource.paginator = this.paginator;
      });
  }

  ngAfterViewInit(): void {
    let text$ = Observable.fromEvent(this.text.nativeElement, 'input')
      .do(()=>console.log(""))
      .debounceTime(750)
      .distinctUntilChanged()
      .switchMap(x =>
      {
        return this.applyFilter(this.text.nativeElement.value);
      })
      .subscribe(
      x => {
          let list = this.completeList(x.list, x.totalCount, this.queryParameters.pageSize * (this.queryParameters.pageNumber - 1));
          this.dataSource = new MatTableDataSource(list);
          this.setupSort();
          this.paginator.length = list.length;
          this.dataSource.paginator = this.paginator;
        });
  }

  setupSort() {
    this.dataSource.sortingDataAccessor = (data: any, sortHeaderId) => {
      var arr = sortHeaderId.split(".");
      while (arr.length && (data = data[arr.shift()])) {
        if (!data)
          return this.extremeValue();
      };
      return data.toString().toLocaleLowerCase();
    };
  }

  setColor(row) {
    if(this.colors)
      for (let color of this.colors)
        if (row[color.conditionName])
          return color.hexaColor
    return '';
  }

  extremeValue() {
    if (this.sort.direction == "asc") {
      return Number.MAX_SAFE_INTEGER;
    }
    else {
      return Number.MIN_SAFE_INTEGER;
    }
  }

  update() {
    this.applyFilter(this.text.nativeElement.value)
      .subscribe(
        x => {
          let list = this.completeList(x.list, x.totalCount, this.queryParameters.pageSize * (this.queryParameters.pageNumber - 1));
          this.dataSource = new MatTableDataSource(list);
          this.setupSort();
          this.paginator.length = list.length;
          this.dataSource.paginator = this.paginator;
          //this.dataSource.sort = this.sort;
        });;
  }

  applyFilter(filterValue: string): Observable<DatatableResponse> {
    this.queryParameters.filterValue = filterValue;
    return this.updateDatatable();
  }

  setupPaginator() {
    this.paginator.pageSizeOptions = [5, 10, 25, 50];
    this.paginator.pageSize = this.queryParameters.pageSize;
    this.paginator._intl.itemsPerPageLabel = "Elementos por página";
    this.paginator._intl.previousPageLabel = "Página anterior";
    this.paginator._intl.nextPageLabel = "Página siguiente";
    this.paginator._intl.firstPageLabel = "Primera página";
    this.paginator._intl.lastPageLabel = "Última página";
    this.paginator._intl.getRangeLabel = (page, size, length) => `${page * size + 1} - ${Math.min((page + 1) * size, length)} de ${length}`;
  }

  public updateDatatable() {
    this.queryParameters.pageNumber = this.paginator.pageIndex + 1;
    this.queryParameters.pageSize = this.paginator.pageSize;
    this.queryParameters.asc = this.sort.direction != "desc";
    this.queryParameters.orderColumnName = this.sort.active;
    if (this.paramsOnListService) {
      return this.service.list(this.queryParameters, this.paramsOnListService);
    }
    else {
      return this.service.list(this.queryParameters);
    }
  }

  completeList(list: any[], count: number, skipped: number): any[]{
    var _list=[];
    for (let i = 0; i < skipped; i++)
      _list.push({});
    for (let i = 0; i<list.length; i++)
      _list.push(list[i]);
    for (let i = list.length + skipped; i < count; i++)
      _list.push({});
    return _list;
  }
}
