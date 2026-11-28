import { Component, inject, signal ,OnInit } from '@angular/core';
import { Hotel } from '../../../services/shared/hotel';
import { FormsModule } from '@angular/forms';
import { SafeResourceUrl } from '@angular/platform-browser';

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

export interface UpdateHotelDto{
  hotelName : string,
  hotelMail : string,
  hotelPhoneNo : string,
  availableRooms : Number,
  totalRooms : Number,
  hotelAddress : string,
  ownerName : string
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
    this.SelectedHotel =data;
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

  UpdateHotel(id:number):void{
    if(!this.SelectedHotel){
      return;
    }
    const Hoteldata : UpdateHotelDto = {
       hotelName: this.SelectedHotel.hotelName,
       hotelAddress : this.SelectedHotel.hotelAddress,
       ownerName : this.SelectedHotel.ownerName,
       hotelMail : this.SelectedHotel.hotelMail,
       hotelPhoneNo : this.SelectedHotel.hotelPhoneNo,
       totalRooms : this.SelectedHotel.totalRooms,
       availableRooms :  this.SelectedHotel.availableRooms,
    }
    this.HotelService.UpdateHotel(id,Hoteldata).subscribe({
      next : (Response)=>{
        console.log(`Response : ${Response}`);
        alert(`Hotel Updated Succesfully`);
        this.Editpopup=false;
      },
      error :(err) =>{
        console.log(`Error : ${err}`);
        alert(`Hotel Updation Failed`);
      },
    });
  }
}
