import { Routes } from '@angular/router';
import { HomeComponent } from './core/home/home.component';
import { LoginComponent } from './core/auth/components/login/login.component';
import { RegisterComponent } from './core/auth/components/register/register.component';
import { authGuard } from './core/auth/guards/auth.guard';
import { AdminPanelComponent } from './core/admin/components/admin-panel/admin-panel.component';
import { UserManagementComponent } from './core/admin/components/user-management/user-management.component';
import { CategoriesComponent } from './core/admin/components/categories/categories.component';
import { SubcategoriesComponent } from './core/admin/components/subcategories/subcategories.component';
import { ProductsComponent } from './core/admin/components/products/products.component';


export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { 
        path: 'admin', 
        component: AdminPanelComponent, 
        canActivate: [authGuard], 
        data: { role: 'Admin' }, 
        children: [
            { path: 'users', component: UserManagementComponent },
            { path: 'categories', component: CategoriesComponent },
            { path: 'subcategories', component: SubcategoriesComponent },
            { path: 'products', component: ProductsComponent }
        ],
    },
];
