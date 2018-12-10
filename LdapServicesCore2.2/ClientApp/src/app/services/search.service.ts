import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  searchUrl = 'api/Search';

  constructor(private http: HttpClient) { }

  searchUsers(
    user: User
  ): Observable<User[]> {
    var params = this.searchUrl + '?'
      + (user.firstName !== '' ? '&firstName=' + user.firstName : '')
      + (user.lastName !== '' ? '&lastName=' + user.lastName : '')
      + (user.email !== '' ? '&email=' + user.email : '')
      + (user.businessAddress !== '' ? '&address=' + user.businessAddress : '');
    console.log(params);
    return this.http.get<User[]>(
      params
    );
  }
}
