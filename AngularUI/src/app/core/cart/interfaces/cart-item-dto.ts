import { ProductDto } from "../../admin/interfaces/product-dto";

export interface CartItemDto {
    productDTO: ProductDto;
    quantity: number;
    total: number;
}