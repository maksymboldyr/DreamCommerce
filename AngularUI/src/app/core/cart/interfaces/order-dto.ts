import { AddressDto } from "./address-dto";
import { OrderDetailDto } from './order-detail-dto';

export interface OrderDto {
  id?: string;
  userId?: string;
  totalPrice?: number;
  createdAt?: Date;
  addressId?: string;
  address?: AddressDto;
  orderDetails?: OrderDetailDto[];
  status?: string;
}
