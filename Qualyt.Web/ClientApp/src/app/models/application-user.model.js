"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ApplicationUser = /** @class */ (function () {
    function ApplicationUser(id, userName, fullName, email, jobTitle, phoneNumber, roles) {
        this.id = id;
        this.userName = userName;
        this.fullName = fullName;
        this.email = email;
        this.jobTitle = jobTitle;
        this.phoneNumber = phoneNumber;
        this.roles = roles;
    }
    ApplicationUser.prototype.getfriendlyName = function () {
        var name = this.fullName || this.userName;
        if (this.jobTitle)
            name = this.jobTitle + " " + name;
        return name;
    };
    return ApplicationUser;
}());
exports.ApplicationUser = ApplicationUser;
var IdentityUserRole = /** @class */ (function () {
    function IdentityUserRole() {
    }
    return IdentityUserRole;
}());
exports.IdentityUserRole = IdentityUserRole;
//# sourceMappingURL=application-user.model.js.map