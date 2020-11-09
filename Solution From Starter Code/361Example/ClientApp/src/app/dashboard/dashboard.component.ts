import { Component, OnInit, Directive, ElementRef,  } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

declare function TestFunction(email): any;
declare function TestFunction2(email): any;
declare function peen(email): any;


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})



/* dashboard component*/
export class DashboardComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public tempName;
  public list;
  public currentCount = 0;
  public name;
  result = [{ "title": "title1", "location": "Walmart", "date": "11/2/2020"}, { "title": "title2", "location": "target", "date": "11/2/2020"}];
    subscription: any;
    private _pubSubService: any;

  constructor(private authorizeService: AuthorizeService) { }




  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.authorizeService.getUser()
      .subscribe(data => {
        this.tempName = data.name;
      });
    //this.list = temp(this.tempName);
  }

  public incrementCounter() {
    this.currentCount++;
  }

  public temp() {
    var inputValue = (<HTMLInputElement>document.getElementById("userInput")).value;
    //this.name = this.GroceryListAccessor.GetAllLists(this.userName);
    this.name = inputValue;
  }


  public addToTable() {

    //need to now add the database info
    var array = [{ "title": "title1", "location": "Walmart", "date": "11/2/2020"}, { "title": "title2", "location": "Walmart", "date": "11/2/2020"}];

    
    this.result = array;
   
  }

  public die() {
    this.list = peen(this.tempName);
  }



}

