export interface UserDto {
    id : string;
    email? : string;
    firstName? : string | null;
    lastName? : string | null;
    phoneNumber? : string | null;
    address? : string | null;    
    roles : Role[];
}

export enum Role {
    Admin = 'Admin',
    Shop = 'Shop',
    User = 'User'
}
