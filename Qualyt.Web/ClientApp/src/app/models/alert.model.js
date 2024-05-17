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
var Alert = /** @class */ (function () {
    function Alert() {
    }
    return Alert;
}());
exports.Alert = Alert;
var PatientWithoutConsentAlert = /** @class */ (function (_super) {
    __extends(PatientWithoutConsentAlert, _super);
    function PatientWithoutConsentAlert() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return PatientWithoutConsentAlert;
}(Alert));
exports.PatientWithoutConsentAlert = PatientWithoutConsentAlert;
var TodayControlAlert = /** @class */ (function (_super) {
    __extends(TodayControlAlert, _super);
    function TodayControlAlert() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return TodayControlAlert;
}(Alert));
exports.TodayControlAlert = TodayControlAlert;
//# sourceMappingURL=alert.model.js.map