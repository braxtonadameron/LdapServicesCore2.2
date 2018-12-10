import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SearchService } from '../services/search.service';
import { User } from '../models/user';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchForm = this.fb.group({
    firstName: [''],
    lastName: [''],
    email: [''],
    businessAddress: [''],
    phone: [''],
    //tag: [''],
  })

  users: User[];
  searchValue: User;

  constructor(private fb: FormBuilder,
    private searchService: SearchService
  ) { }

  ngOnInit() {
  }

  onSubmit() {
    this.searchValue = this.searchForm.value;
    console.log(this.searchValue);
    this.searchService.searchUsers(
      this.searchValue
    ).subscribe(
      data => {
        console.log(data);
        this.users = data;
      }
    );
  }
}
