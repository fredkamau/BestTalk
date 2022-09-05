import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountTypeModel } from './account-type.model';
import { AccountTypesService } from './account-types.service';

@Component({
  selector: 'app-account-type',
  templateUrl: './account-type.component.html',
})
export class AccountTypeComponent implements OnInit {
  /* TODO:
  - Load Accounts Types from the REST Api
  - Observable should be used to notify the account.component about changes in the selected Type
   */
  @Output() AccountTypeSelected: EventEmitter<any> = new EventEmitter();
  
  constructor(private accountTypesService: AccountTypesService) {}

  public accountTypes: AccountTypeModel[];

  ngOnInit(): void {
    this.accountTypesService.getAccountTypes().subscribe((result) => {
      this.accountTypes = result;
    });
  }

  //When select changes on account type
  onChange(selectedAccountType){
    this.AccountTypeSelected.emit(selectedAccountType);
  }
}
