import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { DxDataGridComponent } from 'devextreme-angular';
@Component({
  selector: 'app-pharmacy',
  templateUrl: './pharmacy.component.html',
  styleUrls: ['./pharmacy.component.css']
})
export class PharmacyComponent implements OnInit {
  @ViewChild('meds', { static: false }) dataGrid: DxDataGridComponent;
  pharmacyData: any;
  currentFilter: any;
  selectedMedicine: any;
  selectedAppointmentId: any;
  medicine: any = {};

  constructor(private auth: AuthService) { }

  ngOnInit() {
    this.auth.getApiData().subscribe( response => {
      this.pharmacyData = response;
      console.log(response);
    });
  }

  addMedicineToAppointment() {
    let id =  localStorage.getItem('selectedAppointment');
    console.log(this.medicine);
    this.auth.addMedicine(this.medicine, id);
    this.dataGrid.instance.clearSelection();
  }

  selectMedicine(e) {
    console.log(e);
    this.medicine = {};
    this.selectedAppointmentId = this.selectedMedicine = e.data;
    this.medicine.MedicineName = this.selectedMedicine.rxstring;
    this.medicine.Author = this.selectedMedicine.source;
    this.medicine.ProductCode = this.selectedMedicine.version_number;

  }

}
