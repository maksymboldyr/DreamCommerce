export interface ProductDto {
    id?: string;
    name: string;
    description: string;
    categoryId: string;
    subcategoryId: string;
    subcategoryName?: string;
    price: number;
    stock: number;
    discount: number;
    imageUrl?: string;
}
