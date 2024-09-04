export interface LoginResponseDTO {
    tokenType: string;
    accessToken: string;
    expiresIn: number;
    refreshToken: string;
}
