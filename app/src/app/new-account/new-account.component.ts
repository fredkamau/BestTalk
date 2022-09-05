import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { NewAccountService } from './new-account.service';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
})
export class NewAccountComponent implements OnInit {
  /* TODO:
 - Save account using the REST Api
  */

  accountForm: FormGroup;

  constructor(
    private newAccountService: NewAccountService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.accountForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      balance: ['', [Validators.required, Validators.min(1)]],
    });
  }

  submitForm(form: FormGroup) {
 
    if(this.accountForm.valid)
    {
      this.newAccountService.CreateAccount(form.value).subscribe(
        (res) => {
          window.alert("User Account "+ res.firstName + " added successfully")
          this.router.navigate(['/layout']);
        },
        (err) => console.log(err)
      );

    }
    else
    {
      window.alert("The balance should be greater than 0")
    }
    
  }
}
