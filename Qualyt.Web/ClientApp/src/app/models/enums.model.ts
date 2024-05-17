import { Moment } from 'moment/moment';
import { Field } from './field.model';

function EnumDescription(e: any, id: number): string {
  return e[e[id].toString() + "Description"];
}

function EnumValues(e: any) {
  let array = [];
  for (let enumMember in e) {
    var isValueProperty = parseInt(enumMember, 10) >= 0
    if (isValueProperty) {
      array.push(enumMember);
    }
  }
  return array;
}

export function EnumValDesc(e: any) {
  let array = EnumValues(e);
  let rArray = [];
  for (let item of array) {
    rArray.push({ value: parseInt(item), text: EnumDescription(e,parseInt(item)) });
  }
  return rArray;
}

export enum Gender {
  male=0,
  maleDescription="Masculino",
  female=1,
  femaleDescription="Femenino"
}

export enum MaritalStatus {
  single = 0,
  singleDescription = "Soltera/o",
  divorced = 1,
  divorcedDescription = "Divorciada/o",
  widowed = 2,
  widowedDescription = "Viuda/o",
  separated = 3,
  separatedDescription = "Separada/o",
  married = 4,
  marriedDescription = "Casada/o"
}

export enum ContactMethod {
  mail = 0,
  mailDescription = "Mail",
  phone = 1,
  phoneDescription="Teléfono"
}

export enum FieldType {
  checkbox=0,
  checkboxDescription = "Checkbox",
  //yesOrNoSelect=1,
  text=2,
  textDescription = "Texto",
  numeric=3,
  numericDescription = "Numérico",
  date=4,
  dateDescription = "Fecha",
  //multipleSelect=5,
  //roundButton=6,
  simpleSelect=7,
  simpleSelectDescription="Listado con opción simple"
}

export enum ControlContactType {
  call = 0,
  callDescription = "Llamada",
  mail = 1,
  mailDescription = "Mail",
  sms = 2,
  smsDescription = "SMS",
  whatsapp = 3,
  whatsappDescription = "WhatsApp",
  nurseVisit = 4,
  nurseVisitDescription = "Visita de enfermera",
  adverseEvent = 5,
  adverseEventDescription = "Evento adverso"
}

export enum ControlType {
  normal=0,
  normalDescription="Seguimiento",
  start=1,
  startDescription="Registro de inicio",
  end=2,
  endDescription="Registro de fin"
}

export enum BirthsType {
  parturition = 0,
  parturitionDescription = "Parto",
  caesareanOperation = 1,
  caesareanOperationDescription = "Cesárea",
  both = 2,
  bothDescription = "Ambos"
}

export enum BloodType {
  a = 0,
  aDescription = "A",
  b = 1,
  bDescription = "B",
  aB = 2,
  aBDescription = "AB",
  o = 3,
  oDescription = "O"
}

export enum SchoolLevel {
  elementarySchool = 0,
  elementarySchoolDescription = "Básica",
  secondaryEducation = 1,
  secondaryEducationDescription = "Media",
  postSecondaryEducation = 2,
  postSecondaryEducationDescription = "Universitaria",
  postDoctoral = 3,
  postDoctoralDescription = "Posgrado"
}

export enum LivesWith {
  alone = 0,
  aloneDescription = "Solo",
  parents = 1,
  parentsDescription = "Padres",
  spouse = 2,
  spouseDescription = "Conyuge",
  spouseAndChildren = 3,
  spouseAndChildrenDescription = "Conyuge e hijos",
  children = 4,
  childrenDescription = "Hijos",
  others = 5,
  othersDescription = "Otros"
}

export enum RhFactor {
  positive = 0,
  positiveDescription = "Positivo",
  negative = 1,
  negativeDescription = "Negativo"
}

export enum AlertType {
  patientWithoutConsent = 0,
  todayControl=1
}

export enum ProductType {
  medicine = 0,
  medicineDescription = "Medicamento",
  device = 1,
  deviceDescription = "Dispositivo"
}

export enum DosageForm {
  tablet = 0,
  tabletDescription = "Comprimido",
  capsule = 1,
  capsuleDescription = "Cápsula",
  vaginalCapsule = 2,
  vaginalCapsuleDescription = "Óvulo",
  powder = 3,
  powderDescription = "Polvo",
  syrup = 4,
  syrupDescription = "Jarabe",
  oralSuspension = 5,
  oralSuspensionDescription = "Suspensión",
  oralSolution = 6,
  oralSolutionDescription = "Solución",
  suppository = 7,
  suppositoryDescription = "Supositorio",
  eyeDrop = 8,
  eyeDropDescription = "Gota",
  collyrium = 9,
  collyriumDescription = "Colirio"
}

export enum VariationUnit {
  milligram = 0,
  milligramDescription = "mg",
  gram = 1,
  gramDescription = "g",
  milliliter = 2,
  milliliterDescription = "ml",
  liter = 3,
  literDescription = "l",
  milligramsPerMilliliter = 4,
  milligramsPerMilliliterDescription = "mg/ml",
  gramsPerLiter = 5,
  gramsPerLiterDescription = "g/l",
  milligramsPer100Milliliters = 6,
  milligramsPer100MillilitersDescription = "mg/100ml"
}

export enum DeviceType {
  type1 = 0,
  type1Description = "Un tipo",
  type2 = 1,
  type2Description = "Otro tipo"
}

export enum PatientState {
  preregistered = 0,
  preregisteredDescription = "Preinscrito",
  registered = 1,
  registeredDescription = "Inscrito"
}

export enum TreatmentState
{
    pending=0,
    pendingDescription="Pendiente",
    inTreatment=1,
    inTreatmentDescription="En tratamiento",
    suspended=2,
    suspendedDescription="Suspendido",
    finalized=3,
    finalizedDescription="Finalizado"
}
