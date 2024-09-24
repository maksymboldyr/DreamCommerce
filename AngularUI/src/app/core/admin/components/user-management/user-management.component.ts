import { Component } from '@angular/core';
import { TableLazyLoadEvent, TableModule } from 'primeng/table';
import { Role, UserDto } from '../../interfaces/user-dto';
import { UserService } from '../../services/user.service';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { UserAdminUpdateDto } from '../../interfaces/user-admin-update-dto';
import { CommonModule } from '@angular/common';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { Router } from '@angular/router';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { InputTextModule } from 'primeng/inputtext';

export interface RoleFlag {
  [key: string]: boolean;
}

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [
    TableModule,
    ButtonModule,
    DialogModule,
    CommonModule,
    DropdownModule,
    CheckboxModule,
    FormsModule,
    ProgressSpinnerModule,
    InputTextModule,
  ],
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.scss'
})
export class UserManagementComponent {
  users : Array<UserDto> = [];
  userToUpdate : UserDto | null = null;
  userService: UserService;
  editModalVisible : boolean = false;
  roleDroppdownHidden : boolean = true;
  selectedRoles: RoleFlag = {};
  router : Router;

  loading : boolean = true;
  totalRecords : number = 100;
  page : number = 1;
  pageSize : number = 10;
  sortField :  Array<string> | string = '';
  sortOrder : number = 1;

  constructor(userService: UserService, router: Router) {
    this.userService = userService;
    this.router = router;
  }

  ngOnInit() {
         
  }

  displayRoles(user: UserDto) {
    return user.roles.join(', ');
  }

  get globalRolesCount() {    
    return Object.keys(Role).length;
  }

  get globalRolesArray() : string[] {
    let roles = Object.keys(Role);
    return roles.filter(role => role !== 'User');
  }

  get userRolesArray() : string[] {
    return this.userToUpdate?.roles || [];
  }

  get usersAssignedRoles() : RoleFlag {    
    

    return this.selectedRoles;
  }

  userRolesCount(user: UserDto | null) : number {
    if (user) {
      return user.roles.length;
    }
    return 3;
  }

  userHasRole(user: UserDto, role: Role) {
    return user.roles.includes(role);
  }

  toggleUserRole(user: UserDto, role : Role) {
    if (user.roles.includes(role)) {
      user.roles = user.roles.filter(r => r !== role);
    } else {
      user.roles.push(role);
    }
  }

  closeModal() {
    this.editModalVisible = false;
  }

  editUser(user: UserDto) {
    this.editModalVisible = true;
    this.userToUpdate = user;

    this.globalRolesArray.forEach(role => {
      if (this.userRolesArray.includes(role)) {
        this.selectedRoles[role] = true;
      } else {
        this.selectedRoles[role] = false;
      }      
    });
  }

  getUsers() { 
    this.loading = true;  
    this.userService.getUsers(
      this.page, 
      this.pageSize, 
      this.sortField, 
      this.sortOrder
    ).subscribe(tableData => {
      this.users = tableData.data;
      this.totalRecords = tableData.totalCount;
    });
  }

  onEditUser() {
    console.log('Edit user', this.userToUpdate);
    
    if (this.userToUpdate) {
      console.log('updating');
      
      let updatedUser : UserAdminUpdateDto = {
        id: this.userToUpdate.id,
        roles: Object.keys(this.selectedRoles).filter(role => this.selectedRoles[role])
      };

      this.userService.updateUser(updatedUser).subscribe(
        (response) => {
          console.log(response); // "User updated successfully"
          this.getUsers();
          this.closeModal();
        },
        (error) => {
          console.error('Error updating user', error);
        }
      );
      
    }

    
  }

  loadData(event: TableLazyLoadEvent) {

    this.page = (event.first === 0 || event.first == undefined) ? 1 : event.first / (event.rows == undefined ? 1 : event.rows) + 1;
    this.pageSize = event.rows == undefined ? 10 : event.rows;

    this.sortField = event.sortField || '';
    this.sortOrder = event.sortOrder || 1;

    this.getUsers();

    this.loading = false;

  }

  deleteUser(user: UserDto) {
    console.log('Delete user', user);
  }

}
