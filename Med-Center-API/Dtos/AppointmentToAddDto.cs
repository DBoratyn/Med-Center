using System;

namespace Med_Center_API.Dtos
{
    public class AppointmentToAddDto
    {
        public Int64 parsedstartDate {get;set;}
        public Int64 parsedendDate {get;set;}
        public Boolean allDay {get;set;}
        public string text {get;set;}
        public string description {get;set;}
        public string patientName {get;set;}
        public string patientSurname {get;set;}
        public string patientaddress {get;set;}
        public string patientpesel {get;set;}
        public string specialization {get;set;}
        public string doctor {get;set;}

    }
}