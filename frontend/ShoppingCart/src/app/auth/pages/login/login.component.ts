import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLogin } from '../../interface/user-login.interface';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  hide = true;
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  myForm!: FormGroup
  
  ngOnInit(): void {
    this.myForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    })
  }

  login(){
    //console.log(this.myForm.value);
    const newUsuario = this.myForm.value as UserLogin
    
    this.authService.login(newUsuario)
      .subscribe({
        next: res => {
          console.log('next', res);
          //this.router.navigateByUrl('/');
        },
        error: err => {
          console.log(err);
        }
      })
  }
}
