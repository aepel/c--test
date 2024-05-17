export class ResetPasswordModel {
  constructor(id?: string,token?:string, password?: string, passwordConfirm?: string) {
    this.id = id;
    this.password = password;
    this.token = token;
    this.passwordConfirm = passwordConfirm;
  }

  id: string;
  password: string;
  passwordConfirm: string;
  token: string;
}
