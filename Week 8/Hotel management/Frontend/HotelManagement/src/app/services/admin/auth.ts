import { Injectable , inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { AdminLogindto, AdminLoginResponseDto } from '../../Auth/admin-login/admin-login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Auth {
    private Url = `${environment.apiUrl}/Auth`;

    private http = inject(HttpClient);

    adminLogin(data:AdminLogindto) : Observable<AdminLoginResponseDto>{
        return this.http.post<AdminLoginResponseDto>(`${this.Url}/admin-login`,data);
    }
}