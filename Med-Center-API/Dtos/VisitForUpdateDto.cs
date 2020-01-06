using System;

namespace Med_Center_API.Dtos
{
    public class VisitForUpdateDto
    {
        public int Id {get;set;}
        public Int64 dateOfVisit {get;set;}
        public string descriptionOfVisit {get;set;}
        public int appointmentId {get;set;}
        
    }
}