import { ProductDto } from "../../admin/interfaces/product-dto";

export interface Cart {
    product: ProductDto;
    quantity: number;
  }