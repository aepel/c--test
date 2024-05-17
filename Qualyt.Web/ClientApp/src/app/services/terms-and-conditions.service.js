"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/http");
var BaseService = /** @class */ (function () {
    function BaseService(_http, client, actionUrl, authService, ViewBagsUrl) {
        this._http = _http;
        this.client = client;
        this.actionUrl = actionUrl;
        this.authService = authService;
        this.ViewBagsUrl = ViewBagsUrl;
    }
    BaseService.prototype.getAll = function () {
        var head = this.authService.getRequestHTTPHeaders();
        console.log(this.actionUrl + "get");
        return this.client.get(this.actionUrl + "get", { headers: head });
    };
    BaseService.prototype.list = function () {
        var head = this.authService.getRequestHTTPHeaders();
        console.log(this.actionUrl + "list");
        return this.client.get(this.actionUrl + "list", { headers: head });
    };
    BaseService.prototype.getOne = function (id) {
        var head = new http_1.RequestOptions({ headers: this.authService.getRequestHeaders() });
        console.log(id);
        console.log(this.actionUrl + 'get/' + id);
        return this._http.get(this.actionUrl + 'get/' + id, head);
    };
    BaseService.prototype.getById = function (id) {
        var head = new http_1.RequestOptions({ headers: this.authService.getRequestHeaders() });
        return this._http.get(this.actionUrl + 'get/' + id, head);
    };
    BaseService.prototype.update = function (objeto) {
        var head = this.authService.getRequestHTTPHeaders();
        return this.client.put(this.actionUrl + 'put', objeto, { headers: head }); //.map(resp => resp.json() as T);
    };
    BaseService.prototype.insert = function (objeto) {
        var head = this.authService.getRequestHTTPHeaders();
        return this.client.post(this.actionUrl + 'post', objeto, { headers: head }); //.map(resp => resp.json() as T);
    };
    BaseService.prototype.delete = function (id) {
        var head = this.authService.getRequestHTTPHeaders();
        return this.client.delete(this.actionUrl + 'delete/' + id, { headers: head }); //.map(resp => resp.json() as T);
    };
    BaseService.prototype.loadViewBags = function () {
        return this.client.get(this.actionUrl + this.ViewBagsUrl);
        // .catch(this.errorHandler);
    };
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=base.service.js.map