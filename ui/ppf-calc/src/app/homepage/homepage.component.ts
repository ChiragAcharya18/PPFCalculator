import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  parameters = {
    deposite: 500,
    duration: 15,
    rateOfInterest: 7.1
  }
  totalInvestment = 40;
  totalInterest = 60;
  maturityValues: any = null;
  completeData: any = null;
  constructor(private _s: SharedService) { }
  showInfo = true;
  ngOnInit(): void {
  }
  
  onClick() {
    this._s.GetMaturityAmount(this.parameters).subscribe((data: any) => {
      if(data !== null){
        this.maturityValues = data;
      }
    });

    this._s.getCompleteDetails(this.parameters).subscribe((data: any) => {
      if(data !== null){
        console.log(data);
        
        this.completeData = data;
      }
    });
  }

  onReset() {
    this.parameters = {
      deposite: 500,
      duration: 15,
      rateOfInterest: 7.1
    };
    this.maturityValues = null;
    this.completeData = null;
    this.showInfo = true
  }

}
