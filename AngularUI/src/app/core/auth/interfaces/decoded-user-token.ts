export interface DecodedUserToken {
    unique_name: string;
    id: string;
    role: string[];
    jti: string;
    nbf: number;
    exp: number;
    iat: number;
    iss: string;
    aud: string;
}
