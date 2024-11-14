export enum Role {
    Admin = 'Admin',
    Shop = 'Shop',
    User = 'User'
}

export interface User {
    id : string;
    firstName : string | null;
    lastName : string | null;
    role : Role[];
}