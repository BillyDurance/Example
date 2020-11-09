import { Component, OnInit, Directive, ElementRef} from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  //styleUrls: ['./dashboard.component.css']
})



/*List component*/
export class ListComponent implements OnInit {
    count: any;
    ngOnInit(): void {
        throw new Error("Method not implemented.");
    }
 

  public incrementCounter() {
    this.count++;
  }

}

