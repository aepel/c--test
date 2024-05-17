"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var location_model_1 = require("./location.model");
var clinical_history_model_1 = require("./clinical-history.model");
var Patient = /** @class */ (function () {
    function Patient() {
        this.location = new location_model_1.Location();
        this.clinicalHistory = new clinical_history_model_1.ClinicalHistory();
    }
    Object.defineProperty(Patient.prototype, "addressName", {
        get: function () {
            return this.location.address;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Patient.prototype, "nameActive", {
        get: function () {
            return this.active ? "Si" : "No";
        },
        enumerable: true,
        configurable: true
    });
    return Patient;
}());
exports.Patient = Patient;
//# sourceMappingURL=patient.model.js.map