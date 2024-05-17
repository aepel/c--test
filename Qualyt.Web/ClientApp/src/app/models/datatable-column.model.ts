export class DatatableColumn {
  constructor(_name, _displayedName) {
    this.name = _name;
    this.displayedName = _displayedName;
  }

    name: string
    displayedName: string
}

export class DatatableAction {
  constructor(_icon, _catcher, _idParameter, _tooltip?, _conditionName?) {
    this.icon = _icon;
    this.catcher = _catcher;
    this.idParameter = _idParameter;
    this.tooltip = _tooltip;
    this.conditionName = _conditionName;
  }

  icon: string
  tooltip: string
  conditionName: string
  catcher: any
  idParameter: boolean
}

export class DatatableColor {
  constructor(_conditionName, _hexaColor) {
    this.conditionName = _conditionName;
    this.hexaColor = _hexaColor;
  }
  hexaColor: string;
  conditionName: string;
}

export class KeyValue {
  constructor(_key, _value) {
    this.key = _key;
    this.value = _value;
  }

  key: string
  value: any
}
