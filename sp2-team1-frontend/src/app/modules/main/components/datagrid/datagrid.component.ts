import { UserDialogData } from '../../../shared/models/user-dialog-data.model';
import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { merge, of } from 'rxjs';
import { startWith, switchMap, map, catchError } from 'rxjs/operators';

import { DialogboxComponent } from '../dialogbox/dialogbox.component';

import { User } from '@app/modules/shared/models/user.model';
import { UsersService } from '../../../core/services/users.service';
import { Roles } from '@app/modules/shared/models/roles.model';

@Component({
  selector: 'app-datagrid',
  templateUrl: './datagrid.component.html',
  styleUrls: ['./datagrid.component.css']
})
export class DatagridComponent implements OnInit {

  displayedColumns: string[] = ['id', 'email', 'userName', 'role', 'action'];
  users: User[] = [];
  roles = Roles;

  resultsLength = 0;
  pageSize = 5;

  @ViewChild(MatTable, { static: true }) table: MatTable<any>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private dialog: MatDialog, private usersService: UsersService) { }

  ngOnInit(): void {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.updateUsers();
  }

  updateUsers(filterValue?: string): void {
    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          return this.usersService.getUsers(this.sort.active, this.sort.direction,
            this.paginator.pageIndex + 1, this.pageSize, filterValue);
        }),
        map(result => {
          this.resultsLength = result.countOfRecords;
          return result.users;
        }),
        catchError(() => {
          return of([]);
        })
      ).subscribe(users => this.users = users);
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.updateUsers(filterValue);
  }

  openDialog(obj: UserDialogData): void {
    const dialogRef = this.dialog.open(DialogboxComponent, {
      width: '400px',
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.action === 'Add') {
        this.addUser(result.user);
      } else if (result.action === 'Update') {
        this.updateUser(result.user);
      } else if (result.action === 'Delete') {
        this.deleteUser(result.user.id);
      }
    });
  }

  addUser(user: User): void {
    this.usersService.addUser(user).subscribe(() => { this.updateUsers(); });
  }

  updateUser(user: User): void {
    this.usersService.updateUser(user).subscribe(() => { this.updateUsers(); });
  }

  deleteUser(id: number): void {
    this.usersService.deleteUser(id).subscribe(() => { this.updateUsers(); });
  }
}
