import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountGridDataModel } from './account-grid-data.model';
import { AccountService } from './account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
})
export class AccountComponent implements OnInit {
  /* TODO:
  - Load Accounts from the REST Api
  - Display Accounts in the HTML Table
  - Filter Accounts based on the Account Type
   */

  constructor(private accountService: AccountService, private router: Router) {}

  public accounts: AccountGridDataModel[];
  //holds the data when filtering
  AccountsData: AccountGridDataModel[];

  ngOnInit(): void {
    this.accountService.getAccounts().subscribe((result) => {
      
      //Update the response create accountType key where TypeId 1 - Bronze, 2-Silver, 3-Gold
      result.forEach(account => {
        if(account.typeId == 1)
        {
          account.accountType = "Bronze"
        }
        else if(account.typeId == 2)
        {
          account.accountType = "Silver"
        }
        else if(account.typeId == 3)
        {
          account.accountType = "Gold"
        }
      });

      this.accounts = this.AccountsData = result;
    });
  }

  openNewAccount(): void {
    this.router.navigate(['/new-account']);
  }

  //filter accounts when account type selection changes
  AccountTypeSelected(selectedAccountType){
      //filter the grid data using the selected Account Type
      let selectedAccountTypes = this.AccountsData.filter((x) => {
        if (x.accountType == selectedAccountType) {
          return x;
        }
      });
      this.accounts = selectedAccountTypes;
  }
}
