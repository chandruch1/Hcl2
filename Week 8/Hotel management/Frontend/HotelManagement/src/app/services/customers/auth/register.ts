import { HttpClient } from '@angular/common/http';
import { inject, Injectable, Service } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { CustomerRegisterdto, CustomerResponsedto } from '../../../Auth/customer-register/customer-register';
import { Observable } from 'rxjs';

@Injectable({
    providedIn :'root'
})

export class Register {

    private http = inject(HttpClient);
    private Url = `${environment.apiUrl}/Auth`;

    RegisterCustomer(data : CustomerRegisterdto) : Observable<any> {
        return this.http.post<any>(`${this.Url}/customer-register`,data);
    }
}
