import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { User } from '../../shared/models/user.model';
import { UsersData } from '../../shared/models/users-data.model';
import { environment } from './../../../../environments/environment.prod';

@Injectable({ providedIn: 'root' })
export class UsersService {

    private usersUrl = `${environment.endpoint}/Users`;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) { }

    getUsers(sort: string, order: string, pageNum: number, pageSize: number, filterValue?: string): Observable<UsersData> {
        let url = `${this.usersUrl}/?sortOrder=${sort + order}&pageNum=${pageNum}&pageSize=${pageSize}`;
        if (filterValue) { url += `&searchName=${filterValue}`; }
        return this.http.get<UsersData>(url);
    }

    addUser(user: User): Observable<User> {
        return this.http.post<User>(this.usersUrl, user, this.httpOptions);
    }

    updateUser(user: User): Observable<User> {
        return this.http.put<User>(this.usersUrl, user, this.httpOptions);
    }

    deleteUser(id: number) {
        const url = `${this.usersUrl}/${id}`;
        return this.http.delete(url, this.httpOptions);
    }
}
