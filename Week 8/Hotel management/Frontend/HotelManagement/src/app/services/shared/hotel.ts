import { HttpClient } from '@angular/common/http';
import { inject, Injectable, Service } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { UpdateHotelDto } from '../../Features/admin/list-hotels/list-hotels';

@Injectable({
    providedIn : 'root'
})

export class Hotel {
    private http = inject(HttpClient);
    private apiUrl = `${environment.apiUrl}/hotel`

    ListHotels() : Observable<any>{
        return this.http.get<any>(`${this.apiUrl}`);
    }

    UpdateHotel(id:number, Hotel : UpdateHotelDto) : Observable<any>{
        return this.http.put<any>(`${this.apiUrl}/update-hotel/${id}`,Hotel);
    }
}
