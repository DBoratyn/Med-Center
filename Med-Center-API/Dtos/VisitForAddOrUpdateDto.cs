using System;

namespace Med_Center_API.Dtos
{
    public class VisitForAddOrUpdateDto
    {
        public Int64 dateOfVisit {get;set;}
        public string descriptionOfVisit {get;set;}
        public int appointmentId {get;set;}
        
    }
}