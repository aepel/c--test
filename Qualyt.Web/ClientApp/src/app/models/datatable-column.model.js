"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DatatableColumn = /** @class */ (function () {
    function DatatableColumn(_name, _displayedName) {
        this.name = _name;
        this.displayedName = _displayedName;
    }
    return DatatableColumn;
}());
exports.DatatableColumn = DatatableColumn;
var DatatableAction = /** @class */ (function () {
    function DatatableAction(_icon, _catcher, _idParameter, _tooltip, _conditionName) {
        this.icon = _icon;
        this.catcher = _catcher;
        this.idParameter = _idParameter;
        this.tooltip = _tooltip;
        this.conditionName = _conditionName;
    }
    return DatatableAction;
}());
exports.DatatableAction = DatatableAction;
var KeyValue = /** @class */ (function () {
    function KeyValue(_key, _value) {
        this.key = _key;
        this.value = _value;
    }
    return KeyValue;
}());
exports.KeyValue = KeyValue;
//# sourceMappingURL=datatable-column.model.js.map