import { Component, inject, signal ,OnInit } from '@angular/core';
import { Hotel } from '../../../services/shared/hotel';
import { FormsModule } from '@angular/forms';

export interface HotelsDto {
  hotelId: number;
  hotelName: string;
  ownerName: string;
  hotelMail: string;
  hotelPhoneNo: string;
  hotelAddress: string;
  totalRooms: number;
  availableRooms: number;
}

@Component({
  imports: [FormsModule],
  selector: 'app-list-hotels',
  styleUrl: './list-hotels.css',
  templateUrl: './list-hotels.html',
})
export class ListHotels {
  private HotelService = inject(Hotel);
  Hotels = signal<HotelsDto[]>([]);
  Editpopup = false;
  SelectedHotel : HotelsDto | null = null;

  OpenEditform(data : HotelsDto) : void{
    this.SelectedHotel=data;
    console.log(this.Editpopup)
    this.Editpopup=true;
  }
  
  CloseEditPopup() : void {
    this.Editpopup=false;
  }

  ngOnInit() : void {
    this.LoadHotels();
  }

  LoadHotels() : void {
    this.HotelService.ListHotels().subscribe({
      next : (Response)=>{
        this.Hotels.set(Response);
      },
      error : (err)=>{
        console.log(`Error : ${err}`);
      }
    });
  }

  UpdateHotel():void{
    
  }
}
