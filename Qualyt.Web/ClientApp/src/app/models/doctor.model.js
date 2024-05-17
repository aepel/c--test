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
var location_model_1 = require("./location.model");
var application_user_model_1 = require("./application-user.model");
var Doctor = /** @class */ (function (_super) {
    __extends(Doctor, _super);
    function Doctor() {
        var _this = _super.call(this) || this;
        _this.location = new location_model_1.Location();
        return _this;
    }
    return Doctor;
}(application_user_model_1.ApplicationUser));
exports.Doctor = Doctor;
//# sourceMappingURL=doctor.model.js.map