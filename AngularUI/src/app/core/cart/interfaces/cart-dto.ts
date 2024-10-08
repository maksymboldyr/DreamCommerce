import { CartItemDto } from "./cart-item-dto";

export interface CartDto {
    userId: string;
    cartItems: CartItemDto[];
    total: number;
}