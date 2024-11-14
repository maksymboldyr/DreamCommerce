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
import { Filter } from '../../interfaces/filter';
import { TableFilterService } from '../../services/table-filter.service';
import { MultiSelectChangeEvent, MultiSelectModule } from 'primeng/multiselect';

export interface RoleFlag {
  [key: string]: boolean;
}

@Component({
  selector: 'app-user-management',
  standalone: true,
  providers: [TableFilterService],
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
    MultiSelectModule,
  ],
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.scss'
})
export class UserManagementComponent {
  router : Router;
  userService: UserService;
  filterService: TableFilterService;

  users : Array<UserDto> = [];
  userToUpdate : UserDto | null = null; 

  editModalVisible : boolean = false;
  roleDroppdownHidden : boolean = true;
  selectedRoles: RoleFlag = {};
  

  loading : boolean = true;
  totalRecords : number = 100;
  lastEvent: TableLazyLoadEvent = {};
  globalRolesArray: string[] = [];

  rolesToFilter: string[] = [];
  

  constructor(userService: UserService, router: Router, filterService: TableFilterService) {
    this.userService = userService;
    this.router = router;
    this.filterService = filterService;
    this.globalRolesArray = Object.keys(Role);
    this.globalRolesArray.push('No Roles');
  }

  ngOnInit() {    
    this.getUsers();
  }

  displayRoles(user: UserDto) {
    return user.roles.join(', ');
  }

  get globalRolesCount() {    
    return Object.keys(Role).length;
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
    this.userService.getFiltered(
      this.filterService.filtersString,
      this.filterService.page, 
      this.filterService.pageSize, 
      this.filterService.sortField, 
      this.filterService.sortOrder
    ).subscribe(tableData => {
      this.users = tableData.data;
      this.totalRecords = tableData.totalCount;
      this.loading = false;
    });
  }

  onEditUser() {    
    if (this.userToUpdate) {      
      let updatedUser : UserAdminUpdateDto = {
        id: this.userToUpdate.id,
        roles: Object.keys(this.selectedRoles).filter(role => this.selectedRoles[role])
      };

      this.userService.update(updatedUser).subscribe(
        (response) => {
          this.closeModal();
          this.loadData(this.lastEvent);
        },
        (error) => {
          console.error('Error updating user', error);
        }
      );      
    }    
  }

  loadData(event: TableLazyLoadEvent) {
    if (event.filters) {  
      this.filterService.applyFilters(event);
    }

    this.filterService.applyPaginationAndSorting(event);
    
    this.getUsers();

    this.loading = false;
    this.lastEvent = event;
  }

  applyMultiselectFilter(event: MultiSelectChangeEvent) {
    if (event.value.includes('No Roles')) {
      event.value = event.value.filter((role : string) => role !== 'No Roles');
      event.value.push('');
    }
    
    this.filterService.applyMultiselectFilter(event, 'Roles', this.lastEvent);
    this.loadData(this.lastEvent);
  }

  deleteUser(user: UserDto) {
    console.log('Delete user', user);
  }
}