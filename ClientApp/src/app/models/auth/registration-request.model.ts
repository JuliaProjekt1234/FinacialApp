export class RegistrationRequest{
    constructor(
        public userName: string,
        public password: string,
        public confirmPassword: string
    ){}
}