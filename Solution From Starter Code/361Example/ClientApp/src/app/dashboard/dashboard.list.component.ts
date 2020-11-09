import { Component } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';




interface List {
  title: string,
  location: string,
  email: string
  //dateUpdated: DateTime
  //itemsDict: Dictionary<int, int>,
  //qytDict: string
}

class GroceryList implements List {
  title: string;
  location: string;
  email: string;
  constructor(title: string, location: string, email: string) {
    this.title = title;
    this.location = location;
    this.email = email;

  }
}



let list: Array<GroceryList> = [];
function createList() {

  const titleInput = (<HTMLInputElement>document.getElementById('first-name')).value;
  const locationInput = (<HTMLInputElement>document.getElementById('last-name')).value;
  const userNameInput = this.userName;

  list.push(new GroceryList(titleInput, locationInput, userNameInput));

  (<HTMLFormElement>document.getElementById("createUserForm")).reset();

  //updateTable()
}


