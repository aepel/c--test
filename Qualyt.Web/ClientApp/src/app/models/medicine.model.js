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
var product_model_1 = require("./product.model");
var Medicine = /** @class */ (function (_super) {
    __extends(Medicine, _super);
    function Medicine() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Medicine;
}(product_model_1.Product));
exports.Medicine = Medicine;
//# sourceMappingURL=medicine.model.js.map