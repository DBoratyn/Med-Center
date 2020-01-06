using System;

namespace Med_Center_API.Models
{
    public class Visit
    {
        public int id {get;set;}
        public Int64 dateOfVisit {get;set;}
        public string descriptionOfVisit {get;set;}
        public int appointmentId {get;set;}
    }
}