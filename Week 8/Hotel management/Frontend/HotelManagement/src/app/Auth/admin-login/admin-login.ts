import { Component, inject } from '@angular/core';
import { ReactiveFormsModule , FormControl, FormGroup, Validators } from '@angular/forms';
import { Auth } from '../../services/admin/auth';
import { Token } from '../../services/token';


export interface AdminLogindto{
  email : string,
  password : string
}

export interface AdminLoginResponseDto{
  token : string
}

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-admin-login',
  styleUrl: './admin-login.css',
  templateUrl: './admin-login.html',
})

export class AdminLogin {

  Authservice = inject(Auth);
  TokenService = inject (Token);

 adminLoginForm = new FormGroup({
  email: new FormControl('', {
    validators: [Validators.required, Validators.email],
    nonNullable: true
  }),

  password: new FormControl('', {
    validators: [Validators.required],
    nonNullable: true
  })
});
  adminLogin():void{
    if(this.adminLoginForm.invalid){
      this.adminLoginForm.markAllAsTouched();
      return;
    }

    const data = this.adminLoginForm.getRawValue();
    this.Authservice.adminLogin(data).subscribe({
      next : (Response)=>{
        this.TokenService.saveSession(Response);
        alert (`login succesfully`);
      },
      error : (err)=>{
        console.log(`error: ${err}`)
      }
    });
  }
}
