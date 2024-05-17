declare var jQuery: any;
declare var $: any;

import 'pivottable/dist/pivot.js';
import 'pivottable/dist/plotly_renderers.js';
import 'pivottable/dist/pivot.css';

import { ElementRef, Component, OnInit, Input, HostListener } from '@angular/core';
import { NgxRolesService } from 'ngx-permissions';
import { PivotTableData } from '../../../models/pivot-table-data.model';

@Component({
  selector: 'app-pivot-table',
  templateUrl: './pivot-table.component.html',
  styleUrls: ['./pivot-table.component.scss']
})
export class PivotTableComponent implements OnInit {

  @Input() data: PivotTableData[];
  exportButton: boolean;
  dataTable = [];
  isLaboratory:boolean;
  tpl;
  frFmtInt;
  targetElement;
  frFmt;
  defaultCols;
  defaultRows;
  defaultAggregator;
  defaultRenderer;

  uri = 'data:application/vnd.ms-excel;base64,'
  template = '<!DOCTYPE html><html lang="es" xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/1999/xhtml"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/html; charset=utf-8"/></head><body><table>{table}</table></body></html>'
  base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
  format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) };
  removeDiacritics = require('diacritics').remove;

  constructor(private el: ElementRef,
    private rolesService: NgxRolesService) { }

  @HostListener('window:resize', ['$event'])
    sizeChange(event) {
  }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    for (let elem of this.data) {
      this.dataTable.push(
        {
          Representante: elem.salesContactFullName,
          Medico: elem.doctorFullName,
          Paciente: elem.patientFullName,
          Estado_Paciente: elem.patientState,
          Dirección: elem.attentionAddress,
          Lugar: elem.attentionPlaceName,
          Programa: elem.planName,
          Laboratorio: elem.laboratoryName,
          País: elem.countryName,
          Enfermera: elem.nurseFullName,
          Tratamiento: elem.treatmentCode,
          Estado_Tratamiento: elem.treatmentState,
          Producto: elem.productName,
          Patologia: elem.pathologyName,
          Seguimiento: elem.control
        }
      );
    }
    this.buildPivot();
  }

  private buildPivot() {
    if (!this.el ||
      !this.el.nativeElement ||
      !this.el.nativeElement.children) {
      console.log('cant build without element');
      return;
    }

    var container = this.el.nativeElement;
    var inst = jQuery(container);

    this.targetElement = inst.find('#pivot');

    if (!this.targetElement) {
      console.log('cant find the pivot element');
      return;
    }

    while (this.targetElement.firstChild) {
      this.targetElement.removeChild(this.targetElement.firstChild);
    }
    var nf = $.pivotUtilities.numberFormat;
    this.tpl = $.pivotUtilities.aggregatorTemplates;
    this.frFmt = nf({
      thousandsSep: " ",
      decimalSep: ","
    });
    this.frFmtInt = nf({
      digitsAfterDecimal: 0,
      thousandsSep: " ",
      decimalSep: ","
    });
    var frFmtPct = nf({
      digitsAfterDecimal: 1,
      scaler: 100,
      suffix: "%",
      thousandsSep: " ",
      decimalSep: ","
    });


    
    this.rolesService.hasOnlyRoles("LABORATORIO").then(x => {
        if(x){
          this.defaultCols=[
            "Programa",
            "Paciente",
            "Medico",
            "Tratamiento",
            "Estado_Tratamiento",
            "Seguimiento"
          ];
          this.defaultRows=[];
          this.defaultAggregator="Cuenta";
          this.defaultRenderer="Tabla";
        }
        else{
          this.defaultCols=[];
          this.defaultRows=[
            "Paciente"
          ];
          this.defaultAggregator="Seguimientos";
          this.defaultRenderer="Barras H.";
        }
        this.initPivot();
    });   
  }

  initPivot(){
    var self = this;
    this.targetElement.pivotUI(this.dataTable,
      {
        cols: self.defaultCols,
        rows: self.defaultRows,
        
        hiddenAttributes:
        [
        ],
        aggregatorName: self.defaultAggregator,
        rendererName: self.defaultRenderer,
        onRefresh: function (config) {
          self.exportButton = config.rendererName.includes("Tabla") || config.rendererName.includes("Mapa");
        },
        localeStrings: {
          renderError: "Ocurrió un error durante la interpretación de la tabla dinámica.",
          computeError: "Ocurrió un error durante el cálculo de la tabla dinámica.",
          uiRenderError: "Ocurrió un error durante el dibujado de la tabla dinámica.",
          selectAll: "Seleccionar todo",
          selectNone: "Deseleccionar todo",
          tooMany: "(demasiados valores)",
          filterResults: "Filtrar resultados",
          totals: "Totales",
          vs: "vs",
          by: "por",
          apply: "Aplicar",
          cancel: "Cancelar"
        },
        aggregators: {
          //"Cuenta": self.tpl.countUnique(self.frFmtInt),
          "Cuenta": function () { return self.countUnique(self.frFmtInt)(["Paciente"]); },
          "Suma": self.tpl.sum(self.frFmt),
          "Mínimo": self.tpl.min(self.frFmt),
          "Máximo": self.tpl.max(self.frFmt),
          "Seguimientos": function () { return self.countUnique(self.frFmtInt)(["Seguimiento"]); }
        },
        renderers: {
          "Tabla": $.pivotUtilities.renderers["Table"],
          "Barras H.": $.pivotUtilities.plotly_renderers["Horizontal Bar Chart"],
          "Barras Ap. H.": $.pivotUtilities.plotly_renderers["Horizontal Stacked Bar Chart"],
          "Barras V.": $.pivotUtilities.plotly_renderers["Bar Chart"],
          "Barras Ap. V.": $.pivotUtilities.plotly_renderers["Stacked Bar Chart"],
          "Lineas": $.pivotUtilities.plotly_renderers["Line Chart"],
          "Áreas": $.pivotUtilities.plotly_renderers["Area Chart"],
          "Torta": $.pivotUtilities.plotly_renderers["Multiple Pie Chart"]
        },
        rendererOptions:{
          plotly:{
            width: 600
          }
        }
      });
  }

  saveAs(uri, filename) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
      link.href = uri;
      link.download = filename;
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    } else {
      window.open(uri);
    }
  }

  exportPivotToExcel(pivotBlockId, name) {
    console.log(this.removeDiacritics("Iлｔèｒｎåｔïｏｎɑｌíƶａｔï߀ԉ"));
    var tbl = $('#' + pivotBlockId).find('.pvtTable');
    var ctx = { worksheet: name || 'Worksheet', table: this.removeDiacritics(tbl.html()) };
    var format = this.format(this.removeDiacritics(this.template), ctx)
    console.log(format);
    var uriFile = this.uri + this.base64(format);
    this.saveAs(uriFile, name + '.xls');
  }

  countUnique(f) {
    return this.uniques((function (x) {
      return x.length;
    }), f);
  }

  uniques(fn, formatter) {
    return function (arg) {
      var attr;
      attr = arg[0];
      return function (data, rowKey, colKey) {
        return {
          uniq: [],
          push: function (record) {
            var ref;
            if (ref = record[attr], this.uniq.indexOf(ref) < 0) {
              if(record[attr]!='')
                return this.uniq.push(record[attr]);
            }
          },
          value: function () {
            return fn(this.uniq);
          },
          format: formatter,
          numInputs: attr != null ? 0 : 1
        };
      };
    };
  }

}
