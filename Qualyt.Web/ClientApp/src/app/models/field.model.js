"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var Field = /** @class */ (function () {
    function Field() {
    }
    return Field;
}());
exports.Field = Field;
var BinaryField = /** @class */ (function (_super) {
    __extends(BinaryField, _super);
    function BinaryField() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return BinaryField;
}(Field));
exports.BinaryField = BinaryField;
var DateField = /** @class */ (function (_super) {
    __extends(DateField, _super);
    function DateField() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return DateField;
}(Field));
exports.DateField = DateField;
var TextField = /** @class */ (function (_super) {
    __extends(TextField, _super);
    function TextField() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return TextField;
}(Field));
exports.TextField = TextField;
var NumericField = /** @class */ (function (_super) {
    __extends(NumericField, _super);
    function NumericField() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return NumericField;
}(Field));
exports.NumericField = NumericField;
var OptionsField = /** @class */ (function (_super) {
    __extends(OptionsField, _super);
    function OptionsField() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return OptionsField;
}(Field));
exports.OptionsField = OptionsField;
var Option = /** @class */ (function () {
    function Option(_text) {
        this.text = _text;
    }
    return Option;
}());
exports.Option = Option;
//# sourceMappingURL=field.model.js.map