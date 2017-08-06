import { Component, OnInit } from '@angular/core';
import {RestService} from './../shared/rest.service';
import {Safe} from './safe-html.pipe';
@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css']
})
export class CrudComponent implements OnInit {

  constructor(private restService: RestService) { 
	this.restService.getValues().subscribe(data=>this.holder=data);

	}

  holder ={};  
  ngOnInit() {
  }
  getValues(){
    this.restService.getValues().subscribe(data=>this.holder=data);
  }

}
