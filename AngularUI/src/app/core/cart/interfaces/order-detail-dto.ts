export interface OrderDetailDto {
    id?: string;
    orderId?: string;
    productId: string;
    productName?: string;
    price?: number;
    quantity: number;
    totalPrice: number;
  }
  