export class EmployeeModel{
    FullName! : string;
    EmailId! : string;
    Password! : string;
    Role! : string;
}

export class LoginModel{
    EmailId! : string;
    Password! : string
}

export class AppliedBill{
    id!:number
    emailId! : string;
    fullName? : string;
    applyDate!: Date;
    type!:string;
    amount!:number;
    paymentMode!:string;
    status!:string
    remarks?:string;
    modifiedBy?:string;
}


