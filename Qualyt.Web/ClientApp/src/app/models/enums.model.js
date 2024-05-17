"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function EnumDescription(e, id) {
    return e[e[id].toString() + "Description"];
}
function EnumValues(e) {
    var array = [];
    for (var enumMember in e) {
        var isValueProperty = parseInt(enumMember, 10) >= 0;
        if (isValueProperty) {
            array.push(enumMember);
        }
    }
    return array;
}
function EnumValDesc(e) {
    var array = EnumValues(e);
    var rArray = [];
    for (var _i = 0, array_1 = array; _i < array_1.length; _i++) {
        var item = array_1[_i];
        rArray.push({ value: parseInt(item), text: EnumDescription(e, parseInt(item)) });
    }
    return rArray;
}
exports.EnumValDesc = EnumValDesc;
var Gender;
(function (Gender) {
    Gender[Gender["male"] = 0] = "male";
    Gender["maleDescription"] = "Masculino";
    Gender[Gender["female"] = 1] = "female";
    Gender["femaleDescription"] = "Femenino";
})(Gender = exports.Gender || (exports.Gender = {}));
var MaritalStatus;
(function (MaritalStatus) {
    MaritalStatus[MaritalStatus["single"] = 0] = "single";
    MaritalStatus["singleDescription"] = "Soltera/o";
    MaritalStatus[MaritalStatus["divorced"] = 1] = "divorced";
    MaritalStatus["divorcedDescription"] = "Divorciada/o";
    MaritalStatus[MaritalStatus["widowed"] = 2] = "widowed";
    MaritalStatus["widowedDescription"] = "Viuda/o";
    MaritalStatus[MaritalStatus["separated"] = 3] = "separated";
    MaritalStatus["separatedDescription"] = "Separada/o";
    MaritalStatus[MaritalStatus["married"] = 4] = "married";
    MaritalStatus["marriedDescription"] = "Casada/o";
})(MaritalStatus = exports.MaritalStatus || (exports.MaritalStatus = {}));
var ContactMethod;
(function (ContactMethod) {
    ContactMethod[ContactMethod["mail"] = 0] = "mail";
    ContactMethod["mailDescription"] = "Mail";
    ContactMethod[ContactMethod["phone"] = 1] = "phone";
    ContactMethod["phoneDescription"] = "Tel\u00E9fono";
})(ContactMethod = exports.ContactMethod || (exports.ContactMethod = {}));
var FieldType;
(function (FieldType) {
    FieldType[FieldType["checkbox"] = 0] = "checkbox";
    FieldType["checkboxDescription"] = "Checkbox";
    //yesOrNoSelect=1,
    FieldType[FieldType["text"] = 2] = "text";
    FieldType["textDescription"] = "Texto";
    FieldType[FieldType["numeric"] = 3] = "numeric";
    FieldType["numericDescription"] = "Num\u00E9rico";
    FieldType[FieldType["date"] = 4] = "date";
    FieldType["dateDescription"] = "Fecha";
    //multipleSelect=5,
    //roundButton=6,
    FieldType[FieldType["simpleSelect"] = 7] = "simpleSelect";
    FieldType["simpleSelectDescription"] = "Listado con opci\u00F3n simple";
})(FieldType = exports.FieldType || (exports.FieldType = {}));
var ControlContactType;
(function (ControlContactType) {
    ControlContactType[ControlContactType["call"] = 0] = "call";
    ControlContactType["callDescription"] = "Llamada";
    ControlContactType[ControlContactType["mail"] = 1] = "mail";
    ControlContactType["mailDescription"] = "Mail";
    ControlContactType[ControlContactType["sms"] = 2] = "sms";
    ControlContactType["smsDescription"] = "SMS";
    ControlContactType[ControlContactType["whatsapp"] = 3] = "whatsapp";
    ControlContactType["whatsappDescription"] = "WhatsApp";
    ControlContactType[ControlContactType["nurseVisit"] = 4] = "nurseVisit";
    ControlContactType["nurseVisitDescription"] = "Visita de enfermera";
    ControlContactType[ControlContactType["adverseEvent"] = 5] = "adverseEvent";
    ControlContactType["adverseEventDescription"] = "Evento adverso";
})(ControlContactType = exports.ControlContactType || (exports.ControlContactType = {}));
var ControlType;
(function (ControlType) {
    ControlType[ControlType["normal"] = 0] = "normal";
    ControlType["normalDescription"] = "Seguimiento";
    ControlType[ControlType["start"] = 1] = "start";
    ControlType["startDescription"] = "Registro de inicio";
    ControlType[ControlType["end"] = 2] = "end";
    ControlType["endDescription"] = "Registro de fin";
})(ControlType = exports.ControlType || (exports.ControlType = {}));
var BirthsType;
(function (BirthsType) {
    BirthsType[BirthsType["parturition"] = 0] = "parturition";
    BirthsType["parturitionDescription"] = "Parto";
    BirthsType[BirthsType["caesareanOperation"] = 1] = "caesareanOperation";
    BirthsType["caesareanOperationDescription"] = "Ces\u00E1rea";
    BirthsType[BirthsType["both"] = 2] = "both";
    BirthsType["bothDescription"] = "Ambos";
})(BirthsType = exports.BirthsType || (exports.BirthsType = {}));
var BloodType;
(function (BloodType) {
    BloodType[BloodType["a"] = 0] = "a";
    BloodType["aDescription"] = "A";
    BloodType[BloodType["b"] = 1] = "b";
    BloodType["bDescription"] = "B";
    BloodType[BloodType["aB"] = 2] = "aB";
    BloodType["aBDescription"] = "AB";
    BloodType[BloodType["o"] = 3] = "o";
    BloodType["oDescription"] = "O";
})(BloodType = exports.BloodType || (exports.BloodType = {}));
var SchoolLevel;
(function (SchoolLevel) {
    SchoolLevel[SchoolLevel["elementarySchool"] = 0] = "elementarySchool";
    SchoolLevel["elementarySchoolDescription"] = "B\u00E1sica";
    SchoolLevel[SchoolLevel["secondaryEducation"] = 1] = "secondaryEducation";
    SchoolLevel["secondaryEducationDescription"] = "Media";
    SchoolLevel[SchoolLevel["postSecondaryEducation"] = 2] = "postSecondaryEducation";
    SchoolLevel["postSecondaryEducationDescription"] = "Universitaria";
    SchoolLevel[SchoolLevel["postDoctoral"] = 3] = "postDoctoral";
    SchoolLevel["postDoctoralDescription"] = "Posgrado";
})(SchoolLevel = exports.SchoolLevel || (exports.SchoolLevel = {}));
var LivesWith;
(function (LivesWith) {
    LivesWith[LivesWith["alone"] = 0] = "alone";
    LivesWith["aloneDescription"] = "Solo";
    LivesWith[LivesWith["parents"] = 1] = "parents";
    LivesWith["parentsDescription"] = "Padres";
    LivesWith[LivesWith["spouse"] = 2] = "spouse";
    LivesWith["spouseDescription"] = "Conyuge";
    LivesWith[LivesWith["spouseAndChildren"] = 3] = "spouseAndChildren";
    LivesWith["spouseAndChildrenDescription"] = "Conyuge e hijos";
    LivesWith[LivesWith["children"] = 4] = "children";
    LivesWith["childrenDescription"] = "Hijos";
    LivesWith[LivesWith["others"] = 5] = "others";
    LivesWith["othersDescription"] = "Otros";
})(LivesWith = exports.LivesWith || (exports.LivesWith = {}));
var RhFactor;
(function (RhFactor) {
    RhFactor[RhFactor["positive"] = 0] = "positive";
    RhFactor["positiveDescription"] = "Positivo";
    RhFactor[RhFactor["negative"] = 1] = "negative";
    RhFactor["negativeDescription"] = "Negativo";
})(RhFactor = exports.RhFactor || (exports.RhFactor = {}));
var AlertType;
(function (AlertType) {
    AlertType[AlertType["patientWithoutConsent"] = 0] = "patientWithoutConsent";
    AlertType[AlertType["todayControl"] = 1] = "todayControl";
})(AlertType = exports.AlertType || (exports.AlertType = {}));
var ProductType;
(function (ProductType) {
    ProductType[ProductType["medicine"] = 0] = "medicine";
    ProductType["medicineDescription"] = "Medicamento";
    ProductType[ProductType["device"] = 1] = "device";
    ProductType["deviceDescription"] = "Dispositivo";
})(ProductType = exports.ProductType || (exports.ProductType = {}));
var DosageForm;
(function (DosageForm) {
    DosageForm[DosageForm["tablet"] = 0] = "tablet";
    DosageForm["tabletDescription"] = "Comprimido";
    DosageForm[DosageForm["capsule"] = 1] = "capsule";
    DosageForm["capsuleDescription"] = "C\u00E1psula";
    DosageForm[DosageForm["vaginalCapsule"] = 2] = "vaginalCapsule";
    DosageForm["vaginalCapsuleDescription"] = "\u00D3vulo";
    DosageForm[DosageForm["powder"] = 3] = "powder";
    DosageForm["powderDescription"] = "Polvo";
    DosageForm[DosageForm["syrup"] = 4] = "syrup";
    DosageForm["syrupDescription"] = "Jarabe";
    DosageForm[DosageForm["oralSuspension"] = 5] = "oralSuspension";
    DosageForm["oralSuspensionDescription"] = "Suspensi\u00F3n";
    DosageForm[DosageForm["oralSolution"] = 6] = "oralSolution";
    DosageForm["oralSolutionDescription"] = "Soluci\u00F3n";
    DosageForm[DosageForm["suppository"] = 7] = "suppository";
    DosageForm["suppositoryDescription"] = "Supositorio";
    DosageForm[DosageForm["eyeDrop"] = 8] = "eyeDrop";
    DosageForm["eyeDropDescription"] = "Gota";
    DosageForm[DosageForm["collyrium"] = 9] = "collyrium";
    DosageForm["collyriumDescription"] = "Colirio";
})(DosageForm = exports.DosageForm || (exports.DosageForm = {}));
var VariationUnit;
(function (VariationUnit) {
    VariationUnit[VariationUnit["milligram"] = 0] = "milligram";
    VariationUnit["milligramDescription"] = "mg";
    VariationUnit[VariationUnit["gram"] = 1] = "gram";
    VariationUnit["gramDescription"] = "g";
    VariationUnit[VariationUnit["milliliter"] = 2] = "milliliter";
    VariationUnit["milliliterDescription"] = "ml";
    VariationUnit[VariationUnit["liter"] = 3] = "liter";
    VariationUnit["literDescription"] = "l";
    VariationUnit[VariationUnit["milligramsPerMilliliter"] = 4] = "milligramsPerMilliliter";
    VariationUnit["milligramsPerMilliliterDescription"] = "mg/ml";
    VariationUnit[VariationUnit["gramsPerLiter"] = 5] = "gramsPerLiter";
    VariationUnit["gramsPerLiterDescription"] = "g/l";
    VariationUnit[VariationUnit["milligramsPer100Milliliters"] = 6] = "milligramsPer100Milliliters";
    VariationUnit["milligramsPer100MillilitersDescription"] = "mg/100ml";
})(VariationUnit = exports.VariationUnit || (exports.VariationUnit = {}));
var DeviceType;
(function (DeviceType) {
    DeviceType[DeviceType["type1"] = 0] = "type1";
    DeviceType["type1Description"] = "Un tipo";
    DeviceType[DeviceType["type2"] = 1] = "type2";
    DeviceType["type2Description"] = "Otro tipo";
})(DeviceType = exports.DeviceType || (exports.DeviceType = {}));
var PatientState;
(function (PatientState) {
    PatientState[PatientState["preregistered"] = 0] = "preregistered";
    PatientState["preregisteredDescription"] = "Preinscrito";
    PatientState[PatientState["registered"] = 1] = "registered";
    PatientState["registeredDescription"] = "Inscrito";
})(PatientState = exports.PatientState || (exports.PatientState = {}));
var TreatmentState;
(function (TreatmentState) {
    TreatmentState[TreatmentState["pending"] = 0] = "pending";
    TreatmentState["pendingDescription"] = "Pendiente";
    TreatmentState[TreatmentState["inTreatment"] = 1] = "inTreatment";
    TreatmentState["inTreatmentDescription"] = "En tratamiento";
    TreatmentState[TreatmentState["suspended"] = 2] = "suspended";
    TreatmentState["suspendedDescription"] = "Suspendido";
    TreatmentState[TreatmentState["finalized"] = 3] = "finalized";
    TreatmentState["finalizedDescription"] = "Finalizado";
})(TreatmentState = exports.TreatmentState || (exports.TreatmentState = {}));
//# sourceMappingURL=enums.model.js.map