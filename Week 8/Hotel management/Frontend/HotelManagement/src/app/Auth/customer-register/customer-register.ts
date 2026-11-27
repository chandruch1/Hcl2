import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SafeResourceUrl } from '@angular/platform-browser';
import { Register } from '../../services/customers/auth/register';

export interface CustomerRegisterdto{
   UserName : string,
   Password : string,
  Email : string
}

export interface CustomerResponsedto{
  response : string
}


@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-customer-register',
  styleUrl: './customer-register.css',
  templateUrl: './customer-register.html',
})
export class CustomerRegister {

   RegisterService = inject(Register);
   Router = inject(Router);

  registerForm = new FormGroup({
    UserName : new FormControl('',{ validators: [Validators.required],nonNullable: true}),
    Password : new FormControl ('',{ validators :[Validators.required],nonNullable: true}),
    Email : new FormControl ('',{ validators :[Validators.required],nonNullable: true})
  })

  CustomerRegister() : void {
    if(this.registerForm.invalid){
      this.registerForm.markAllAsTouched();
      return;
    }

    const data : CustomerRegisterdto = this.registerForm.getRawValue();

    this.RegisterService.RegisterCustomer(data).subscribe({
      next : (Response)=>{
        console.log(Response);
        this.Router.navigate(['User-login']);
        
      },
      error : (err) => {
        console.log(`error : ${err}`);
        alert(`Registersation failed`)
      }
    })
  }
}
