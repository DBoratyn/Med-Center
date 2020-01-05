using System;

namespace Med_Center_API.Models
{
    public class Appointment
    {
        public int Id {get;set;}
        public Int64 startDate {get;set;}
        public Int64 endDate {get;set;}
        public Boolean allDay {get;set;}
        public string text {get;set;}
        public string description {get;set;}
        public string patientName {get;set;}
        public string patientSurname {get;set;}
        public string patientaddress {get;set;}
        public string patientpesel {get;set;}
        public string specialization {get;set;}
        public string NameOfTreatment {get;set;}
        public string doctor {get;set;}
        public double price {get;set;}
        public Boolean paid {get;set;}


    }
}