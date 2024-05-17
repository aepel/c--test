export class QueryParameters {
  constructor() {
    this.asc = true;
    this.pageNumber = 1;
    this.pageSize = 20;
    this.filterValue = "";
  }

    asc: boolean
    orderColumnName: string
    filterValue: string
    pageNumber: number
    pageSize: number
}
